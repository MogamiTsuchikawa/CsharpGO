using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUImakerV3
{
    public partial class AddControlesSetting : Form
    {
        public AddControlesSetting()
        {
            InitializeComponent();
        }

        private void AddControlesSetting_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Location");
            comboBox1.Items.Add("Size");
            comboBox1.Items.Add("Text");
            comboBox1.Items.Add("Font");
            comboBox1.Items.Add("BackColor");
            comboBox1.Items.Add("ForeColor");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("選んでください");
            }
            else
            {
                int count = 2;
                bool here = false;
                while (Hensu.Dates[Hensu.SelectControleNumber, count] != null)
                {
                    if(Hensu.Dates[Hensu.SelectControleNumber, count]==comboBox1.Text)here=true;
                    ++count;
                    ++count;
                }
                if (here)
                {
                    MessageBox.Show("すでにあります");
                }
                else
                {


                    int i = 2;
                    while (Hensu.Dates[Hensu.SelectControleNumber, i] != null)
                    {

                        ++i;
                        ++i;
                    }
                    Hensu.Dates[Hensu.SelectControleNumber, i] = comboBox1.Text;
                    string input = "";
                    switch (comboBox1.Text)
                    {
                        case "Location":
                            input = "0:0";
                            break;
                        case "Size":
                            input = "20:20";
                            break;
                        case "Text":
                            input = Hensu.SelectControleName;
                            break;
                        case "Font":
                            input = "Arial:12";
                            break;
                        case "BackColor":
                            input = "Red";//システム定義色のみ
                            break;
                        case "ForeColor":
                            input = "Red";//システム定義色のみ
                            break;


                    }
                    Hensu.Dates[Hensu.SelectControleNumber, i + 1] = input;
                    this.Close();
                }
            }
        }
    }
}
