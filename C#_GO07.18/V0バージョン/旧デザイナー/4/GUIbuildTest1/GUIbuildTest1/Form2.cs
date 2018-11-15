using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIbuildTest1
{
    public partial class Form2 : Form
    {
        
        private Button[] buttons;
        private TextBox[] textboxs;
        private CheckBox[] checkboxs;
        private ComboBox[] comboboxs;
        private Label[] labels;
        private ListBox[] listboxs;
        private MenuStrip[] menustrips;
        private PictureBox[] pictureboxs;
        private ProgressBar[] progressbars;
        private RadioButton[] radiobuttons;
        private RichTextBox[] richtextboxs;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //それぞれのコントロールのデータを配列から取得し、表示していく

            //Message.Show(Form2.ButtonDate);
            int ButtonVV = 0,TextBoxVV = 0,CheckBoxVV=0,ComboBoxVV =0,LabelVV=0,ListBoxVV=0,MenuStripVV =0,PictureBoxVV=0,ProgressBarVV=0,RadioButtonVV=0,RichTextBoxVV=0;

            this.buttons = new Button[Hensu.ButtonV];
            this.textboxs = new TextBox[Hensu.TextBoxV];
            this.checkboxs = new CheckBox[Hensu.CheckBoxV];
            this.comboboxs = new ComboBox[Hensu.ComboBoxV];
            this.labels = new Label[Hensu.LabelV];
            this.listboxs = new ListBox[Hensu.ListBoxV];
            this.menustrips = new MenuStrip[Hensu.MenuStripV];
            this.pictureboxs = new PictureBox[Hensu.PictureBoxV];
            this.progressbars = new ProgressBar[Hensu.ProgressBarV];
            this.radiobuttons = new RadioButton[Hensu.RadioButtonV];
            this.richtextboxs = new RichTextBox[Hensu.RichTextBoxV];
            String TargetControle = "Form";
            



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
                                this.Height = int.Parse(Items[4]);
                                this.Width = int.Parse(Items[5]);
                                break;
                            case "Button":
                                this.buttons[ButtonVV] = new Button(); 
                                this.buttons[ButtonVV].Name = Items[1];
                                this.buttons[ButtonVV].Text = Items[6];
                                if (Items[2] == "") {
                                    MessageBox.Show(Items[1]+"のX軸が設定されていません");
                                }else
                                {
                                    if (Items[3] == "")
                                    {
                                        MessageBox.Show(Items[1] + "のY軸が設定されていません");
                                    }else
                                    {
                                        this.buttons[ButtonVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));
                                    }
                                }
                                


                                this.Controls.Add(this.buttons[ButtonVV]);
                                ButtonVV = ButtonVV + 1;
                                break;
                            case "TextBox":
                                this.textboxs[TextBoxVV] = new TextBox();
                                this.textboxs[TextBoxVV].Name = Items[1];
                                this.textboxs[TextBoxVV].Text = Items[6];
                                this.textboxs[TextBoxVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.textboxs[TextBoxVV]);
                                TextBoxVV = TextBoxVV + 1;
                                break;
                            case "CheckBox":
                                this.checkboxs[CheckBoxVV] = new CheckBox();
                                this.checkboxs[CheckBoxVV].Name = Items[1];
                                this.checkboxs[CheckBoxVV].Text = Items[6];
                                this.checkboxs[CheckBoxVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.checkboxs[CheckBoxVV]);
                                CheckBoxVV = CheckBoxVV + 1;
                                break;
                            case "ComboBox":
                                this.comboboxs[ComboBoxVV] = new ComboBox();
                                this.comboboxs[ComboBoxVV].Name = Items[1];
                                this.comboboxs[ComboBoxVV].Text = Items[6];
                                this.comboboxs[ComboBoxVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.comboboxs[ComboBoxVV]);
                                ComboBoxVV = ComboBoxVV + 1;
                                break;
                            case "Label":
                                this.labels[LabelVV] = new Label();
                                this.labels[LabelVV].Name = Items[1];
                                this.labels[LabelVV].Text = Items[6];
                                this.labels[LabelVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.labels[LabelVV]);
                                LabelVV = LabelVV + 1;
                                break;
                            case "ListBox":
                                this.listboxs[ListBoxVV] = new ListBox();
                                this.listboxs[ListBoxVV].Name = Items[1];
                                this.listboxs[ListBoxVV].Text = Items[6];
                                this.listboxs[ListBoxVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.listboxs[ListBoxVV]);
                                ListBoxVV = ListBoxVV + 1;
                                break;
                            case "MenuStrip":
                                this.menustrips[MenuStripVV] = new MenuStrip();
                                this.menustrips[MenuStripVV].Name = Items[1];
                                this.menustrips[MenuStripVV].Text = Items[6];
                                //this.menustrips[MenuStripVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.menustrips[MenuStripVV]);
                                MenuStripVV = MenuStripVV + 1;
                                break;
                            case "PictureBox":
                                this.pictureboxs[PictureBoxVV] = new PictureBox();
                                this.pictureboxs[PictureBoxVV].Name = Items[1];
                                this.pictureboxs[PictureBoxVV].Text = Items[6];
                                this.pictureboxs[PictureBoxVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.pictureboxs[PictureBoxVV]);
                                PictureBoxVV = PictureBoxVV + 1;
                                break;
                            case "ProgressBar":
                                this.progressbars[ProgressBarVV] = new ProgressBar();
                                this.progressbars[ProgressBarVV].Name = Items[1];
                                this.progressbars[ProgressBarVV].Text = Items[6];
                                this.progressbars[ProgressBarVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.progressbars[ProgressBarVV]);
                                ProgressBarVV = ProgressBarVV + 1;
                                break;
                            case "RadioButton":
                                this.radiobuttons[RadioButtonVV] = new RadioButton();
                                this.radiobuttons[RadioButtonVV].Name = Items[1];
                                this.radiobuttons[RadioButtonVV].Text = Items[6];
                                this.radiobuttons[RadioButtonVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.radiobuttons[RadioButtonVV]);
                                RadioButtonVV = RadioButtonVV + 1;
                                break;
                            case "RichTextBox":
                                this.richtextboxs[RichTextBoxVV] = new RichTextBox();
                                this.richtextboxs[RichTextBoxVV].Name = Items[1];
                                this.richtextboxs[RichTextBoxVV].Text = Items[6];
                                this.richtextboxs[RichTextBoxVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.richtextboxs[RichTextBoxVV]);
                                RichTextBoxVV = RichTextBoxVV + 1;
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

        }
    }
}
