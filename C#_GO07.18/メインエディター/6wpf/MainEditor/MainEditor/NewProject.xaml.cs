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
            if (Nini.IsChecked == true) Path = textBox2.Text;
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
                    mainCS.WriteLine("{");
                    mainCS.WriteLine("	static class main");
                    mainCS.WriteLine("  {");
                    mainCS.WriteLine("      [STAThread]");
                    mainCS.WriteLine("      static void Main()");
                    mainCS.WriteLine("      {");
                    mainCS.WriteLine("          Application.EnableVisualStyles();");
                    mainCS.WriteLine("          Application.SetCompatibleTextRenderingDefault(false);");
                    mainCS.WriteLine("          Application.Run(new Form1());");
                    mainCS.WriteLine("      }");
                    mainCS.WriteLine("  }");
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
                    sw.WriteLine("  public partial class Form1 : Form");
                    sw.WriteLine("  {");
                    sw.WriteLine("      public Form1(){");
                    sw.WriteLine("      InitializeComponent();");
                    sw.WriteLine("                ");
                    sw.WriteLine("      }");
                    sw.WriteLine("  }");
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
                    mainCS.WriteLine("  static class main");
                    mainCS.WriteLine("  {");
                    mainCS.WriteLine("      [STAThread]");
                    mainCS.WriteLine("      static void Main()");
                    mainCS.WriteLine("      {");
                    mainCS.WriteLine("          ");
                    mainCS.WriteLine("      }");
                    mainCS.WriteLine("  }");
                    mainCS.WriteLine("}");
                    mainCS.Close();
                }
                if(WPF.IsChecked == true)
                {
                    MessageBox.Show("WPFはまだ実装されていません。代わりにFormsアプリケーションを生成します。");
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
                    mainCS.WriteLine("{");
                    mainCS.WriteLine("  static class main");
                    mainCS.WriteLine("  {");
                    mainCS.WriteLine("      [STAThread]");
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


            }

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Desktop.IsChecked = true;
        }

        
    }
}
