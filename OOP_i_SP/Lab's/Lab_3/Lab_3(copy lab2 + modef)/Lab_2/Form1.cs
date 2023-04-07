using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Lab_2
{
    public partial class Airport : Form
    {
        static int co = 0;
        double progressValue = 12.5;
        int progressBarMaxValue = 100;
        bool id = true, model = true, count = true, yearIssue = true, weight = true, yearControl = true, type = true, click = true;

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        Flights newFlight = new Flights();
        CrewMember cm = new();
        public Airport()
        {
            InitializeComponent();
            FillWithInf.Text = newFlight.ToString();
            using (StreamWriter sw = new StreamWriter("DateBase.txt", false)) ;
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxID.Text;
            string pattern = "[^0-9]"; // регулярное выражение для поиска всех символов, кроме цифр
            string replacement = ""; // заменяем найденные символы на пустую строку
            string result = Regex.Replace(input, pattern, replacement);
            textBoxID.Text = result;

            if (textBoxID.Text.Length > 0 && id)
            {
                barFilling.Value += (int)(progressValue / (double)progressBarMaxValue * 100);
                id = false;
                chekBar();
            }

            if (textBoxID.Text.Length == 0 && barFilling.Value != 0)
            {
                barFilling.Value -= (int)(progressValue / (double)progressBarMaxValue * 100);
                id = true;
            }
        }

        private void chekBar()
        {
            if (barFilling.Value >= 96)
            {
                barFilling.Value = 100;
            }
        }

        private void textBoxID_Leave(object sender, EventArgs e)
        {
            if (textBoxID.Text == "")
            {
                FillWithInf.Text = newFlight.ToString();
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
                    FillWithInf.Text = newFlight.ToString();
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
                FillWithInf.Text = newFlight.ToString();
                if (barFilling.Value != 0) barFilling.Value -= (int)(progressValue / (double)progressBarMaxValue * 100);
                model = true;
                chekBar();
            }
            else
            {
                if (comboBoxModel.Text == "Boeing") newFlight.model_ = Flights.model.Boeing;
                if (comboBoxModel.Text == "Airbus") newFlight.model_ = Flights.model.Airbus;
                if (comboBoxModel.Text == "Embraer") newFlight.model_ = Flights.model.Embraer;
                if (comboBoxModel.Text == "CRJ") newFlight.model_ = Flights.model.CRJ;

                FillWithInf.Text = newFlight.ToString();
            }
        }

        private void textBoxCountOfSeat_Leave(object sender, EventArgs e)
        {
            if (textBoxCountOfSeat.Text == "")
            {
                FillWithInf.Text = newFlight.ToString();
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
                    FillWithInf.Text = newFlight.ToString();
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

            if (textBoxCountOfSeat.Text.Length > 0 && count)
            {
                barFilling.Value += (int)(progressValue / (double)progressBarMaxValue * 100);
                count = false;
                chekBar();
            }

            if (textBoxCountOfSeat.Text.Length == 0 && barFilling.Value != 0)
            {
                barFilling.Value -= (int)(progressValue / (double)progressBarMaxValue * 100);
                count = true;
            }
        }

        private void dateOfIssueChoose_Leave(object sender, EventArgs e)
        {
            newFlight.yearOfIssue = Convert.ToString(dateOfIssueChoose.Value.Day + "." + dateOfIssueChoose.Value.Month + "." + dateOfIssueChoose.Value.Year);
            FillWithInf.Text = newFlight.ToString();
        }

        private void textBoxCarrying_Leave(object sender, EventArgs e)
        {
            if (textBoxCarrying.Text == "")
            {
                FillWithInf.Text = newFlight.ToString();
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
                    FillWithInf.Text = newFlight.ToString();
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

            if (textBoxCarrying.Text.Length > 0 && weight)
            {
                barFilling.Value += (int)(progressValue / (double)progressBarMaxValue * 100);
                weight = false;
                chekBar();
            }

            if (textBoxCarrying.Text == "" && barFilling.Value != 0)
            {
                barFilling.Value -= (int)(progressValue / (double)progressBarMaxValue * 100);
                weight = true;
            }
        }

        private void dateOfServiceChoose_Leave(object sender, EventArgs e)
        {
            newFlight.DateOfService = Convert.ToString(dateOfServiceChoose.Value.Day + "." + dateOfServiceChoose.Value.Month + "." + dateOfServiceChoose.Value.Year);
            FillWithInf.Text = newFlight.ToString();
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

                FillWithInf.Text = newFlight.ToString();
            }

            else
            {
                FillWithInf.Text = newFlight.ToString();
            }

            if (listBoxType.Text.Length > 0 && type)
            {
                barFilling.Value += (int)(progressValue / (double)progressBarMaxValue * 100);
                type = false;
                chekBar();
            }

            if (listBoxType.Text == "" && barFilling.Value != 0)
            {
                barFilling.Value -= (int)(progressValue / (double)progressBarMaxValue * 100);
                type = true;
            }
        }

        private void serialize_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new(typeof(Flights));
            newFlight.crewMe = crewMem.crewMe;
            using (FileStream fs = new("Flights.xml", FileMode.OpenOrCreate))
            {
                newFlight.crewMe = crewMem.crewMe;
                xmlSerializer.Serialize(fs, newFlight);
            }
        }

        private void deserialize_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new(typeof(Flights));
            using (FileStream fs = new("Flights.xml", FileMode.Open))
            {
                Flights newFlig = (Flights)serializer.Deserialize(fs);
                MessageBox.Show(newFlig.ToString(), "Информация");
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = !toolStrip.Visible;

            // Если панель инструментов видима, закрепите ее в верхней части формы
            if (toolStripButton3.Visible)
            {
                toolStripButton3.Visible = false;
                toolStripButton1.Visible = false;
                toolStripButton5.Visible = false;
            }
            else // Если панель инструментов скрыта, открепите ее
            {
                toolStripButton3.Visible = true;
                toolStripButton1.Visible = true;
                toolStripButton5.Visible = true;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("v 1.0.0" + Environment.NewLine + "Lab_3", "О программе");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Sort sort = new();
            sort.Show();
        }

        private void ConfirmTheCorrect_CheckedChanged(object sender, EventArgs e)
        {
            if (ConfirmTheCorrect.Checked == true && click)
            {
                barFilling.Value += (int)(progressValue / (double)progressBarMaxValue * 100);
                click = false;
                chekBar();
            }

            if (ConfirmTheCorrect.Text == "" && barFilling.Value != 0)
            {
                barFilling.Value -= (int)(progressValue / (double)progressBarMaxValue * 100);
                click = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var validationContext = new ValidationContext(newFlight);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(newFlight, validationContext, validationResults, true);

            if (!isValid)
            {
                foreach (var validation in validationResults)
                {
                    MessageBox.Show(validation.ErrorMessage);
                }
            }

            else
            {
                if (ConfirmTheCorrect.Checked == true)
                {
                    using (StreamWriter sw = new StreamWriter("DateBase.txt", true))
                    {
                        newFlight.crewMe = crewMem.crewMe;
                        sw.WriteLine(newFlight.ToString());
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
                    DataStorage.Instance.AddObject(newFlight);
                    newFlight = new Flights();

                    listBoxType.Text = Convert.ToString(Flights.typeOfPlane.Пассажирский);
                    dateOfIssueChoose.Value = DateTime.Now;
                    dateOfServiceChoose.Value = DateTime.Now;
                    newFlight.crewMe = crewMem.crewMe;
                    crewMem.crewMe.Clear();

                    //newFlight.returnToTheDefaultValue();
                    FillWithInf.Text = newFlight.ToString();
                    labelCountOfObjects.Text = "Количество объектов: " + Convert.ToInt32(++co) + Environment.NewLine + "Последнее время создания: " + DateAndTime.Now;
                }

                else
                {
                    MessageBox.Show("Вы не подтвердили правильность введенных данных!", "Ошибка");
                }
            }

        }

        private void dateOfServiceChoose_ValueChanged(object sender, EventArgs e)
        {
            if (dateOfServiceChoose.Text.Length > 0 && yearControl)
            {
                barFilling.Value += (int)(progressValue / (double)progressBarMaxValue * 100);
                yearControl = false;
                chekBar();
            }

            if (dateOfServiceChoose.Text == "" && barFilling.Value != 0)
            {
                barFilling.Value -= (int)(progressValue / (double)progressBarMaxValue * 100);
                yearControl = true;
            }
        }

        private void dateOfIssueChoose_ValueChanged(object sender, EventArgs e)
        {
            if (dateOfIssueChoose.Text.Length > 0 && yearIssue)
            {
                barFilling.Value += (int)(progressValue / (double)progressBarMaxValue * 100);
                yearIssue = false;
                chekBar();
            }

            if (dateOfIssueChoose.Text == "" && barFilling.Value != 0)
            {
                barFilling.Value -= (int)(progressValue / (double)progressBarMaxValue * 100);
                yearIssue = true;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
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
            dateOfIssueChoose.Value = DateTime.Now;
            dateOfServiceChoose.Value = DateTime.Now;
            ConfirmTheCorrect.Checked = false;
            FillWithInf.Text = "";
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            crewMem crewMe = new crewMem();
            crewMe.Show();
        }

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModel.Text.Length > 0 && model)
            {
                barFilling.Value += (int)(progressValue / (double)progressBarMaxValue * 100);
                model = false;
                chekBar();
            }

            if (comboBoxModel.Text == "" && barFilling.Value != 0)
            {
                barFilling.Value -= (int)(progressValue / (double)progressBarMaxValue * 100);
                model = true;
            }
        }
    }

    public class DataStorage
    {
        private static DataStorage instance;
        private List<Flights> flights;

        private DataStorage()
        {
            flights = new List<Flights>();
        }

        public static DataStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataStorage();
                }
                return instance;
            }
        }

        public void AddObject(Flights obj)
        {
            flights.Add(obj);
        }

        public List<Flights> GetObjects()
        {
            return flights;
        }
    }
}


