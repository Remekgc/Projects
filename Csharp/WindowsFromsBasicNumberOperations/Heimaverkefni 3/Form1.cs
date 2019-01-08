using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heimaverkefni_3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.pic5; //on click set image to chosen one
        }

        private void button1_Click(object sender, EventArgs e)
        { 

            for (int i = 0; i < 100; i++)
            {
                textBox2.Text += i + 1 +"\r\n"; //Display numbers from 1 to 100
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 51; i++)
            {
                textBox3.Text += i * 2 + "\r\n"; //Even numbers from 2 to 100
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            int userPick = Convert.ToInt32(textBox1.Text); //Set user choice and count it
            for (int i = 2; i < 25; i++)
            {
                textBox4.Text += i * userPick + "\r\n";
            }
        }
    }
}
