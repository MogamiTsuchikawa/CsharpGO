using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Interop;
using ClosedXML.Excel;

namespace MainEditor
{
    /// <summary>
    /// NewProject.xaml の相互作用ロジック
    /// </summary>
    public partial class NewProject : Window
    {
        public NewProject()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            
            string Path = "";
            if (Desktop.IsChecked == true) Path = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (Doc.IsChecked == true) Path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //if (Nini.IsChecked == true) Path = textBox2.Text;
            if (Path == "")
            {
                //
                MessageBox.Show("選択してください");
            }
            else
            {
                if(Forms.IsChecked == true)
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
                    prof.WriteLine("kind:forms");
                    prof.Close();
                    Hensu.RunHikisu = Path + @"\" + textBox1.Text + @"\ProjectInfo.projectt";
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
                    System.IO.StreamReader sr = new System.IO.StreamReader(
                        @"AppData\res\form\main.cs",
                        System.Text.Encoding.GetEncoding("shift_jis"));
                    //内容をすべて読み込む
                    string s = sr.ReadToEnd();
                    //閉じる
                    sr.Close();
                    mainCS.WriteLine(s);

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
                    System.IO.StreamReader sr1 = new System.IO.StreamReader(
                        @"AppData\res\form\form1.cs",
                        System.Text.Encoding.GetEncoding("shift_jis"));
                    //内容をすべて読み込む
                    string s1 = sr1.ReadToEnd();
                    //閉じる
                    sr1.Close();
                    sw.WriteLine(s1);
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
                if(Console.IsChecked == true)
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
                    prof.WriteLine("kind:console");
                    prof.Close();
                    Hensu.RunHikisu = Path + @"\" + textBox1.Text + @"\ProjectInfo.projectt";
                    System.IO.StreamWriter mainCS = new System.IO.StreamWriter(
                        Path + @"\" + textBox1.Text + @"\source\main.cs",
                        false,
                        System.Text.Encoding.GetEncoding("shift_jis"));
                    mainCS.WriteLine("using System;");
                    mainCS.WriteLine("namespace " + textBox1.Text);
                    mainCS.WriteLine("{");
                    mainCS.WriteLine("\tstatic class main");
                    mainCS.WriteLine("\t{");
                    mainCS.WriteLine("\t\t[STAThread]");
                    mainCS.WriteLine("\t\tstatic void Main()");
                    mainCS.WriteLine("\t\t{");
                    mainCS.WriteLine("\t\t\t");
                    mainCS.WriteLine("\t\t}");
                    mainCS.WriteLine("\t}");
                    mainCS.WriteLine("}");
                    mainCS.Close();
                }
                if(WPF.IsChecked == true)
                {
                    //MessageBox.Show("WPFはまだ実装されていません。代わりにFormsアプリケーションを生成します。");
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
                    prof.WriteLine("kind:wpf");
                    prof.Close();
                    Hensu.RunHikisu = Path + @"\" + textBox1.Text + @"\ProjectInfo.projectt";
                    System.IO.StreamWriter appF = new System.IO.StreamWriter(
                        Path + @"\" + textBox1.Text + @"\source\app.xaml",
                        false,
                        System.Text.Encoding.GetEncoding("shift_jis"));
                    appF.WriteLine(@"<Application x:Class="""+textBox1.Text+@".App""");
                    appF.WriteLine("\t\t" + @"xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""");
                    appF.WriteLine("\t\t" + @"xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""");
                    appF.WriteLine("\t\t" + @"xmlns:local=""clr -namespace:" +textBox1.Text+@"""");
                    appF.WriteLine("\t\t" + @"StartupUri=""MainWindow.xaml"">");
                    appF.WriteLine("\t" + @"<Application.Resources>");
                    appF.WriteLine("\t" + @"</Application.Resources>");
                    appF.WriteLine(@"</Application>");
                    appF.Close();
                    System.IO.StreamWriter MainW = new System.IO.StreamWriter(
                        Path + @"\" + textBox1.Text + @"\source\MainWindow.xaml",
                        false,
                        System.Text.Encoding.GetEncoding("shift_jis"));
                    MainW.WriteLine(@"<Window x:Class="""+textBox1.Text+@".MainWindow""");
                    MainW.WriteLine("\t\t" + @"xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""");
                    MainW.WriteLine("\t\t" + @"xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""");
                    MainW.WriteLine("\t\t" + @"xmlns:d=""http://schemas.microsoft.com/expression/blend/2008""");
                    MainW.WriteLine("\t\t" + @"xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""");
                    MainW.WriteLine("\t\t" + @"xmlns:local=""clr-namespace:""" + textBox1.Text+@"""");
                    MainW.WriteLine("\t\t" + @"mc:Ignorable=""d""");
                    MainW.WriteLine("\t\t" + @"Title=""MainWindow"" Height=""350"" Width=""525"">");
                    MainW.WriteLine("\t" + @"<Grid>");
                    MainW.WriteLine("\t\t" );
                    MainW.WriteLine("\t" + @"</Grid>");
                    MainW.WriteLine( @"</Window>");
                    MainW.WriteLine( @"");
                    MainW.Close();
                    System.IO.StreamWriter mainCS = new System.IO.StreamWriter(
                        Path + @"\" + textBox1.Text + @"\source\main.cs",
                        false,
                        System.Text.Encoding.GetEncoding("shift_jis"));
                    mainCS.WriteLine("using System;");
                    mainCS.WriteLine("namespace " + textBox1.Text);
                    mainCS.WriteLine("{");
                    mainCS.WriteLine("\tstatic class main");
                    mainCS.WriteLine("\t{");
                    mainCS.WriteLine("\t\t");
                    mainCS.WriteLine("\t}");
                    mainCS.WriteLine("}");
                    mainCS.Close();


                }
                if (IotA.IsChecked == true)
                {

                }


            }

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Desktop.IsChecked = true;
        }

        
    }
}
