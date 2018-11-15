using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;

namespace MainEditor
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private ICSharpCode.AvalonEdit.TextEditor[] avalons;
        private string[] TabString;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            //単独起動　プロジェクトマネジャー込

            ProjectM f = new ProjectM();
            f.ShowDialog();

            if (Hensu.RunHikisu == "")
            {
                Environment.Exit(0);
            }

            Hensu.ProjectPath = System.IO.Path.GetDirectoryName(Hensu.RunHikisu);
            //MessageBox.Show(Hensu.ProjectPath);
            System.IO.StreamReader fsr = new System.IO.StreamReader(
                Hensu.RunHikisu,
                System.Text.Encoding.GetEncoding("shift_jis"));
            string line = fsr.ReadLine();//一行目は捨てる
            Hensu.ProjectName = fsr.ReadLine();
            Hensu.ProjectName = Hensu.ProjectName.Replace("\r", "").Replace("\n", "");
            Hensu.ProjectKinds = fsr.ReadLine();
            switch (Hensu.ProjectKinds)
            {
                case "kind:forms":
                    break;
                case "kind:console":
                    AddWinForm.IsEnabled = false;
                    break;
                case "kind:wpf":

                    break;
                case "kind:dll":

                    break;
                case "kind:android":

                    break;
                case "kind:IotA":

                    break;
            }

            fsr.Close();
            //ver取得
            System.IO.StreamReader readVER = new System.IO.StreamReader(
                @"AppData\main\ver.txt",
                System.Text.Encoding.GetEncoding("shift_jis"));
            Hensu.Ver = double.Parse(readVER.ReadLine());
            readVER.Close();
            //versionをフォームタブに表示
            this.Title = "C#_GO  " + Hensu.Ver.ToString();

            //設定を読み込み
            System.IO.StreamReader sr = new System.IO.StreamReader(
                @"AppData\editor\Setting.txt",
                System.Text.Encoding.GetEncoding("shift_jis"));

            line = sr.ReadLine();
            if (line != null)
            {
                if (line.IndexOf(":") == 1)
                {
                    Hensu.EditorPath = line;//エディターのPATH C:\とかから始まっている奴
                }
                else
                {
                    //C#_GOのフォルダにエディタがいるやつ
                    Hensu.EditorPath = System.IO.Directory.GetCurrentDirectory() + line;
                }
            }
            //閉じる
            sr.Close();
            
            rootItem.Header = Hensu.ProjectName;
            
            var files = System.IO.Directory.GetFiles(Hensu.ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
            files = files.Where(x => x != Hensu.ProjectPath + @"\source\main.cs").ToArray();
            TreeViewItem FileNode = new TreeViewItem();
            FileNode.Header = "main.cs";
            rootItem.Items.Add(FileNode);
            if (files.Length != 0)
            {
                for (int i = 0; i < files.Length; ++i)
                {
                    TreeViewItem FileNodei = new TreeViewItem();
                    FileNodei.Header=System.IO.Path.GetFileName(files[i]);
                    rootItem.Items.Add(FileNodei);
                }
            }
            else
            {
                //MessageBox.Show("プロジェクト内にファイルが見つかりません！");
            }
            //main.cs表示
            System.IO.StreamReader mainCS = new System.IO.StreamReader(
                Hensu.ProjectPath + @"\source\main.cs",
                System.Text.Encoding.GetEncoding("shift_jis"));
            avalon1.Text = mainCS.ReadToEnd();
            mainCS.Close();
            var reader1 = new System.Xml.XmlTextReader(@"AppData\editor\csharp.xshd");
            var definition = HighlightingLoader.Load(reader1, HighlightingManager.Instance);
            avalon1.SyntaxHighlighting = definition;
            reader1.Close();
            //他.cs表示
            //.csの数を調べる
            int CountCS=0;
            for(int a = 0; a < files.Length;++a)
            {
                ++CountCS;
            }
            avalons = new ICSharpCode.AvalonEdit.TextEditor[CountCS];
            TabString = new string[CountCS+1];
            TabString[0] = "main.cs";
            var TabPages = new TabItem[CountCS];
            CountCS = 0;
            if (files.Length != 0)
            {
                for (int i = 0; i != files.Length; ++i)
                {
                    if (System.IO.Path.GetFileName(files[i]) != "main.cs")
                    {
                        if (System.IO.Path.GetExtension(files[i]) != ".xlsx" && System.IO.Path.GetExtension(files[i]) != ".eve")
                        {
                            //avalons[i] = new ICSharpCode.AvalonEdit.TextEditor();
                            TabPages[CountCS] = new TabItem();
                            avalons[CountCS] = new ICSharpCode.AvalonEdit.TextEditor();
                            TabPages[CountCS].Header = System.IO.Path.GetFileName(files[i]);
                            TabString[CountCS+1] = System.IO.Path.GetFileName(files[i]);
                            TabPages[CountCS].Content = avalons[CountCS];
                            TabControl1.Items.Add(TabPages[CountCS]);
                            System.IO.StreamReader rf = new System.IO.StreamReader(
                            Hensu.ProjectPath + @"\source\" + System.IO.Path.GetFileName(files[i]),
                            System.Text.Encoding.GetEncoding("shift_jis"));
                            avalons[CountCS].Text = rf.ReadToEnd();
                            rf.Close();
                            var reader = new System.Xml.XmlTextReader(@"AppData\editor\csharp.xshd");
                            definition = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                            avalons[CountCS].SyntaxHighlighting = definition;
                            reader.Close();
                            avalons[CountCS].ShowLineNumbers = true;
                            ++CountCS;
                        }
                    }
                }
            }
        }
        private void BuildAndRun_Click(object sender, RoutedEventArgs e)
        {
            Save_All();
            switch (Hensu.ProjectKinds)
            {
                case "kind:wpf":
                    textBox1.Text =Build.wpfbuild();
                    if (System.IO.File.Exists(Hensu.ProjectPath + @"\build\main.exe"))
                    {
                        System.Diagnostics.Process.Start(Hensu.ProjectPath + @"\build\main.exe");
                    }
                    else
                    {
                        MessageBox.Show("コンパイルエラーだよ！", "コンパイル情報", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
                case "kind:forms":
                    //dllを探す


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
                    if (Hensu.ProjectKinds == "kind:console")
                    {
                        p1.StartInfo.Arguments = "/c cd /d" + Hensu.ProjectPath + @"\build" + @"& C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe *.cs";
                    }
                    else
                    {
                        p1.StartInfo.Arguments = "/c cd /d" + Hensu.ProjectPath + @"\build" + @"& C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe  /target:winexe *.cs";
                    }

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
                        MessageBox.Show("コンパイルエラーだよ！", "コンパイル情報", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
            }
            
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //保存
            var files = System.IO.Directory.GetFiles(Hensu.ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
            files = files.Where(x => x != Hensu.ProjectPath + @"\source\main.cs").ToArray();
            if (TabControl1.SelectedIndex == 0)
            {
                System.IO.StreamWriter wmainCS = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\main.cs",
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                wmainCS.Write(avalon1.Text);
                //閉じる
                wmainCS.Close();
            }
            else
            {
                System.IO.StreamWriter wCS = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\" + System.IO.Path.GetFileName(files[TabControl1.SelectedIndex - 1]),
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                wCS.Write(avalons[TabControl1.SelectedIndex - 1].Text);
                //閉じる
                wCS.Close();
            }
        }
        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var select = treeView1.SelectedItem.ToString();
            select = select.Replace("System.Windows.Controls.TreeViewItem Header:", "");
            select = select.Replace("Items.Count", "");
            select = select.Remove(select.IndexOf(":"));
            select = select.TrimEnd();
            var files = System.IO.Directory.GetFiles(Hensu.ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
            files = files.Where(x => x != Hensu.ProjectPath + @"\source\main.cs").ToArray();
            //MessageBox.Show(select);
            if(select != Hensu.ProjectName)
            {
                if (System.IO.Path.GetExtension(select) == ".xlsx"|| System.IO.Path.GetExtension(select) == ".eve")
                {
                    if (System.IO.Path.GetExtension(select) == ".xlsx")
                    {
                        //デザイナー起動
                        System.Diagnostics.Process.Start("GUIeditor.exe", Hensu.ProjectPath + @"\source\" + select);
                    }
                    
                }
                else
                {
                    if (select.IndexOf(".") != -1)
                    {
                        if (Hensu.EditorPath == "")
                        {
                            int index = Array.IndexOf(TabString,select);
                            TabControl1.SelectedIndex = index;
                            Save.Header = select + "の保存";
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(Hensu.EditorPath, Hensu.ProjectPath + @"\source\" + select);
                        }
                    }
                }
            }
        }
        private void SaveAll_Click(object sender, RoutedEventArgs e)
        {
            Save_All();
        }
        private void TabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabString != null)
            {
                if(TabControl1.SelectedIndex != -1)
                {
                    Save.Header = TabString[TabControl1.SelectedIndex];
                }
                
            }
        }
        private void AddClass_Click(object sender, RoutedEventArgs e)
        {
            AddClass f = new AddClass();
            f.ShowDialog();
            MessageBoxResult result = MessageBox.Show("プロジェクトを再読み込みするまで、IDEで編集することができません。直ちにIDEを再起動しますか？","再起動オプション",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start(@"AppData\editor\ReBootProject.exe", Hensu.RunHikisu);
                this.Close();
            }
        }
        private void AddWinForm_Click(object sender, RoutedEventArgs e)
        {
            AddForm f = new AddForm();
            f.ShowDialog();
            MessageBoxResult result = MessageBox.Show("プロジェクトを再読み込みするまで、IDEで編集することができません。直ちにIDEを再起動しますか？", "再起動オプション", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start(@"AppData\editor\ReBootProject.exe", Hensu.RunHikisu);
                this.Close();
            }
        }
        private void BuildOnly_Click(object sender, RoutedEventArgs e)
        {
            Save_All();
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
            if (Hensu.ProjectKinds == "kind:console")
            {
                p1.StartInfo.Arguments = "/c cd /d" + Hensu.ProjectPath + @"\build" + @"&& C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe *.cs";
            }
            else
            {
                p1.StartInfo.Arguments = "/c cd /d" + Hensu.ProjectPath + @"\build" + @"&& C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe  /target:winexe *.cs";
            }
            //起動
            p1.Start();
            p1.WaitForExit();
            textBox1.Text = p1.StandardOutput.ReadToEnd();
            p1.Close();

            if (System.IO.File.Exists(Hensu.ProjectPath + @"\build\main.exe"))
            {}else
            {
                MessageBox.Show("コンパイルエラーだよ！", "コンパイル情報", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void OpenDirectryOfExe_Click(object sender, RoutedEventArgs e)
        {
            //exeの場所をエクスプローラーで開く
            System.Diagnostics.Process.Start(Hensu.ProjectPath+@"\build");
        }
        private void EasyDebug_Click(object sender, RoutedEventArgs e)
        {
            Save_All();
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
            p1.StartInfo.Arguments = "/c cd /d" + Hensu.ProjectPath + @"\build" + @"&& C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe *.cs";
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
                MessageBox.Show("コンパイルエラーだよ！", "コンパイル情報", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            if(TabControl1.SelectedIndex == 0)
            {
                Clipboard.SetData(DataFormats.Text, avalon1.SelectedText);
                avalon1.SelectedText = "";
            }
            else
            {
                Clipboard.SetData(DataFormats.Text, avalons[TabControl1.SelectedIndex -1].SelectedText);
                avalons[TabControl1.SelectedIndex - 1].SelectedText = "";
            }
        }
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            if (TabControl1.SelectedIndex == 0)
            {
                Clipboard.SetData(DataFormats.Text, avalon1.SelectedText);            }
            else
            {
                Clipboard.SetData(DataFormats.Text, avalons[TabControl1.SelectedIndex - 1].SelectedText);
            }
        }
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                if (TabControl1.SelectedIndex == 0)
                {
                    int index = avalon1.SelectionStart;
                    avalon1.Text = avalon1.Text.Insert(index, Clipboard.GetText());
                }
                else
                {
                    int index = avalons[TabControl1.SelectedIndex - 1].SelectionStart;
                    avalons[TabControl1.SelectedIndex-1].Text = avalons[TabControl1.SelectedIndex - 1].Text.Insert(index, Clipboard.GetText());
                }
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            var i =MessageBox.Show("本当に終了して問題ない？", "一応確認する", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (i == MessageBoxResult.OK) this.Close();
        }
        public void Save_All()
        {
            //すべて保存
            var files = System.IO.Directory.GetFiles(Hensu.ProjectPath + @"\source", "*", System.IO.SearchOption.AllDirectories);
            files = files.Where(x => x != Hensu.ProjectPath + @"\source\main.cs").ToArray();
            System.IO.StreamWriter wmainCS = new System.IO.StreamWriter(
                Hensu.ProjectPath + @"\source\main.cs",
                false,
                System.Text.Encoding.GetEncoding("shift_jis"));
            //TextBox1.Textの内容を書き込む
            wmainCS.Write(avalon1.Text);
            //閉じる
            wmainCS.Close();
            for (int i = 1; i < TabControl1.Items.Count; ++i)
            {
                System.IO.StreamWriter wCS = new System.IO.StreamWriter(
                    Hensu.ProjectPath + @"\source\" + System.IO.Path.GetFileName(files[i - 1]),
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                wCS.Write(avalons[i - 1].Text);
                //閉じる
                wCS.Close();
            }
        }

        private void AddDLL_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "DLLファイルを開く";
            dialog.Filter = "ダイナミックリンクライブラリ(*.dll)|*.dll";
            if (dialog.ShowDialog() == true)
            {
                System.IO.File.Copy(dialog.FileName, Hensu.ProjectPath+@"source\"+ System.IO.Path.GetFileName(dialog.FileName));
            }
            else
            {
                MessageBox.Show("キャンセルされました");
            }
        }
    }
}
