using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{

    public partial class Fill : Form
    {
        public long saveSum = 0;
        public long currentSum = 0;
        public bool plus = false;
        public bool minus = false;
        public bool mult = false;
        public bool del = false;
        public bool ost = false;
       
        Calculator calculator= new Calculator();
        
        public Fill()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputArea.Text += '1';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inputArea.Text += '2';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inputArea.Text += '3';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inputArea.Text += '4';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            inputArea.Text += '5';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            inputArea.Text += '6';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            inputArea.Text += '7';
        }

        private void button10_Click(object sender, EventArgs e)
        {
            inputArea.Text += '8';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inputArea.Text += '9';
        }

        private void button13_Click(object sender, EventArgs e)
        {
            inputArea.Text += '0';
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (inputArea.Text != null)
            {
                inputArea.Text = null;
            }
            currentSum = 0;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (inputArea.Text.Length > 0)
            {
                inputArea.Text = inputArea.Text.Remove(inputArea.Text.Length - 1);
            }

            else
            {
                inputArea.Text = null;
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            calculator.MakeOpeartion(ref currentSum, ref inputArea, ref plus, ref minus, ref del, ref mult, ref ost);
            ost = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            calculator.MakeOpeartion(ref currentSum, ref inputArea, ref plus, ref minus, ref del, ref mult, ref ost);
            plus = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            calculator.MakeOpeartion(ref currentSum, ref inputArea, ref plus, ref minus, ref del, ref mult, ref ost);
            minus = true;
         
        }

        private void button14_Click(object sender, EventArgs e)
        {
            calculator.MakeOpeartion(ref currentSum, ref inputArea, ref plus, ref minus, ref del, ref mult, ref ost);
            mult = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            calculator.MakeOpeartion(ref currentSum, ref inputArea, ref plus, ref minus, ref del, ref mult, ref ost);
            del = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            calculator.MakeOpeartion(ref currentSum, ref inputArea, ref plus, ref minus, ref del, ref mult, ref ost);
            inputArea.Text = Convert.ToString(currentSum);
        }

        private void inputArea_TextChanged(object sender, EventArgs e)
        {
            if (inputArea.Text.Length > 10)
            {
                inputArea.ScrollBars = ScrollBars.Both;
            }
          
        }

        private void button19_Click(object sender, EventArgs e)
        {
            saveSum = currentSum;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            inputArea.Text = saveSum.ToString();
        }
    }
}
