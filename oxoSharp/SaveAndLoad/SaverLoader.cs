using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace oxoSharp
{
    public static class SaverLoader
    {
        private const string _savefilename = "save.xml";
        private const string _configfilename = "config.xml";

        private static string SaveFile = Path.Combine(GlobalDataAndMethods.AbsoluteDirectory, _savefilename);
        private static string SaveFileBackup = Path.ChangeExtension(SaveFile, ".bak");

        private static string ConfigFile = Path.Combine(GlobalDataAndMethods.AbsoluteDirectory, _configfilename);

        private static XmlSerializer SessionSerializer = new XmlSerializer(typeof(Session));
        private static XmlSerializer ConfigSerializer = new XmlSerializer(typeof(Config));


        public static bool LoadSession(out Session session)
        {
            return LoadSession(out session, SaveFile);
        }
        public static bool LoadSession(out Session session, string SessionFile)
        {
            object loaded;
            bool result = LoadAny(SessionFile, SessionSerializer, out loaded);
            session = (Session)loaded;
            return result;
            //try
            //{
            //    if (File.Exists(SaveFile))
            //    {

            //        using (FileStream fs = File.OpenRead(SaveFile))
            //        {
            //            session = (Session)serializer.Deserialize(fs);
            //            return true;
            //        }
            //    }
            //}
            //catch { }
            //session = new Session();
            //return false;
        }


        public static bool SaveSession(Session session)
        {
            return SaveSession(session, SaveFile, SaveFileBackup, true);
        }
        public static bool SaveSession(Session session, string SessionFile, string BackupFile="", bool backup = false)
        {
            return SaveAny(SessionFile, SessionSerializer, session, backup, BackupFile);
            //try
            //{
            //    if (File.Exists(SaveFile))
            //        try
            //        {
            //            File.Delete(SaveFileBackup);
            //            File.Copy(SaveFile, SaveFileBackup); // backup old save file
            //        }
            //        catch { }

            //    using (FileStream fs = File.Open(SaveFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //    {
            //        fs.SetLength(0);
            //        serializer.Serialize(fs, session);
            //    }
            //}
            //catch { return false; }
            //return true;
        }

        public static bool LoadConfig(out Config config)
        {
            object loaded;
            bool result = LoadAny(ConfigFile, ConfigSerializer, out loaded);
            config = (result) ? (Config)loaded : new Config();
            return result;
        }
        public static bool SaveConfig(Config config)
        {
            return SaveAny(ConfigFile, ConfigSerializer, config);
        }
        private static bool LoadAny(string filename, XmlSerializer serializer, out Object loaded)
        {
            try
            {
                if (File.Exists(filename))
                {

                    using (FileStream fs = File.OpenRead(filename))
                    {
                        loaded = serializer.Deserialize(fs);
                        return true;
                    }
                }
            }
            catch { }
            loaded = null;
            return false;
        }
        private static bool SaveAny(string filename, XmlSerializer serializer, Object toSave, bool backup = false, string backupfilename = "")
        {
            try
            {
                if (backup)
                    Backup(filename, backupfilename);

                using (FileStream fs = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fs.SetLength(0);
                    serializer.Serialize(fs, toSave);
                }
            }
            catch { return false; }
            return true;
        }

        private static void Backup(string filename, string backupfilename)
        {
            if (File.Exists(filename))
                try
                {
                    File.Delete(backupfilename);
                    File.Copy(filename, backupfilename); // backup old file
                }
                catch { }
        }
    }
}
