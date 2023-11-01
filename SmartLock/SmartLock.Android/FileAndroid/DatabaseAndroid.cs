using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLock.Droid
{
    public class DatabaseAndroid
    {
        
        public static string GetLocalFilePath (string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }

    }
}
