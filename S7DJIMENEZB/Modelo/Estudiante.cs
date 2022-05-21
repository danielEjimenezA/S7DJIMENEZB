using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace S7DJIMENEZB.Modelo
{
    public class Estudiante
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string User { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
