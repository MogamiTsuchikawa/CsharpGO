using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIbuildTest1
{
    public partial class Form2 : Form
    {
        
        private Button[] buttons;
        private TextBox[] textboxs;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //それぞれのコントロールのデータを配列から取得し、表示していく

            //Message.Show(Form2.ButtonDate);
            int ButtonVV = 0,TextBoxVV = 0;

            this.buttons = new Button[Hensu.ButtonV];
            this.textboxs = new TextBox[Hensu.TextBoxV];
            String TargetControle = "Form";
            



            while (TargetControle != "END")
            {
                //内容を一行ずつ読み込む
                System.IO.StreamReader fsr = new System.IO.StreamReader(
                Hensu.RunHikisu,
                System.Text.Encoding.GetEncoding("shift_jis"));
                while (fsr.Peek() > -1)
                {

                    String line = fsr.ReadLine();
                    String[] Items = line.Split('/');
                    //MessageBox.Show(Items[0]);
                    if (Items[0] == TargetControle)
                    {
                        switch (Items[0])
                        {
                            case "Form":
                                this.Height = int.Parse(Items[4]);
                                this.Width = int.Parse(Items[5]);
                                break;
                            case "Button":
                                this.buttons[ButtonVV] = new Button(); 
                                this.buttons[ButtonVV].Name = Items[1];
                                this.buttons[ButtonVV].Text = Items[6];
                                this.buttons[ButtonVV].Location = new Point(int.Parse(Items[2]),int.Parse(Items[3]));


                                this.Controls.Add(this.buttons[ButtonVV]);
                                ButtonVV = ButtonVV + 1;
                                break;
                            case "TextBox":
                                this.textboxs[TextBoxVV] = new TextBox();
                                this.textboxs[TextBoxVV].Name = Items[1];
                                this.textboxs[TextBoxVV].Text = Items[6];
                                this.textboxs[TextBoxVV].Location = new Point(int.Parse(Items[2]), int.Parse(Items[3]));


                                this.Controls.Add(this.textboxs[TextBoxVV]);
                                TextBoxVV = TextBoxVV + 1;
                                break;

                        }
                    }


                }
                fsr.Close();
                //次のターゲットに変更
                switch (TargetControle)
                {
                    case "Form":
                        TargetControle = "Button";
                        break;
                    case "Button":
                        TargetControle = "TextBox";

                        break;
                    case "TextBox":
                        TargetControle = "END";

                        break;
                }
                if (TargetControle != "END")
                {

                }
            }

        }
    }
}
