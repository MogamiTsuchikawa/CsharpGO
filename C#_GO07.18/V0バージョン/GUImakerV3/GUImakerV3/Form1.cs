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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1000;

            //Load[.guit]
            int Controles = 0;
            //各要素個数調べ
            String TargetControle = "Form";
            
                //内容を一行ずつ読み込む
                System.IO.StreamReader fr = new System.IO.StreamReader(
                Hensu.RunHikisu,
                System.Text.Encoding.GetEncoding("shift_jis"));
                while (fr.Peek() > -1)
                {
                    String Vline = fr.ReadLine();
                    String[] VItems = Vline.Split('/');

                    switch (VItems[0])
                    {
                        case "Button":
                            Hensu.ButtonV = Hensu.ButtonV + 1;
                            break;
                        case "TextBox":
                            Hensu.TextBoxV = Hensu.TextBoxV + 1;
                            break;
                        case "CheckBox":
                            Hensu.CheckBoxV = Hensu.CheckBoxV + 1;
                            break;
                        case "ComboBox":
                            Hensu.ComboBoxV = Hensu.ComboBoxV + 1;
                            break;
                        case "Label":
                            Hensu.LabelV = Hensu.LabelV + 1;
                            break;
                        case "ListBox":
                            Hensu.ListBoxV = Hensu.ListBoxV + 1;
                            break;
                        case "MenuStrip":
                            Hensu.MenuStripV = Hensu.MenuStripV + 1;
                            break;
                        case "PictureBox":
                            Hensu.PictureBoxV = Hensu.PictureBoxV + 1;
                            break;
                        case "ProgressBar":
                            Hensu.ProgressBarV = Hensu.ProgressBarV + 1;
                            break;
                        case "RadioButton":
                            Hensu.RadioButtonV = Hensu.RadioButtonV + 1;
                            break;
                        case "RichTextBox":
                            Hensu.RichTextBoxV = Hensu.RichTextBoxV + 1;
                            break;
                    }
                }
                fr.Close();
                

            
            TargetControle = "Form";
            while (TargetControle != "END")
            {
                //内容を一行ずつ読み込む
                System.IO.StreamReader fsr = new System.IO.StreamReader(
                Hensu.RunHikisu,
                System.Text.Encoding.GetEncoding("shift_jis"));
                while (fsr.Peek() > -1)
                {

                    String line = fsr.ReadLine();
                    String[] Items = line.Split('/');
                    //MessageBox.Show(Items[0]);
                    if (Items[0] == TargetControle)
                    {
                        switch (Items[0])
                        {
                            case "Form":
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "Button":
                                
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "TextBox":
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "CheckBox":
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "ComboBox":
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "Label":
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "ListBox":
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "MenuStrip":
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "PictureBox":
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "ProgressBar":
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "RadioButton":
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                            case "RichTextBox":
                                
                                Hensu.Dates[Controles, 0] = Items[0];
                                Hensu.Dates[Controles, 1] = Items[1];
                                Hensu.Dates[Controles, 2] = Items[2];
                                Hensu.Dates[Controles, 3] = Items[3];
                                Hensu.Dates[Controles, 4] = Items[4];
                                Hensu.Dates[Controles, 5] = Items[5];
                                Hensu.Dates[Controles, 6] = Items[6];
                                Hensu.Dates[Controles, 7] = Items[7];
                                Hensu.Dates[Controles, 8] = Items[8];
                                Controles = Controles + 1;
                                break;
                        }
                    }


                }
                fsr.Close();
                //次のターゲットに変更
                switch (TargetControle)
                {
                    case "Form":
                        TargetControle = "Button";
                        break;
                    case "Button":
                        TargetControle = "TextBox";
                        break;
                    case "TextBox":
                        TargetControle = "CheckBox";
                        break;
                    case "CheckBox":
                        TargetControle = "ComboBox";
                        break;
                    case "ComboBox":
                        TargetControle = "Label";
                        break;
                    case "Label":
                        TargetControle = "ListBox";
                        break;
                    case "ListBox":
                        TargetControle = "MenuStrip";
                        break;
                    case "MenuStrip":
                        TargetControle = "PictureBox";
                        break;
                    case "PictureBox":
                        TargetControle = "ProgressBar";
                        break;
                    case "ProgressBar":
                        TargetControle = "RadioButton";
                        break;
                    case "RadioButton":
                        TargetControle = "RichTextBox";
                        break;
                    case "RichTextBox":
                        TargetControle = "END";
                        break;
                }
                if (TargetControle != "END")
                {

                }
            }

            /////////
            Form2 f = new Form2();
            f.MdiParent = this;
            


            f.Show();
            f.Top = 0;
            f.Left = 186;

        }

        
        public void ChangeDate()
        {

            label3.Text = Hensu.Dates[Hensu.SelectControleNumber, 0];
            label4.Text = Hensu.Dates[Hensu.SelectControleNumber, 1];
            textBox1.Text = Hensu.Dates[Hensu.SelectControleNumber, 2];
            textBox2.Text = Hensu.Dates[Hensu.SelectControleNumber, 3];
            textBox3.Text = Hensu.Dates[Hensu.SelectControleNumber, 4];
            textBox4.Text = Hensu.Dates[Hensu.SelectControleNumber, 5];
            textBox5.Text = Hensu.Dates[Hensu.SelectControleNumber, 6];
            textBox6.Text = Hensu.Dates[Hensu.SelectControleNumber, 7];
            textBox7.Text = Hensu.Dates[Hensu.SelectControleNumber, 8];
            textBox8.Text = Hensu.Dates[Hensu.SelectControleNumber, 9];
            textBox9.Text = Hensu.Dates[Hensu.SelectControleNumber, 10];
            textBox10.Text = Hensu.Dates[Hensu.SelectControleNumber, 11];
            textBox11.Text = Hensu.Dates[Hensu.SelectControleNumber, 12];
            textBox12.Text = Hensu.Dates[Hensu.SelectControleNumber, 13];
            textBox13.Text = Hensu.Dates[Hensu.SelectControleNumber, 14];
            //textBox14.Text = Items[15];
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Hensu.ControleMove)
            {
                Hensu.ControleMove = false;
            }
            else
            {
                Hensu.ControleMove = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Hensu.Dates[Hensu.SelectControleNumber, 2] = textBox1.Text;
                Form[] hMdiChildren = this.MdiChildren;
                // すべての MDI 子フォームを閉じる
                foreach (Form hMdiChild in hMdiChildren)
                {
                    hMdiChild.Close();
                    hMdiChild.Dispose();
                }
                Form2 f = new Form2();
                f.MdiParent = this;
                f.Show();
                f.Top = 0;
                f.Left = 186;
            }
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hensu.Dates[Hensu.SelectControleNumber, 3] = textBox2.Text;
                Form[] hMdiChildren = this.MdiChildren;
                // すべての MDI 子フォームを閉じる
                foreach (Form hMdiChild in hMdiChildren)
                {
                    hMdiChild.Close();
                    hMdiChild.Dispose();
                }
                Form2 f = new Form2();
                f.MdiParent = this;
                f.Show();
                f.Top = 0;
                f.Left = 186;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hensu.Dates[Hensu.SelectControleNumber, 4] = textBox3.Text;
                Form[] hMdiChildren = this.MdiChildren;
                // すべての MDI 子フォームを閉じる
                foreach (Form hMdiChild in hMdiChildren)
                {
                    hMdiChild.Close();
                    hMdiChild.Dispose();
                }
                Form2 f = new Form2();
                f.MdiParent = this;
                f.Show();
                f.Top = 0;
                f.Left = 186;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hensu.Dates[Hensu.SelectControleNumber, 5] = textBox4.Text;
                Form[] hMdiChildren = this.MdiChildren;
                // すべての MDI 子フォームを閉じる
                foreach (Form hMdiChild in hMdiChildren)
                {
                    hMdiChild.Close();
                    hMdiChild.Dispose();
                }
                Form2 f = new Form2();
                f.MdiParent = this;
                f.Show();
                f.Top = 0;
                f.Left = 186;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hensu.Dates[Hensu.SelectControleNumber, 6] = textBox5.Text;
                Form[] hMdiChildren = this.MdiChildren;
                // すべての MDI 子フォームを閉じる
                foreach (Form hMdiChild in hMdiChildren)
                {
                    hMdiChild.Close();
                    hMdiChild.Dispose();
                }
                Form2 f = new Form2();
                f.MdiParent = this;
                f.Show();
                f.Top = 0;
                f.Left = 186;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hensu.Dates[Hensu.SelectControleNumber, 7] = textBox6.Text;
                Form[] hMdiChildren = this.MdiChildren;
                // すべての MDI 子フォームを閉じる
                foreach (Form hMdiChild in hMdiChildren)
                {
                    hMdiChild.Close();
                    hMdiChild.Dispose();
                }
                Form2 f = new Form2();
                f.MdiParent = this;
                f.Show();
                f.Top = 0;
                f.Left = 186;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hensu.Dates[Hensu.SelectControleNumber, 8] = textBox7.Text;
                Form[] hMdiChildren = this.MdiChildren;
                // すべての MDI 子フォームを閉じる
                foreach (Form hMdiChild in hMdiChildren)
                {
                    hMdiChild.Close();
                    hMdiChild.Dispose();
                }
                Form2 f = new Form2();
                f.MdiParent = this;
                f.Show();
                f.Top = 0;
                f.Left = 186;
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hensu.Dates[Hensu.SelectControleNumber, 9] = textBox8.Text;
                Form[] hMdiChildren = this.MdiChildren;
                // すべての MDI 子フォームを閉じる
                foreach (Form hMdiChild in hMdiChildren)
                {
                    hMdiChild.Close();
                    hMdiChild.Dispose();
                }
                Form2 f = new Form2();
                f.MdiParent = this;
                f.Show();
                f.Top = 0;
                f.Left = 186;
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hensu.Dates[Hensu.SelectControleNumber, 10] = textBox9.Text;
                Form[] hMdiChildren = this.MdiChildren;
                // すべての MDI 子フォームを閉じる
                foreach (Form hMdiChild in hMdiChildren)
                {
                    hMdiChild.Close();
                    hMdiChild.Dispose();
                }
                Form2 f = new Form2();
                f.MdiParent = this;
                f.Show();
                f.Top = 0;
                f.Left = 186;
            }
        }
        //ここからは未使用
        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    Hensu.Dates[Hensu.SelectControleNumber, 11] = textBox10.Text;
            //}
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    Hensu.Dates[Hensu.SelectControleNumber, 12] = textBox11.Text;
            //}
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    Hensu.Dates[Hensu.SelectControleNumber, 13] = textBox12.Text;
            //}
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    Hensu.Dates[Hensu.SelectControleNumber, 14] = textBox13.Text;
            //}
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    Hensu.Dates[Hensu.SelectControleNumber, 15] = textBox14.Text;
            //}
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                Hensu.RunHikisu,
                false,
                System.Text.Encoding.GetEncoding("shift_jis"));
            int Num = 0;
            while (Hensu.Dates[Num, 0] != null)
            {
                sw.WriteLine(Hensu.Dates[Num, 0]+"/"+ Hensu.Dates[Num, 1]+"/"+ Hensu.Dates[Num, 2] + "/" + Hensu.Dates[Num, 3] + "/" + Hensu.Dates[Num, 4] + "/" + Hensu.Dates[Num, 5] + "/" + Hensu.Dates[Num, 6] + "/" + Hensu.Dates[Num,7] + "/" + Hensu.Dates[Num, 8] + "/" + Hensu.Dates[Num, 9]+"/");
                Num = Num + 1;
            }
            sw.Close();
            MessageBox.Show("保存完了");
        }

        private void 新規コントロールToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddControles f = new AddControles();
            f.ShowDialog(this);
            f.Dispose();
            if (Hensu.NewControleTF)
            {
                int AllCtrl = Hensu.ButtonV + Hensu.TextBoxV + Hensu.CheckBoxV + Hensu.ComboBoxV + Hensu.LabelV + Hensu.ListBoxV + Hensu.MenuStripV + Hensu.PictureBoxV + Hensu.ProgressBarV + Hensu.RadioButtonV + Hensu.RichTextBoxV+1;
                switch (Hensu.NewControleKind)
                {
                    case "Button":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "";
                        Hensu.Dates[AllCtrl, 5] = "";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "12";
                        Hensu.Dates[AllCtrl, 8] = "Arial";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.ButtonV;
                        break;
                    case "TextBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "";
                        Hensu.Dates[AllCtrl, 5] = "";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "";
                        Hensu.Dates[AllCtrl, 8] = "";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.TextBoxV;
                        break;
                    case "CheckBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "";
                        Hensu.Dates[AllCtrl, 5] = "";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "";
                        Hensu.Dates[AllCtrl, 8] = "";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.CheckBoxV;
                        break;
                    case "ComboBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "";
                        Hensu.Dates[AllCtrl, 5] = "";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "";
                        Hensu.Dates[AllCtrl, 8] = "";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.ComboBoxV;
                        break;
                    case "Label":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "";
                        Hensu.Dates[AllCtrl, 5] = "";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "";
                        Hensu.Dates[AllCtrl, 8] = "";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.LabelV;
                        break;
                    case "ListBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "10";
                        Hensu.Dates[AllCtrl, 5] = "10";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "";
                        Hensu.Dates[AllCtrl, 8] = "";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.ListBoxV;
                        break;
                    case "MenuStrip":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "";
                        Hensu.Dates[AllCtrl, 5] = "";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "";
                        Hensu.Dates[AllCtrl, 8] = "";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.MenuStripV;
                        break;
                    case "PictureBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "10";
                        Hensu.Dates[AllCtrl, 5] = "10";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "";
                        Hensu.Dates[AllCtrl, 8] = "";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.PictureBoxV;
                        break;
                    case "ProgressBar":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "10";
                        Hensu.Dates[AllCtrl, 5] = "50";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "";
                        Hensu.Dates[AllCtrl, 8] = "";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.ProgressBarV;
                        break;
                    case "RadioButton":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "";
                        Hensu.Dates[AllCtrl, 5] = "";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "";
                        Hensu.Dates[AllCtrl, 8] = "";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.RadioButtonV;
                        break;
                    case "RichTextBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 2] = "0";
                        Hensu.Dates[AllCtrl, 3] = "0";
                        Hensu.Dates[AllCtrl, 4] = "10";
                        Hensu.Dates[AllCtrl, 5] = "10";
                        Hensu.Dates[AllCtrl, 6] = Hensu.NewControleName;
                        Hensu.Dates[AllCtrl, 7] = "";
                        Hensu.Dates[AllCtrl, 8] = "";
                        Hensu.Dates[AllCtrl, 9] = "";
                        ++Hensu.RichTextBoxV;
                        break;

                }
                Form[] hMdiChildren = this.MdiChildren;
                // すべての MDI 子フォームを閉じる
                foreach (Form hMdiChild in hMdiChildren)
                {
                    hMdiChild.Close();
                    hMdiChild.Dispose();
                }
                Form2 ff = new Form2();
                ff.MdiParent = this;
                ff.Show();
                ff.Top = 0;
                ff.Left = 186;
                string FileName = System.IO.Path.GetDirectoryName(Hensu.RunHikisu) + @"\"
                    + System.IO.Path.GetFileNameWithoutExtension(Hensu.RunHikisu) + @".eve";
                System.IO.StreamReader sr = new System.IO.StreamReader(
                        FileName,
                        System.Text.Encoding.GetEncoding("shift_jis"));
                string keep = sr.ReadToEnd();
                keep = keep + Hensu.NewControleKind + "/" + Hensu.NewControleName + "/;";
                sr.Close();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
    FileName,
    false,
    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                sw.Write(keep);
                //閉じる
                sw.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Null")
            {
                MessageBox.Show("コントロールが選択されていません","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }else
            {
                //イベント設定ウインドウ
                Hensu.EventControleKinde = label3.Text;
                Hensu.EventControleName = label4.Text;
                AddEvents f = new AddEvents();
                f.ShowDialog(this);
                f.Dispose();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hensu.SelectControleNumber = 0;
            ChangeDate();
        }
    }
}
