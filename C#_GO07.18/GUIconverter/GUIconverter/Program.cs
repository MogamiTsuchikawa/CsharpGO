using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

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
                        case ".dll":
                            System.IO.File.Copy(files[i], ProjectPath + @"\build\" + System.IO.Path.GetFileName(files[i]), true);
                            break;
                        case ".xlsx":
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
                            
                            //guixファイルとeveファイルを開く
                            var guiBook = new XLWorkbook(files[i]);
                            var guiDate = guiBook.Worksheet("guiDate");
                            
                            System.IO.StreamReader sr1 = new System.IO.StreamReader(
                                ProjectPath + @"\source\" + System.IO.Path.GetFileNameWithoutExtension(files[i])+".eve",
                                System.Text.Encoding.GetEncoding("shift_jis"));
                            //event関連データを配列Eventsに格納
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
                            //guixファイルを一行ずつcsに変換
                            int countX = 2;//XはExcelファイルでの縦 Excelなので初期値は1
                            int countY = 1;//YはExcelファイルでの横
                            while (guiDate.Cell(countX, 1).Value.ToString() != "")
                            {
                                string name = guiDate.Cell(countX, 2).Value.ToString();
                                sw.WriteLine("private "+guiDate.Cell(countX, 1).Value.ToString()+" "+name+";");
                                ++countX;
                            }
                            sw.WriteLine("public void InitializeComponent(){");
                            countX = 1;
                            countY = 1;
                            while (guiDate.Cell(countX,1).Value.ToString()!="")
                            {
                                bool read = false;
                                int keepcount;
                                string[] targetEve = new String[50];
                                string name = guiDate.Cell(countX, 2).Value.ToString();

                                switch (guiDate.Cell(countX, 1).Value.ToString())
                                {
                                    case "Form":
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(@"this.Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine("ClientSize = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine("this.BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine("this." + targetEve[count] + " += new System.EventHandler(this." + name + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        break;
                                    case "Button":
                                        sw.WriteLine(name + " = new Button();");
                                        sw.WriteLine(name + ".Name = \""+ name+"\";");
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(name+@".Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine(name+".Size = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine(name+".BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                                case "ForeColor":
                                                    sw.WriteLine(name + ".ForeColor = Color." + value + ";");
                                                    break;
                                                case "Location":
                                                    string[] location = value.Split(':');
                                                    sw.WriteLine(name + ".Location = new Point(" + location[0] + "," + location[1] + ");");
                                                    break;
                                                case "Font":
                                                    string[] font = value.Split(':');//Font名,FontSize
                                                    sw.WriteLine(name + @".Font = new Font(""" + font[0] + @"""," + font[1] + ");");
                                                    break;


                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        //
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine(name+"."+targetEve[count]+" += new System.EventHandler("+name+"_"+targetEve[count]+");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add("+ name + ");");
                                        break;
                                    case "TextBox":
                                        
                                        sw.WriteLine(name +" = new TextBox();");
                                        sw.WriteLine(name + ".Name = \"" + name + "\";");
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(name + @".Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine(name + ".Size = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine("this.BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                                case "ForeColor":
                                                    sw.WriteLine(name + ".ForeColor = Color." + value + ";");
                                                    break;
                                                case "Location":
                                                    string[] location = value.Split(':');
                                                    sw.WriteLine(name + ".Location = new Point(" + location[0] + "," + location[1] + ");");
                                                    break;
                                                case "Font":
                                                    string[] font = value.Split(':');//Font名,FontSize
                                                    sw.WriteLine(name + @".Font = new Font(""" + font[0] + @"""," + font[1] + ");");
                                                    break;
                                                case "MultLine"://value は true false
                                                    sw.WriteLine(name + ".MultiLine = "+ value +";");
                                                    break;
                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine(name + "." + targetEve[count] + " += new System.EventHandler(" + name + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + name + ");");
                                        sw.WriteLine("");
                                        sw.WriteLine("");
                                        break;
                                    case "CheckBox":
                                        sw.WriteLine(name + " = new CheckBox();");
                                        sw.WriteLine(name + ".Name = \"" + name + "\";");
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(name + @".Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine(name + ".Size = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine("this.BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                                case "ForeColor":
                                                    sw.WriteLine(name + ".ForeColor = Color." + value + ";");
                                                    break;
                                                case "Location":
                                                    string[] location = value.Split(':');
                                                    sw.WriteLine(name + ".Location = new Point(" + location[0] + "," + location[1] + ");");
                                                    break;
                                                case "Font":
                                                    string[] font = value.Split(':');//Font名,FontSize
                                                    sw.WriteLine(name + @".Font = new Font(""" + font[0] + @"""," + font[1] + ");");
                                                    break;
                                                
                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine(name + "." + targetEve[count] + " += new System.EventHandler(" + name + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + name + ");");
                                        break;
                                    case "ComboBox":
                                        sw.WriteLine(name + " = new ComboBox();");
                                        sw.WriteLine(name + ".Name = \"" + name + "\";");
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(name + @".Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine(name + ".Size = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine("this.BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                                case "ForeColor":
                                                    sw.WriteLine(name + ".ForeColor = Color." + value + ";");
                                                    break;
                                                case "Location":
                                                    string[] location = value.Split(':');
                                                    sw.WriteLine(name + ".Location = new Point(" + location[0] + "," + location[1] + ");");
                                                    break;
                                                case "Font":
                                                    string[] font = value.Split(':');//Font名,FontSize
                                                    sw.WriteLine(name + @".Font = new Font(""" + font[0] + @"""," + font[1] + ");");
                                                    break;

                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine(name + "." + targetEve[count] + " += new System.EventHandler(" + name + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + name + ");");
                                        break;
                                    case "Label":
                                        sw.WriteLine(name + " = new Label();");
                                        sw.WriteLine(name + ".Name = \"" + name + "\";");
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(name + @".Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine(name + ".Size = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine("this.BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                                case "ForeColor":
                                                    sw.WriteLine(name + ".ForeColor = Color." + value + ";");
                                                    break;
                                                case "Location":
                                                    string[] location = value.Split(':');
                                                    sw.WriteLine(name + ".Location = new Point(" + location[0] + "," + location[1] + ");");
                                                    break;
                                                case "Font":
                                                    string[] font = value.Split(':');//Font名,FontSize
                                                    sw.WriteLine(name + @".Font = new Font(""" + font[0] + @"""," + font[1] + ");");
                                                    break;

                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine(name + "." + targetEve[count] + " += new System.EventHandler(" + name + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + name + ");");
                                        break;
                                    case "ListBox":
                                        sw.WriteLine(name + " = new ListBox();");
                                        sw.WriteLine(name + ".Name = \"" + name + "\";");
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(name + @".Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine(name + ".Size = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine("this.BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                                case "ForeColor":
                                                    sw.WriteLine(name + ".ForeColor = Color." + value + ";");
                                                    break;
                                                case "Location":
                                                    string[] location = value.Split(':');
                                                    sw.WriteLine(name + ".Location = new Point(" + location[0] + "," + location[1] + ");");
                                                    break;
                                                case "Font":
                                                    string[] font = value.Split(':');//Font名,FontSize
                                                    sw.WriteLine(name + @".Font = new Font(""" + font[0] + @"""," + font[1] + ");");
                                                    break;

                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine(name + "." + targetEve[count] + " += new System.EventHandler(" + name + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + name + ");");
                                        break;
                                    case "PictureBox":
                                        sw.WriteLine(name + " = new PictureBox();");
                                        sw.WriteLine(name + ".Name = \"" + name + "\";");
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(name + @".Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine(name + ".Size = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine("this.BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                                case "ForeColor":
                                                    sw.WriteLine(name + ".ForeColor = Color." + value + ";");
                                                    break;
                                                case "Location":
                                                    string[] location = value.Split(':');
                                                    sw.WriteLine(name + ".Location = new Point(" + location[0] + "," + location[1] + ");");
                                                    break;
                                                case "Font":
                                                    string[] font = value.Split(':');//Font名,FontSize
                                                    sw.WriteLine(name + @".Font = new Font(""" + font[0] + @"""," + font[1] + ");");
                                                    break;

                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine(name + "." + targetEve[count] + " += new System.EventHandler(" + name + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + name + ");");
                                        break;
                                    case "ProgressBar":
                                        sw.WriteLine(name + " = new ProgressBar();");
                                        sw.WriteLine(name + ".Name = \"" + name + "\";");
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(name + @".Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine(name + ".Size = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine("this.BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                                case "ForeColor":
                                                    sw.WriteLine(name + ".ForeColor = Color." + value + ";");
                                                    break;
                                                case "Location":
                                                    string[] location = value.Split(':');
                                                    sw.WriteLine(name + ".Location = new Point(" + location[0] + "," + location[1] + ");");
                                                    break;
                                                case "Font":
                                                    string[] font = value.Split(':');//Font名,FontSize
                                                    sw.WriteLine(name + @".Font = new Font(""" + font[0] + @"""," + font[1] + ");");
                                                    break;

                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine(name + "." + targetEve[count] + " += new System.EventHandler(" + name + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + name + ");");
                                        break;
                                    case "RadioButton":
                                        sw.WriteLine(name + " = new RadioButton();");
                                        sw.WriteLine(name + ".Name = \"" + name + "\";");
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(name + @".Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine(name + ".Size = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine("this.BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                                case "ForeColor":
                                                    sw.WriteLine(name + ".ForeColor = Color." + value + ";");
                                                    break;
                                                case "Location":
                                                    string[] location = value.Split(':');
                                                    sw.WriteLine(name + ".Location = new Point(" + location[0] + "," + location[1] + ");");
                                                    break;
                                                case "Font":
                                                    string[] font = value.Split(':');//Font名,FontSize
                                                    sw.WriteLine(name + @".Font = new Font(""" + font[0] + @"""," + font[1] + ");");
                                                    break;

                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine(name + "." + targetEve[count] + " += new System.EventHandler(" + name + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + name + ");");
                                        break;
                                    case "RichTextBox":
                                        sw.WriteLine(name + " = new RichTextBox();");
                                        sw.WriteLine(name + ".Name = \"" + name + "\";");
                                        countY = 3;
                                        while (guiDate.Cell(countX, countY).Value.ToString() != "")
                                        {
                                            string kind;
                                            kind = guiDate.Cell(countX, countY).Value.ToString();
                                            string value;
                                            value = guiDate.Cell(countX, countY+1).Value.ToString();
                                            switch (kind)
                                            {
                                                case "Text":
                                                    sw.WriteLine(name + @".Text = """ + value + @""";");
                                                    break;
                                                case "Size":
                                                    string[] size = value.Split(':');
                                                    sw.WriteLine(name + ".Size = new Size(" + size[0] + "," + size[1] + ");");
                                                    break;
                                                case "BackColor":
                                                    sw.WriteLine("this.BackColor = System.Drawing.Color." + value + ";");
                                                    break;
                                                case "ForeColor":
                                                    sw.WriteLine(name + ".ForeColor = Color." + value + ";");
                                                    break;
                                                case "Location":
                                                    string[] location = value.Split(':');
                                                    sw.WriteLine(name + ".Location = new Point(" + location[0] + "," + location[1] + ");");
                                                    break;
                                                case "Font":
                                                    string[] font = value.Split(':');//Font名,FontSize
                                                    sw.WriteLine(name + @".Font = new Font(""" + font[0] + @"""," + font[1] + ");");
                                                    break;

                                            }
                                            ++countY;
                                        }
                                        ++countX;
                                        
                                        //イベント記述
                                        //
                                        //対象コントロールのイベント記述がある行を検索
                                        count = 0;
                                        read = true;
                                        keepcount = -1;//対象がある行
                                        while (read)
                                        {
                                            if (Events[count, 1] == name)
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
                                            sw.WriteLine(name + "." + targetEve[count] + " += new System.EventHandler(" + name + "_" + targetEve[count] + ");");
                                            ++count;
                                        }
                                        //イベント関連記述終了
                                        sw.WriteLine("this.Controls.Add(" + name + ");");
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
