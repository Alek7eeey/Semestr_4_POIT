using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class CrewMember
    {
        public string name = "" ;
        public int age = 0;
        public int yearExp = 0;

        public string position = "";

        public CrewMember(string nam, int ag, int yearEx, string pos)
        {
            name = nam;
            age = ag;
            yearExp = yearEx;
            position = pos;
        }
        public CrewMember() { }

        public void returnDefaultValue()
        {
            name = "";
            age = 0;
            yearExp = 0;
            position = "";
        }


        public override string ToString()
        {
            return Environment.NewLine+ Environment.NewLine + "Должность: "+position + Environment.NewLine + "имя: " + name + Environment.NewLine + "Возраст: " + age + Environment.NewLine + "Стаж: " + yearExp;
        }
    }
}
