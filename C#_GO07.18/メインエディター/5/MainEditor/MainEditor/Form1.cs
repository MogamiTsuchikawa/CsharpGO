using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sgry.Azuki.WinForms;
using Sgry.Azuki;
using Sgry.Azuki.Highlighter;

namespace MainEditor
{
    public partial class Form1 : Form
    {
        private AzukiControl[] Azukis;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ver取得
            System.IO.StreamReader readVER = new System.IO.StreamReader(
                @"AppData\main\ver.txt",
                System.Text.Encoding.GetEncoding("shift_jis"));
            Hensu.Ver= double.Parse(readVER.ReadLine());
            readVER.Close();
            //versionをフォームタブに表示
            this.Text = "C#_GO  " + Hensu.Ver.ToString();

            //設定を読み込み
            System.IO.StreamReader sr = new System.IO.StreamReader(
                @"AppData\editor\Setting.txt",
                System.Text.Encoding.GetEncoding("shift_jis"));

            string line = sr.ReadLine();
            if (line.IndexOf(":") == 1)
            {
                Hensu.EditorPath = line;//エディターのPATH C:\とかから始まっている奴
            }else
            {
                //C#_GOのフォルダにエディタがいるやつ
                Hensu.EditorPath = System.IO.Directory.GetCurrentDirectory() + line;

            }

            //閉じる
            sr.Close();


            azukiControl1.Highlighter = new KeywordHighlighter();
            var keywordHighlighter = (KeywordHighlighter)azukiControl1.Highlighter;
            // キーワードを定義
            keywordHighlighter.AddKeywordSet(new string[] {
    "abstract", "as", "base", "bool",
    "break", "byte", "case", "catch",
    "char", "checked", "class", "const",
    "continue", "decimal", "default", "delegate",
    "do", "double", "else", "enum", "event",
    "explicit", "extern", "false", "finally",
    "fixed", "float", "for", "foreach",
    "goto", "if", "implicit", "in",
    "int", "interface", "internal",
    "is", "lock", "long", "namespace",
    "new", "null", "object", "operator",
    "out", "override", "params", "private",
    "protected", "public", "readonly", "ref",
    "return", "sbyte", "sealed", "short",
    "sizeof", "stackalloc", "static", "string",
    "struct", "switch", "this", "throw",
    "true", "try", "typeof", "uint",
    "ulong", "unchecked", "unsafe", "ushort",
    "using", "virtual", "void", "volatile", "while"
}, CharClass.Keyword);

            // 文脈依存キーワードを定義
            keywordHighlighter.AddKeywordSet(new string[] {
    "add", "from", "get", "global", "group", "into",
    "join", "let", "orderby", "partial", "remove",
    "select", "set", "value", "var", "where", "yield"
}, CharClass.Keyword2);

            // プリプロセッサのキーワードを定義
            keywordHighlighter.AddKeywordSet(new string[] {
    "#define", "#elif", "#else", "#endif",
    "#endregion", "#error", "#if", "#line",
    "#region", "#undef", "#warning"
}, CharClass.Macro);

            // 囲いを定義
            keywordHighlighter.AddEnclosure("'", "'", CharClass.String, false, '\\');
            keywordHighlighter.AddEnclosure("@\"", "\"", CharClass.String, true, '\"');
            keywordHighlighter.AddEnclosure("\"", "\"", CharClass.String, false, '\\');
            keywordHighlighter.AddEnclosure("/**", "*/", CharClass.DocComment, true);
            keywordHighlighter.AddEnclosure("/*", "*/", CharClass.Comment, true);

            // 行コメントを定義
            keywordHighlighter.AddLineHighlight("///", CharClass.DocComment);
            keywordHighlighter.AddLineHighlight("//", CharClass.Comment);
            azukiControl1.Text = @"using System";


