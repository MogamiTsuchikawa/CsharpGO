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
using ClosedXML.Excel;

namespace MainEditor
{
    /// <summary>
    /// AddForm.xaml の相互作用ロジック
    /// </summary>
    public partial class AddForm : Window
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\" + textBox1.Text + ".cs",
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                sw.WriteLine("using System;");
                sw.WriteLine("using System.CodeDom;");
                sw.WriteLine("using System.CodeDom.Compiler;");
                sw.WriteLine("using System.Reflection;");
                sw.WriteLine("using System.Windows.Forms;");
                sw.WriteLine("using System.Drawing;");
                sw.WriteLine("namespace " + Hensu.ProjectName);
                sw.WriteLine("{");
                sw.WriteLine("        public partial class " + textBox1.Text + " : Form");
                sw.WriteLine("        {");
                sw.WriteLine("                public " + textBox1.Text + "(){");
                sw.WriteLine("                InitializeComponent();");
                sw.WriteLine("                ");
                sw.WriteLine("                }");
                sw.WriteLine("        }");
                sw.WriteLine("}");
                //閉じる
                sw.Close();
                //.xlsx生成
                var guiBook = new XLWorkbook();
                var guiDate = guiBook.AddWorksheet("guiDate");
                guiDate.Cell(1, 1).Value = "Form";
                guiDate.Cell(1, 2).Value = textBox1.Text;
                guiDate.Cell(1, 3).Value = "Size";
                guiDate.Cell(1, 4).Value = "200:300";
                guiBook.SaveAs(Hensu.ProjectPath + @"\source\" + textBox1.Text + ".xlsx");
                //.eve作成
                System.IO.StreamWriter sw2 = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\" + textBox1.Text + ".eve",
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                sw2.WriteLine("Form/" + textBox1.Text + "/;");
                sw2.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("正しい値を入力してください。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
