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
    public partial class AddEvents : Form
    {
        public AddEvents()
        {
            InitializeComponent();
        }

        private void AddEvents_Load(object sender, EventArgs e)
        {
            label2.Text = Hensu.EventControleKinde;
            label6.Text = Hensu.EventControleName;
            string FileName = System.IO.Path.GetDirectoryName(Hensu.RunHikisu) + @"\"
                + System.IO.Path.GetFileNameWithoutExtension(Hensu.RunHikisu) + @".eve";
            if (Hensu.RunHikisu == "GUIcode.xlsx")
            {
                FileName = "GUIcode.eve";
            }
            
            System.IO.StreamReader sr = new System.IO.StreamReader(
    FileName,
    System.Text.Encoding.GetEncoding("shift_jis"));
            //内容を一行ずつ読み込む
            string[] Items = new String[100];
            string[] Data = new String[100];
            bool find = false;
            while (sr.Peek() > -1)
            {
                Items = sr.ReadLine().Split('/');
                if(Items[1] == Hensu.EventControleName&&Items[0]==Hensu.EventControleKinde)
                {
                    Data = Items;
                    find = true;
                }
            }
            //閉じる
            sr.Close();
            if (find)
            {
                //イベント設定がある場合
                bool read = true;
                int count = 2;
                while (read)
                {
                    if (Data[count] == ";")
                    {
                        read = false;
                    }
                    else
                    {
                        
                        listBox1.Items.Add(Data[count]);
                        ++count;
                    }
                }
            }
            else
            {
                //イベント設定がない場合
            }



            //イベント追加系
            System.IO.StreamReader sr1 = new System.IO.StreamReader(
                System.IO.Directory.GetCurrentDirectory() +  @"\AppData\GUImaker\" + Hensu.EventControleKinde + @".txt",
                System.Text.Encoding.GetEncoding("shift_jis"));
            string[] adds = sr1.ReadLine().Split(',');
            comboBox1.Items.AddRange(adds);
            sr1.Close();
            System.IO.StreamReader sr2 = new System.IO.StreamReader(
                System.IO.Directory.GetCurrentDirectory() + @"\AppData\GUImaker\" + Hensu.EventControleKinde + @"Ex.txt",
                System.Text.Encoding.GetEncoding("shift_jis"));
            Hensu.Ex = sr2.ReadLine().Split(';');
            sr2.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text=Hensu.Ex[comboBox1.SelectedIndex];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //イベント追加
            if (comboBox1.Text == null && comboBox1.Text == "")
            {

            }else
            {
                if (listBox1.FindString(comboBox1.Text) != -1)
                {
                    //既に存在するイベント
                    MessageBox.Show("そのイベントはすでに存在します");
                }
                else
                {

                    listBox1.Items.Add(comboBox1.Text);
                    string FileName = System.IO.Path.GetDirectoryName(Hensu.RunHikisu) + @"\"
                    + System.IO.Path.GetFileNameWithoutExtension(Hensu.RunHikisu) + @".eve";
                    if (Hensu.RunHikisu == "GUIcode.guit")
                    {
                        FileName = "GUIcode.eve";
                    }
                    System.IO.StreamReader sr = new System.IO.StreamReader(
                        FileName,
                        System.Text.Encoding.GetEncoding("shift_jis"));
                    string[,] Items = new String[999, 50];
                    int count = 0;
                    while (sr.Peek() > -1)
                    {
                        string[] keep = sr.ReadLine().Split('/');
                        int count1 = 0;
                        do
                        {
                            Items[count, count1] = keep[count1];
                            ++count1;
                        }
                        while (keep[count1 - 1] != ";");
                        ++count;
                    }
                    sr.Close();
                    count = 0;
                    while (Items[count, 0] != null && Items[count, 0] != "")
                    {
                        if (Items[count, 1] == Hensu.EventControleName)
                        {
                            int count2 = 2;
                            bool notfind = true;
                            while (notfind)
                            {
                                if (Items[count, count2] == ";")
                                {
                                    Items[count, count2] = comboBox1.Text;
                                    Items[count, count2 + 1] = ";";
                                    notfind = false;
                                }
                                ++count2;
                            }
                        }
                        ++count;
                    }
                    //イベントファイルにItemsを書き込み
                    //区切り文字は"/"である
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
                        FileName,
                        false,
                        System.Text.Encoding.GetEncoding("shift_jis"));
                    count = 0;
                    while (Items[count, 0] != null && Items[count, 0] != "")
                    {
                        int count1 = 0;
                        while (Items[count, count1] != ";")
                        {
                            sw.Write(Items[count, count1] + "/");
                            ++count1;
                        }
                        sw.WriteLine(";");
                        ++count;
                    }
                    sw.Close();
                }
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listbox値変更時
            string targetEve = listBox1.SelectedItem.ToString();
            System.IO.StreamReader sr1 = new System.IO.StreamReader(
                System.IO.Directory.GetCurrentDirectory() + @"\AppData\GUImaker\" + Hensu.EventControleKinde + @".txt",
                System.Text.Encoding.GetEncoding("shift_jis"));
            string[] adds = sr1.ReadLine().Split(',');
            comboBox1.Items.AddRange(adds);
            sr1.Close();
            int ExNum = Array.IndexOf(adds, targetEve);
            textBox1.Text = Hensu.Ex[ExNum];
            azukiControl1.Text = "private void "+Hensu.EventControleName+"_"+targetEve+"(object sender, EventArgs e)\n{\n        \n        \n}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(azukiControl1.Text);
        }
    }
}
