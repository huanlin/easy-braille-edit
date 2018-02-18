using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EasyBrailleEdit
{
	public partial class BusyForm : Form
	{
		public BusyForm()
		{
			InitializeComponent();
		}

		public string Message
		{
			set
			{
				lblMsg.Text = value;
				Application.DoEvents();
			}
		}
	}
}