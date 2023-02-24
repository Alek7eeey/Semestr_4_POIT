using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class CrewMember
    {
        [Required(ErrorMessage = "Введите имя")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Имя должно содержать только буквы и пробелы")]
        [StringLength(50, ErrorMessage = "Имя должно содержать не более 50 символов")]
        public string name { get; set; } = "";

        [Range(0, 120, ErrorMessage = "Возраст должен быть в диапазоне от 0 до 120")]
        public int age { get; set; } = 0;
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
