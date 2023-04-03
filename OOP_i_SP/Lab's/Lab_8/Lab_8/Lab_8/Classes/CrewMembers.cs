using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8.Classes
{
    public class CrewMembers
    {
        public string? name { get; set; }
        public string? position { get; set; }
        public int age { get; set; }
        public int yearOfExp {get; set; }

        public CrewMembers(string? name, string? position, int age, int year)
        {
            this.name = name;
            this.position = position;
            this.age = age;
            this.yearOfExp = year;
        }

        public CrewMembers() { }

        public override string ToString()
        {
            return $"- {name} ({position}), age {age}, experience {yearOfExp} years";
        }

        public void clearClass()
        {
            name = null ;
            position = null ;
            age = 0 ;
            yearOfExp = 0 ;
        }
    }
}
