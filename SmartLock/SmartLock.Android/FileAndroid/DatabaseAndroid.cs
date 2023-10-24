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

        public bool CriarBancoDeDados()
        {
            //try
            //{
            //    using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "SmartLock.db")))
            //    {
            //        conexao.CreateTable<Login>();
            //        return true;
            //    }
            //}
            //catch (SQLiteException ex)
            //{
            return false;
            //}
        }

        public bool InserirLogin(Login aluno)
        {
            //try
            //{
            //    using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "SmartLock.db")))
            //    {
            //        conexao.Insert(aluno);
            //        return true;
            //    }
            //}
            //catch (SQLiteException ex)
            //{
            return false;
            //}
        }
    }
}
