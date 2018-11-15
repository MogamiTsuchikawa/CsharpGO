using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUImakerV3
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
        //コントロールマウス移動用変数
        private Point mousePoint;
        static int SearchControleNum(string name)
        {
            int CtrlNum = 0;
            while (Hensu.Dates[CtrlNum, 1] != name)
            {
                CtrlNum = CtrlNum + 1;
                //Debug.WriteLine(Hensu.Dates[CtrlNum, 1]);
            }
            return CtrlNum;
        }

        private void FormClick(object sender, System.EventArgs e)
        {
            Form obj = (Form)sender;
            Hensu.SelectControleName = obj.Text;

            ((Form1)this.MdiParent).ChangeDate();

        }
        private void ButtonClick(object sender, System.EventArgs e)
        {
            Button obj = (Button)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            Hensu.SelectControleKinds = "Button";
            if (Hensu.ControleMove)
            {
                if (Hensu.ControleMove2)
                {
                    Hensu.ControleMove2 = false;

                }
                else
                {
                    //フォーム上の座標でマウスポインタの位置を取得する
                    //画面座標でマウスポインタの位置を取得する
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    //画面座標をクライアント座標に変換する

                    obj.Location = this.PointToClient(sp);
                    Hensu.ControleMove2 = true;
                }

            }
            else
            {
                ((Form1)this.MdiParent).ChangeDate();
            }

        }
        private void TextBoxClick(object sender, System.EventArgs e)
        {
            TextBox obj = (TextBox)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            Hensu.SelectControleKinds = "TextBox";
            if (Hensu.ControleMove)
            {
                if (Hensu.ControleMove2)
                {
                    Hensu.ControleMove2 = false;
                }
                else
                {
                    //フォーム上の座標でマウスポインタの位置を取得する
                    //画面座標でマウスポインタの位置を取得する
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    //画面座標をクライアント座標に変換する

                    obj.Location = this.PointToClient(sp);
                    Hensu.ControleMove2 = true;
                }

            }
            else
            {
                ((Form1)this.MdiParent).ChangeDate();
            }

        }
        private void CheckBoxClick(object sender, System.EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            Hensu.SelectControleKinds = "CheckBox";
            if (Hensu.ControleMove)
            {
                if (Hensu.ControleMove2)
                {
                    Hensu.ControleMove2 = false;
                }
                else
                {
                    //フォーム上の座標でマウスポインタの位置を取得する
                    //画面座標でマウスポインタの位置を取得する
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    //画面座標をクライアント座標に変換する

                    obj.Location = this.PointToClient(sp);
                    Hensu.ControleMove2 = true;
                }

            }
            else
            {
                ((Form1)this.MdiParent).ChangeDate();
            }

        }
        private void ComboBoxClick(object sender, System.EventArgs e)
        {
            ComboBox obj = (ComboBox)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            Hensu.SelectControleKinds = "ComboBox";
            if (Hensu.ControleMove)
            {
                if (Hensu.ControleMove2)
                {
                    Hensu.ControleMove2 = false;
                }
                else
                {
                    //フォーム上の座標でマウスポインタの位置を取得する
                    //画面座標でマウスポインタの位置を取得する
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    //画面座標をクライアント座標に変換する

                    obj.Location = this.PointToClient(sp);
                    Hensu.ControleMove2 = true;
                }

            }
            else
            {
                ((Form1)this.MdiParent).ChangeDate();
            }

        }
        private void LabelClick(object sender, System.EventArgs e)
        {
            Label obj = (Label)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            Hensu.SelectControleKinds = "Label";
            if (Hensu.ControleMove)
            {
                if (Hensu.ControleMove2)
                {
                    Hensu.ControleMove2 = false;
                }
                else
                {
                    //フォーム上の座標でマウスポインタの位置を取得する
                    //画面座標でマウスポインタの位置を取得する
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    //画面座標をクライアント座標に変換する

                    obj.Location = this.PointToClient(sp);
                    Hensu.ControleMove2 = true;
                }

            }
            else
            {
                ((Form1)this.MdiParent).ChangeDate();
            }

        }
        private void ListBoxClick(object sender, System.EventArgs e)
        {
            ListBox obj = (ListBox)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            Hensu.SelectControleKinds = "ListBox";
            if (Hensu.ControleMove)
            {
                if (Hensu.ControleMove2)
                {
                    Hensu.ControleMove2 = false;
                }
                else
                {
                    //フォーム上の座標でマウスポインタの位置を取得する
                    //画面座標でマウスポインタの位置を取得する
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    //画面座標をクライアント座標に変換する

                    obj.Location = this.PointToClient(sp);
                    Hensu.ControleMove2 = true;
                }

            }
            else
            {
                ((Form1)this.MdiParent).ChangeDate();
            }

        }
        private void MenuStripClick(object sender, System.EventArgs e)
        {
            MenuStrip obj = (MenuStrip)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            ((Form1)this.MdiParent).ChangeDate();
        }
        private void PictureBoxClick(object sender, System.EventArgs e)
        {
            PictureBox obj = (PictureBox)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            Hensu.SelectControleKinds = "PictureBox";
            if (Hensu.ControleMove)
            {
                if (Hensu.ControleMove2)
                {
                    Hensu.ControleMove2 = false;
                }
                else
                {
                    //フォーム上の座標でマウスポインタの位置を取得する
                    //画面座標でマウスポインタの位置を取得する
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    //画面座標をクライアント座標に変換する

                    obj.Location = this.PointToClient(sp);
                    Hensu.ControleMove2 = true;
                }

            }
            else
            {
                ((Form1)this.MdiParent).ChangeDate();
            }

        }
        private void ProgressBarClick(object sender, System.EventArgs e)
        {
            ProgressBar obj = (ProgressBar)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            Hensu.SelectControleKinds = "ProgressBar";
            if (Hensu.ControleMove)
            {
                if (Hensu.ControleMove2)
                {
                    Hensu.ControleMove2 = false;
                }
                else
                {
                    //フォーム上の座標でマウスポインタの位置を取得する
                    //画面座標でマウスポインタの位置を取得する
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    //画面座標をクライアント座標に変換する

                    obj.Location = this.PointToClient(sp);
                    Hensu.ControleMove2 = true;
                }

            }
            else
            {
                ((Form1)this.MdiParent).ChangeDate();
            }

        }
        private void RadioButtonClick(object sender, System.EventArgs e)
        {
            RadioButton obj = (RadioButton)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            Hensu.SelectControleKinds = "RadioButton";
            if (Hensu.ControleMove)
            {
                if (Hensu.ControleMove2)
                {
                    Hensu.ControleMove2 = false;
                }
                else
                {
                    //フォーム上の座標でマウスポインタの位置を取得する
                    //画面座標でマウスポインタの位置を取得する
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    //画面座標をクライアント座標に変換する

                    obj.Location = this.PointToClient(sp);
                    Hensu.ControleMove2 = true;
                }

            }
            else
            {
                ((Form1)this.MdiParent).ChangeDate();
            }

        }
        private void RichTextBoxClick(object sender, System.EventArgs e)
        {
            RichTextBox obj = (RichTextBox)sender;
            Hensu.SelectControleName = obj.Name;
            Hensu.SelectControleNumber = SearchControleNum(obj.Name);
            Hensu.SelectControleKinds = "RichTextBox";
            if (Hensu.ControleMove)
            {
                if (Hensu.ControleMove2)
                {
                    Hensu.ControleMove2 = false;
                }
                else
                {
                    //フォーム上の座標でマウスポインタの位置を取得する
                    //画面座標でマウスポインタの位置を取得する
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    //画面座標をクライアント座標に変換する

                    obj.Location = this.PointToClient(sp);
                    Hensu.ControleMove2 = true;
                }

            }
            else
            {
                ((Form1)this.MdiParent).ChangeDate();
            }

        }

        public Form2()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
        }

        //マウスのボタンが押されたとき
        private void Form1_MouseDown(object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        //マウスが動いたとき
        private void Form1_MouseMove(object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;

            }
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            //LoadGuitFiles


            //それぞれのコントロールのデータを配列から取得し、表示していく

            //Message.Show(Form2.ButtonDate);
            int Controles = 0, ButtonVV = 0, TextBoxVV = 0, CheckBoxVV = 0, ComboBoxVV = 0, LabelVV = 0, ListBoxVV = 0, MenuStripVV = 0, PictureBoxVV = 0, ProgressBarVV = 0, RadioButtonVV = 0, RichTextBoxVV = 0;
            //各要素個数調べ
            String TargetControle = "Form";

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


            while (TargetControle != "END")
            {

                while (Hensu.Dates[Controles, 0] != null)
                {
                    int i = 0;
                    switch (Hensu.Dates[Controles, 0])
                    {
                        case "Form":
                            i = 2;
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            this.Click += new System.EventHandler(FormClick);
                            Controles = Controles + 1;
                            break;
                        case "Button":
                            i = 2;
                            this.buttons[ButtonVV] = new Button();
                            this.buttons[ButtonVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.buttons[ButtonVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Location":
                                        string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.buttons[ButtonVV].Location = new Point(int.Parse(location[0]),int.Parse(location[1]));
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.buttons[ButtonVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.buttons[ButtonVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.buttons[ButtonVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.buttons[ButtonVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            this.buttons[ButtonVV].Click += new System.EventHandler(ButtonClick);
                            this.Controls.Add(this.buttons[ButtonVV]);
                            ButtonVV = ButtonVV + 1;
                            Controles = Controles + 1;
                            break;
                        case "TextBox":
                            i = 2;
                            this.textboxs[TextBoxVV] = new TextBox();
                            this.textboxs[TextBoxVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.textboxs[TextBoxVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Location":
                                        string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.textboxs[TextBoxVV].Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.textboxs[TextBoxVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.textboxs[TextBoxVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.textboxs[TextBoxVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.textboxs[TextBoxVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                    case "MultLine":
                                        if (Hensu.Dates[Controles, i + 1] == "true")
                                        {
                                            this.textboxs[TextBoxVV].Multiline = true;
                                        }else
                                        {
                                            this.textboxs[TextBoxVV].Multiline = false;
                                        }
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            
                            this.textboxs[TextBoxVV].Click += new System.EventHandler(TextBoxClick);
                            this.Controls.Add(this.textboxs[TextBoxVV]);
                            TextBoxVV = TextBoxVV + 1;

                            Controles = Controles + 1;
                            break;
                        case "CheckBox":
                            i = 2;
                            this.checkboxs[CheckBoxVV] = new CheckBox();
                            this.checkboxs[CheckBoxVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.checkboxs[CheckBoxVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Location":
                                        string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.checkboxs[CheckBoxVV].Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.checkboxs[CheckBoxVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.checkboxs[CheckBoxVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.checkboxs[CheckBoxVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.checkboxs[CheckBoxVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            
                            this.checkboxs[CheckBoxVV].Click += new System.EventHandler(CheckBoxClick);
                            this.Controls.Add(this.checkboxs[CheckBoxVV]);
                            CheckBoxVV = CheckBoxVV + 1;

                            Controles = Controles + 1;
                            break;
                        case "ComboBox":
                            i = 2;
                            this.comboboxs[ComboBoxVV] = new ComboBox();
                            this.comboboxs[ComboBoxVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.comboboxs[ComboBoxVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Location":
                                        string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.comboboxs[ComboBoxVV].Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.comboboxs[ComboBoxVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.comboboxs[ComboBoxVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.comboboxs[ComboBoxVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.comboboxs[ComboBoxVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            
                            this.comboboxs[ComboBoxVV].Click += new System.EventHandler(ComboBoxClick);
                            this.Controls.Add(this.comboboxs[ComboBoxVV]);
                            ComboBoxVV = ComboBoxVV + 1;

                            Controles = Controles + 1;
                            break;
                        case "Label":
                            i = 2;
                            this.labels[LabelVV] = new Label();
                            this.labels[LabelVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.labels[LabelVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Location":
                                        string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.labels[LabelVV].Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.labels[LabelVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.labels[LabelVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.labels[LabelVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.labels[LabelVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            this.labels[LabelVV].Click += new System.EventHandler(LabelClick);
                            this.Controls.Add(this.labels[LabelVV]);
                            LabelVV = LabelVV + 1;

                            Controles = Controles + 1;
                            break;
                        case "ListBox":
                            i = 2;
                            this.listboxs[ListBoxVV] = new ListBox();
                            this.listboxs[ListBoxVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.listboxs[ListBoxVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Location":
                                        string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.listboxs[ListBoxVV].Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.listboxs[ListBoxVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.listboxs[ListBoxVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.listboxs[ListBoxVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.listboxs[ListBoxVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            this.listboxs[ListBoxVV].Click += new System.EventHandler(ListBoxClick);
                            this.Controls.Add(this.listboxs[ListBoxVV]);
                            ListBoxVV = ListBoxVV + 1;

                            Controles = Controles + 1;
                            break;
                        case "MenuStrip":
                            i = 2;
                            this.menustrips[MenuStripVV] = new MenuStrip();
                            this.menustrips[MenuStripVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.menustrips[MenuStripVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    //case "Location":
                                    //    string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                    //    this.menustrips[MenuStripVV].Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                                    //    break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.menustrips[MenuStripVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.menustrips[MenuStripVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.menustrips[MenuStripVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.menustrips[MenuStripVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            this.menustrips[MenuStripVV].Click += new System.EventHandler(MenuStripClick);
                            this.Controls.Add(this.menustrips[MenuStripVV]);
                            MenuStripVV = MenuStripVV + 1;

                            Controles = Controles + 1;
                            break;
                        case "PictureBox":
                            i = 2;
                            this.pictureboxs[PictureBoxVV] = new PictureBox();
                            this.pictureboxs[PictureBoxVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.pictureboxs[PictureBoxVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Location":
                                        string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.pictureboxs[PictureBoxVV].Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.pictureboxs[PictureBoxVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.pictureboxs[PictureBoxVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.pictureboxs[PictureBoxVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.pictureboxs[PictureBoxVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            this.pictureboxs[PictureBoxVV].Click += new System.EventHandler(PictureBoxClick);
                            this.Controls.Add(this.pictureboxs[PictureBoxVV]);
                            PictureBoxVV = PictureBoxVV + 1;

                            Controles = Controles + 1;
                            break;
                        case "ProgressBar":
                            i = 2;
                            this.progressbars[ProgressBarVV] = new ProgressBar();
                            this.progressbars[ProgressBarVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.progressbars[ProgressBarVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Location":
                                        string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.progressbars[ProgressBarVV].Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.progressbars[ProgressBarVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.progressbars[ProgressBarVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.progressbars[ProgressBarVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.progressbars[ProgressBarVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            this.progressbars[ProgressBarVV].Click += new System.EventHandler(ProgressBarClick);
                            this.Controls.Add(this.progressbars[ProgressBarVV]);
                            ProgressBarVV = ProgressBarVV + 1;

                            Controles = Controles + 1;
                            break;
                        case "RadioButton":
                            i = 2;
                            this.radiobuttons[RadioButtonVV] = new RadioButton();
                            this.radiobuttons[RadioButtonVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.radiobuttons[RadioButtonVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Location":
                                        string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.radiobuttons[RadioButtonVV].Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.radiobuttons[RadioButtonVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.radiobuttons[RadioButtonVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.radiobuttons[RadioButtonVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.radiobuttons[RadioButtonVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            this.radiobuttons[RadioButtonVV].Click += new System.EventHandler(RadioButtonClick);
                            this.Controls.Add(this.radiobuttons[RadioButtonVV]);
                            RadioButtonVV = RadioButtonVV + 1;

                            Controles = Controles + 1;
                            break;
                        case "RichTextBox":
                            i = 2;
                            this.richtextboxs[RichTextBoxVV] = new RichTextBox();
                            this.richtextboxs[RichTextBoxVV].Name = Hensu.Dates[Controles, 1];
                            while (Hensu.Dates[Controles, i] != null)
                            {
                                switch (Hensu.Dates[Controles, i])
                                {
                                    case "Text":
                                        this.richtextboxs[RichTextBoxVV].Text = Hensu.Dates[Controles, i + 1];
                                        break;
                                    case "Location":
                                        string[] location = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.richtextboxs[RichTextBoxVV].Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
                                        break;
                                    case "Size":
                                        string[] size = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.richtextboxs[RichTextBoxVV].Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                                        break;
                                    case "BackColor":
                                        Color color = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.richtextboxs[RichTextBoxVV].BackColor = color;
                                        break;
                                    case "ForeColor":
                                        Color color2 = Color.FromName(Hensu.Dates[Controles, i + 1]);
                                        this.richtextboxs[RichTextBoxVV].ForeColor = color2;
                                        break;
                                    case "Font":
                                        string[] font = Hensu.Dates[Controles, i + 1].Split(':');
                                        this.richtextboxs[RichTextBoxVV].Font = new Font(font[0], int.Parse(font[1]));
                                        break;
                                }

                                ++i;
                                ++i;
                            }
                            this.richtextboxs[RichTextBoxVV].Click += new System.EventHandler(RichTextBoxClick);
                            this.Controls.Add(this.richtextboxs[RichTextBoxVV]);
                            RichTextBoxVV = RichTextBoxVV + 1;

                            Controles = Controles + 1;
                            break;
                    }
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

            }

        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Hensu.ControleMove2)
            {
                Control[] SelectControleObject = this.Controls.Find(Hensu.SelectControleName, true);
                //フォーム上の座標でマウスポインタの位置を取得する
                //画面座標でマウスポインタの位置を取得する
                System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                //画面座標をクライアント座標に変換する
                switch (Hensu.SelectControleKinds)
                {
                    case "Button":
                        ((Button)SelectControleObject[0]).Location = this.PointToClient(sp);
                        break;
                    case "TextBox":
                        ((TextBox)SelectControleObject[0]).Location = this.PointToClient(sp);
                        break;
                    case "CheckBox":
                        ((CheckBox)SelectControleObject[0]).Location = this.PointToClient(sp);
                        break;
                    case "ComboBox":
                        ((ComboBox)SelectControleObject[0]).Location = this.PointToClient(sp);
                        break;
                    case "Label":
                        ((Label)SelectControleObject[0]).Location = this.PointToClient(sp);
                        break;
                    case "ListBox":
                        ((ListBox)SelectControleObject[0]).Location = this.PointToClient(sp);
                        break;
                    case "PictureBox":
                        ((PictureBox)SelectControleObject[0]).Location = this.PointToClient(sp);
                        break;
                    case "ProgressBar":
                        ((ProgressBar)SelectControleObject[0]).Location = this.PointToClient(sp);
                        break;
                    case "RadioButton":
                        ((RadioButton)SelectControleObject[0]).Location = this.PointToClient(sp);
                        break;
                    case "RichTextBox":
                        ((RichTextBox)SelectControleObject[0]).Location = this.PointToClient(sp);
                        break;
                }
                int i = 2;
                while(Hensu.Dates[Hensu.SelectControleNumber,i]!=null)
                {
                    if(Hensu.Dates[Hensu.SelectControleNumber, i] == "Location")
                    {
                        Hensu.Dates[Hensu.SelectControleNumber, i + 1] = this.PointToClient(sp).X.ToString() + ":" + this.PointToClient(sp).Y.ToString();
                    }
                    ++i;
                    ++i;
                }

            }
        }
    }
}



