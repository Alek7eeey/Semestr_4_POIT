using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Lab_2
{
    public partial class Airport : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public Flights newFlight = new Flights();
        CrewMember cm = new();
        public Airport()
        {
            InitializeComponent();
            FillWithInf.Text = newFlight.ToString() + cm.ToString();
            using (StreamWriter sw = new StreamWriter("DateBase", false))
            {
                sw.WriteLine("");
            }
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxID.Text;
            string pattern = "[^0-9]"; // регулярное выражение для поиска всех символов, кроме цифр
            string replacement = ""; // заменяем найденные символы на пустую строку
            string result = Regex.Replace(input, pattern, replacement);
            textBoxID.Text = result;
        }

        private void textBoxID_Leave(object sender, EventArgs e)
        {
            if (textBoxID.Text == "")
            {
                FillWithInf.Text = newFlight.ToString() + cm.ToString();
            }

            else
            {
                if (Convert.ToInt64(textBoxID.Text) > int.MaxValue)
                {
                    MessageBox.Show("Слишком большое значение для ID", "Ошибка");
                }
                else
                {
                    newFlight.ID = Convert.ToInt32(textBoxID.Text);
                    FillWithInf.Text = newFlight.ToString() + cm.ToString();
                }
            }
        }

        private void FillWithInf_Enter(object sender, EventArgs e)
        {
            HideCaret(FillWithInf.Handle);
            buttonSave.Focus();
        }

        private void comboBoxModel_Leave(object sender, EventArgs e)
        {
            if (comboBoxModel.Text == "")
            {
                FillWithInf.Text = newFlight.ToString() + cm.ToString();
            }
            else
            {
                if (comboBoxModel.Text == "Boeing") newFlight.model_ = Flights.model.Boeing;
                if (comboBoxModel.Text == "Airbus") newFlight.model_ = Flights.model.Airbus;
                if (comboBoxModel.Text == "Embraer") newFlight.model_ = Flights.model.Embraer;
                if (comboBoxModel.Text == "CRJ") newFlight.model_ = Flights.model.CRJ;

                FillWithInf.Text = newFlight.ToString() + cm.ToString();
            }
        }

        private void textBoxCountOfSeat_Leave(object sender, EventArgs e)
        {
            if (textBoxCountOfSeat.Text == "")
            {
                FillWithInf.Text = newFlight.ToString() + cm.ToString();
            }

            else
            {
                if (Convert.ToInt64(textBoxCountOfSeat.Text) > int.MaxValue)
                {
                    MessageBox.Show("Слишком большое значение для ID", "Ошибка");
                }
                else
                {
                    newFlight.countOfSeat = Convert.ToInt32(textBoxCountOfSeat.Text);
                    FillWithInf.Text = newFlight.ToString() + cm.ToString();
                }
            }
        }

        private void textBoxCountOfSeat_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxCountOfSeat.Text;
            string pattern = "[^0-9]"; // регулярное выражение для поиска всех символов, кроме цифр
            string replacement = ""; // заменяем найденные символы на пустую строку
            string result = Regex.Replace(input, pattern, replacement);
            textBoxCountOfSeat.Text = result;
        }

        private void dateOfIssueChoose_Leave(object sender, EventArgs e)
        {
            newFlight.yearOfIssue = Convert.ToString(dateOfIssueChoose.Value.Day +"."+ dateOfIssueChoose.Value.Month + "." + dateOfIssueChoose.Value.Year);
            FillWithInf.Text = newFlight.ToString() + cm.ToString();
        }

        private void textBoxCarrying_Leave(object sender, EventArgs e)
        {
            if (textBoxCarrying.Text == "")
            {
                FillWithInf.Text = newFlight.ToString() + cm.ToString();
            }

            else
            {
                if (Convert.ToInt64(textBoxCarrying.Text) > int.MaxValue)
                {
                    MessageBox.Show("Слишком большое значение для ID", "Ошибка");
                }
                else
                {
                    newFlight.carrying = Convert.ToInt32(textBoxCarrying.Text);
                    FillWithInf.Text = newFlight.ToString() + cm.ToString();
                }
            }
        }

        private void textBoxCarrying_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxCarrying.Text;
            string pattern = "[^0-9]"; // регулярное выражение для поиска всех символов, кроме цифр
            string replacement = ""; // заменяем найденные символы на пустую строку
            string result = Regex.Replace(input, pattern, replacement);
            textBoxCarrying.Text = result;
        }

        private void dateOfServiceChoose_Leave(object sender, EventArgs e)
        {
            newFlight.DateOfService = Convert.ToString(dateOfServiceChoose.Value.Day + "." + dateOfServiceChoose.Value.Month + "." + dateOfServiceChoose.Value.Year);
            FillWithInf.Text = newFlight.ToString() + cm.ToString();
        }

        private void listBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxType.SelectedIndex != -1) // Проверка, что элемент выбран
            {
                
                string selectedItem = listBoxType.SelectedItem.ToString(); // Получение выбранного элемента
                                                                           // Действия, которые необходимо выполнить при выборе элемента
                if (selectedItem == "Пассажирский") newFlight.typePlane = Flights.typeOfPlane.Пассажирский;
                if (selectedItem == "Грузовой") newFlight.typePlane = Flights.typeOfPlane.Грузовой;
                if (selectedItem == "Военный") newFlight.typePlane = Flights.typeOfPlane.Военный;

                FillWithInf.Text = newFlight.ToString() + cm.ToString();
            }

            else
            {
                FillWithInf.Text = newFlight.ToString() + cm.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(ConfirmTheCorrect.Checked == true)
            {
                using (StreamWriter sw = new StreamWriter("DateBase", true))
                {

                    sw.WriteLine(newFlight.ToString() + cm.ToString());
                    sw.WriteLine("--------------------------------------------");
                }
                MessageBox.Show("Информация сохранена!", "Сообщение");

                foreach (Control control in this.Controls)
                {
                    if (control is System.Windows.Forms.TextBox)
                    {
                        System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)control;
                        textBox.Text = "";
                    }

                    if (control is System.Windows.Forms.ComboBox Comb)
                    {
                        Comb.Text = "";
                    }

                    if (control is System.Windows.Forms.ListBox)
                    {
                        System.Windows.Forms.ListBox lb = (System.Windows.Forms.ListBox)control;
                        lb.Text = "";
                    }
                }

                listBoxType.Text = Convert.ToString(Flights.typeOfPlane.Пассажирский);
            }

            else
            {
                MessageBox.Show("Вы не подтвердили правильность введенных данных!", "Ошибка");
            }
       
        }
    }
}


