using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUImakerV3
{
    class Hensu
    {
        public static string RunHikisu;//対象ファイルのパス
                                       //各コントロールの数
        public static int ButtonV = 0;
        public static int TextBoxV = 0;
        public static int CheckBoxV = 0;
        public static int ComboBoxV = 0;
        public static int LabelV = 0;
        public static int ListBoxV = 0;
        public static int MenuStripV = 0;
        public static int PictureBoxV = 0;
        public static int ProgressBarV = 0;
        public static int RadioButtonV = 0;
        public static int RichTextBoxV = 0;

        //追加するコントロールの要素
        public static string NewControleKind, NewControleName;
        public static bool NewControleTF = false;

        //イベント追加Windows向け変数
        public static string EventControleKinde, EventControleName;
        public static string[] Ex = new String[50];

        //Form2コントロール　マウス移動関連
        public static string SelectControleKinds;
        public static string SelectControleName;
        public static int SelectControleNumber;

        public static bool ControleMove = false;
        public static bool ControleMove2 = false;


        public static string[,] Dates = new String[99999, 100];

        public static string[] listboxDate = new string[50];
        
    }
}
