using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
namespace Test
{
    static class main
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Console.WriteLine("Hello World!");
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }
    }
}