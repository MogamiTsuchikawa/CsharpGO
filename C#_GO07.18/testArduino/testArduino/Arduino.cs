using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace testArduino
{
    class Arduino
    {
        static SerialPort SP = new SerialPort();
        public static void SetArduino(string COM)
        {
            
            SP.BaudRate = 9600;
            SP.PortName = COM;
            SP.Open();
        }
        public static void EndArduino()
        {
            SP.Close();
        }
        public static void digitalWrite(int pn, bool value)
        {
            //disitalWrite
            if(2 <= pn && pn <= 13)
            {
                if(pn < 10)
                {
                    if (value)
                    {
                        SP.Write("a0" + pn + "h////");
                    }
                    else
                    {
                        SP.Write("a0" + pn + "l////");
                    }
                }
                else
                {
                    if (value)
                    {
                        SP.Write("a" + pn + "h////");
                    }
                    else
                    {
                        SP.Write("a" + pn + "l////");
                    }
                }
                
            }
            else
            {
                //対応していないPIN
                MessageBox.Show("PIN" + pn.ToString() + "はデジタル出力に対応していません");
            }
        }
        public static void analogWrite(int pn,int value)
        {
            if(pn == 3 || pn == 5 || pn == 6 || pn == 9 || pn == 10 || pn == 11)
            {
                if (value <= 255 && value >= 0)
                {
                    //OK
                    string sendV;
                    if(value < 100)
                    {
                        if(value < 10)
                        {
                            sendV = "00" + value.ToString();
                        }
                        else
                        {
                            sendV = "0" + value.ToString();
                        }
                    }
                    else
                    {
                        sendV = value.ToString();
                    }
                    if (pn == 10 || pn == 11)
                    {
                        SP.Write("d" + pn.ToString() +sendV+"00");
                    }
                    else
                    {
                        SP.Write("d0" + pn.ToString() + sendV + "00");
                    }
                }
                else
                {
                    //範囲外
                }
            }
            else
            {
                //対応していないPIN
                MessageBox.Show("PIN"+pn.ToString()+"はアナログ出力に対応していません");
            }
            
        }
        public static bool digitalRead(int pn)
        {
            if (pn <10)
            {
                SP.Write("b0"+pn.ToString()+"/////");
            }
            else
            {
                SP.Write("b" + pn.ToString() + "/////");
            }
            bool rt=true;
            string i = SP.ReadLine();
            if (int.Parse(i)==1)
            {
                rt = true;
            }
            else
            {
                rt = false;
            }
            return rt;
        } 
        public static int analogRead(int pn)
        {
            if (pn < 10)
            {
                SP.Write("c0" + pn.ToString() + "/////");
            }
            else
            {
                SP.Write("c" + pn.ToString() + "/////");
            }
            return int.Parse(SP.ReadLine());
        }
        
    }
}
