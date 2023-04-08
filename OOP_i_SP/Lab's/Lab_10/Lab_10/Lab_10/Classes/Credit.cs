using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10.Classes
{
    public class Credit
    {
        public int ID { get; set; }

        [Column("Sum_of_credit")]
        public int sumOfCredit { get; set; }

        [Column("Date_of_credit")]
        public DateTime date { get; set; }

        public int personID { get; set; }

        public override string ToString()
        {
            return $"Credit {{ ID = {ID}, Sum of credit = {sumOfCredit}, Date of credit = {date}, Person ID = {personID} }}";
        }
    }
}
