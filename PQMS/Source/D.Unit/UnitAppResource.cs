using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Ulee.Utils;

namespace PQMS
{
    public static class AppRes
    {
        public static bool Busy { get; set; }
        public static string UserId { get; set; }
        public static UlIniFile Ini { get; private set; }
        public static UlLogger TotalLog { get; private set; }
        public static UlLogger DbLog { get; private set; }
        public static AppDatabase DB { get; private set; }

        private static UlStringCrypto crypto;

        //private const string csIniFName = @"C:\\Users\\hiel_kim\\OneDrive - SGS\\Documents\\All\\C#\\Seoul\\Quality\\PQMS\\Config\\Sgs.PQMS.ini";

        public static void Create()
        {
            Busy = false;
            crypto = new UlStringCrypto("!rpting@");
            //Ini = new UlIniFile(csIniFName);

            //DbLog = new UlLogger();
            //DbLog.Path = Path.GetFullPath(Ini.GetString("Log", "DatabasePath"));
            //DbLog.FName = Ini.GetString("Log", "DatabaseFileName");

            //DB = new AppDatabase(crypto.Decrypt(Ini.GetString("Database", "ConnectString")));            

            // Connect DB Information
            // Data Source=KRSEC001;Initial Catalog=PQMS;User ID=pqms;Password=PQMS;Connection Timeout=600;
            // crypto 암호화
            DB = new AppDatabase(crypto.Decrypt("qpFvq8W8GPfrD6pa6zQbtN//IVovZDerNB8Wu/yHIvV3OKVV35nsrn3XgJ8M2pNmkQQN0c8a3F6hnDabJbXikfLxSMEl/TZeZmA8jqE9vrmClpRvlJNICorcn78kf35Y"));
            DB.Open();
        }

        public static void Destroy()
        {
            if (DB.Connect.State == ConnectionState.Open)
            {
                DB.Close();
            }
        }
    }
}
