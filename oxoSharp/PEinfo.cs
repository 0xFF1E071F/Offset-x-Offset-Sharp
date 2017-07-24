using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace oxoSharp
{
    public struct SectionInfo
    {
        public int RawAddress;
        public int RawSize;
        public int VirtualAddress;
        public int VirtualSize;
        public string SectionName;
        public bool ContainsCode;
    }
    public class PEinfo
    {

        private bool _isPE = false;

        public int NumberOfSections;
        public int SizeOfHeader;
        public int EP;
        public int AddressOfEOF;
        public int SizeOfEOF;
        public int FileSize;
        public SectionInfo[] Sections;


        private static unsafe byte* pointer { get; set; }
        public bool isPE
        {
            get { return _isPE; }
        }
        public bool hasEOF
        {
            get { return SizeOfEOF > 0; }
        }
        public int SizeOfSections
        {
            get { return AddressOfEOF - SizeOfHeader; ; }
        }

        public static unsafe PEinfo ExtractInfo(byte[] data)
        {

            PEinfo info = new PEinfo() { FileSize = data.Length };
            fixed (byte* array = &data[0])
            {
                pointer = array;

                if (CheckMZSignature()) // IMAGE_DOS_HEADER.e_magic == "MZ" ?
                {
                    MovePointerToIMAGE_NT_HEADERS_Signature();
                    if (CheckPESignature()) // IMAGE_NT_HEADERS.Signature == "PE" ?
                    {

                        info.NumberOfSections = GetNumberOfSections();
                        info.EP = AddressOfEntryPoint();

                        MovePointerToFirstSection();

                        info.Sections = ReadSections(info.NumberOfSections);
                        info.SizeOfHeader = info.Sections.First().RawAddress;                        
                        info.AddressOfEOF = GetAddressOfEOF(info.Sections.Last());
                        info.SizeOfEOF = info.FileSize - info.AddressOfEOF;
                        info._isPE = true;
                    }
                }
            }
            return info;
        }

        private static SectionInfo[] ReadSections(int nSections)
        {

            SectionInfo[] sections = new SectionInfo[nSections];
            for (int i = 0; i < nSections; i++)
            {                
                sections[i].SectionName = ReadStringFromPointer();
                sections[i].VirtualSize = VirtualSize();
                sections[i].VirtualAddress = VirtualAddress();
                sections[i].RawSize = SizeOfRawData();
                sections[i].RawAddress = AddressOfRawData();
                sections[i].ContainsCode = ContainsCode();
                MovePointerToNextSection();
            }
            return sections;
        }

        private static unsafe void MovePointerToNextSection()
        {
            pointer += 0x28;
        }

        private static unsafe string ReadStringFromPointer(int offset = 0)
        {
            return new string((sbyte*)(pointer + offset), 0, 8, Encoding.ASCII).TrimEnd(new Char[]{'\0'});
        }
        private static unsafe int VirtualSize()
        {
            return ReadInt32(8);
        }
        private static unsafe int VirtualAddress()
        {
            return ReadInt32(0xc);
        }

  
        private static unsafe bool ContainsCode()
        {
            return hasFlag(ReadInt32(0x24),0x20);
        }

        private static bool hasFlag(int carac, int flag)
        {
            return (carac & flag) == flag;
        }

        private static int GetAddressOfEOF(SectionInfo LastSection)
        {
            return LastSection.RawAddress + LastSection.RawSize;
        }

        private static unsafe int AddressOfEntryPoint()
        {
            return ReadInt32(0x28);
        }

        private static unsafe int SizeOfRawData()
        {
            return ReadInt32(0x10);
        }

        private static unsafe int AddressOfRawData()
        {
            return ReadInt32(0x14);
        }

        private static unsafe int ReadInt32(int offset = 0)
        {
            return ((Int32*)(pointer + offset))[0];
        }
        private static unsafe Int16 ReadInt16(int offset = 0)
        {
            return ((Int16*)(pointer + offset))[0];
        }

        private static unsafe void MovePointerToFirstSection()
        {
            pointer += 0xF8;
        }

        private static unsafe short GetNumberOfSections()
        {
            return ReadInt16(0x6);
        }

        private static unsafe void MovePointerToIMAGE_NT_HEADERS_Signature()
        {
            pointer += ReadInt32(0x3c);
        }

        private static unsafe bool CheckPESignature()
        {
            return ReadInt32() == 0x00004550;
        }

        private static unsafe bool CheckMZSignature()
        {
            return ReadInt16() == 0x5A4D;
        }

        internal static PEinfo ExtractInfo(string filename)
        {
            try
            {
                return ExtractInfo(File.ReadAllBytes(filename));
            }
            catch { return new PEinfo(); }
        }
    }
}
