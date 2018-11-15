using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainEditor
{
    public partial class Project設定 : Form
    {
        public Project設定()
        {
            InitializeComponent();
        }

        private void Project設定_Load(object sender, EventArgs e)
        {
            label2.Text = Hensu.ProjectName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //保存して終了
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //保存しないで終了
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ファイルオープンダイアログ
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "default.html";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 2;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DialogResult r = MessageBox.Show("選択したアイコンファイルをコピーしてプロジェクトに追加します。よろしいですか？","確認",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                if(r == DialogResult.Yes)
                {
                    string filepath = ofd.FileName;
                    string filename = System.IO.Path.GetFileName(filepath);
                    System.IO.File.Copy(filepath,Hensu.ProjectPath+@"\include\ico\icon.ico", true);
                    textBox1.Text = filename;

                }
                
            }
        }
    }
}
