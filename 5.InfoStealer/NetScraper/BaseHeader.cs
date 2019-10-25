using System.Net;
using System.Text;
using System;
using System.IO;
using System.Windows.Forms;

namespace HackingPOS.Scrapers.NetScraper
{
    public abstract class BaseHeader
    {
        public const byte PROTOCOL_TCP = 6;

        protected byte headerLength;
        protected byte[] payload = new byte[4096];
        protected ushort payloadLength;

        public BaseHeader(byte[] ReceivedBuffer, int ReceivedLength)
        {

            try
            {
                MemoryStream memoryStream = new MemoryStream(ReceivedBuffer, 0, ReceivedLength);
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                DecodeBuffer(ReceivedBuffer, ReceivedLength, binaryReader);

                // Get the payload
                Array.Copy(ReceivedBuffer,
                           headerLength,  
                           Payload, 0,
                           ReceivedLength - headerLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NetScraper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        abstract protected void DecodeBuffer(byte[] ReceivedBuffer, int ReceivedLength, BinaryReader binaryReader);

        public ushort PayloadLength
        {
            get
            {
                return (ushort)payloadLength;
            }
        }

        public byte[] Payload
        {
            get
            {
                return payload;
            }
        }
    }
}
