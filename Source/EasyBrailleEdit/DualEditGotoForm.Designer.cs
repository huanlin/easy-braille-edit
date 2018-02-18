namespace EasyBrailleEdit
{
	partial class DualEditGotoForm
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
			this.rdoLine = new System.Windows.Forms.RadioButton();
			this.rdoPage = new System.Windows.Forms.RadioButton();
			this.numPosition = new System.Windows.Forms.NumericUpDown();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numPosition)).BeginInit();
			this.SuspendLayout();
			// 
			// rdoLine
			// 
			this.rdoLine.AutoSize = true;
			this.rdoLine.Checked = true;
			this.rdoLine.Location = new System.Drawing.Point(25, 25);
			this.rdoLine.Name = "rdoLine";
			this.rdoLine.Size = new System.Drawing.Size(63, 19);
			this.rdoLine.TabIndex = 0;
			this.rdoLine.TabStop = true;
			this.rdoLine.Text = "列 (&L)";
			this.rdoLine.UseVisualStyleBackColor = true;
			// 
			// rdoPage
			// 
			this.rdoPage.AutoSize = true;
			this.rdoPage.Location = new System.Drawing.Point(26, 50);
			this.rdoPage.Name = "rdoPage";
			this.rdoPage.Size = new System.Drawing.Size(62, 19);
			this.rdoPage.TabIndex = 1;
			this.rdoPage.Text = "頁 (&P)";
			this.rdoPage.UseVisualStyleBackColor = true;
			// 
			// numPosition
			// 
			this.numPosition.Location = new System.Drawing.Point(26, 84);
			this.numPosition.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numPosition.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numPosition.Name = "numPosition";
			this.numPosition.Size = new System.Drawing.Size(79, 25);
			this.numPosition.TabIndex = 2;
			this.numPosition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(156, 25);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 30);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "確定";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(156, 61);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// DualEditGotoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(243, 121);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.numPosition);
			this.Controls.Add(this.rdoPage);
			this.Controls.Add(this.rdoLine);
			this.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DualEditGotoForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "移動至";
			((System.ComponentModel.ISupportInitialize)(this.numPosition)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rdoLine;
		private System.Windows.Forms.RadioButton rdoPage;
		private System.Windows.Forms.NumericUpDown numPosition;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
	}
}