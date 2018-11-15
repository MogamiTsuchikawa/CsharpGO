using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIconverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] args = Environment.GetCommandLineArgs();
            String ProjectPath;
            if (args.Length < 2)
            {
                ProjectPath = System.IO.Directory.GetCurrentDirectory();
            }
            else
            {
                ProjectPath = args[0];
            }
            System.IO.StreamReader now = new System.IO.StreamReader(
    @"now.txt",
    System.Text.Encoding.GetEncoding("shift_jis"));
            //内容をすべて読み込む
            ProjectPath = now.ReadToEnd();
            //閉じる
            now.Close();
            String[] files = System.IO.Directory.GetFiles(ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
            
            files = System.IO.Directory.GetFiles(ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
            if (files.Length != 0)
            {
                for(int i = 0;i < files.Length; ++i)
                {
                    switch (System.IO.Path.GetExtension(files[i]))
                    {
                        case ".cs":

                            System.IO.File.Copy(files[i], ProjectPath + @"\build\" + System.IO.Path.GetFileName(files[i]), true);
                            break;
                        case ".guit":
                            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                                ProjectPath + @"\build\" + System.IO.Path.GetFileNameWithoutExtension(files[i])+"D.cs",
                                false,
                                System.Text.Encoding.GetEncoding("shift_jis"));
                            sw.WriteLine("using System;");
                            sw.WriteLine("using System.CodeDom;");
                            sw.WriteLine("using System.CodeDom.Compiler;");
                            sw.WriteLine("using System.Reflection;");
                            sw.WriteLine("using System.Windows.Forms;");
                            sw.WriteLine("using System.Drawing;");
                            
                            System.IO.StreamReader fsr = new System.IO.StreamReader(
                                ProjectPath+@"\ProjectInfo.projectt",
                                System.Text.Encoding.GetEncoding("shift_jis"));
                            String line = fsr.ReadLine();//一行目は捨てる
                            String ProjectName = fsr.ReadLine();
                            ProjectName = ProjectName.Replace("\r", "").Replace("\n", "");
                            fsr.Close();
                            sw.WriteLine("namespace "+ProjectName);
                            sw.WriteLine("{");
                            sw.WriteLine("public partial class "+System.IO.Path.GetFileNameWithoutExtension(files[i])+" : Form");
                            sw.WriteLine("{");
                            sw.WriteLine("private void InitializeComponent(){");
                            System.IO.StreamReader sr = new System.IO.StreamReader(
                                files[i],
                                System.Text.Encoding.GetEncoding("shift_jis"));
                            System.IO.StreamReader sr1 = new System.IO.StreamReader(
                                ProjectPath + @"\source\" + System.IO.Path.GetFileNameWithoutExtension(files[i])+".eve",
                                System.Text.Encoding.GetEncoding("shift_jis"));
                            string[,] Events = new String[999, 50];
                            int count = 0;
                            while (sr1.Peek() > -1)
                            {
                                string[] keep = sr1.ReadLine().Split('/');
                                int count1 = 0;
                                while (keep[count1]!=";")
                                {
                                    Events[count, count1] = keep[count1];
                                    ++count1;
                                }
                                Events[count, count1] = ";";
                                ++count;
                            }
                            while (sr.Peek() > -1)
                            {
                                
                                line = sr.ReadLine();
                                String[] Items = line.Split('/');
                                bool read = false;
                                int keepcount;
                                string[] targetEve = new String[50];
                                switch (Items[0])
                                {
                                    case "Form":
                                        sw.WriteLine(@"this.Text = """+Items[6]+@""";");
                                        sw.WriteLine("ClientSize = new Size("+Items[5]+","+Items[4]+");");
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount, count] != ";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine("this." + targetEve[count] + " += new System.EventHandler(this." + Items[1] + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        if (Items[9] != "")
                                        {
                                            sw.WriteLine("this.BackColor = System.Drawing.Color."+Items[9]+";");
                                        }
                                        break;
                                    case "Button":
                                        sw.WriteLine("Button "+Items[1]+" = new Button();");
                                        sw.WriteLine(Items[1] +".Location = new Point("+Items[2]+","+Items[3]+");");
                                        if (Items[4] != "")
                                        {
                                            if (Items[5] != "")
                                            {
                                                sw.WriteLine(Items[1] + ".Size = new Size(" + Items[4] + "," + Items[5] + ");");
                                            }
                                        }
                                        sw.WriteLine(Items[1]+@".Font = new Font("""+Items[8]+@""","+Items[7]+");");
                                        sw.WriteLine(Items[1]+@".Text = """+Items[6]+@""";");
                                        //
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount,count]!=";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine(Items[1]+"."+targetEve[count]+" += new System.EventHandler("+Items[1]+"_"+targetEve[count]+");");
                                            ++count;
                                        }
                                        //イベント関連記述終了

                                        if (Items[9] != "")
                                        {
                                            sw.WriteLine( Items[1] + ".ForeColor = Color." + Items[9] + ";");
                                        }
                                        if (Items[10] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".BackColor = Color." + Items[10] + ";");
                                        }

                                        sw.WriteLine("this.Controls.Add("+Items[1]+");");

                                        break;
                                    case "TextBox":
                                        sw.WriteLine("TextBox"+Items[1]+" = new TextBox();");
                                        sw.WriteLine(Items[1] + ".Location = new Point(" + Items[2] + "," + Items[3] + ");");
                                        if (Items[4] != "")
                                        {
                                            if (Items[5] != "")
                                            {
                                                sw.WriteLine(Items[1] + ".Size = new Size(" + Items[4] + "," + Items[5] + ");");
                                            }
                                        }
                                        sw.WriteLine(Items[1] + @".Text = """ + Items[6] + @""";");
                                        if (Items[9] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".ForeColor = Color." + Items[9] + ";");
                                        }
                                        if (Items[10] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".BackColor = Color." + Items[10] + ";");
                                        }
                                        if (Items[11] == "true")
                                        {
                                            //複数行
                                            sw.WriteLine(Items[1]+".MultiLine = true;");
                                        }
                                        sw.WriteLine(Items[1] + @".Font = new Font(""" + Items[8] + @"""," + Items[7] + ");");
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount, count] != ";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine(Items[1] + "." + targetEve[count] + " += new System.EventHandler(" + Items[1] + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + Items[1] + ");");
                                        sw.WriteLine("");
                                        sw.WriteLine("");
                                        break;
                                    case "CheckBox":
                                        sw.WriteLine("CheckBox" + Items[1] + " = new CheckBox();");
                                        sw.WriteLine(Items[1] + ".Location = new Point(" + Items[2] + "," + Items[3] + ");");
                                        if (Items[4] != "")
                                        {
                                            if (Items[5] != "")
                                            {
                                                sw.WriteLine(Items[1] + ".Size = new Size(" + Items[4] + "," + Items[5] + ");");
                                            }
                                        }
                                        sw.WriteLine(Items[1] + @".Text = """ + Items[6] + @""";");
                                        if (Items[9] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".ForeColor = Color." + Items[9] + ";");
                                        }
                                        if (Items[10] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".BackColor = Color." + Items[10] + ";");
                                        }
                                        sw.WriteLine(Items[1] + @".Font = new Font(""" + Items[8] + @"""," + Items[7] + ");");
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount, count] != ";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine(Items[1] + "." + targetEve[count] + " += new System.EventHandler(" + Items[1] + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + Items[1] + ");");
                                        break;
                                    case "ComboBox":
                                        sw.WriteLine("ComboBox" + Items[1] + " = new ComboBox();");
                                        sw.WriteLine(Items[1] + ".Location = new Point(" + Items[2] + "," + Items[3] + ");");
                                        if (Items[4] != "")
                                        {
                                            if (Items[5] != "")
                                            {
                                                sw.WriteLine(Items[1] + ".Size = new Size(" + Items[4] + "," + Items[5] + ");");
                                            }
                                        }
                                        sw.WriteLine(Items[1] + @".Text = """ + Items[6] + @""";");
                                        if (Items[9] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".ForeColor = Color." + Items[9] + ";");
                                        }
                                        if (Items[10] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".BackColor = Color." + Items[10] + ";");
                                        }
                                        sw.WriteLine(Items[1] + @".Font = new Font(""" + Items[8] + @"""," + Items[7] + ");");
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount, count] != ";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine(Items[1] + "." + targetEve[count] + " += new System.EventHandler(" + Items[1] + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + Items[1] + ");");
                                        break;
                                    case "Label":
                                        sw.WriteLine("Label" + Items[1] + " = new Label();");
                                        sw.WriteLine(Items[1] + ".Location = new Point(" + Items[2] + "," + Items[3] + ");");
                                        if (Items[4] != "")
                                        {
                                            if (Items[5] != "")
                                            {
                                                sw.WriteLine(Items[1] + ".Size = new Size(" + Items[4] + "," + Items[5] + ");");
                                            }
                                        }
                                        sw.WriteLine(Items[1] + @".Text = """ + Items[6] + @""";");
                                        if (Items[9] != "")
                                        {
                                            sw.WriteLine( Items[1] + ".ForeColor = Color." + Items[9] + ";");
                                        }
                                        if (Items[10] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".BackColor = Color." + Items[10] + ";");
                                        }
                                        sw.WriteLine(Items[1] + @".Font = new Font(""" + Items[8] + @"""," + Items[7] + ");");
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount, count] != ";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine(Items[1] + "." + targetEve[count] + " += new System.EventHandler(" + Items[1] + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + Items[1] + ");");
                                        break;
                                    case "ListBox":
                                        sw.WriteLine("ListBox" + Items[1] + " = new ListBox();");
                                        sw.WriteLine(Items[1] + ".Location = new Point(" + Items[2] + "," + Items[3] + ");");
                                        if (Items[4] != "")
                                        {
                                            if (Items[5] != "")
                                            {
                                                sw.WriteLine(Items[1] + ".Size = new Size(" + Items[4] + "," + Items[5] + ");");
                                            }
                                        }
                                        sw.WriteLine(Items[1] + @".Text = """ + Items[6] + @""";");
                                        if (Items[9] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".ForeColor = Color." + Items[9] + ";");
                                        }
                                        if (Items[10] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".BackColor = Color." + Items[10] + ";");
                                        }
                                        sw.WriteLine(Items[1] + @".Font = new Font(""" + Items[8] + @"""," + Items[7] + ");");
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount, count] != ";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine(Items[1] + "." + targetEve[count] + " += new System.EventHandler(" + Items[1] + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + Items[1] + ");");
                                        break;
                                    case "PictureBox":
                                        sw.WriteLine("PictureBox" + Items[1] + " = new PictureBox();");
                                        sw.WriteLine(Items[1] + ".Location = new Point(" + Items[2] + "," + Items[3] + ");");
                                        if (Items[4] != "")
                                        {
                                            if (Items[5] != "")
                                            {
                                                sw.WriteLine(Items[1] + ".Size = new Size(" + Items[4] + "," + Items[5] + ");");
                                            }
                                        }
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount, count] != ";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine(Items[1] + "." + targetEve[count] + " += new System.EventHandler(" + Items[1] + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + Items[1] + ");");
                                        break;
                                    case "ProgressBar":
                                        sw.WriteLine("ProgressBar" + Items[1] + " = new ProgressBar();");
                                        sw.WriteLine(Items[1] + ".Location = new Point(" + Items[2] + "," + Items[3] + ");");
                                        if (Items[4] != "")
                                        {
                                            if (Items[5] != "")
                                            {
                                                sw.WriteLine(Items[1] + ".Size = new Size(" + Items[4] + "," + Items[5] + ");");
                                            }
                                        }
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount, count] != ";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine(Items[1] + "." + targetEve[count] + " += new System.EventHandler(" + Items[1] + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + Items[1] + ");");
                                        break;
                                    case "RadioButton":
                                        sw.WriteLine("RadioButton" + Items[1] + " = new RadioButton();");
                                        sw.WriteLine(Items[1] + ".Location = new Point(" + Items[2] + "," + Items[3] + ");");
                                        if (Items[4] != "")
                                        {
                                            if (Items[5] != "")
                                            {
                                                sw.WriteLine(Items[1] + ".Size = new Size(" + Items[4] + "," + Items[5] + ");");
                                            }
                                        }
                                        sw.WriteLine(Items[1] + @".Text = """ + Items[6] + @""";");
                                        if (Items[9] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".ForeColor = Color." + Items[9] + ";");
                                        }
                                        if (Items[10] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".BackColor = Color." + Items[10] + ";");
                                        }
                                        sw.WriteLine("this." + Items[1] + @".Font = new Font(""" + Items[8] + @"""," + Items[7] + ");");
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount, count] != ";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine(Items[1] + "." + targetEve[count] + " += new System.EventHandler(" + Items[1] + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + Items[1] + ");");
                                        break;
                                    case "RichTextBox":
                                        sw.WriteLine("RichTextBox" + Items[1] + " = new RichTextBox();");
                                        sw.WriteLine(Items[1] + ".Location = new Point(" + Items[2] + "," + Items[3] + ");");
                                        if (Items[4] != "")
                                        {
                                            if (Items[5] != "")
                                            {
                                                sw.WriteLine(Items[1] + ".Size = new Size(" + Items[4] + "," + Items[5] + ");");
                                            }
                                        }
                                        sw.WriteLine(Items[1] + @".Text = """ + Items[6] + @""";");
                                        if (Items[9] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".ForeColor = Color." + Items[9] + ";");
                                        }
                                        if (Items[10] != "")
                                        {
                                            sw.WriteLine(Items[1] + ".BackColor = Color." + Items[10] + ";");
                                        }
                                        
                                        sw.WriteLine("this." + Items[1] + @".Font = new Font(""" + Items[8] + @"""," + Items[7] + ");");
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == Items[1])
                                            {
                                                read = false;
                                                keepcount = count;
                                            }
                                            ++count;
                                        }
                                        //対象コントロールのイベントデータを配列targetEveに退避
                                        count = 0;
                                        while (Events[keepcount, count] != ";")
                                        {
                                            targetEve[count] = Events[keepcount, count];
                                            ++count;
                                        }
                                        targetEve[count] = ";";
                                        //csファイルにイベントの記述開始
                                        //this.button1.Click += new System.EventHandler(this.button1_Click);のように
                                        count = 2;
                                        while (targetEve[count] != ";")
                                        {
                                            sw.WriteLine(Items[1] + "." + targetEve[count] + " += new System.EventHandler(" + Items[1] + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + Items[1] + ");");
                                        break;
                                }

                            }

                            sw.WriteLine("}");
                            sw.WriteLine("}");
                            sw.WriteLine("}");


                            //閉じる
                            sw.Close();
                            
                            break;
                    }
                }
            }
        }
    }
}
