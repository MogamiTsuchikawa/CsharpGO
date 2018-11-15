using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainEditor
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length < 2)
            {
                //Hensu.RunHikisu = @"Test\ProjectInfo.projectt";
                Hensu.RunHikisu = @"D:\Desktop\tesutesu\ProjectInfo.projectt";
            }
            else
            {
                Hensu.RunHikisu = args[1];
            }
            Hensu.ProjectPath= System.IO.Path.GetDirectoryName(Hensu.RunHikisu);
            //MessageBox.Show(Hensu.ProjectPath);
            System.IO.StreamReader fsr = new System.IO.StreamReader(
                Hensu.RunHikisu,
                System.Text.Encoding.GetEncoding("shift_jis"));
            String line = fsr.ReadLine();//一行目は捨てる
            Hensu.ProjectName = fsr.ReadLine();
            Hensu.ProjectName = Hensu.ProjectName.Replace("\r", "").Replace("\n", "");

            fsr.Close();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
