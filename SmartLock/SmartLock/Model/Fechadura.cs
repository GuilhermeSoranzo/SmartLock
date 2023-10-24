using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLock.Model
{
    public class Fechadura
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public string Description { get; set; }
        public string Estado { get; set; }
        public string Color { get; set; }
    }
}
