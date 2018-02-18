namespace EasyBrailleEdit
{
	partial class FormattedForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.rtbFormatted = new Huanlin.WinForms.RichTextBoxHL();
			this.rtbBraille = new Huanlin.WinForms.RichTextBoxHL();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.rtbMixed = new Huanlin.WinForms.RichTextBoxHL();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCopy);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 430);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(907, 56);
			this.panel1.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Location = new System.Drawing.Point(764, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(129, 34);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "關閉視窗";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(145, 8);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(129, 34);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "另存檔案";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(10, 8);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(129, 34);
			this.btnCopy.TabIndex = 0;
			this.btnCopy.Text = "複製到剪貼簿";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(907, 430);
			this.tabControl1.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.splitContainer1);
			this.tabPage1.Location = new System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(899, 402);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "文字與點字分開";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.rtbFormatted);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.rtbBraille);
			this.splitContainer1.Size = new System.Drawing.Size(893, 396);
			this.splitContainer1.SplitterDistance = 274;
			this.splitContainer1.TabIndex = 7;
			// 
			// rtbFormatted
			// 
			this.rtbFormatted.BackColor = System.Drawing.SystemColors.Window;
			this.rtbFormatted.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbFormatted.EnableTagColor = false;
			this.rtbFormatted.EnableUpdate = true;
			this.rtbFormatted.Font = new System.Drawing.Font("MingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.rtbFormatted.Location = new System.Drawing.Point(0, 0);
			this.rtbFormatted.Name = "rtbFormatted";
			this.rtbFormatted.ReadOnly = true;
			this.rtbFormatted.Size = new System.Drawing.Size(274, 396);
			this.rtbFormatted.TabIndex = 3;
			this.rtbFormatted.TagColor = System.Drawing.Color.Maroon;
			this.rtbFormatted.Text = "";
			this.rtbFormatted.WordWrap = false;
			// 
			// rtbBraille
			// 
			this.rtbBraille.BackColor = System.Drawing.SystemColors.Window;
			this.rtbBraille.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbBraille.EnableTagColor = false;
			this.rtbBraille.EnableUpdate = true;
			this.rtbBraille.Font = new System.Drawing.Font("SimBraille", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbBraille.Location = new System.Drawing.Point(0, 0);
			this.rtbBraille.Name = "rtbBraille";
			this.rtbBraille.ReadOnly = true;
			this.rtbBraille.Size = new System.Drawing.Size(615, 396);
			this.rtbBraille.TabIndex = 5;
			this.rtbBraille.TagColor = System.Drawing.Color.Maroon;
			this.rtbBraille.Text = "";
			this.rtbBraille.WordWrap = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.rtbMixed);
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(899, 402);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "文字與點字相間";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// rtbMixed
			// 
			this.rtbMixed.BackColor = System.Drawing.SystemColors.Window;
			this.rtbMixed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbMixed.EnableTagColor = false;
			this.rtbMixed.EnableUpdate = true;
			this.rtbMixed.Font = new System.Drawing.Font("MingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.rtbMixed.Location = new System.Drawing.Point(3, 3);
			this.rtbMixed.Name = "rtbMixed";
			this.rtbMixed.ReadOnly = true;
			this.rtbMixed.Size = new System.Drawing.Size(893, 396);
			this.rtbMixed.TabIndex = 4;
			this.rtbMixed.TagColor = System.Drawing.Color.Maroon;
			this.rtbMixed.Text = "";
			this.rtbMixed.WordWrap = false;
			// 
			// FormattedForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(907, 486);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("MingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormattedForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "編排結果";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.FormattedForm_Load);
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private Huanlin.WinForms.RichTextBoxHL rtbFormatted;
		private Huanlin.WinForms.RichTextBoxHL rtbBraille;
		private System.Windows.Forms.TabPage tabPage2;
		private Huanlin.WinForms.RichTextBoxHL rtbMixed;
	}
}