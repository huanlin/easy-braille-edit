using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Huanlin.Windows.Forms;

namespace EasyBrailleEdit
{
    public partial class FormattedForm : Form
    {
        public FormattedForm()
        {
            InitializeComponent();			
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            rtbFormatted.HideSelection = true;
            rtbFormatted.SelectAll();
            rtbFormatted.Copy();
            rtbFormatted.SelectionStart = 0;
            rtbFormatted.HideSelection = false;
        }

        public string FormattedText
        {
            get
            {
                return rtbFormatted.Text;
            }
            set 
            {
                rtbFormatted.Text = value;
            }
        }

        public string FormattedBraille
        {
            get
            {
                return rtbBraille.Text;
            }
            set
            {
                rtbBraille.Text = value;
            }
        }

        public string MixedText
        {
            get
            {
                return rtbMixed.Text;
            }
            set
            {
                rtbMixed.Text = value;
                SetBrailleFont();
            }
        }

        /// <summary>
        /// 設定 RichTextBox 的點字列為點字字型。
        /// </summary>
        private void SetBrailleFont()
        {
            int i = 0;
            int start = i;
            int lineCount = 0;

            //Font mingFont = new Font("細明體", 15.75f);
            Font brFont = new Font("SimBraille", 21.75f);

            MatchCollection matches = Regex.Matches(rtbMixed.Text, "\n");

            rtbMixed.EnableUpdate = false;
            try
            {
                foreach (Match match in matches)
                {
                    if (lineCount % 2 == 0)
                    {
                        start = match.Index + 1;
                    }
                    else
                    {
                        rtbMixed.SelectionStart = start;
                        rtbMixed.SelectionLength = match.Index - start;
                        rtbMixed.SelectionFont = brFont;
                    }
                    lineCount++;
                }
            }
            finally
            {
                rtbMixed.EnableUpdate = true;
            }
        }


        private void FormattedForm_Load(object sender, EventArgs e)
        {
            tabControl1.TabIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MsgBoxHelper.ShowInfo("此功能尚未完成!");			
        }
    }
}