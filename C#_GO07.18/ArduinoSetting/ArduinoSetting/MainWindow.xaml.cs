using System;
using System.Collections.Generic;
using System.IO.Ports;
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

namespace ArduinoSetting
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var portName in SerialPort.GetPortNames())
            {
                com.Items.Add(portName);
            }
            ArduinoType.Items.Add("ArduinoUno");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(com.Text == "")
            {
                MessageBox.Show("COMポート洗濯してください");
            }
            else
            {
                //Build and Write to Arduino
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    @"iot.txt",
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //内容をすべて読み込む
                string s = sr.ReadToEnd();
                //閉じる
                sr.Close();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    @"bin\csharp.ino",
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                sw.WriteLine("void setup() {");
                if (d2.IsChecked == true)
                {
                    if (d2in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(2,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(2,OUTPUT);");
                    }
                }
                if (d3.IsChecked == true)
                {
                    if (d3in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(3,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(3,OUTPUT);");
                    }
                }
                if (d4.IsChecked == true)
                {
                    if (d4in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(4,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(4,OUTPUT);");
                    }
                }
                if (d5.IsChecked == true)
                {
                    if (d5in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(5,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(5,OUTPUT);");
                    }
                }
                if (d6.IsChecked == true)
                {
                    if (d6in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(6,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(6,OUTPUT);");
                    }
                }
                if (d7.IsChecked == true)
                {
                    if (d7in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(7,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(7,OUTPUT);");
                    }
                }
                if (d8.IsChecked == true)
                {
                    if (d8in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(8,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(8,OUTPUT);");
                    }
                }
                if (d9.IsChecked == true)
                {
                    if (d9in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(9,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(9,OUTPUT);");
                    }
                }
                if (d10.IsChecked == true)
                {
                    if (d10in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(10,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(10,OUTPUT);");
                    }
                }
                if (d11.IsChecked == true)
                {
                    if (d11in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(11,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(11,OUTPUT);");
                    }
                }
                if (d12.IsChecked == true)
                {
                    if (d12in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(12,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(12,OUTPUT);");
                    }
                }
                if (d13.IsChecked == true)
                {
                    if (d13in.IsChecked == true)
                    {
                        sw.WriteLine("pinMode(13,INPUT);");
                    }
                    else
                    {
                        sw.WriteLine("pinMode(13,OUTPUT);");
                    }
                }
                sw.Write(s);
                //閉じる
                sw.Close();
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.Arguments = @"/c cd bin& ArduinoUploader.exe csharp.ino 1 " + com.Text;
                p.Start();
            }
            
        }

        
    }
}
