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
            //コントロールの個数格納用変数
            


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
                        TargetControle = "END";
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
            if(e.Node.Text != "Button")
            {
                if (e.Node.Text != "TextBox")
                {
                    if (e.Node.Text != "Label")
                    {
                        if (e.Node.Text != "CheckBox")
                        {
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
                                }
                            }
                            TreeViewSelect = 1;
                            label2.Text = e.Node.Text;
                            if(e.Node.Text == "Form")
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
                                        label00.Text = ButtonDate[index,0];
                                        textBox1.Text = ButtonDate[index,2];
                                        textBox2.Text = ButtonDate[index,3];
                                        textBox3.Text = ButtonDate[index,4];
                                        textBox4.Text = ButtonDate[index,5];
                                        textBox5.Text = ButtonDate[index,6];
                                        textBox6.Text = ButtonDate[index,7];
                                        textBox7.Text = ButtonDate[index,8];
                                        textBox8.Text = ButtonDate[index,9];
                                        textBox9.Text = ButtonDate[index,10];
                                        textBox10.Text = ButtonDate[index,11];
                                        textBox11.Text = ButtonDate[index,12];
                                        textBox12.Text = ButtonDate[index,13];
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
                                ENDe = "TextBox";

                                break;

                            case "TextBox":
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

                                ENDe = "CheckBox";
                                break;
                            case "CheckBox":
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
