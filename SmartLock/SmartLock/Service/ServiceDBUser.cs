using SmartLock.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartLock.Service
{
    public class ServiceDBUser
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }
        public ServiceDBUser(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<User>();
        }

        public void Inserir(User cadastro)
        {
            if (cadastro.Email.Length > 0 && cadastro.Senha.Length > 0)
            {
                int result = conn.Insert(cadastro);
                this.StatusMessage = string.Format("{0} registro adicionado: [Nota: {1}]", result, cadastro.Email);
            }
        }

        public bool AutorizarLogin(string email, string senha)
        {
            var usuario = conn.Table<User>().Where(x => x.Email.Equals(email) && x.Senha.Equals(senha)).ToList();

            return usuario.Any();
        }
    }
}
