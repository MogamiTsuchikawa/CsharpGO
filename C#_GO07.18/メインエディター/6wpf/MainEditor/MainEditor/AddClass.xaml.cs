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

namespace MainEditor
{
    /// <summary>
    /// AddClass.xaml の相互作用ロジック
    /// </summary>
    public partial class AddClass : Window
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "")
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\" + textBox.Text + ".cs",
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
                sw.WriteLine("        public partial class " + textBox.Text + "");
                sw.WriteLine("        {");

                sw.WriteLine("        }");
                sw.WriteLine("}");
                //閉じる
                sw.Close();

                this.Close();
            }
            else
            {
                MessageBox.Show("正しい値を入力してください。", "警告", MessageBoxButton.OK ,MessageBoxImage.Warning);
            }
        }
    }
}
