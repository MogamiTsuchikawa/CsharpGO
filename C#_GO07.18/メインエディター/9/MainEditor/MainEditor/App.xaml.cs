using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace MainEditor
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            foreach (string arg in e.Args)
            {
                string a = arg;
            }
            

            //fsr.Close();
            //2秒スプラッシュスクリーンを待機させる
            //動作しているUSBデバイスのシリアルを取得
            string USBID = USBs.GetUSBdeviceID();
            System.IO.StreamReader sr = new System.IO.StreamReader(
                @"AppData\main\id.lid",
                System.Text.Encoding.GetEncoding("shift_jis"));
            //内容をすべて読み込む
            string s = sr.ReadToEnd();
            //閉じる
            sr.Close();

            /*
             * ライセンス認証部分
             */

            //if (s != USBID)
            //{
            //    MessageBox.Show("構成エラーが発生しました。", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
            //    Environment.Exit(0);
            //}




            //Debug.WriteLine(USBID);
            //StartUP Objectは指定せずにここで初期化する
            MainWindow mainWindow = new MainWindow(); //←起動したい画面クラス名
            mainWindow.Show();


        }

    }
}
