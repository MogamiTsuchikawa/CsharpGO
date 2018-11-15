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
    public partial class Project設定 : Form
    {
        public Project設定()
        {
            InitializeComponent();
        }

        private void Project設定_Load(object sender, EventArgs e)
        {
            label2.Text = Hensu.ProjectName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //保存して終了
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //保存しないで終了
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
