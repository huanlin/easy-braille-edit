namespace EasyBrailleEdit
{
	partial class DualEditFindForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtTarget = new System.Windows.Forms.TextBox();
			this.btnFind = new System.Windows.Forms.Button();
			this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 25);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "尋找目標(&N):";
			// 
			// txtTarget
			// 
			this.txtTarget.Location = new System.Drawing.Point(114, 22);
			this.txtTarget.MaxLength = 20;
			this.txtTarget.Name = "txtTarget";
			this.txtTarget.Size = new System.Drawing.Size(225, 25);
			this.txtTarget.TabIndex = 1;
			// 
			// btnFind
			// 
			this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFind.Location = new System.Drawing.Point(204, 92);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(135, 31);
			this.btnFind.TabIndex = 2;
			this.btnFind.Text = "尋找下一筆(&F)";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// chkCaseSensitive
			// 
			this.chkCaseSensitive.AutoSize = true;
			this.chkCaseSensitive.Location = new System.Drawing.Point(19, 74);
			this.chkCaseSensitive.Name = "chkCaseSensitive";
			this.chkCaseSensitive.Size = new System.Drawing.Size(101, 19);
			this.chkCaseSensitive.TabIndex = 3;
			this.chkCaseSensitive.Text = "大小寫相符";
			this.chkCaseSensitive.UseVisualStyleBackColor = true;
			// 
			// DualEditFindForm
			// 
			this.AcceptButton = this.btnFind;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 139);
			this.Controls.Add(this.chkCaseSensitive);
			this.Controls.Add(this.btnFind);
			this.Controls.Add(this.txtTarget);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "DualEditFindForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "尋找";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DualEditFindForm_FormClosing);
			this.Load += new System.EventHandler(this.DualEditFindForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTarget;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.CheckBox chkCaseSensitive;
	}
}