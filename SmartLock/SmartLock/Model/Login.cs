using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLock.Model
{
    public class Login
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

    }
}
