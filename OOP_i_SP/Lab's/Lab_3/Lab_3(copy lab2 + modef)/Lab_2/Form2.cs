using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Status;

namespace Lab_2
{
    public partial class crewMem : Form
    {
        CrewMember cm = new CrewMember();
        public static List<CrewMember> crewMe = new List<CrewMember>();
        public crewMem()
        {
            InitializeComponent();
        }

        private void expInput_TextChanged(object sender, EventArgs e)
        {
            string input = expInput.Text;
            string pattern = "[^0-9]"; // регулярное выражение для поиска всех символов, кроме цифр
            string replacement = ""; // заменяем найденные символы на пустую строку
            string result = Regex.Replace(input, pattern, replacement);
            expInput.Text = result;
        }

        private void ageInp_TextChanged(object sender, EventArgs e)
        {
            string input = ageInp.Text;
            string pattern = "[^0-9]"; // регулярное выражение для поиска всех символов, кроме цифр
            string replacement = ""; // заменяем найденные символы на пустую строку
            string result = Regex.Replace(input, pattern, replacement);
            ageInp.Text = result;
        }

        private void comboBoxConditionlInput_Leave(object sender, EventArgs e)
        {
            cm.position = comboBoxConditionlInput.Text;
        }

        private void nameInput_Leave(object sender, EventArgs e)
        {
            cm.name = nameInput.Text;
        }

        private void expInput_Leave(object sender, EventArgs e)
        {
            if(expInput.Text != "")
            {
                cm.yearExp = Convert.ToInt32(expInput.Text);
            }
        }

        private void ageInp_Leave(object sender, EventArgs e)
        {
            if (expInput.Text != "")
            {
                cm.age = Convert.ToInt32(ageInp.Text);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string patternt = @"^[А-Я|A-Z]\w+$";
            Regex regex = new(patternt);
            Match match = regex.Match(nameInput.Text);

            if (match.Success)
            {
                if (ageInp.Text == "" || expInput.Text == "" || nameInput.Text == "" || comboBoxConditionlInput.Text == "")
                {
                    MessageBox.Show("Вы заполнили не все поля!", "Ошибка");
                }

                else
                {
                    var validationContext = new ValidationContext(cm);
                    var validationResults = new List<ValidationResult>();
                    bool isValid = Validator.TryValidateObject(cm, validationContext, validationResults, true);

                    if (isValid)
                    {
                        crewMe.Add(cm);
                        // cm.returnDefaultValue();

                        ageInp.Text = "";
                        expInput.Text = "";
                        nameInput.Text = "";
                        comboBoxConditionlInput.Text = "";
                    }

                    else
                    {
                        foreach (var validationResult in validationResults)
                        {
                            MessageBox.Show(validationResult.ErrorMessage);
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("Имя должно начинаться с большой буквы!");
            }
        }
    }
}
