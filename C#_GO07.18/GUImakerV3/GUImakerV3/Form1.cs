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

            //Load[.guix]
            
            //各要素個数調べ
            String TargetControle = "Form";

            //内容を一行ずつ読み込む
            
            var workbook = new XLWorkbook(Hensu.RunHikisu);
            var guiDate = workbook.Worksheets.Worksheet("guiDate");
            int countX = 1, countY = 1;
            while (guiDate.Cell(countX,countY).Value.ToString()!="")
            {
                
                switch (guiDate.Cell(countX,1).Value.ToString())
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
                ++countX;
            }




            TargetControle = "Form";
            while (TargetControle != "END")
            {
                countX = 1;
                countY = 1;
                
                //内容を一行ずつ読み込む
                
                while (guiDate.Cell(countX,1).Value.ToString()!="")
                {

                    
                    //MessageBox.Show(Items[0]);
                    if (guiDate.Cell(countX,1).Value.ToString() == TargetControle)
                    {
                        switch (guiDate.Cell(countX, 1).Value.ToString())
                        {
                            case "Form":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                
                                break;
                            case "Button":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                            case "TextBox":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                            case "CheckBox":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                            case "ComboBox":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                            case "Label":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                            case "ListBox":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                            case "MenuStrip":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                            case "PictureBox":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                            case "ProgressBar":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                            case "RadioButton":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                            case "RichTextBox":
                                countY = 1;
                                while (guiDate.Cell(countX, countY).Value.ToString() != ""||guiDate.Cell(countX,countY+1).Value.ToString()!="")
                                {
                                    Hensu.Dates[countX - 1, countY - 1] = guiDate.Cell(countX, countY).Value.ToString();
                                    ++countY;
                                }
                                break;
                        }
                        
                    }
                    ++countX;


                }
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
            listBox1.Items.Clear();
            label3.Text = Hensu.Dates[Hensu.SelectControleNumber, 0];
            label4.Text = Hensu.Dates[Hensu.SelectControleNumber, 1];
            int i = 2;
            while (Hensu.Dates[Hensu.SelectControleNumber, i] != null)
            {
                listBox1.Items.Add(Hensu.Dates[Hensu.SelectControleNumber,i]);
                ++i;
                ++i;
            }
            
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
        

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var workbook = new XLWorkbook(Hensu.RunHikisu);
            var guiDate = workbook.Worksheets.Worksheet("guiDate");
            
            
            int Num = 0;
            int i = 0;
            while (Hensu.Dates[Num, 0] != null)
            {
                i = 0;
                while (Hensu.Dates[Num, i]!=null)
                {

                    guiDate.Cell(Num + 1, i + 1).SetDataType(XLCellValues.Text);
                    guiDate.Cell(Num + 1, i + 2).SetDataType(XLCellValues.Text);
                    guiDate.Cell(Num + 1, i + 1).Value = Hensu.Dates[Num, i];
                    guiDate.Cell(Num + 1, i + 2).Value = Hensu.Dates[Num, i + 1];
                    ++i;
                    ++i;
                }
                ++Num;
            }
            i = 0;
            while (Hensu.Dates[Num, i] != null)
            {

                guiDate.Cell(Num + 1, i + 1).SetDataType(XLCellValues.Text);
                guiDate.Cell(Num + 1, i + 2).SetDataType(XLCellValues.Text);
                guiDate.Cell(Num + 1, i + 1).Value = Hensu.Dates[Num, i];
                guiDate.Cell(Num + 1, i + 2).Value = Hensu.Dates[Num, i + 1];
                ++i;
                ++i;
            }
            workbook.Save();
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
                        ++Hensu.ButtonV;
                        break;
                    case "TextBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        ++Hensu.TextBoxV;
                        break;
                    case "CheckBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        ++Hensu.CheckBoxV;
                        break;
                    case "ComboBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        ++Hensu.ComboBoxV;
                        break;
                    case "Label":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        ++Hensu.LabelV;
                        break;
                    case "ListBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        ++Hensu.ListBoxV;
                        break;
                    case "MenuStrip":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        ++Hensu.MenuStripV;
                        break;
                    case "PictureBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        ++Hensu.PictureBoxV;
                        break;
                    case "ProgressBar":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        ++Hensu.ProgressBarV;
                        break;
                    case "RadioButton":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
                        ++Hensu.RadioButtonV;
                        break;
                    case "RichTextBox":
                        Hensu.Dates[AllCtrl, 0] = Hensu.NewControleKind;
                        Hensu.Dates[AllCtrl, 1] = Hensu.NewControleName;
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
                string FileName = "";
                if (Hensu.RunHikisu == "GUIcode.xlsx")
                {
                    FileName = "GUIcode.eve";
                } else
                {
                    FileName = System.IO.Path.GetDirectoryName(Hensu.RunHikisu) + @"\"
                        + System.IO.Path.GetFileNameWithoutExtension(Hensu.RunHikisu) + @".eve";
                }

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
                MessageBox.Show("コントロールが選択されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ValueKind = listBox1.Text;
            label5.Text = listBox1.Text;
            int i = 2;
            while (Hensu.Dates[Hensu.SelectControleNumber, i] != null)
            {
                if (Hensu.Dates[Hensu.SelectControleNumber, i] == ValueKind)
                {
                    textBox13.Text = Hensu.Dates[Hensu.SelectControleNumber, i + 1];
                }
                ++i;
                ++i;
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            //Value変更
            int i = 2;
            while (Hensu.Dates[Hensu.SelectControleNumber, i] != null)
            {
                if (Hensu.Dates[Hensu.SelectControleNumber, i] == label5.Text)
                {
                    Hensu.Dates[Hensu.SelectControleNumber, i + 1] = textBox13.Text;
                }
                
                ++i;
                ++i;
            }
            if (e.KeyCode == Keys.Enter)
            {
                
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

        private void button4_Click(object sender, EventArgs e)
        {
            
            //コントール設定追加
            AddControlesSetting ff = new AddControlesSetting();
            ff.ShowDialog(this);
            ff.Dispose();
            //
            //
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
            //
            //
            listBox1.Items.Clear();
            label3.Text = Hensu.Dates[Hensu.SelectControleNumber, 0];
            label4.Text = Hensu.Dates[Hensu.SelectControleNumber, 1];
            int i = 2;
            while (Hensu.Dates[Hensu.SelectControleNumber, i] != null)
            {
                listBox1.Items.Add(Hensu.Dates[Hensu.SelectControleNumber, i]);
                ++i;
                ++i;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectControleWindows f1 = new SelectControleWindows();
            f1.Owner = this;
            f1.ShowDialog(this);
            f1.Dispose();
        }
    }
}
