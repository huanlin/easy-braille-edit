using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EasyBrailleEdit
{
	public partial class ConvertionProgressForm : Form
	{
		private StringBuilder m_InvalidChars;

		public ConvertionProgressForm()
		{
			InitializeComponent();

            SimpleMessageForm = false;
		}

		public string Message
		{
			set
			{
				lblMsg.Text = value;
				Application.DoEvents();
			}
		}

		public int ProgressValue
		{
			get
			{
				return progressBar1.Value;
			}
			set
			{
                if (value > progressBar1.Maximum)
                    value = progressBar1.Maximum;
				progressBar1.Value = value;
			}
		}

        public bool ProgressVisible
        {
            get
            {
                return progressBar1.Visible; 
            }
            set
            {
                progressBar1.Visible = value;
            }
        }

        public bool SimpleMessageForm
        {
            set
            {
                if (value)
                {
                    progressBar1.Visible = false;
                    lblInvalidChar.Visible = false;
                    txtInvalidChar.Visible = false;                    
                    this.Height = lblInvalidChar.Top;
                    this.CenterToScreen();
                }
                else
                {
                    progressBar1.Visible = true;
                    lblInvalidChar.Visible = true;
                    txtInvalidChar.Visible = true;
                    this.Height = 304;
                    this.CenterToScreen();
                }
            }
        }

		public string InvalidChars
		{
			get
			{
				return txtInvalidChar.Text;
			}
		}

		public void AddInvalidChar(char ch)
		{
			m_InvalidChars.Append(ch);
			m_InvalidChars.Append(" ");
			txtInvalidChar.Text = m_InvalidChars.ToString();
		}

		private void ConvertionProgressForm_Load(object sender, EventArgs e)
		{
			m_InvalidChars = new StringBuilder();

			ProgressValue = 0;
		}
	}
}