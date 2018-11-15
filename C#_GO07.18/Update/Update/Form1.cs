using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Update
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader readVER = new System.IO.StreamReader(
                @"main\ver.txt",
                System.Text.Encoding.GetEncoding("shift_jis"));
            Hensu.Ver = double.Parse(readVER.ReadLine());
            label2.Text = Hensu.Ver.ToString();
            readVER.Close();
            System.IO.StreamReader readBaseVer = new System.IO.StreamReader(
                @"main\BaseVer.txt",
                System.Text.Encoding.GetEncoding("shift_jis"));
            Hensu.BaseVer = int.Parse(readBaseVer.ReadLine());

            //Webサイトよりバージョン情報及びダウンロード先を確認


            //現バージョンとの確認


            if (Hensu.FindNew)
            {
                //最新版を見つけた場合
                button1.Enabled = true;
                label3.Text = "最新バージョンを見つけました。";
                MessageBox.Show("最新バージョンを見つけましたが、ファイルフォーマットが変更されており、前のバージョンで作成したプロジェクトは正しく扱えなくなります。よろしいですか？");
            }
            else
            {
                if (Hensu.IsNew)
                {
                    //最新バージョンである場合
                    label3.Text = "最新バージョンです。";
                }
                else
                {
                    //見つからなかった場合
                    label3.Text = "アップデート不可能です。\nソフトウェアが古すぎるか、\nすでにサポートを終了しています。";
                }
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Update
            MessageBox.Show("C#_GOのすべてのプロセスを終了してください。すべてのプロセスが終了しないで続行するとC#_GOが破損し修復、アップデートもできなくなります。　　　　　　よろしいですか？");

        }
    }
}