            TreeNode FileNode = new TreeNode();
            FileNode.Text = Hensu.ProjectName;
            //String[] files = System.IO.Directory.GetFiles(Hensu.ProjectPath+@"\source", "*", System.IO.SearchOption.AllDirectories);
            var files = System.IO.Directory.GetFiles(Hensu.ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
            files = files.Where(x => x != Hensu.ProjectPath+@"\source\main.cs").ToArray();
            FileNode.Nodes.Add("main.cs");
            if (files.Length!=0) 
            {
                for (int i = 0; i < files.Length; ++i)
                {
                    FileNode.Nodes.Add(System.IO.Path.GetFileName(files[i]));
                }
                
                treeView1.Nodes.Add(FileNode);
            }
            else
            {
                MessageBox.Show("プロジェクト内にファイルが見つかりません！");
            }

            this.Azukis = new AzukiControl[files.Length];
            System.IO.StreamReader mainCS = new System.IO.StreamReader(
                Hensu.ProjectPath+@"\source\main.cs",
                System.Text.Encoding.GetEncoding("shift_jis"));
            azukiControl1.Text = mainCS.ReadToEnd();
            mainCS.Close();
            if (files.Length != 0)
            {
                for (int i = 0; i < files.Length; ++i)
                {
                    if (System.IO.Path.GetFileName(files[i])!="main.cs")
                    {
                        if (System.IO.Path.GetExtension(files[i]) != ".xlsx"&& System.IO.Path.GetExtension(files[i]) != ".eve")
                        {
                            TabPage myTabpage = new TabPage(System.IO.Path.GetFileName(files[i]));
                            tabControl1.TabPages.Add(myTabpage);
                            this.Azukis[i] = new AzukiControl();
                            this.Azukis[i].Size = new Size(451, 349);
                            this.Azukis[i].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
                            myTabpage.Controls.Add(this.Azukis[i]);
                            System.IO.StreamReader rf = new System.IO.StreamReader(
                    Hensu.ProjectPath + @"\source\" + System.IO.Path.GetFileName(files[i]),
                    System.Text.Encoding.GetEncoding("shift_jis"));
                            this.Azukis[i].Text = rf.ReadToEnd();
                            rf.Close();

                            this.Azukis[i].Highlighter = new KeywordHighlighter();
                            var keywordHighlighter1 = (KeywordHighlighter)this.Azukis[i].Highlighter;
                            // キーワードを定義
                            keywordHighlighter1.AddKeywordSet(new string[] {
    "abstract", "as", "base", "bool",
    "break", "byte", "case", "catch",
    "char", "checked", "class", "const",
    "continue", "decimal", "default", "delegate",
    "do", "double", "else", "enum", "event",
    "explicit", "extern", "false", "finally",
    "fixed", "float", "for", "foreach",
    "goto", "if", "implicit", "in",
    "int", "interface", "internal",
    "is", "lock", "long", "namespace",
    "new", "null", "object", "operator",
    "out", "override", "params", "private",
    "protected", "public", "readonly", "ref",
    "return", "sbyte", "sealed", "short",
    "sizeof", "stackalloc", "static", "string",
    "struct", "switch", "this", "throw",
    "true", "try", "typeof", "uint",
    "ulong", "unchecked", "unsafe", "ushort",
    "using", "virtual", "void", "volatile", "while"
}, CharClass.Keyword);

                            // 文脈依存キーワードを定義
                            keywordHighlighter1.AddKeywordSet(new string[] {
    "add", "from", "get", "global", "group", "into",
    "join", "let", "orderby", "partial", "remove",
    "select", "set", "value", "var", "where", "yield"
}, CharClass.Keyword2);

                            // プリプロセッサのキーワードを定義
                            keywordHighlighter1.AddKeywordSet(new string[] {
    "#define", "#elif", "#else", "#endif",
    "#endregion", "#error", "#if", "#line",
    "#region", "#undef", "#warning"
}, CharClass.Macro);

                            // 囲いを定義
                            keywordHighlighter1.AddEnclosure("'", "'", CharClass.String, false, '\\');
                            keywordHighlighter1.AddEnclosure("@\"", "\"", CharClass.String, true, '\"');
                            keywordHighlighter1.AddEnclosure("\"", "\"", CharClass.String, false, '\\');
                            keywordHighlighter1.AddEnclosure("/**", "*/", CharClass.DocComment, true);
                            keywordHighlighter1.AddEnclosure("/*", "*/", CharClass.Comment, true);

                            // 行コメントを定義
                            keywordHighlighter1.AddLineHighlight("///", CharClass.DocComment);
                            keywordHighlighter1.AddLineHighlight("//", CharClass.Comment);
                            
                        }
                        

                    }
                    
                    
                }
                //FileNode.Nodes.Add();
                //treeView1.Nodes.Add(FileNode);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //保存
            var files = System.IO.Directory.GetFiles(Hensu.ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
            files = files.Where(x => x != Hensu.ProjectPath + @"\source\main.cs").ToArray();
            if (tabControl1.SelectedIndex == 0)
            {
                System.IO.StreamWriter wmainCS = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\main.cs",
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                wmainCS.Write(azukiControl1.Text);
                //閉じる
                wmainCS.Close();
            }else
            {
                System.IO.StreamWriter wCS = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\" + System.IO.Path.GetFileName(files[tabControl1.SelectedIndex - 1]),
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                wCS.Write(Azukis[tabControl1.SelectedIndex-1].Text);
                //閉じる
                wCS.Close();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //すべて保存
            var files = System.IO.Directory.GetFiles(Hensu.ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
            files = files.Where(x => x != Hensu.ProjectPath + @"\source\main.cs").ToArray();
            System.IO.StreamWriter wmainCS = new System.IO.StreamWriter(
                Hensu.ProjectPath + @"\source\main.cs",
                false,
                System.Text.Encoding.GetEncoding("shift_jis"));
            //TextBox1.Textの内容を書き込む
            wmainCS.Write(azukiControl1.Text);
            //閉じる
            wmainCS.Close();
            for (int i=1; i < tabControl1.TabCount;++i)
            {
                System.IO.StreamWriter wCS = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\" + System.IO.Path.GetFileName(files[i-1]),
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                wCS.Write(Azukis[i-1].Text);
                //閉じる
                wCS.Close();
            }
        }

        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            var files = System.IO.Directory.GetFiles(Hensu.ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
            files = files.Where(x => x != Hensu.ProjectPath + @"\source\main.cs").ToArray();
            if (System.IO.Path.GetExtension(e.Node.Text) == ".xlsx")
            {
                //デザイナー起動
                System.Diagnostics.Process.Start("GUIeditor.exe",Hensu.ProjectPath+@"\source\"+e.Node.Text);
            }
            else
            {
                if (e.Node.Text.IndexOf(".") != -1)
                {
                    if (Hensu.EditorPath == "")
                    {
                        int index = Array.IndexOf(files, Hensu.ProjectPath + @"\source\" + e.Node.Text);
                        ++index;
                        tabControl1.SelectedIndex = index;
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(Hensu.EditorPath, Hensu.ProjectPath + @"\source\" + e.Node.Text);
                    }
                }
                
            }
            
        }

        private void 切り取りToolStripMenuItem_Click(object sender, EventArgs e)
        {
    //        //Clipboard.SetText();
    //        var files = System.IO.Directory.GetFiles(Hensu.ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
    //        files = files.Where(x => x != Hensu.ProjectName + @"\source\main.cs").ToArray();
    //        if (tabControl1.SelectedIndex == 0)
    //        {
    //            //Clipboard.SetText(azukiControl1.Document.SetSelection());
                
    //        }
    //        else
    //        {
    //            System.IO.StreamWriter wCS = new System.IO.StreamWriter(
    //Hensu.ProjectPath + @"\source\" + System.IO.Path.GetFileName(files[tabControl1.SelectedIndex - 1]),
    //false,
    //System.Text.Encoding.GetEncoding("shift_jis"));
    //            //TextBox1.Textの内容を書き込む
    //            wCS.Write(Azukis[tabControl1.SelectedIndex - 1].Text);
    //            //閉じる
    //            wCS.Close();
            //}
        }

        private void ビルドして実行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //main.exe削除
            System.IO.File.Delete(Hensu.ProjectPath + @"\build\main.exe");
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
    @"now.txt",
    false,
    System.Text.Encoding.GetEncoding("shift_jis"));
            //TextBox1.Textの内容を書き込む
            sw.Write(Hensu.ProjectPath);
            //閉じる
            sw.Close();
            //System.Diagnostics.Process.Start("GUIconverter.exe ");
            //Processオブジェクトを作成
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
            p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
            //出力を読み取れるようにする
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            //ウィンドウを表示しないようにする
            p.StartInfo.CreateNoWindow = true;
            //コマンドラインを指定（"/c"は実行後閉じるために必要）
            p.StartInfo.Arguments = "/c GUIconverter.exe ";

            //起動
            p.Start();

            //プロセス終了まで待機する
            //WaitForExitはReadToEndの後である必要がある
            //(親プロセス、子プロセスでブロック防止のため)
            p.WaitForExit();
            p.Close();


            //
            //Processオブジェクトを作成
            System.Diagnostics.Process p1 = new System.Diagnostics.Process();

            //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
            p1.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
            //出力を読み取れるようにする
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.RedirectStandardInput = false;
            //ウィンドウを表示しないようにする
            p1.StartInfo.CreateNoWindow = true;
            //コマンドラインを指定（"/c"は実行後閉じるために必要）
            p1.StartInfo.Arguments = "/c cd /d" + Hensu.ProjectPath + @"\build"+ @"&& C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe  /target:winexe *.cs";
            //
            //起動
            p1.Start();
            p1.WaitForExit();
            textBox1.Text = p1.StandardOutput.ReadToEnd();
            p1.Close();
            
            if (System.IO.File.Exists(Hensu.ProjectPath + @"\build\main.exe"))
            {
                System.Diagnostics.Process.Start(Hensu.ProjectPath + @"\build\main.exe");

            }
            else
            {
                MessageBox.Show("エラー","コンパイルエラー");
            }
            //System.Diagnostics.Process.Start(Hensu.ProjectPath + @"\build\main.exe");
        }

        private void プロジェクト設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project設定 f = new Project設定();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void windowsフォームの追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void クラスの追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClass f = new AddClass();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void windowsフォームの追加ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void クラスの追加ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddClass f = new AddClass();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void ビルドのみToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ソフトウェアアップデートの確認ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AppData内のUpdate.exeを起動
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
