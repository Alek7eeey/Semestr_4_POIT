using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9.Classes
{
    public class InfoAboutPeople
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
