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
    public partial class AddControles : Form
    {
        public AddControles()
        {
            InitializeComponent();
        }

        private void AddControles_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Button");
            comboBox1.Items.Add("TextBox");
            comboBox1.Items.Add("CheckBox");
            comboBox1.Items.Add("ComboBox");
            comboBox1.Items.Add("Label");
            comboBox1.Items.Add("ListBox");
            comboBox1.Items.Add("MenuStrip");
            comboBox1.Items.Add("PictureBox");
            comboBox1.Items.Add("ProgressBar");
            comboBox1.Items.Add("RadioButton");
            comboBox1.Items.Add("RichTextBox");


        }
        static int SearchControleNum(string name)
        {
            int CtrlNum = 0;
            while (Hensu.Dates[CtrlNum, 1] != name)
            {
                CtrlNum = CtrlNum + 1;
                //Debug.WriteLine(Hensu.Dates[CtrlNum, 1]);
                if (CtrlNum == 99999)
                {
                    CtrlNum = -1;
                    break;
                }
            }

            return CtrlNum;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("コントロールの種類が選択されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("コントロールの名前が入力されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //既存のコントロールと名称が被っていないかをチェック
                    if (SearchControleNum(textBox1.Text) == -1)
                    {
                        //OK
                        Hensu.NewControleKind = comboBox1.Text;
                        Hensu.NewControleName = textBox1.Text;
                        Hensu.NewControleTF = true;
                        this.Close();
                    }else
                    {
                        MessageBox.Show("そのコントロールの名前はすでに使われています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    
                }
            }
        }
    }
}
