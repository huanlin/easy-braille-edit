using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Huanlin.Helpers;
using Huanlin.Braille;

namespace Dots2Byte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            int[] dots = new int[txtDots.Text.Length];

            for (int i = 0; i < txtDots.Text.Length && i < 8; i++) 
            {
                dots[i] = Convert.ToInt32(new string(txtDots.Text[i], 1));
            }

            byte value = BrailleCell.DotsToByte(dots);
            txtByte.Text = String.Format("{0:X}", value);
        }
    }
}