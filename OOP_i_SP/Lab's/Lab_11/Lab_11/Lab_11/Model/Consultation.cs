using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11.Model
{
    public class Consultation
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string time { get; set; }

        public DateOnly date { get; set; } 

        public bool isFree { get; set; }

        public Consultation(string name, string subject, string timr, DateOnly date, bool boo = true)
        {
            this.Name = name;
            this.Subject = subject; 
            this.time = timr;
            this.date = date;
            this.isFree = boo;
        }

    }
}
