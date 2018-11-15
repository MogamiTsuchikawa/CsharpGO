using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testArduino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Arduino.SetArduino("COM4");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arduino.digitalWrite(13, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Arduino.digitalWrite(13, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Arduino.analogWrite(11, int.Parse(textBox1.Text));
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Arduino.digitalRead(2))
            {
                label2.Text = "T";
            }
            else
            {
                label2.Text = "F";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label3.Text = Arduino.analogRead(2).ToString();
        }
    }
}
