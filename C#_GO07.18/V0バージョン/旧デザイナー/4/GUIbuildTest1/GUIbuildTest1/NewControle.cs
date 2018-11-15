using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUIbuildTest1
{
    public partial class NewControle : Form
    {
        public NewControle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewControle_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Closing");
            
            Hensu.NewControle = comboBox1.Text;
            
            
            Hensu.NewControleName = textBox1.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.co.jp/?gfe_rd=cr&ei=_qulV9SvF5KL8QeWgJuACA#q=%E4%BA%88%E7%B4%84%E8%AA%9E%E3%80%80C%23");
        }

        private void NewControle_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Button");
            comboBox1.Items.Add("TextBox");
            comboBox1.Items.Add("CheckBox");
            comboBox1.Items.Add("ComboBox");
            comboBox1.Items.Add("Label");
            comboBox1.Items.Add("ListBox");
            //comboBox1.Items.Add("MenuStrip");
            comboBox1.Items.Add("PictureBox");
            comboBox1.Items.Add("ProgressBar");
            comboBox1.Items.Add("RadioButton");
            comboBox1.Items.Add("RichTextBox");
            Hensu.NewControle = "";
            Hensu.NewControleName = "";
        }
    }
}
