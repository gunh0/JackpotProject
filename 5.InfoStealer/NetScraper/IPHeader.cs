using System.Net;
using System.Text;
using System;
using System.IO;
using System.Windows.Forms;

namespace HackingPOS.Scrapers.NetScraper
{
    public class IPHeader: BaseHeader
    {
        private byte      versionAndHeaderLength;   
        private byte      differentiatedServices;    
        private ushort    datagramLength;              
        private ushort    identification;          
        private ushort    flagsAndOffset;           
        private byte      ttl;                     
        private byte      protocolID;                 
        private short     checksum;                  
                                                      
        private uint      sourceAddress;          
        private uint      destinationAddress;     
        
        public IPHeader(byte[] ReceivedBuffer, int ReceivedLength)
            : base(ReceivedBuffer, ReceivedLength)
        {
        }

        protected override void DecodeBuffer(byte[] ReceivedBuffer, int ReceivedLength, BinaryReader binaryReader)
        {
            versionAndHeaderLength = binaryReader.ReadByte();
            differentiatedServices = binaryReader.ReadByte();
            datagramLength = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            identification = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            flagsAndOffset = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            ttl = binaryReader.ReadByte();
            protocolID = binaryReader.ReadByte();
            checksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
            sourceAddress = (uint)(binaryReader.ReadInt32());
            destinationAddress = (uint)(binaryReader.ReadInt32());

            headerLength = versionAndHeaderLength;
            headerLength <<= 4;
            headerLength >>= 4;
            headerLength *= 4;
            
            payloadLength = (ushort)(datagramLength-headerLength);
        }
        
        public byte ProtocolID
        {
            get
            {
                    return protocolID;
            }
        }

        public string SourceAddress
        {
            get
            {
                return (new IPAddress(sourceAddress)).ToString();
            }
        }

        public string DestinationAddress
        {
            get
            {
                return (new IPAddress(destinationAddress)).ToString();
            }
        }
    }
}
