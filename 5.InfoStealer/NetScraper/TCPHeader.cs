using System.Net;
using System.Text;
using System;
using System.IO;
using System.Windows.Forms;

namespace HackingPOS.Scrapers.NetScraper
{
    public class TCPHeader: BaseHeader
    {
        private ushort sourcePort;              
        private ushort destinationPort;         
        private uint   seqNumber=555;          
        private uint   acknowledgementNumber;   
        private ushort dataOffsetAndFlags;      
        private ushort window;                  
        private short  checksum;                
        private ushort urgentPointer;           

        public TCPHeader(byte [] IPBuffer, int IPBufferLength): base(IPBuffer, IPBufferLength)
        {
        }

        protected override void DecodeBuffer(byte[] ReceivedBuffer, int ReceivedLength, BinaryReader binaryReader)
        {
            sourcePort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            destinationPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            seqNumber = (uint)IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());
            acknowledgementNumber = (uint)IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());
            dataOffsetAndFlags = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            window = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            checksum = (short)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            urgentPointer = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

            headerLength = (byte)(dataOffsetAndFlags >> 12);
            headerLength *= 4;

            payloadLength = (ushort)(ReceivedLength - headerLength);
        }

        public string SourcePort
        {
            get
            {
                return sourcePort.ToString();
            }
        }

        public string DestinationPort
        {
            get
            {
                return destinationPort.ToString();
            }
        }
    }
}