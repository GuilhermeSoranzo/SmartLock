using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLock.DB
{
    public class Database
    {
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CriarBancoDeDados()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "SmartLock.db")))
                {
                    conexao.CreateTable<Login>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public bool InserirLogin(Login aluno)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "SmartLock.db")))
                {
                    conexao.Insert(aluno);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
    }
}
