using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainEditor
{
    public partial class AddClass : Form
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                sw.WriteLine("        public partial class " + textBox1.Text + "");
                sw.WriteLine("        {");
                
                sw.WriteLine("        }");
                sw.WriteLine("}");
                //閉じる
                sw.Close();
                
                this.Close();
            }
            else
            {
                MessageBox.Show("正しい値を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
