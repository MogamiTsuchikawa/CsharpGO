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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\" + textBox1.Text+".cs",
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
                sw.WriteLine("                ");
                sw.WriteLine("                ");
                sw.WriteLine("                }");
                sw.WriteLine("        }");
                sw.WriteLine("}");
                //閉じる
                sw.Close();
                System.IO.StreamWriter sw1 = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\" + textBox1.Text + ".guit",
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                sw1.WriteLine("Form/"+textBox1.Text+"///200/200/////");
                sw1.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("正しい値を入力してください。","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
