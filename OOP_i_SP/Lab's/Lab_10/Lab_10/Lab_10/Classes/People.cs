using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10.Classes
{
    public class People
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Adress")]
        public string adress { get; set; }

        public override string ToString()
        {
            return $"Client {{ ID = {ID}, Name = {Name}, Address = {adress} }}";
        }
    }
}
