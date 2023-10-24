using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLock.Model
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Email { get; set; }

        [NotNull]
        public string Senha { get; set; }

    }
}
