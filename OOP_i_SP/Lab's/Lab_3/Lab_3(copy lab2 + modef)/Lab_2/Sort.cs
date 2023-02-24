using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab_2
{
    public partial class Sort : Form
    {
        public Sort()
        {
            InitializeComponent();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            var newArr = DataStorage.Instance.GetObjects().OrderBy(p => p.DateOfService);
            fill_2.Text = "";

            foreach (var item in newArr)
            {
                fill_2.Text += item.ToString();
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newArr = DataStorage.Instance.GetObjects().OrderBy(p => p.yearOfIssue);
            fill_2.Text = "";

            foreach (var item in newArr)
            {
                fill_2.Text += item.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new(typeof(string));
            using (FileStream fs = new("SortByYearOfIssue.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, fill_2.Text);
            }

            MessageBox.Show ("Информация сериализована!","Serialize");
        }
    }
}
