using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oxoSharp
{
    public class Config
    {
        public int SizeDivider = 0x10;
        public bool ReinitSessionOnFileLoad = true;
        public bool AutoDetectPE = true;
        public bool AutoSaveSessionOnExit = true;
        public bool ReloadLastSessionOnStartup = true;
        public string AV_File = "";

        public string AbsoluteAV_File
        {
            get
            {
                return Path.GetFullPath(AV_File);
            }
        }
        public string AV_CommandLine = "";
        // auto process config
        public bool EnableUserDefinedFixedRange = true;
        public NextRange nextRange = NextRange._first;
        public bool AutoGenerateFixedRange = false;
        public int SignatureMaxSize = 0x50;
    }
}