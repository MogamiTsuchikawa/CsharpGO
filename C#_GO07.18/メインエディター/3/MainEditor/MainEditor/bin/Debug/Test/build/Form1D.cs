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
Button �{�^��1 = new Button();
�{�^��1.Location = new Point(50,10);
�{�^��1.Font = new Font("Arial",12);
�{�^��1.Text = "�ڂ����";
�{�^��1.Click += new EventHandler(�{�^��1_Click);
this.Controls.Add(�{�^��1);
}
}
}
