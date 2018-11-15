using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainEditor
{
    public partial class 設定 : Form
    {
        public 設定()
        {
            InitializeComponent();
        }

        private void 設定_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(
                @"AppData\editor\Setting.txt",
                System.Text.Encoding.GetEncoding("shift_jis"));
            //内容をすべて読み込む

            while (sr.Peek() > -1)
            {
                string[] line = sr.ReadLine().Split(':');
                switch (line[0])
                {
                    case "外部エディタ":
                        if (line[1] == "true")
                        {
                            checkBox1.Select();
                        }
                        break;
                    case "外部エディタPATH":
                        textBox1.Text = line[1];
                        Hensu.EditorPath = line[1];
                        break;

                }
            }
            //閉じる
            sr.Close();
        }
    }
}
