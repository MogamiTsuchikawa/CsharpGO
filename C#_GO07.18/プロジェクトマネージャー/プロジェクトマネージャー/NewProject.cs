using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace プロジェクトマネージャー
{
    public partial class NewProject : Form
    {
        public NewProject()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            radioButton1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Path = "";
            if (radioButton1.Checked) Path = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (radioButton2.Checked) Path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (radioButton3.Checked) Path = textBox2.Text;
            if (Path == "")
            {
                //
                MessageBox.Show("選択してください");
            }
            else
            {
                System.IO.DirectoryInfo di =
    System.IO.Directory.CreateDirectory(Path + @"\" + textBox1.Text + @"\source");
                System.IO.DirectoryInfo di1 =
        System.IO.Directory.CreateDirectory(Path + @"\" + textBox1.Text + @"\build");
                System.IO.StreamWriter prof = new System.IO.StreamWriter(
                    Path + @"\" + textBox1.Text + @"\ProjectInfo.projectt",
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                prof.WriteLine("/////決してこのファイルを編集しないでください/////");
                prof.WriteLine(textBox1.Text);
                prof.Close();
                Hensu.ProjjectFilePath = Path + @"\" + textBox1.Text + @"\ProjectInfo.projectt";
                System.IO.StreamWriter mainCS = new System.IO.StreamWriter(
                    Path + @"\" + textBox1.Text + @"\source\main.cs",
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                mainCS.WriteLine("using System;");
                mainCS.WriteLine("using System.CodeDom;");
                mainCS.WriteLine("using System.CodeDom.Compiler;");
                mainCS.WriteLine("using System.Reflection;");
                mainCS.WriteLine("using System.Windows.Forms;");
                mainCS.WriteLine("using System.Drawing;");
                mainCS.WriteLine("namespace " + textBox1.Text);
                mainCS.WriteLine("{");
                mainCS.WriteLine("        static class main");
                mainCS.WriteLine("        {");
                mainCS.WriteLine("                [STAThread]");
                mainCS.WriteLine("                static void Main()");
                mainCS.WriteLine("                {");
                mainCS.WriteLine("                        Application.EnableVisualStyles();");
                mainCS.WriteLine("                        Application.SetCompatibleTextRenderingDefault(false);");
                mainCS.WriteLine("                        Application.Run(new Form1());");
                mainCS.WriteLine("                }");
                mainCS.WriteLine("        }");
                mainCS.WriteLine("}");
                mainCS.Close();


                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                        Path + @"\" + textBox1.Text + @"\source\Form1.cs",
                        false,
                        System.Text.Encoding.GetEncoding("shift_jis"));
                sw.WriteLine("using System;");
                sw.WriteLine("using System.CodeDom;");
                sw.WriteLine("using System.CodeDom.Compiler;");
                sw.WriteLine("using System.Reflection;");
                sw.WriteLine("using System.Windows.Forms;");
                sw.WriteLine("using System.Drawing;");
                sw.WriteLine("namespace " + textBox1.Text);
                sw.WriteLine("{");
                sw.WriteLine("        public partial class Form1 : Form");
                sw.WriteLine("        {");
                sw.WriteLine("                public Form1(){");
                sw.WriteLine("                InitializeComponent();");
                sw.WriteLine("                ");
                sw.WriteLine("                }");
                sw.WriteLine("        }");
                sw.WriteLine("}");
                //閉じる
                sw.Close();
                //guidate
                var guiBook = new XLWorkbook();
                var guiDate = guiBook.AddWorksheet("guiDate");
                guiDate.Cell(1, 1).Value = "Form";
                guiDate.Cell(1, 2).Value = "Form1";
                guiDate.Cell(1, 3).Value = "Size";
                guiDate.Cell(1, 4).Value = "200:300";
                guiBook.SaveAs(Path + @"\" + textBox1.Text + @"\source\Form1.xlsx");
                //event
                System.IO.StreamWriter sw2 = new System.IO.StreamWriter(
                    Path + @"\" + textBox1.Text + @"\source\Form1.eve",
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                sw2.WriteLine("Form/Form1/;");
                sw2.Close();
            

            }
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //その他の場合のフォルダ選択

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
                textBox2.Text=fbd.SelectedPath;
            }
        }
    }
}
