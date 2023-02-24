using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Search : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public Search()
        {
            InitializeComponent();
        }
        
        
        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxID.Text;
            string pattern = "[^0-9]"; // регулярное выражение для поиска всех символов, кроме цифр
            string replacement = ""; // заменяем найденные символы на пустую строку
            string result = Regex.Replace(input, pattern, replacement);
            textBoxID.Text = result;
            bool isTrue = false;
            fill.Text = "";

            if (textBoxID.Text != "")
            {
                int searchText = 0;
                searchText += Convert.ToInt32(textBoxID.Text);

                foreach (var obj in DataStorage.Instance.GetObjects())
                {
                    if (obj.ID == searchText)
                    {
                        fill.Text += obj.ToString();
                        isTrue = true;
                    }
                }
            }

            if (!isTrue)
            {
                fill.Text = "";
            }

        }

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isTrue = false;
            fill.Text = "";

            if (comboBoxModel.Text != "")
            {
                string text = "";
                text+= comboBoxModel.Text;
               
                foreach (var obj in DataStorage.Instance.GetObjects())
                {
                    if (Convert.ToString(obj.model_) == text)
                    {
                        fill.Text += obj.ToString();
                        isTrue = true;
                    }
                }
            }

            if (!isTrue)
            {
                fill.Text = "";
            }
        }

        private void fill_Enter(object sender, EventArgs e)
        {
            HideCaret(fill.Handle);
            textBoxID.Focus();
        }

        private void listBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isTrue = false;
            fill.Text = "";
            if (listBoxType.Text != "")
            {
                string text = "";
                text += listBoxType.Text;
                fill.Text = "";
                foreach (var obj in DataStorage.Instance.GetObjects())
                {
                    if (Convert.ToString(obj.typePlane) == text)
                    {
                        fill.Text += obj.ToString();
                        isTrue = true;
                    }
                }
            }

            if (!isTrue)
            {
                fill.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string input = textBox3.Text;
            string pattern = "[^0-9]"; // регулярное выражение для поиска всех символов, кроме цифр
            string replacement = ""; // заменяем найденные символы на пустую строку
            string result = Regex.Replace(input, pattern, replacement);
            textBox3.Text = result;
            fill.Text = "";

            int start = 0, finish = 0;
            bool isTrue = false;


            if (textBox2.Text != "" && textBox3.Text!="" && Convert.ToInt32(textBox3.Text) < Convert.ToInt32(textBox2.Text))
            {
                start = Convert.ToInt32(textBox3.Text);
                finish = Convert.ToInt32(textBox2.Text);

                foreach (var a in DataStorage.Instance.GetObjects())
                {
                    if (a.countOfSeat >= start && a.countOfSeat <= finish)
                    {
                        fill.Text += a.ToString();
                        isTrue = true;
                    }
                }
            }

            if (!isTrue)
            {
                fill.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string input = textBox2.Text;
            string pattern = "[^0-9]"; // регулярное выражение для поиска всех символов, кроме цифр
            string replacement = ""; // заменяем найденные символы на пустую строку
            string result = Regex.Replace(input, pattern, replacement);
            textBox2.Text = result;
            fill.Text = "";

            int start = 0, finish = 0;
            bool isTrue = false;

            if (textBox2.Text != "" && textBox3.Text != "" && Convert.ToInt32(textBox3.Text) < Convert.ToInt32(textBox2.Text))
            {
                start = Convert.ToInt32(textBox3.Text);
                finish = Convert.ToInt32(textBox2.Text);

                foreach (var a in DataStorage.Instance.GetObjects())
                {
                    if (a.countOfSeat >= start && a.countOfSeat <= finish)
                    {
                        fill.Text += a.ToString();
                        isTrue = true;
                    }
                }
            }

            if (!isTrue)
            {
                fill.Text = "";
            }
        }
    }
}
