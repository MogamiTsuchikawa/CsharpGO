using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_GOライセンス付与ソフト
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            fbd.SelectedPath = @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                textBox1.Text=fbd.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "実行中";
            string ID = GetUSBdeviceID(textBox1.Text);
            string path = textBox1.Text + @"\AppData\main\id.lid";
            //Shift JISで書き込む
            //書き込むファイルが既に存在している場合は、上書きする
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                path,
                false,
                System.Text.Encoding.GetEncoding("shift_jis"));
            //TextBox1.Textの内容を書き込む
            sw.Write(ID);
            //閉じる
            sw.Close();
            label1.Text = "完了";
        }
        public static string GetUSBdeviceID(string path)
        {
            
            string drive = path.Substring(0, 2);
            string h = "Win32_LogicalDisk=\"" + drive + "\"";
            ManagementObject mo = new System.Management.ManagementObject(h);
            return (string)mo.Properties["VolumeSerialNumber"].Value;
        }
    }
}
