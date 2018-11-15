using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUImakerV3
{
    public partial class SelectControleWindows : Form
    {
        public SelectControleWindows()
        {
            InitializeComponent();
        }

        private void SelectControleWindows_Load(object sender, EventArgs e)
        {
            //Load
            int countX = 0;
            while (Hensu.Dates[countX, 0] != null)
            {
                listBox1.Items.Add(Hensu.Dates[countX, 0] + "*" + Hensu.Dates[countX, 1]);
                ++countX;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //選択時
            if (listBox1.Text != null && listBox1.Text != "")
            {
                string[] keep = listBox1.Text.Split('*');
                Hensu.SelectControleKinds = keep[0];
                Hensu.SelectControleName = keep[1];
                Hensu.SelectControleNumber = SearchControleNum(keep[1]);
                ((Form1)this.Owner).ChangeDate();
                this.Close();
            }
        }
        static int SearchControleNum(string name)
        {
            int CtrlNum = 0;
            while (Hensu.Dates[CtrlNum, 1] != name)
            {
                CtrlNum = CtrlNum + 1;
                //Debug.WriteLine(Hensu.Dates[CtrlNum, 1]);
            }
            return CtrlNum;
        }
    }
}
