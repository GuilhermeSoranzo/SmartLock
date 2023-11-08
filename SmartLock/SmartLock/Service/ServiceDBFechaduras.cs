using SmartLock.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLock.Service
{
    public class ServiceDBFechaduras
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public ServiceDBFechaduras(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Fechadura>();
        }

        public void Inserir(Fechadura cadastro)
        {
            int result = conn.Insert(cadastro);
        }

        public void Alterar(Fechadura cadastro)
        {
            int result = conn.Update(cadastro);
        }

        public List<Fechadura> ListarFechaduras()
        {
            return conn.Table<Fechadura>().ToList();
        }

        public void RemoverFechadura(long id)
        {
            conn.Delete<Fechadura>(id);
        }
    }
}
