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
    public partial class Form1 : Form
    {
        int TreeViewSelect = 0;//0ならまだ選択されたことがない、1なら選択されたことがある,
        String[] Yoyakugo = new string[] {"abstract",   "as",   "base", "bool"  ,"break",   "byte",
"case"  ,"catch"    ,"char" ,"checked"  ,"class" ,  "const",
"continue", "decimal",  "default",  "delegate" ,   "do",    "double",
"else"  ,"enum" ,   "event",   "explicit" ,   "extern", "false",
"finally"   ,"fixed", "float", "For", "foreach",    "goto",
"if"    ,"implicit"  , "in" ,"int" ,"interface"  , "internal",
"is",   "lock"  ,"long" ,   "namespace" ,  "new"    ,"null",
"object" ,"operator"   , "out"  ,"override" ,"params",  "private",
"protected" ,"public" ,"readonly",  "ref"   ,"return",  "sbyte",
"sealed" ,"short",  "sizeof"    ,"stackalloc",  "static" ,"String",
"struct" , "switch" ,"this"  ,  "throw",    "true"  ,"try",
"typeof"    ,"uint"   , "ulong" ,  "unchecked", "unsafe" ,"ushort",
"using",    "virtual", "void" ,"volatile"   ,"while"    };
    String[] FormDate = new string[30];
        String[,] ButtonDate = new string[1000, 30];
        String[] ButtonName = new string[1000];
        String[,] TextBoxDate = new string[1000, 30];
        String[] TextBoxName = new string[1000];
        String[,] CheckBoxDate = new string[1000, 30];
        String[] CheckBoxName = new string[1000];
        String[,] ComboBoxDate = new string[1000, 30];
        String[] ComboBoxName = new string[1000];
        String[,] LabelDate = new string[1000, 30];
        String[] LabelName = new string[1000];
        String[,] ListBoxDate = new string[1000, 30];
        String[] ListBoxName = new string[1000];
        String[,] MenuStripDate = new string[1000, 30];
        String[] MenuStripName = new string[1000];
        String[,] PictureBoxDate = new string[1000, 30];
        String[] PictureBoxName = new string[1000];
        String[,] ProgressBarDate = new string[1000, 30];
        String[] ProgressBarName = new string[1000];
        String[,] RadioButtonDate = new string[1000, 30];
        String[] RadioButtonName = new string[1000];
        String[,] RichTextBoxDate = new string[1000, 30];
        String[] RichTextBoxName = new string[1000];

        public Form1()
        {
            InitializeComponent();
            String Erorr = TreeViewAndShowForm2(Hensu.RunHikisu);
            //MessageBox.Show(Erorr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        public String TreeViewAndShowForm2(String Path)
        {
            //MessageBox.Show(Path);


            treeView1.Nodes.Clear();
            TreeNode tn;
            // tn = treeView1.Nodes.Add("Form");
            String TargetControle = "Form";
            //各コントロールの個数調べ
            //コントロールの個数格納用変数初期化
            Hensu.ButtonV = 0;
            Hensu.TextBoxV = 0;
            Hensu.CheckBoxV = 0;
            Hensu.ComboBoxV = 0;
            Hensu.LabelV = 0;
            Hensu.ListBoxV = 0;
            Hensu.MenuStripV = 0;
            Hensu.MenuStripV = 0;
            Hensu.PictureBoxV = 0;
            Hensu.ProgressBarV = 0;
            Hensu.RadioButtonV = 0;
            Hensu.RichTextBoxV = 0;
            


            while (TargetControle != "END")
            {
                //内容を一行ずつ読み込む
                System.IO.StreamReader fsr = new System.IO.StreamReader(
                Path,
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
                
            }
            //MessageBox.Show(Hensu.ButtonV.ToString());
            TargetControle = "Form";
            tn = treeView1.Nodes.Add(TargetControle);
            int ControlNum = 0;
            //CSVファイル開く
            while (TargetControle != "END")
            {
                ControlNum = 0;
                //内容を一行ずつ読み込む
                System.IO.StreamReader sr = new System.IO.StreamReader(
                Path,
                System.Text.Encoding.GetEncoding("shift_jis"));
                while (sr.Peek() > -1)
                {
                    String line = sr.ReadLine();
                    String[] Items = line.Split('/');
                    //MessageBox.Show(Items[0]);
                    if (Items[0] == TargetControle)
                    {
                        switch (Items[0])
                        {
                            case "Form":
                                FormDate[0] = Items[0];
                                FormDate[1] = Items[1];
                                FormDate[2] = Items[2];
                                FormDate[3] = Items[3];
                                FormDate[4] = Items[4];
                                FormDate[5] = Items[5];
                                FormDate[6] = Items[6];
                                FormDate[7] = Items[7];
                                FormDate[8] = Items[8];
                                FormDate[9] = Items[9];

                                break;
                            case "Button":
                                tn.Nodes.Add(Items[1]);
                                ButtonDate[ControlNum, 0] = Items[0];
                                ButtonName[ControlNum] = Items[1];
                                ButtonDate[ControlNum, 1] = Items[1];
                                ButtonDate[ControlNum, 2] = Items[2];
                                ButtonDate[ControlNum, 3] = Items[3];
                                ButtonDate[ControlNum, 4] = Items[4];
                                ButtonDate[ControlNum, 5] = Items[5];
                                ButtonDate[ControlNum, 6] = Items[6];
                                ButtonDate[ControlNum, 7] = Items[7];
                                ButtonDate[ControlNum, 8] = Items[8];
                                ButtonDate[ControlNum, 9] = Items[9];
                                ButtonDate[ControlNum, 10] = Items[10];
                                ButtonDate[ControlNum, 11] = Items[11];
                                ButtonDate[ControlNum, 12] = Items[12];
                                ButtonDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum  + 1;
                                break;
                            case "TextBox":
                                tn.Nodes.Add(Items[1]);
                                TextBoxDate[ControlNum, 0] = Items[0];
                                TextBoxName[ControlNum] = Items[1];
                                TextBoxDate[ControlNum, 1] = Items[1];
                                TextBoxDate[ControlNum, 2] = Items[2];
                                TextBoxDate[ControlNum, 3] = Items[3];
                                TextBoxDate[ControlNum, 4] = Items[4];
                                TextBoxDate[ControlNum, 5] = Items[5];
                                TextBoxDate[ControlNum, 6] = Items[6];
                                TextBoxDate[ControlNum, 7] = Items[7];
                                TextBoxDate[ControlNum, 8] = Items[8];
                                TextBoxDate[ControlNum, 9] = Items[9];
                                TextBoxDate[ControlNum, 10] = Items[10];
                                TextBoxDate[ControlNum, 11] = Items[11];
                                TextBoxDate[ControlNum, 12] = Items[12];
                                TextBoxDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum + 1;
                                break;
                            case "CheckBox":
                                tn.Nodes.Add(Items[1]);
                                CheckBoxDate[ControlNum, 0] = Items[0];
                                CheckBoxName[ControlNum] = Items[1];
                                CheckBoxDate[ControlNum, 1] = Items[1];
                                CheckBoxDate[ControlNum, 2] = Items[2];
                                CheckBoxDate[ControlNum, 3] = Items[3];
                                CheckBoxDate[ControlNum, 4] = Items[4];
                                CheckBoxDate[ControlNum, 5] = Items[5];
                                CheckBoxDate[ControlNum, 6] = Items[6];
                                CheckBoxDate[ControlNum, 7] = Items[7];
                                CheckBoxDate[ControlNum, 8] = Items[8];
                                CheckBoxDate[ControlNum, 9] = Items[9];
                                CheckBoxDate[ControlNum, 10] = Items[10];
                                CheckBoxDate[ControlNum, 11] = Items[11];
                                CheckBoxDate[ControlNum, 12] = Items[12];
                                CheckBoxDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum + 1;
                                break;
                            case "ComboBox":
                                tn.Nodes.Add(Items[1]);
                                ComboBoxDate[ControlNum, 0] = Items[0];
                                ComboBoxName[ControlNum] = Items[1];
                                ComboBoxDate[ControlNum, 1] = Items[1];
                                ComboBoxDate[ControlNum, 2] = Items[2];
                                ComboBoxDate[ControlNum, 3] = Items[3];
                                ComboBoxDate[ControlNum, 4] = Items[4];
                                ComboBoxDate[ControlNum, 5] = Items[5];
                                ComboBoxDate[ControlNum, 6] = Items[6];
                                ComboBoxDate[ControlNum, 7] = Items[7];
                                ComboBoxDate[ControlNum, 8] = Items[8];
                                ComboBoxDate[ControlNum, 9] = Items[9];
                                ComboBoxDate[ControlNum, 10] = Items[10];
                                ComboBoxDate[ControlNum, 11] = Items[11];
                                ComboBoxDate[ControlNum, 12] = Items[12];
                                ComboBoxDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum + 1;
                                break;
                            case "Label":
                                tn.Nodes.Add(Items[1]);
                                LabelDate[ControlNum, 0] = Items[0];
                                LabelName[ControlNum] = Items[1];
                                LabelDate[ControlNum, 1] = Items[1];
                                LabelDate[ControlNum, 2] = Items[2];
                                LabelDate[ControlNum, 3] = Items[3];
                                LabelDate[ControlNum, 4] = Items[4];
                                LabelDate[ControlNum, 5] = Items[5];
                                LabelDate[ControlNum, 6] = Items[6];
                                LabelDate[ControlNum, 7] = Items[7];
                                LabelDate[ControlNum, 8] = Items[8];
                                LabelDate[ControlNum, 9] = Items[9];
                                LabelDate[ControlNum, 10] = Items[10];
                                LabelDate[ControlNum, 11] = Items[11];
                                LabelDate[ControlNum, 12] = Items[12];
                                LabelDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum + 1;
                                break;
                            case "ListBox":
                                tn.Nodes.Add(Items[1]);
                                ListBoxDate[ControlNum, 0] = Items[0];
                                ListBoxName[ControlNum] = Items[1];
                                ListBoxDate[ControlNum, 1] = Items[1];
                                ListBoxDate[ControlNum, 2] = Items[2];
                                ListBoxDate[ControlNum, 3] = Items[3];
                                ListBoxDate[ControlNum, 4] = Items[4];
                                ListBoxDate[ControlNum, 5] = Items[5];
                                ListBoxDate[ControlNum, 6] = Items[6];
                                ListBoxDate[ControlNum, 7] = Items[7];
                                ListBoxDate[ControlNum, 8] = Items[8];
                                ListBoxDate[ControlNum, 9] = Items[9];
                                ListBoxDate[ControlNum, 10] = Items[10];
                                ListBoxDate[ControlNum, 11] = Items[11];
                                ListBoxDate[ControlNum, 12] = Items[12];
                                ListBoxDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum + 1;
                                break;
                            case "MenuStrip":
                                tn.Nodes.Add(Items[1]);
                                MenuStripDate[ControlNum, 0] = Items[0];
                                MenuStripName[ControlNum] = Items[1];
                                MenuStripDate[ControlNum, 1] = Items[1];
                                MenuStripDate[ControlNum, 2] = Items[2];
                                MenuStripDate[ControlNum, 3] = Items[3];
                                MenuStripDate[ControlNum, 4] = Items[4];
                                MenuStripDate[ControlNum, 5] = Items[5];
                                MenuStripDate[ControlNum, 6] = Items[6];
                                MenuStripDate[ControlNum, 7] = Items[7];
                                MenuStripDate[ControlNum, 8] = Items[8];
                                MenuStripDate[ControlNum, 9] = Items[9];
                                MenuStripDate[ControlNum, 10] = Items[10];
                                MenuStripDate[ControlNum, 11] = Items[11];
                                MenuStripDate[ControlNum, 12] = Items[12];
                                MenuStripDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum + 1;
                                break;
                            case "PictureBox":
                                tn.Nodes.Add(Items[1]);
                                PictureBoxDate[ControlNum, 0] = Items[0];
                                PictureBoxName[ControlNum] = Items[1];
                                PictureBoxDate[ControlNum, 1] = Items[1];
                                PictureBoxDate[ControlNum, 2] = Items[2];
                                PictureBoxDate[ControlNum, 3] = Items[3];
                                PictureBoxDate[ControlNum, 4] = Items[4];
                                PictureBoxDate[ControlNum, 5] = Items[5];
                                PictureBoxDate[ControlNum, 6] = Items[6];
                                PictureBoxDate[ControlNum, 7] = Items[7];
                                PictureBoxDate[ControlNum, 8] = Items[8];
                                PictureBoxDate[ControlNum, 9] = Items[9];
                                PictureBoxDate[ControlNum, 10] = Items[10];
                                PictureBoxDate[ControlNum, 11] = Items[11];
                                PictureBoxDate[ControlNum, 12] = Items[12];
                                PictureBoxDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum + 1;
                                break;
                            case "ProgressBar":
                                tn.Nodes.Add(Items[1]);
                                ProgressBarDate[ControlNum, 0] = Items[0];
                                ProgressBarName[ControlNum] = Items[1];
                                ProgressBarDate[ControlNum, 1] = Items[1];
                                ProgressBarDate[ControlNum, 2] = Items[2];
                                ProgressBarDate[ControlNum, 3] = Items[3];
                                ProgressBarDate[ControlNum, 4] = Items[4];
                                ProgressBarDate[ControlNum, 5] = Items[5];
                                ProgressBarDate[ControlNum, 6] = Items[6];
                                ProgressBarDate[ControlNum, 7] = Items[7];
                                ProgressBarDate[ControlNum, 8] = Items[8];
                                ProgressBarDate[ControlNum, 9] = Items[9];
                                ProgressBarDate[ControlNum, 10] = Items[10];
                                ProgressBarDate[ControlNum, 11] = Items[11];
                                ProgressBarDate[ControlNum, 12] = Items[12];
                                ProgressBarDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum + 1;
                                break;
                            case "RadioButton":
                                tn.Nodes.Add(Items[1]);
                                RadioButtonDate[ControlNum, 0] = Items[0];
                                RadioButtonName[ControlNum] = Items[1];
                                RadioButtonDate[ControlNum, 1] = Items[1];
                                RadioButtonDate[ControlNum, 2] = Items[2];
                                RadioButtonDate[ControlNum, 3] = Items[3];
                                RadioButtonDate[ControlNum, 4] = Items[4];
                                RadioButtonDate[ControlNum, 5] = Items[5];
                                RadioButtonDate[ControlNum, 6] = Items[6];
                                RadioButtonDate[ControlNum, 7] = Items[7];
                                RadioButtonDate[ControlNum, 8] = Items[8];
                                RadioButtonDate[ControlNum, 9] = Items[9];
                                RadioButtonDate[ControlNum, 10] = Items[10];
                                RadioButtonDate[ControlNum, 11] = Items[11];
                                RadioButtonDate[ControlNum, 12] = Items[12];
                                RadioButtonDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum + 1;
                                break;
                            case "RichTextBox":
                                tn.Nodes.Add(Items[1]);
                                RichTextBoxDate[ControlNum, 0] = Items[0];
                                RichTextBoxName[ControlNum] = Items[1];
                                RichTextBoxDate[ControlNum, 1] = Items[1];
                                RichTextBoxDate[ControlNum, 2] = Items[2];
                                RichTextBoxDate[ControlNum, 3] = Items[3];
                                RichTextBoxDate[ControlNum, 4] = Items[4];
                                RichTextBoxDate[ControlNum, 5] = Items[5];
                                RichTextBoxDate[ControlNum, 6] = Items[6];
                                RichTextBoxDate[ControlNum, 7] = Items[7];
                                RichTextBoxDate[ControlNum, 8] = Items[8];
                                RichTextBoxDate[ControlNum, 9] = Items[9];
                                RichTextBoxDate[ControlNum, 10] = Items[10];
                                RichTextBoxDate[ControlNum, 11] = Items[11];
                                RichTextBoxDate[ControlNum, 12] = Items[12];
                                RichTextBoxDate[ControlNum, 13] = Items[13];

                                ControlNum = ControlNum + 1;
                                break;
                        }
                    }
                }
                sr.Close();
                //次のターゲットに変更
                switch (TargetControle)
                {
                    case "Form":
                        TargetControle = "Button";
                        ControlNum = 0;
                        break;
                    case "Button":
                        TargetControle = "TextBox";
                        ControlNum = 0;
                        break;
                    case "TextBox":
                        TargetControle = "CheckBox";
                        ControlNum = 0;
                        break;
                    case "CheckBox":
                        TargetControle = "ComboBox";
                        ControlNum = 0;
                        break;
                    case "ComboBox":
                        TargetControle = "Label";
                        ControlNum = 0;
                        break;
                    case "Label":
                        TargetControle = "ListBox";
                        ControlNum = 0;
                        break;
                    case "ListBox":
                        TargetControle = "MenuStrip";
                        ControlNum = 0;
                        break;
                    case "MenuStrip":
                        TargetControle = "PictureBox";
                        ControlNum = 0;
                        break;
                    case "PictureBox":
                        TargetControle = "ProgressBar";
                        ControlNum = 0;
                        break;
                    case "ProgressBar":
                        TargetControle = "RadioButton";
                        ControlNum = 0;
                        break;
                    case "RadioButton":
                        TargetControle = "RichTextBox";
                        ControlNum = 0;
                        break;
                    case "RichTextBox":
                        TargetControle = "END";
                        ControlNum = 0;
                        break;
                }
                if(TargetControle != "END")
                {
                    tn = treeView1.Nodes.Add(TargetControle);
                }
            }
            //内容を一行ずつ読み込む
            //while (sr.Peek() > -1)
            //{
            //    Console.WriteLine(sr.ReadLine());
            //}
            //閉じる

            String Erorr = "No";
            return Erorr;
        
        }
        

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            //label3.Text = "：";
            //label4.Text = "：";
            //label5.Text = "：";
            //label6.Text = "：";
            //label7.Text = "：";
            //label8.Text = "：";
            //label9.Text = "：";
            //label9.Text = "：";
            int index;
            TreeNode selectedNode = e.Node;
            Hensu.selectNode = e.Node.Text;
            if(e.Node.Text != "Button")
            {
                if (e.Node.Text != "TextBox")
                {
                    if (e.Node.Text != "Label")
                    {
                        if (e.Node.Text != "CheckBox")
                        {
                            if (e.Node.Text != "ComboBox")
                            {
                                if(e.Node.Text != "ListBox")
                                {
                                    if(e.Node.Text != "MenuStrip")
                                    {
                                        if (e.Node.Text != "PictureBox")
                                        {
                                            if (e.Node.Text != "ProgressBar")
                                            {
                                                if (e.Node.Text != "RadioButton")
                                                {
                                                    if (e.Node.Text != "RichTextBox")
                                                    {
                                                        //☆
                                                        if (TreeViewSelect == 1)
                                                        {
                                                            //他のコントロール選択時、コントロールの値を保持する
                                                            switch (label00.Text)
                                                            {
                                                                case "Form":
                                                                    FormDate[2] = textBox1.Text;
                                                                    FormDate[3] = textBox2.Text;
                                                                    FormDate[4] = textBox3.Text;
                                                                    FormDate[5] = textBox4.Text;
                                                                    FormDate[6] = textBox5.Text;
                                                                    FormDate[7] = textBox6.Text;
                                                                    FormDate[8] = textBox7.Text;
                                                                    FormDate[9] = textBox8.Text;
                                                                    FormDate[10] = textBox9.Text;
                                                                    FormDate[11] = textBox10.Text;
                                                                    FormDate[12] = textBox11.Text;
                                                                    FormDate[13] = textBox14.Text;

                                                                    break;
                                                                case "Button":
                                                                    index = Array.IndexOf(ButtonName, label2.Text);


                                                                    ButtonDate[index, 2] = textBox1.Text;
                                                                    ButtonDate[index, 3] = textBox2.Text;
                                                                    ButtonDate[index, 4] = textBox3.Text;
                                                                    ButtonDate[index, 5] = textBox4.Text;
                                                                    ButtonDate[index, 6] = textBox5.Text;
                                                                    ButtonDate[index, 7] = textBox6.Text;
                                                                    ButtonDate[index, 8] = textBox7.Text;
                                                                    ButtonDate[index, 9] = textBox8.Text;
                                                                    ButtonDate[index, 10] = textBox9.Text;
                                                                    ButtonDate[index, 11] = textBox10.Text;
                                                                    ButtonDate[index, 12] = textBox11.Text;
                                                                    ButtonDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "TextBox":
                                                                    index = Array.IndexOf(TextBoxName, label2.Text);


                                                                    TextBoxDate[index, 2] = textBox1.Text;
                                                                    TextBoxDate[index, 3] = textBox2.Text;
                                                                    TextBoxDate[index, 4] = textBox3.Text;
                                                                    TextBoxDate[index, 5] = textBox4.Text;
                                                                    TextBoxDate[index, 6] = textBox5.Text;
                                                                    TextBoxDate[index, 7] = textBox6.Text;
                                                                    TextBoxDate[index, 8] = textBox7.Text;
                                                                    TextBoxDate[index, 9] = textBox8.Text;
                                                                    TextBoxDate[index, 10] = textBox9.Text;
                                                                    TextBoxDate[index, 11] = textBox10.Text;
                                                                    TextBoxDate[index, 12] = textBox11.Text;
                                                                    TextBoxDate[index, 13] = textBox12.Text;
                                                                    break;

                                                                case "CheckBox":
                                                                    index = Array.IndexOf(CheckBoxName, label2.Text);


                                                                    CheckBoxDate[index, 2] = textBox1.Text;
                                                                    CheckBoxDate[index, 3] = textBox2.Text;
                                                                    CheckBoxDate[index, 4] = textBox3.Text;
                                                                    CheckBoxDate[index, 5] = textBox4.Text;
                                                                    CheckBoxDate[index, 6] = textBox5.Text;
                                                                    CheckBoxDate[index, 7] = textBox6.Text;
                                                                    CheckBoxDate[index, 8] = textBox7.Text;
                                                                    CheckBoxDate[index, 9] = textBox8.Text;
                                                                    CheckBoxDate[index, 10] = textBox9.Text;
                                                                    CheckBoxDate[index, 11] = textBox10.Text;
                                                                    CheckBoxDate[index, 12] = textBox11.Text;
                                                                    CheckBoxDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "ComboBox":
                                                                    index = Array.IndexOf(ComboBoxName, label2.Text);


                                                                    ComboBoxDate[index, 2] = textBox1.Text;
                                                                    ComboBoxDate[index, 3] = textBox2.Text;
                                                                    ComboBoxDate[index, 4] = textBox3.Text;
                                                                    ComboBoxDate[index, 5] = textBox4.Text;
                                                                    ComboBoxDate[index, 6] = textBox5.Text;
                                                                    ComboBoxDate[index, 7] = textBox6.Text;
                                                                    ComboBoxDate[index, 8] = textBox7.Text;
                                                                    ComboBoxDate[index, 9] = textBox8.Text;
                                                                    ComboBoxDate[index, 10] = textBox9.Text;
                                                                    ComboBoxDate[index, 11] = textBox10.Text;
                                                                    ComboBoxDate[index, 12] = textBox11.Text;
                                                                    ComboBoxDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "Label":
                                                                    index = Array.IndexOf(LabelName, label2.Text);


                                                                    LabelDate[index, 2] = textBox1.Text;
                                                                    LabelDate[index, 3] = textBox2.Text;
                                                                    LabelDate[index, 4] = textBox3.Text;
                                                                    LabelDate[index, 5] = textBox4.Text;
                                                                    LabelDate[index, 6] = textBox5.Text;
                                                                    LabelDate[index, 7] = textBox6.Text;
                                                                    LabelDate[index, 8] = textBox7.Text;
                                                                    LabelDate[index, 9] = textBox8.Text;
                                                                    LabelDate[index, 10] = textBox9.Text;
                                                                    LabelDate[index, 11] = textBox10.Text;
                                                                    LabelDate[index, 12] = textBox11.Text;
                                                                    LabelDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "ListBox":
                                                                    index = Array.IndexOf(ListBoxName, label2.Text);


                                                                    ListBoxDate[index, 2] = textBox1.Text;
                                                                    ListBoxDate[index, 3] = textBox2.Text;
                                                                    ListBoxDate[index, 4] = textBox3.Text;
                                                                    ListBoxDate[index, 5] = textBox4.Text;
                                                                    ListBoxDate[index, 6] = textBox5.Text;
                                                                    ListBoxDate[index, 7] = textBox6.Text;
                                                                    ListBoxDate[index, 8] = textBox7.Text;
                                                                    ListBoxDate[index, 9] = textBox8.Text;
                                                                    ListBoxDate[index, 10] = textBox9.Text;
                                                                    ListBoxDate[index, 11] = textBox10.Text;
                                                                    ListBoxDate[index, 12] = textBox11.Text;
                                                                    ListBoxDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "MenuStrip":
                                                                    index = Array.IndexOf(MenuStripName, label2.Text);


                                                                    MenuStripDate[index, 2] = textBox1.Text;
                                                                    MenuStripDate[index, 3] = textBox2.Text;
                                                                    MenuStripDate[index, 4] = textBox3.Text;
                                                                    MenuStripDate[index, 5] = textBox4.Text;
                                                                    MenuStripDate[index, 6] = textBox5.Text;
                                                                    MenuStripDate[index, 7] = textBox6.Text;
                                                                    MenuStripDate[index, 8] = textBox7.Text;
                                                                    MenuStripDate[index, 9] = textBox8.Text;
                                                                    MenuStripDate[index, 10] = textBox9.Text;
                                                                    MenuStripDate[index, 11] = textBox10.Text;
                                                                    MenuStripDate[index, 12] = textBox11.Text;
                                                                    MenuStripDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "PictureBox":
                                                                    index = Array.IndexOf(PictureBoxName, label2.Text);


                                                                    PictureBoxDate[index, 2] = textBox1.Text;
                                                                    PictureBoxDate[index, 3] = textBox2.Text;
                                                                    PictureBoxDate[index, 4] = textBox3.Text;
                                                                    PictureBoxDate[index, 5] = textBox4.Text;
                                                                    PictureBoxDate[index, 6] = textBox5.Text;
                                                                    PictureBoxDate[index, 7] = textBox6.Text;
                                                                    PictureBoxDate[index, 8] = textBox7.Text;
                                                                    PictureBoxDate[index, 9] = textBox8.Text;
                                                                    PictureBoxDate[index, 10] = textBox9.Text;
                                                                    PictureBoxDate[index, 11] = textBox10.Text;
                                                                    PictureBoxDate[index, 12] = textBox11.Text;
                                                                    PictureBoxDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "ProgressBar":
                                                                    index = Array.IndexOf(ProgressBarName, label2.Text);


                                                                    ProgressBarDate[index, 2] = textBox1.Text;
                                                                    ProgressBarDate[index, 3] = textBox2.Text;
                                                                    ProgressBarDate[index, 4] = textBox3.Text;
                                                                    ProgressBarDate[index, 5] = textBox4.Text;
                                                                    ProgressBarDate[index, 6] = textBox5.Text;
                                                                    ProgressBarDate[index, 7] = textBox6.Text;
                                                                    ProgressBarDate[index, 8] = textBox7.Text;
                                                                    ProgressBarDate[index, 9] = textBox8.Text;
                                                                    ProgressBarDate[index, 10] = textBox9.Text;
                                                                    ProgressBarDate[index, 11] = textBox10.Text;
                                                                    ProgressBarDate[index, 12] = textBox11.Text;
                                                                    ProgressBarDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "RadioButton":
                                                                    index = Array.IndexOf(RadioButtonName, label2.Text);


                                                                    RadioButtonDate[index, 2] = textBox1.Text;
                                                                    RadioButtonDate[index, 3] = textBox2.Text;
                                                                    RadioButtonDate[index, 4] = textBox3.Text;
                                                                    RadioButtonDate[index, 5] = textBox4.Text;
                                                                    RadioButtonDate[index, 6] = textBox5.Text;
                                                                    RadioButtonDate[index, 7] = textBox6.Text;
                                                                    RadioButtonDate[index, 8] = textBox7.Text;
                                                                    RadioButtonDate[index, 9] = textBox8.Text;
                                                                    RadioButtonDate[index, 10] = textBox9.Text;
                                                                    RadioButtonDate[index, 11] = textBox10.Text;
                                                                    RadioButtonDate[index, 12] = textBox11.Text;
                                                                    RadioButtonDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "RichTextBox":
                                                                    index = Array.IndexOf(RichTextBoxName, label2.Text);


                                                                    RichTextBoxDate[index, 2] = textBox1.Text;
                                                                    RichTextBoxDate[index, 3] = textBox2.Text;
                                                                    RichTextBoxDate[index, 4] = textBox3.Text;
                                                                    RichTextBoxDate[index, 5] = textBox4.Text;
                                                                    RichTextBoxDate[index, 6] = textBox5.Text;
                                                                    RichTextBoxDate[index, 7] = textBox6.Text;
                                                                    RichTextBoxDate[index, 8] = textBox7.Text;
                                                                    RichTextBoxDate[index, 9] = textBox8.Text;
                                                                    RichTextBoxDate[index, 10] = textBox9.Text;
                                                                    RichTextBoxDate[index, 11] = textBox10.Text;
                                                                    RichTextBoxDate[index, 12] = textBox11.Text;
                                                                    RichTextBoxDate[index, 13] = textBox12.Text;
                                                                    break;
                                                            }
                                                        }

                                                        TreeViewSelect = 1;
                                                        label2.Text = e.Node.Text;
                                                        if (e.Node.Text == "Form")
                                                        {
                                                            label3.Text = "：";
                                                            label4.Text = "：";
                                                            label5.Text = "縦の長さ：";
                                                            label6.Text = "横の長さ：";
                                                            label7.Text = "テキスト：";
                                                            label8.Text = "：";
                                                            label9.Text = "：";
                                                            label9.Text = "：";
                                                            label10.Text = "：";
                                                            label11.Text = "：";

                                                            label00.Text = FormDate[0];
                                                            textBox1.Text = FormDate[2];
                                                            textBox2.Text = FormDate[3];
                                                            textBox3.Text = FormDate[4];
                                                            textBox4.Text = FormDate[5];
                                                            textBox5.Text = FormDate[6];
                                                            textBox6.Text = FormDate[7];
                                                            textBox7.Text = FormDate[8];
                                                            textBox8.Text = FormDate[9];
                                                            textBox9.Text = FormDate[10];
                                                            textBox10.Text = FormDate[11];
                                                            textBox11.Text = FormDate[12];
                                                            textBox14.Text = FormDate[13];

                                                        }
                                                        TreeNode parentNode = new TreeNode();
                                                        parentNode = selectedNode.Parent;

                                                        if (parentNode != null)
                                                        {
                                                            switch (parentNode.Text)
                                                            {
                                                                //case "Form":
                                                                //    label3.Text = "X座標：";
                                                                //    label4.Text = "Y座標：";
                                                                //    label5.Text = "縦の長さ：";
                                                                //    label6.Text = "横の長さ：";
                                                                //    label7.Text = "テキスト：";
                                                                //    label8.Text = "：";
                                                                //    label9.Text = "：";
                                                                //    label9.Text = "：";
                                                                //    label10.Text = "：";
                                                                //    label11.Text = "：";
                                                                //    break;
                                                                case "Button":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "：";

                                                                    index = Array.IndexOf(ButtonName, label2.Text);
                                                                    label00.Text = ButtonDate[index, 0];
                                                                    textBox1.Text = ButtonDate[index, 2];
                                                                    textBox2.Text = ButtonDate[index, 3];
                                                                    textBox3.Text = ButtonDate[index, 4];
                                                                    textBox4.Text = ButtonDate[index, 5];
                                                                    textBox5.Text = ButtonDate[index, 6];
                                                                    textBox6.Text = ButtonDate[index, 7];
                                                                    textBox7.Text = ButtonDate[index, 8];
                                                                    textBox8.Text = ButtonDate[index, 9];
                                                                    textBox9.Text = ButtonDate[index, 10];
                                                                    textBox10.Text = ButtonDate[index, 11];
                                                                    textBox11.Text = ButtonDate[index, 12];
                                                                    textBox12.Text = ButtonDate[index, 13];
                                                                    //textBox15.Text = ButtonDate[index,14];
                                                                    //textBox16.Text = ButtonDate[index,15];
                                                                    break;
                                                                case "TextBox":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "複数行許可：";
                                                                    index = Array.IndexOf(TextBoxName, label2.Text);
                                                                    label00.Text = TextBoxDate[index, 0];
                                                                    textBox1.Text = TextBoxDate[index, 2];
                                                                    textBox2.Text = TextBoxDate[index, 3];
                                                                    textBox3.Text = TextBoxDate[index, 4];
                                                                    textBox4.Text = TextBoxDate[index, 5];
                                                                    textBox5.Text = TextBoxDate[index, 6];
                                                                    textBox6.Text = TextBoxDate[index, 7];
                                                                    textBox7.Text = TextBoxDate[index, 8];
                                                                    textBox8.Text = TextBoxDate[index, 9];
                                                                    textBox9.Text = TextBoxDate[index, 10];
                                                                    textBox10.Text = TextBoxDate[index, 11];
                                                                    textBox11.Text = TextBoxDate[index, 12];
                                                                    textBox12.Text = TextBoxDate[index, 13];
                                                                    break;
                                                                case "CheckBox":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "：";

                                                                    index = Array.IndexOf(CheckBoxName, label2.Text);
                                                                    label00.Text = CheckBoxDate[index, 0];
                                                                    textBox1.Text = CheckBoxDate[index, 2];
                                                                    textBox2.Text = CheckBoxDate[index, 3];
                                                                    textBox3.Text = CheckBoxDate[index, 4];
                                                                    textBox4.Text = CheckBoxDate[index, 5];
                                                                    textBox5.Text = CheckBoxDate[index, 6];
                                                                    textBox6.Text = CheckBoxDate[index, 7];
                                                                    textBox7.Text = CheckBoxDate[index, 8];
                                                                    textBox8.Text = CheckBoxDate[index, 9];
                                                                    textBox9.Text = CheckBoxDate[index, 10];
                                                                    textBox10.Text = CheckBoxDate[index, 11];
                                                                    textBox11.Text = CheckBoxDate[index, 12];
                                                                    textBox12.Text = CheckBoxDate[index, 13];
                                                                    break;
                                                                case "ComboBox":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "："; 

                                                                    index = Array.IndexOf(ComboBoxName, label2.Text);
                                                                    label00.Text = ComboBoxDate[index, 0];
                                                                    textBox1.Text = ComboBoxDate[index, 2];
                                                                    textBox2.Text = ComboBoxDate[index, 3];
                                                                    textBox3.Text = ComboBoxDate[index, 4];
                                                                    textBox4.Text = ComboBoxDate[index, 5];
                                                                    textBox5.Text = ComboBoxDate[index, 6];
                                                                    textBox6.Text = ComboBoxDate[index, 7];
                                                                    textBox7.Text = ComboBoxDate[index, 8];
                                                                    textBox8.Text = ComboBoxDate[index, 9];
                                                                    textBox9.Text = ComboBoxDate[index, 10];
                                                                    textBox10.Text = ComboBoxDate[index, 11];
                                                                    textBox11.Text = ComboBoxDate[index, 12];
                                                                    textBox12.Text = ComboBoxDate[index, 13];
                                                                    break;
                                                                case "Label":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "：";

                                                                    index = Array.IndexOf(LabelName, label2.Text);
                                                                    label00.Text = LabelDate[index, 0];
                                                                    textBox1.Text = LabelDate[index, 2];
                                                                    textBox2.Text = LabelDate[index, 3];
                                                                    textBox3.Text = LabelDate[index, 4];
                                                                    textBox4.Text = LabelDate[index, 5];
                                                                    textBox5.Text = LabelDate[index, 6];
                                                                    textBox6.Text = LabelDate[index, 7];
                                                                    textBox7.Text = LabelDate[index, 8];
                                                                    textBox8.Text = LabelDate[index, 9];
                                                                    textBox9.Text = LabelDate[index, 10];
                                                                    textBox10.Text = LabelDate[index, 11];
                                                                    textBox11.Text = LabelDate[index, 12];
                                                                    textBox12.Text = LabelDate[index, 13];
                                                                    break;
                                                                case "ListBox":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "：";

                                                                    index = Array.IndexOf(ListBoxName, label2.Text);
                                                                    label00.Text = ListBoxDate[index, 0];
                                                                    textBox1.Text = ListBoxDate[index, 2];
                                                                    textBox2.Text = ListBoxDate[index, 3];
                                                                    textBox3.Text = ListBoxDate[index, 4];
                                                                    textBox4.Text = ListBoxDate[index, 5];
                                                                    textBox5.Text = ListBoxDate[index, 6];
                                                                    textBox6.Text = ListBoxDate[index, 7];
                                                                    textBox7.Text = ListBoxDate[index, 8];
                                                                    textBox8.Text = ListBoxDate[index, 9];
                                                                    textBox9.Text = ListBoxDate[index, 10];
                                                                    textBox10.Text = ListBoxDate[index, 11];
                                                                    textBox11.Text = ListBoxDate[index, 12];
                                                                    textBox12.Text = ListBoxDate[index, 13];
                                                                    break;
                                                                case "MenuStrip":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "：";

                                                                    index = Array.IndexOf(MenuStripName, label2.Text);
                                                                    label00.Text = MenuStripDate[index, 0];
                                                                    textBox1.Text = MenuStripDate[index, 2];
                                                                    textBox2.Text = MenuStripDate[index, 3];
                                                                    textBox3.Text = MenuStripDate[index, 4];
                                                                    textBox4.Text = MenuStripDate[index, 5];
                                                                    textBox5.Text = MenuStripDate[index, 6];
                                                                    textBox6.Text = MenuStripDate[index, 7];
                                                                    textBox7.Text = MenuStripDate[index, 8];
                                                                    textBox8.Text = MenuStripDate[index, 9];
                                                                    textBox9.Text = MenuStripDate[index, 10];
                                                                    textBox10.Text = MenuStripDate[index, 11];
                                                                    textBox11.Text = MenuStripDate[index, 12];
                                                                    textBox12.Text = MenuStripDate[index, 13];
                                                                    break;
                                                                case "PictureBox":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "：";

                                                                    index = Array.IndexOf(PictureBoxName, label2.Text);
                                                                    label00.Text = PictureBoxDate[index, 0];
                                                                    textBox1.Text = PictureBoxDate[index, 2];
                                                                    textBox2.Text = PictureBoxDate[index, 3];
                                                                    textBox3.Text = PictureBoxDate[index, 4];
                                                                    textBox4.Text = PictureBoxDate[index, 5];
                                                                    textBox5.Text = PictureBoxDate[index, 6];
                                                                    textBox6.Text = PictureBoxDate[index, 7];
                                                                    textBox7.Text = PictureBoxDate[index, 8];
                                                                    textBox8.Text = PictureBoxDate[index, 9];
                                                                    textBox9.Text = PictureBoxDate[index, 10];
                                                                    textBox10.Text = PictureBoxDate[index, 11];
                                                                    textBox11.Text = PictureBoxDate[index, 12];
                                                                    textBox12.Text = PictureBoxDate[index, 13];
                                                                    break;
                                                                case "ProgressBar":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "：";

                                                                    index = Array.IndexOf(ProgressBarName, label2.Text);
                                                                    label00.Text = ProgressBarDate[index, 0];
                                                                    textBox1.Text = ProgressBarDate[index, 2];
                                                                    textBox2.Text = ProgressBarDate[index, 3];
                                                                    textBox3.Text = ProgressBarDate[index, 4];
                                                                    textBox4.Text = ProgressBarDate[index, 5];
                                                                    textBox5.Text = ProgressBarDate[index, 6];
                                                                    textBox6.Text = ProgressBarDate[index, 7];
                                                                    textBox7.Text = ProgressBarDate[index, 8];
                                                                    textBox8.Text = ProgressBarDate[index, 9];
                                                                    textBox9.Text = ProgressBarDate[index, 10];
                                                                    textBox10.Text = ProgressBarDate[index, 11];
                                                                    textBox11.Text = ProgressBarDate[index, 12];
                                                                    textBox12.Text = ProgressBarDate[index, 13];
                                                                    break;
                                                                case "RadioButton":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "：";

                                                                    index = Array.IndexOf(RadioButtonName, label2.Text);
                                                                    label00.Text = RadioButtonDate[index, 0];
                                                                    textBox1.Text = RadioButtonDate[index, 2];
                                                                    textBox2.Text = RadioButtonDate[index, 3];
                                                                    textBox3.Text = RadioButtonDate[index, 4];
                                                                    textBox4.Text = RadioButtonDate[index, 5];
                                                                    textBox5.Text = RadioButtonDate[index, 6];
                                                                    textBox6.Text = RadioButtonDate[index, 7];
                                                                    textBox7.Text = RadioButtonDate[index, 8];
                                                                    textBox8.Text = RadioButtonDate[index, 9];
                                                                    textBox9.Text = RadioButtonDate[index, 10];
                                                                    textBox10.Text = RadioButtonDate[index, 11];
                                                                    textBox11.Text = RadioButtonDate[index, 12];
                                                                    textBox12.Text = RadioButtonDate[index, 13];
                                                                    break;
                                                                case "RichTextBox":
                                                                    label3.Text = "X座標：";
                                                                    label4.Text = "Y座標：";
                                                                    label5.Text = "縦の長さ：";
                                                                    label6.Text = "横の長さ：";
                                                                    label7.Text = "テキスト：";
                                                                    label8.Text = "文字大きさ：";
                                                                    label9.Text = "フォント：";
                                                                    label9.Text = "文字色：";
                                                                    label10.Text = "固定方向：";
                                                                    label11.Text = "：";

                                                                    index = Array.IndexOf(RichTextBoxName, label2.Text);
                                                                    label00.Text = RichTextBoxDate[index, 0];
                                                                    textBox1.Text = RichTextBoxDate[index, 2];
                                                                    textBox2.Text = RichTextBoxDate[index, 3];
                                                                    textBox3.Text = RichTextBoxDate[index, 4];
                                                                    textBox4.Text = RichTextBoxDate[index, 5];
                                                                    textBox5.Text = RichTextBoxDate[index, 6];
                                                                    textBox6.Text = RichTextBoxDate[index, 7];
                                                                    textBox7.Text = RichTextBoxDate[index, 8];
                                                                    textBox8.Text = RichTextBoxDate[index, 9];
                                                                    textBox9.Text = RichTextBoxDate[index, 10];
                                                                    textBox10.Text = RichTextBoxDate[index, 11];
                                                                    textBox11.Text = RichTextBoxDate[index, 12];
                                                                    textBox12.Text = RichTextBoxDate[index, 13];
                                                                    break;

                                                            }
                                                        }



                                                        //☆

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }//ifの閉カッコ終了
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void プレビューToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            
            if (Hensu.selectNode != "Button")
            {
                if (Hensu.selectNode != "TextBox")
                {
                    if (Hensu.selectNode != "Label")
                    {
                        if (Hensu.selectNode != "CheckBox")
                        {
                            if (Hensu.selectNode != "ComboBox")
                            {
                                if (Hensu.selectNode != "ListBox")
                                {
                                    if (Hensu.selectNode != "MenuStrip")
                                    {
                                        if (Hensu.selectNode != "PictureBox")
                                        {
                                            if (Hensu.selectNode != "ProgressBar")
                                            {
                                                if (Hensu.selectNode != "RadioButton")
                                                {
                                                    if (Hensu.selectNode != "RichTextBox")
                                                    {
                                                        //☆
                                                        if (TreeViewSelect == 1)
                                                        {
                                                            //他のコントロール選択時、コントロールの値を保持する
                                                            switch (label00.Text)
                                                            {
                                                                case "Form":
                                                                    FormDate[2] = textBox1.Text;
                                                                    FormDate[3] = textBox2.Text;
                                                                    FormDate[4] = textBox3.Text;
                                                                    FormDate[5] = textBox4.Text;
                                                                    FormDate[6] = textBox5.Text;
                                                                    FormDate[7] = textBox6.Text;
                                                                    FormDate[8] = textBox7.Text;
                                                                    FormDate[9] = textBox8.Text;
                                                                    FormDate[10] = textBox9.Text;
                                                                    FormDate[11] = textBox10.Text;
                                                                    FormDate[12] = textBox11.Text;
                                                                    FormDate[13] = textBox14.Text;

                                                                    break;
                                                                case "Button":
                                                                    index = Array.IndexOf(ButtonName, label2.Text);


                                                                    ButtonDate[index, 2] = textBox1.Text;
                                                                    ButtonDate[index, 3] = textBox2.Text;
                                                                    ButtonDate[index, 4] = textBox3.Text;
                                                                    ButtonDate[index, 5] = textBox4.Text;
                                                                    ButtonDate[index, 6] = textBox5.Text;
                                                                    ButtonDate[index, 7] = textBox6.Text;
                                                                    ButtonDate[index, 8] = textBox7.Text;
                                                                    ButtonDate[index, 9] = textBox8.Text;
                                                                    ButtonDate[index, 10] = textBox9.Text;
                                                                    ButtonDate[index, 11] = textBox10.Text;
                                                                    ButtonDate[index, 12] = textBox11.Text;
                                                                    ButtonDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "TextBox":
                                                                    index = Array.IndexOf(TextBoxName, label2.Text);


                                                                    TextBoxDate[index, 2] = textBox1.Text;
                                                                    TextBoxDate[index, 3] = textBox2.Text;
                                                                    TextBoxDate[index, 4] = textBox3.Text;
                                                                    TextBoxDate[index, 5] = textBox4.Text;
                                                                    TextBoxDate[index, 6] = textBox5.Text;
                                                                    TextBoxDate[index, 7] = textBox6.Text;
                                                                    TextBoxDate[index, 8] = textBox7.Text;
                                                                    TextBoxDate[index, 9] = textBox8.Text;
                                                                    TextBoxDate[index, 10] = textBox9.Text;
                                                                    TextBoxDate[index, 11] = textBox10.Text;
                                                                    TextBoxDate[index, 12] = textBox11.Text;
                                                                    TextBoxDate[index, 13] = textBox12.Text;
                                                                    break;

                                                                case "CheckBox":
                                                                    index = Array.IndexOf(CheckBoxName, label2.Text);


                                                                    CheckBoxDate[index, 2] = textBox1.Text;
                                                                    CheckBoxDate[index, 3] = textBox2.Text;
                                                                    CheckBoxDate[index, 4] = textBox3.Text;
                                                                    CheckBoxDate[index, 5] = textBox4.Text;
                                                                    CheckBoxDate[index, 6] = textBox5.Text;
                                                                    CheckBoxDate[index, 7] = textBox6.Text;
                                                                    CheckBoxDate[index, 8] = textBox7.Text;
                                                                    CheckBoxDate[index, 9] = textBox8.Text;
                                                                    CheckBoxDate[index, 10] = textBox9.Text;
                                                                    CheckBoxDate[index, 11] = textBox10.Text;
                                                                    CheckBoxDate[index, 12] = textBox11.Text;
                                                                    CheckBoxDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "ComboBox":
                                                                    index = Array.IndexOf(ComboBoxName, label2.Text);


                                                                    ComboBoxDate[index, 2] = textBox1.Text;
                                                                    ComboBoxDate[index, 3] = textBox2.Text;
                                                                    ComboBoxDate[index, 4] = textBox3.Text;
                                                                    ComboBoxDate[index, 5] = textBox4.Text;
                                                                    ComboBoxDate[index, 6] = textBox5.Text;
                                                                    ComboBoxDate[index, 7] = textBox6.Text;
                                                                    ComboBoxDate[index, 8] = textBox7.Text;
                                                                    ComboBoxDate[index, 9] = textBox8.Text;
                                                                    ComboBoxDate[index, 10] = textBox9.Text;
                                                                    ComboBoxDate[index, 11] = textBox10.Text;
                                                                    ComboBoxDate[index, 12] = textBox11.Text;
                                                                    ComboBoxDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "Label":
                                                                    index = Array.IndexOf(LabelName, label2.Text);


                                                                    LabelDate[index, 2] = textBox1.Text;
                                                                    LabelDate[index, 3] = textBox2.Text;
                                                                    LabelDate[index, 4] = textBox3.Text;
                                                                    LabelDate[index, 5] = textBox4.Text;
                                                                    LabelDate[index, 6] = textBox5.Text;
                                                                    LabelDate[index, 7] = textBox6.Text;
                                                                    LabelDate[index, 8] = textBox7.Text;
                                                                    LabelDate[index, 9] = textBox8.Text;
                                                                    LabelDate[index, 10] = textBox9.Text;
                                                                    LabelDate[index, 11] = textBox10.Text;
                                                                    LabelDate[index, 12] = textBox11.Text;
                                                                    LabelDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "ListBox":
                                                                    index = Array.IndexOf(ListBoxName, label2.Text);


                                                                    ListBoxDate[index, 2] = textBox1.Text;
                                                                    ListBoxDate[index, 3] = textBox2.Text;
                                                                    ListBoxDate[index, 4] = textBox3.Text;
                                                                    ListBoxDate[index, 5] = textBox4.Text;
                                                                    ListBoxDate[index, 6] = textBox5.Text;
                                                                    ListBoxDate[index, 7] = textBox6.Text;
                                                                    ListBoxDate[index, 8] = textBox7.Text;
                                                                    ListBoxDate[index, 9] = textBox8.Text;
                                                                    ListBoxDate[index, 10] = textBox9.Text;
                                                                    ListBoxDate[index, 11] = textBox10.Text;
                                                                    ListBoxDate[index, 12] = textBox11.Text;
                                                                    ListBoxDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "MenuStrip":
                                                                    index = Array.IndexOf(MenuStripName, label2.Text);


                                                                    MenuStripDate[index, 2] = textBox1.Text;
                                                                    MenuStripDate[index, 3] = textBox2.Text;
                                                                    MenuStripDate[index, 4] = textBox3.Text;
                                                                    MenuStripDate[index, 5] = textBox4.Text;
                                                                    MenuStripDate[index, 6] = textBox5.Text;
                                                                    MenuStripDate[index, 7] = textBox6.Text;
                                                                    MenuStripDate[index, 8] = textBox7.Text;
                                                                    MenuStripDate[index, 9] = textBox8.Text;
                                                                    MenuStripDate[index, 10] = textBox9.Text;
                                                                    MenuStripDate[index, 11] = textBox10.Text;
                                                                    MenuStripDate[index, 12] = textBox11.Text;
                                                                    MenuStripDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "PictureBox":
                                                                    index = Array.IndexOf(PictureBoxName, label2.Text);


                                                                    PictureBoxDate[index, 2] = textBox1.Text;
                                                                    PictureBoxDate[index, 3] = textBox2.Text;
                                                                    PictureBoxDate[index, 4] = textBox3.Text;
                                                                    PictureBoxDate[index, 5] = textBox4.Text;
                                                                    PictureBoxDate[index, 6] = textBox5.Text;
                                                                    PictureBoxDate[index, 7] = textBox6.Text;
                                                                    PictureBoxDate[index, 8] = textBox7.Text;
                                                                    PictureBoxDate[index, 9] = textBox8.Text;
                                                                    PictureBoxDate[index, 10] = textBox9.Text;
                                                                    PictureBoxDate[index, 11] = textBox10.Text;
                                                                    PictureBoxDate[index, 12] = textBox11.Text;
                                                                    PictureBoxDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "ProgressBar":
                                                                    index = Array.IndexOf(ProgressBarName, label2.Text);


                                                                    ProgressBarDate[index, 2] = textBox1.Text;
                                                                    ProgressBarDate[index, 3] = textBox2.Text;
                                                                    ProgressBarDate[index, 4] = textBox3.Text;
                                                                    ProgressBarDate[index, 5] = textBox4.Text;
                                                                    ProgressBarDate[index, 6] = textBox5.Text;
                                                                    ProgressBarDate[index, 7] = textBox6.Text;
                                                                    ProgressBarDate[index, 8] = textBox7.Text;
                                                                    ProgressBarDate[index, 9] = textBox8.Text;
                                                                    ProgressBarDate[index, 10] = textBox9.Text;
                                                                    ProgressBarDate[index, 11] = textBox10.Text;
                                                                    ProgressBarDate[index, 12] = textBox11.Text;
                                                                    ProgressBarDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "RadioButton":
                                                                    index = Array.IndexOf(RadioButtonName, label2.Text);


                                                                    RadioButtonDate[index, 2] = textBox1.Text;
                                                                    RadioButtonDate[index, 3] = textBox2.Text;
                                                                    RadioButtonDate[index, 4] = textBox3.Text;
                                                                    RadioButtonDate[index, 5] = textBox4.Text;
                                                                    RadioButtonDate[index, 6] = textBox5.Text;
                                                                    RadioButtonDate[index, 7] = textBox6.Text;
                                                                    RadioButtonDate[index, 8] = textBox7.Text;
                                                                    RadioButtonDate[index, 9] = textBox8.Text;
                                                                    RadioButtonDate[index, 10] = textBox9.Text;
                                                                    RadioButtonDate[index, 11] = textBox10.Text;
                                                                    RadioButtonDate[index, 12] = textBox11.Text;
                                                                    RadioButtonDate[index, 13] = textBox12.Text;
                                                                    break;
                                                                case "RichTextBox":
                                                                    index = Array.IndexOf(RichTextBoxName, label2.Text);


                                                                    RichTextBoxDate[index, 2] = textBox1.Text;
                                                                    RichTextBoxDate[index, 3] = textBox2.Text;
                                                                    RichTextBoxDate[index, 4] = textBox3.Text;
                                                                    RichTextBoxDate[index, 5] = textBox4.Text;
                                                                    RichTextBoxDate[index, 6] = textBox5.Text;
                                                                    RichTextBoxDate[index, 7] = textBox6.Text;
                                                                    RichTextBoxDate[index, 8] = textBox7.Text;
                                                                    RichTextBoxDate[index, 9] = textBox8.Text;
                                                                    RichTextBoxDate[index, 10] = textBox9.Text;
                                                                    RichTextBoxDate[index, 11] = textBox10.Text;
                                                                    RichTextBoxDate[index, 12] = textBox11.Text;
                                                                    RichTextBoxDate[index, 13] = textBox12.Text;
                                                                    break;
                                                            }
                                                        

                                                        
                                                        }



                                                        //☆

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }//ifの閉カッコ終了
            String ENDe = "Form";
            //デザイナーファイル保存
            //各コントロール配列からデータ取得
            //CSVファイルに書き込むときに使うEncoding
            System.Text.Encoding enc =
                System.Text.Encoding.GetEncoding("Shift_JIS");

            //書き込むファイルを開く
            System.IO.StreamWriter sr =
                new System.IO.StreamWriter(Hensu.RunHikisu, false, enc);
            while (ENDe != "END")
            {
                int count = 0;
                switch (ENDe)
                {
                    case "Form":
                        sr.WriteLine("Form/" + FormDate[1] + "/" + FormDate[2] + "/" + FormDate[3] + "/" + FormDate[4] + "/"
                            + FormDate[5] + "/" + FormDate[6] + "/" + FormDate[7] + "/" + FormDate[8] + "/" + FormDate[9] + "/");
                        ENDe = "Button";

                        break;
                    case "Button":
                        if (Hensu.ButtonV != 0)
                        {
                            bool ButtonWriteLoop = false;
                            while (ButtonWriteLoop == false)
                            {
                                sr.WriteLine("Button/" + ButtonDate[count, 1] + "/" + ButtonDate[count, 2] + "/"
                                    + ButtonDate[count, 3] + "/" + ButtonDate[count, 4] + "/" + ButtonDate[count, 5]
                                    + "/" + ButtonDate[count, 6] + "/" + ButtonDate[count, 7] + "/" + ButtonDate[count, 8]
                                    + "/" + ButtonDate[count, 9] + "/" + ButtonDate[count, 10] + "/" + ButtonDate[count, 11]
                                    + "/" + ButtonDate[count, 12] + "/" + ButtonDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.ButtonV)
                                {
                                    ButtonWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "TextBox";
                        break;

                    case "TextBox":
                        if(Hensu.TextBoxV != 0)
                        {
                            bool TextBoxWriteLoop = false;
                            while (TextBoxWriteLoop == false)
                            {
                                sr.WriteLine("TextBox/" + TextBoxDate[count, 1] + "/" + TextBoxDate[count, 2] + "/"
                                    + TextBoxDate[count, 3] + "/" + TextBoxDate[count, 4] + "/" + TextBoxDate[count, 5]
                                    + "/" + TextBoxDate[count, 6] + "/" + TextBoxDate[count, 7] + "/" + TextBoxDate[count, 8]
                                    + "/" + TextBoxDate[count, 9] + "/" + TextBoxDate[count, 10] + "/" + TextBoxDate[count, 11]
                                    + "/" + TextBoxDate[count, 12] + "/" + TextBoxDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.TextBoxV)
                                {
                                    TextBoxWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "CheckBox";
                        break;

                    case "CheckBox":
                        if (Hensu.CheckBoxV != 0)
                        {
                            bool CheckBoxWriteLoop = false;
                            while (CheckBoxWriteLoop == false)
                            {
                                sr.WriteLine("CheckBox/" + CheckBoxDate[count, 1] + "/" + CheckBoxDate[count, 2] + "/"
                                    + CheckBoxDate[count, 3] + "/" + CheckBoxDate[count, 4] + "/" + CheckBoxDate[count, 5]
                                    + "/" + CheckBoxDate[count, 6] + "/" + CheckBoxDate[count, 7] + "/" + CheckBoxDate[count, 8]
                                    + "/" + CheckBoxDate[count, 9] + "/" + CheckBoxDate[count, 10] + "/" + CheckBoxDate[count, 11]
                                    + "/" + CheckBoxDate[count, 12] + "/" + CheckBoxDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.CheckBoxV)
                                {
                                    CheckBoxWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "ComboBox";
                        break;
                    case "ComboBox":
                        if (Hensu.ComboBoxV != 0)
                        {
                            bool ComboBoxWriteLoop = false;
                            while (ComboBoxWriteLoop == false)
                            {
                                sr.WriteLine("ComboBox/" + ComboBoxDate[count, 1] + "/" + ComboBoxDate[count, 2] + "/"
                                    + ComboBoxDate[count, 3] + "/" + ComboBoxDate[count, 4] + "/" + ComboBoxDate[count, 5]
                                    + "/" + ComboBoxDate[count, 6] + "/" + ComboBoxDate[count, 7] + "/" + ComboBoxDate[count, 8]
                                    + "/" + ComboBoxDate[count, 9] + "/" + ComboBoxDate[count, 10] + "/" + ComboBoxDate[count, 11]
                                    + "/" + ComboBoxDate[count, 12] + "/" + ComboBoxDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.ComboBoxV)
                                {
                                    ComboBoxWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "Label";
                        break;
                    case "Label":
                        if (Hensu.LabelV != 0)
                        {
                            bool LabelWriteLoop = false;
                            while (LabelWriteLoop == false)
                            {
                                sr.WriteLine("Label/" + LabelDate[count, 1] + "/" + LabelDate[count, 2] + "/"
                                    + LabelDate[count, 3] + "/" + LabelDate[count, 4] + "/" + LabelDate[count, 5]
                                    + "/" + LabelDate[count, 6] + "/" + LabelDate[count, 7] + "/" + LabelDate[count, 8]
                                    + "/" + LabelDate[count, 9] + "/" + LabelDate[count, 10] + "/" + LabelDate[count, 11]
                                    + "/" + LabelDate[count, 12] + "/" + LabelDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.LabelV)
                                {
                                    LabelWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "ListBox";
                        break;
                    case "ListBox":
                        if (Hensu.ListBoxV != 0)
                        {
                            bool ListBoxWriteLoop = false;
                            while (ListBoxWriteLoop == false)
                            {
                                sr.WriteLine("ListBox/" + ListBoxDate[count, 1] + "/" + ListBoxDate[count, 2] + "/"
                                    + ListBoxDate[count, 3] + "/" + ListBoxDate[count, 4] + "/" + ListBoxDate[count, 5]
                                    + "/" + ListBoxDate[count, 6] + "/" + ListBoxDate[count, 7] + "/" + ListBoxDate[count, 8]
                                    + "/" + ListBoxDate[count, 9] + "/" + ListBoxDate[count, 10] + "/" + ListBoxDate[count, 11]
                                    + "/" + ListBoxDate[count, 12] + "/" + ListBoxDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.ListBoxV)
                                {
                                    ListBoxWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "MenuStrip";
                        break;
                    case "MenuStrip":
                        if (Hensu.MenuStripV != 0)
                        {
                            bool MenuStripWriteLoop = false;
                            while (MenuStripWriteLoop == false)
                            {
                                sr.WriteLine("MenuStrip/" + MenuStripDate[count, 1] + "/" + MenuStripDate[count, 2] + "/"
                                    + MenuStripDate[count, 3] + "/" + MenuStripDate[count, 4] + "/" + MenuStripDate[count, 5]
                                    + "/" + MenuStripDate[count, 6] + "/" + MenuStripDate[count, 7] + "/" + MenuStripDate[count, 8]
                                    + "/" + MenuStripDate[count, 9] + "/" + MenuStripDate[count, 10] + "/" + MenuStripDate[count, 11]
                                    + "/" + MenuStripDate[count, 12] + "/" + MenuStripDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.MenuStripV)
                                {
                                    MenuStripWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "PictureBox";
                        break;
                    case "PictureBox":
                        if (Hensu.PictureBoxV != 0)
                        {
                            bool PictureBoxWriteLoop = false;
                            while (PictureBoxWriteLoop == false)
                            {
                                sr.WriteLine("PictureBox/" + PictureBoxDate[count, 1] + "/" + PictureBoxDate[count, 2] + "/"
                                    + PictureBoxDate[count, 3] + "/" + PictureBoxDate[count, 4] + "/" + PictureBoxDate[count, 5]
                                    + "/" + PictureBoxDate[count, 6] + "/" + PictureBoxDate[count, 7] + "/" + PictureBoxDate[count, 8]
                                    + "/" + PictureBoxDate[count, 9] + "/" + PictureBoxDate[count, 10] + "/" + PictureBoxDate[count, 11]
                                    + "/" + PictureBoxDate[count, 12] + "/" + PictureBoxDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.PictureBoxV)
                                {
                                    PictureBoxWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "ProgressBar";
                        break;
                    case "ProgressBar":
                        if (Hensu.ProgressBarV != 0)
                        {
                            bool ProgressBarWriteLoop = false;
                            while (ProgressBarWriteLoop == false)
                            {
                                sr.WriteLine("ProgressBar/" + ProgressBarDate[count, 1] + "/" + ProgressBarDate[count, 2] + "/"
                                    + ProgressBarDate[count, 3] + "/" + ProgressBarDate[count, 4] + "/" + ProgressBarDate[count, 5]
                                    + "/" + ProgressBarDate[count, 6] + "/" + ProgressBarDate[count, 7] + "/" + ProgressBarDate[count, 8]
                                    + "/" + ProgressBarDate[count, 9] + "/" + ProgressBarDate[count, 10] + "/" + ProgressBarDate[count, 11]
                                    + "/" + ProgressBarDate[count, 12] + "/" + ProgressBarDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.ProgressBarV)
                                {
                                    ProgressBarWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "RadioButton";
                        break;
                    case "RadioButton":
                        if (Hensu.RadioButtonV != 0)
                        {
                            bool RadioButtonWriteLoop = false;
                            while (RadioButtonWriteLoop == false)
                            {
                                sr.WriteLine("RadioButton/" + RadioButtonDate[count, 1] + "/" + RadioButtonDate[count, 2] + "/"
                                    + RadioButtonDate[count, 3] + "/" + RadioButtonDate[count, 4] + "/" + RadioButtonDate[count, 5]
                                    + "/" + RadioButtonDate[count, 6] + "/" + RadioButtonDate[count, 7] + "/" + RadioButtonDate[count, 8]
                                    + "/" + RadioButtonDate[count, 9] + "/" + RadioButtonDate[count, 10] + "/" + RadioButtonDate[count, 11]
                                    + "/" + RadioButtonDate[count, 12] + "/" + RadioButtonDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.RadioButtonV)
                                {
                                    RadioButtonWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "RichTextBox";
                        break;
                    case "RichTextBox":
                        if (Hensu.RichTextBoxV != 0)
                        {
                            bool RichTextBoxWriteLoop = false;
                            while (RichTextBoxWriteLoop == false)
                            {
                                sr.WriteLine("RichTextBox/" + RichTextBoxDate[count, 1] + "/" + RichTextBoxDate[count, 2] + "/"
                                    + RichTextBoxDate[count, 3] + "/" + RichTextBoxDate[count, 4] + "/" + RichTextBoxDate[count, 5]
                                    + "/" + RichTextBoxDate[count, 6] + "/" + RichTextBoxDate[count, 7] + "/" + RichTextBoxDate[count, 8]
                                    + "/" + RichTextBoxDate[count, 9] + "/" + RichTextBoxDate[count, 10] + "/" + RichTextBoxDate[count, 11]
                                    + "/" + RichTextBoxDate[count, 12] + "/" + RichTextBoxDate[count, 13] + "/");
                                count = count + 1;
                                if (count == Hensu.RichTextBoxV)
                                {
                                    RichTextBoxWriteLoop = true;
                                }
                            }
                        }
                        ENDe = "END";
                        break;

                }
            }
            //閉じる
            sr.Close();

            Form2 f = new Form2();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void コントロール追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //コントロール追加
            NewControle f = new NewControle();
            f.ShowDialog(this);
            f.Dispose();
            int SearchNamePoint = 1;

            switch (Hensu.NewControle)
            {
                case "Button":
                    SearchNamePoint= Array.IndexOf(ButtonName, Hensu.NewControleName);
                    break;
                case "TextBox":
                    SearchNamePoint = Array.IndexOf(TextBoxName, Hensu.NewControleName);
                    break;
                case "CheckBox":
                    SearchNamePoint = Array.IndexOf(CheckBoxName, Hensu.NewControleName);
                    break;
                case "ComboBox":
                    SearchNamePoint = Array.IndexOf(ComboBoxName, Hensu.NewControleName);
                    break;
                case "Label":
                    SearchNamePoint = Array.IndexOf(LabelName, Hensu.NewControleName);
                    break;
                case "ListBox":
                    SearchNamePoint = Array.IndexOf(ListBoxName, Hensu.NewControleName);
                    break;
                case "MenuStrip":
                    SearchNamePoint = Array.IndexOf(MenuStripName, Hensu.NewControleName);
                    break;
                case "PictureBox":
                    SearchNamePoint = Array.IndexOf(PictureBoxName, Hensu.NewControleName);
                    break;
                case "ProgressBar":
                    SearchNamePoint = Array.IndexOf(ProgressBarName, Hensu.NewControleName);
                    break;
                case "RadioButton":
                    SearchNamePoint = Array.IndexOf(RadioButtonName, Hensu.NewControleName);
                    break;
                case "RichTextBox":
                    SearchNamePoint = Array.IndexOf(RichTextBoxName, Hensu.NewControleName);
                    break;

                default:

                    break;
            }
            if (SearchNamePoint == -1)
            {
                SearchNamePoint= Array.IndexOf(Yoyakugo, Hensu.NewControleName);
            }
            if (Hensu.NewControleName == "")
            {

                MessageBox.Show("コントロールの名称が指定されていません。\n再度やり直してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if(SearchNamePoint != -1)
                {
                    MessageBox.Show("予約語もしくは既存のコントロールと同一の名称が\n追加する名称に指定されました。\n再度やり直してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    switch (Hensu.NewControle)
                    {
                        case "Button":
                            ButtonDate[Hensu.ButtonV, 0] = Hensu.NewControle;
                            ButtonDate[Hensu.ButtonV, 1] = Hensu.NewControleName;
                            ButtonName[Hensu.ButtonV] = Hensu.NewControleName;

                            Hensu.ButtonV = Hensu.ButtonV + 1;

                            break;

                        case "TextBox":
                            TextBoxDate[Hensu.TextBoxV, 0] = Hensu.NewControle;
                            TextBoxDate[Hensu.TextBoxV, 1] = Hensu.NewControleName;
                            TextBoxName[Hensu.TextBoxV] = Hensu.NewControleName;

                            Hensu.TextBoxV = Hensu.TextBoxV + 1;
                            break;
                        case "CheckBox":
                            CheckBoxDate[Hensu.CheckBoxV, 0] = Hensu.NewControle;
                            CheckBoxDate[Hensu.CheckBoxV, 1] = Hensu.NewControleName;
                            CheckBoxName[Hensu.CheckBoxV] = Hensu.NewControleName;

                            Hensu.CheckBoxV = Hensu.CheckBoxV + 1;
                            break;
                        case "ComboBox":
                            ComboBoxDate[Hensu.ComboBoxV, 0] = Hensu.NewControle;
                            ComboBoxDate[Hensu.ComboBoxV, 1] = Hensu.NewControleName;
                            ComboBoxName[Hensu.ComboBoxV] = Hensu.NewControleName;

                            Hensu.ComboBoxV = Hensu.ComboBoxV + 1;
                            break;
                        case "Label":
                            LabelDate[Hensu.LabelV, 0] = Hensu.NewControle;
                            LabelDate[Hensu.LabelV, 1] = Hensu.NewControleName;
                            LabelName[Hensu.LabelV] = Hensu.NewControleName;

                            Hensu.LabelV = Hensu.LabelV + 1;
                            break;
                        case "ListBox":
                            ListBoxDate[Hensu.ListBoxV, 0] = Hensu.NewControle;
                            ListBoxDate[Hensu.ListBoxV, 1] = Hensu.NewControleName;
                            ListBoxName[Hensu.ListBoxV] = Hensu.NewControleName;

                            Hensu.ListBoxV = Hensu.ListBoxV + 1;
                            break;
                        case "MenuStrip":
                            MenuStripDate[Hensu.MenuStripV, 0] = Hensu.NewControle;
                            MenuStripDate[Hensu.MenuStripV, 1] = Hensu.NewControleName;
                            MenuStripName[Hensu.MenuStripV] = Hensu.NewControleName;

                            Hensu.MenuStripV = Hensu.MenuStripV + 1;
                            break;
                        case "PictureBox":
                            PictureBoxDate[Hensu.PictureBoxV, 0] = Hensu.NewControle;
                            PictureBoxDate[Hensu.PictureBoxV, 1] = Hensu.NewControleName;
                            PictureBoxName[Hensu.PictureBoxV] = Hensu.NewControleName;

                            Hensu.PictureBoxV = Hensu.PictureBoxV + 1;
                            break;
                        case "ProgressBar":
                            ProgressBarDate[Hensu.ProgressBarV, 0] = Hensu.NewControle;
                            ProgressBarDate[Hensu.ProgressBarV, 1] = Hensu.NewControleName;
                            ProgressBarName[Hensu.ProgressBarV] = Hensu.NewControleName;

                            Hensu.ProgressBarV = Hensu.ProgressBarV + 1;
                            break;
                        case "RadioButton":
                            RadioButtonDate[Hensu.RadioButtonV, 0] = Hensu.NewControle;
                            RadioButtonDate[Hensu.RadioButtonV, 1] = Hensu.NewControleName;
                            RadioButtonName[Hensu.RadioButtonV] = Hensu.NewControleName;

                            Hensu.RadioButtonV = Hensu.RadioButtonV + 1;
                            break;
                        case "RichTextBox":
                            RichTextBoxDate[Hensu.RichTextBoxV, 0] = Hensu.NewControle;
                            RichTextBoxDate[Hensu.RichTextBoxV, 1] = Hensu.NewControleName;
                            RichTextBoxName[Hensu.RichTextBoxV] = Hensu.NewControleName;

                            Hensu.RichTextBoxV = Hensu.RichTextBoxV + 1;
                            break;



                        default:
                            MessageBox.Show("存在しないコントロールを指定されました。\n再度やり直してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                    }
                    String ENDe = "Form";
                    //デザイナーファイル保存
                    //各コントロール配列からデータ取得
                    //CSVファイルに書き込むときに使うEncoding
                    System.Text.Encoding enc =
                        System.Text.Encoding.GetEncoding("Shift_JIS");

                    //書き込むファイルを開く
                    System.IO.StreamWriter sr =
                        new System.IO.StreamWriter(Hensu.RunHikisu, false, enc);
                    while (ENDe != "END")
                    {
                        int count = 0;
                        switch (ENDe)
                        {
                            case "Form":
                                sr.WriteLine("Form/" + FormDate[1] + "/" + FormDate[2] + "/" + FormDate[3] + "/" + FormDate[4] + "/"
                                    + FormDate[5] + "/" + FormDate[6] + "/" + FormDate[7] + "/" + FormDate[8] + "/" + FormDate[9] + "/");
                                ENDe = "Button";

                                break;
                            case "Button":
                                bool ButtonWriteLoop = false;
                                if (Hensu.ButtonV != 0)
                                {
                                    while (ButtonWriteLoop == false)
                                    {

                                        sr.WriteLine("Button/" + ButtonDate[count, 1] + "/" + ButtonDate[count, 2] + "/"
                                            + ButtonDate[count, 3] + "/" + ButtonDate[count, 4] + "/" + ButtonDate[count, 5]
                                            + "/" + ButtonDate[count, 6] + "/" + ButtonDate[count, 7] + "/" + ButtonDate[count, 8]
                                            + "/" + ButtonDate[count, 9] + "/" + ButtonDate[count, 10] + "/" + ButtonDate[count, 11]
                                            + "/" + ButtonDate[count, 12] + "/" + ButtonDate[count, 13] + "/");


                                        count = count + 1;
                                        if (count == Hensu.ButtonV)
                                        {
                                            ButtonWriteLoop = true;
                                        }

                                    }
                                }
                                
                                ENDe = "TextBox";

                                break;

                            case "TextBox":
                                bool TextBoxWriteLoop = false;
                                if (Hensu.TextBoxV != 0)
                                {
                                    while (TextBoxWriteLoop == false)
                                    {
                                        sr.WriteLine("TextBox/" + TextBoxDate[count, 1] + "/" + TextBoxDate[count, 2] + "/"
                                            + TextBoxDate[count, 3] + "/" + TextBoxDate[count, 4] + "/" + TextBoxDate[count, 5]
                                            + "/" + TextBoxDate[count, 6] + "/" + TextBoxDate[count, 7] + "/" + TextBoxDate[count, 8]
                                            + "/" + TextBoxDate[count, 9] + "/" + TextBoxDate[count, 10] + "/" + TextBoxDate[count, 11]
                                            + "/" + TextBoxDate[count, 12] + "/" + TextBoxDate[count, 13] + "/");


                                        count = count + 1;
                                        if (count == Hensu.TextBoxV)
                                        {
                                            TextBoxWriteLoop = true;
                                        }

                                    }
                                }
                                

                                ENDe = "CheckBox";
                                break;
                            case "CheckBox":
                                bool CheckBoxWriteLoop = false;
                                if (Hensu.CheckBoxV != 0)
                                {
                                    while (CheckBoxWriteLoop == false)
                                    {
                                        sr.WriteLine("CheckBox/" + CheckBoxDate[count, 1] + "/" + CheckBoxDate[count, 2] + "/"
                                            + CheckBoxDate[count, 3] + "/" + CheckBoxDate[count, 4] + "/" + CheckBoxDate[count, 5]
                                            + "/" + CheckBoxDate[count, 6] + "/" + CheckBoxDate[count, 7] + "/" + CheckBoxDate[count, 8]
                                            + "/" + CheckBoxDate[count, 9] + "/" + CheckBoxDate[count, 10] + "/" + CheckBoxDate[count, 11]
                                            + "/" + CheckBoxDate[count, 12] + "/" + CheckBoxDate[count, 13] + "/");


                                        count = count + 1;
                                        if (count == Hensu.CheckBoxV)
                                        {
                                            CheckBoxWriteLoop = true;
                                        }

                                    }
                                }
                                

                                ENDe = "ComboBox";
                                break;
                            case "ComboBox":
                                if (Hensu.ComboBoxV != 0)
                                {
                                    bool ComboBoxWriteLoop = false;
                                    while (ComboBoxWriteLoop == false)
                                    {
                                        sr.WriteLine("ComboBox/" + ComboBoxDate[count, 1] + "/" + ComboBoxDate[count, 2] + "/"
                                            + ComboBoxDate[count, 3] + "/" + ComboBoxDate[count, 4] + "/" + ComboBoxDate[count, 5]
                                            + "/" + ComboBoxDate[count, 6] + "/" + ComboBoxDate[count, 7] + "/" + ComboBoxDate[count, 8]
                                            + "/" + ComboBoxDate[count, 9] + "/" + ComboBoxDate[count, 10] + "/" + ComboBoxDate[count, 11]
                                            + "/" + ComboBoxDate[count, 12] + "/" + ComboBoxDate[count, 13] + "/");
                                        count = count + 1;
                                        if (count == Hensu.ComboBoxV)
                                        {
                                            ComboBoxWriteLoop = true;
                                        }
                                    }
                                }
                                ENDe = "Label";
                                break;
                            case "Label":
                                if (Hensu.LabelV != 0)
                                {
                                    bool LabelWriteLoop = false;
                                    while (LabelWriteLoop == false)
                                    {
                                        sr.WriteLine("Label/" + LabelDate[count, 1] + "/" + LabelDate[count, 2] + "/"
                                            + LabelDate[count, 3] + "/" + LabelDate[count, 4] + "/" + LabelDate[count, 5]
                                            + "/" + LabelDate[count, 6] + "/" + LabelDate[count, 7] + "/" + LabelDate[count, 8]
                                            + "/" + LabelDate[count, 9] + "/" + LabelDate[count, 10] + "/" + LabelDate[count, 11]
                                            + "/" + LabelDate[count, 12] + "/" + LabelDate[count, 13] + "/");
                                        count = count + 1;
                                        if (count == Hensu.LabelV)
                                        {
                                            LabelWriteLoop = true;
                                        }
                                    }
                                }
                                ENDe = "ListBox";
                                break;
                            case "ListBox":
                                if (Hensu.ListBoxV != 0)
                                {
                                    bool ListBoxWriteLoop = false;
                                    while (ListBoxWriteLoop == false)
                                    {
                                        sr.WriteLine("ListBox/" + ListBoxDate[count, 1] + "/" + ListBoxDate[count, 2] + "/"
                                            + ListBoxDate[count, 3] + "/" + ListBoxDate[count, 4] + "/" + ListBoxDate[count, 5]
                                            + "/" + ListBoxDate[count, 6] + "/" + ListBoxDate[count, 7] + "/" + ListBoxDate[count, 8]
                                            + "/" + ListBoxDate[count, 9] + "/" + ListBoxDate[count, 10] + "/" + ListBoxDate[count, 11]
                                            + "/" + ListBoxDate[count, 12] + "/" + ListBoxDate[count, 13] + "/");
                                        count = count + 1;
                                        if (count == Hensu.ListBoxV)
                                        {
                                            ListBoxWriteLoop = true;
                                        }
                                    }
                                }
                                ENDe = "MenuStrip";
                                break;
                            case "MenuStrip":
                                if (Hensu.MenuStripV != 0)
                                {
                                    bool MenuStripWriteLoop = false;
                                    while (MenuStripWriteLoop == false)
                                    {
                                        sr.WriteLine("MenuStrip/" + MenuStripDate[count, 1] + "/" + MenuStripDate[count, 2] + "/"
                                            + MenuStripDate[count, 3] + "/" + MenuStripDate[count, 4] + "/" + MenuStripDate[count, 5]
                                            + "/" + MenuStripDate[count, 6] + "/" + MenuStripDate[count, 7] + "/" + MenuStripDate[count, 8]
                                            + "/" + MenuStripDate[count, 9] + "/" + MenuStripDate[count, 10] + "/" + MenuStripDate[count, 11]
                                            + "/" + MenuStripDate[count, 12] + "/" + MenuStripDate[count, 13] + "/");
                                        count = count + 1;
                                        if (count == Hensu.MenuStripV)
                                        {
                                            MenuStripWriteLoop = true;
                                        }
                                    }
                                }
                                ENDe = "PictureBox";
                                break;
                            case "PictureBox":
                                if (Hensu.PictureBoxV != 0)
                                {
                                    bool PictureBoxWriteLoop = false;
                                    while (PictureBoxWriteLoop == false)
                                    {
                                        sr.WriteLine("PictureBox/" + PictureBoxDate[count, 1] + "/" + PictureBoxDate[count, 2] + "/"
                                            + PictureBoxDate[count, 3] + "/" + PictureBoxDate[count, 4] + "/" + PictureBoxDate[count, 5]
                                            + "/" + PictureBoxDate[count, 6] + "/" + PictureBoxDate[count, 7] + "/" + PictureBoxDate[count, 8]
                                            + "/" + PictureBoxDate[count, 9] + "/" + PictureBoxDate[count, 10] + "/" + PictureBoxDate[count, 11]
                                            + "/" + PictureBoxDate[count, 12] + "/" + PictureBoxDate[count, 13] + "/");
                                        count = count + 1;
                                        if (count == Hensu.PictureBoxV)
                                        {
                                            PictureBoxWriteLoop = true;
                                        }
                                    }
                                }
                                ENDe = "ProgressBar";
                                break;
                            case "ProgressBar":
                                if (Hensu.ProgressBarV != 0)
                                {
                                    bool ProgressBarWriteLoop = false;
                                    while (ProgressBarWriteLoop == false)
                                    {
                                        sr.WriteLine("ProgressBar/" + ProgressBarDate[count, 1] + "/" + ProgressBarDate[count, 2] + "/"
                                            + ProgressBarDate[count, 3] + "/" + ProgressBarDate[count, 4] + "/" + ProgressBarDate[count, 5]
                                            + "/" + ProgressBarDate[count, 6] + "/" + ProgressBarDate[count, 7] + "/" + ProgressBarDate[count, 8]
                                            + "/" + ProgressBarDate[count, 9] + "/" + ProgressBarDate[count, 10] + "/" + ProgressBarDate[count, 11]
                                            + "/" + ProgressBarDate[count, 12] + "/" + ProgressBarDate[count, 13] + "/");
                                        count = count + 1;
                                        if (count == Hensu.ProgressBarV)
                                        {
                                            ProgressBarWriteLoop = true;
                                        }
                                    }
                                }
                                ENDe = "RadioButton";
                                break;
                            case "RadioButton":
                                if (Hensu.RadioButtonV != 0)
                                {
                                    bool RadioButtonWriteLoop = false;
                                    while (RadioButtonWriteLoop == false)
                                    {
                                        sr.WriteLine("RadioButton/" + RadioButtonDate[count, 1] + "/" + RadioButtonDate[count, 2] + "/"
                                            + RadioButtonDate[count, 3] + "/" + RadioButtonDate[count, 4] + "/" + RadioButtonDate[count, 5]
                                            + "/" + RadioButtonDate[count, 6] + "/" + RadioButtonDate[count, 7] + "/" + RadioButtonDate[count, 8]
                                            + "/" + RadioButtonDate[count, 9] + "/" + RadioButtonDate[count, 10] + "/" + RadioButtonDate[count, 11]
                                            + "/" + RadioButtonDate[count, 12] + "/" + RadioButtonDate[count, 13] + "/");
                                        count = count + 1;
                                        if (count == Hensu.RadioButtonV)
                                        {
                                            RadioButtonWriteLoop = true;
                                        }
                                    }
                                }
                                ENDe = "RichTextBox";
                                break;
                            case "RichTextBox":
                                if (Hensu.RichTextBoxV != 0)
                                {
                                    bool RichTextBoxWriteLoop = false;
                                    while (RichTextBoxWriteLoop == false)
                                    {
                                        sr.WriteLine("RichTextBox/" + RichTextBoxDate[count, 1] + "/" + RichTextBoxDate[count, 2] + "/"
                                            + RichTextBoxDate[count, 3] + "/" + RichTextBoxDate[count, 4] + "/" + RichTextBoxDate[count, 5]
                                            + "/" + RichTextBoxDate[count, 6] + "/" + RichTextBoxDate[count, 7] + "/" + RichTextBoxDate[count, 8]
                                            + "/" + RichTextBoxDate[count, 9] + "/" + RichTextBoxDate[count, 10] + "/" + RichTextBoxDate[count, 11]
                                            + "/" + RichTextBoxDate[count, 12] + "/" + RichTextBoxDate[count, 13] + "/");
                                        count = count + 1;
                                        if (count == Hensu.RichTextBoxV)
                                        {
                                            RichTextBoxWriteLoop = true;
                                        }
                                    }
                                }
                                ENDe = "END";
                                break;
                        }





                    }
                    //閉じる
                    sr.Close();
                    String Erorr = TreeViewAndShowForm2(Hensu.RunHikisu);
                }
                
            }

            
        }
    }
}