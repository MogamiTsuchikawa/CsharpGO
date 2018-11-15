using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
namespace Test
{
public partial class Form1 : Form
{
public Form1(){
Text = "";
ClientSize = new Size(500,400);
Button ボタン1 = new Button();
ボタン1.Location = new Point(50,10);
ボタン1.Font = new Font("Arial",12);
ボタン1.Text = "ぼたん一";
ボタン1.Click += new EventHandler(ボタン1_Click);
this.Controls.Add(ボタン1);
}
}
}
