﻿namespace EasyBrailleEdit
{
	partial class DualEditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DualEditForm));
			this.brGrid = new SourceGrid.Grid();
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.miFile = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.miFilePrint = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.離開XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditPageTitle = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditFetchPageTitles = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.尋找FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditFindNext = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditGoto = new System.Windows.Forms.ToolStripMenuItem();
			this.miView = new System.Windows.Forms.ToolStripMenuItem();
			this.miViewMode = new System.Windows.Forms.ToolStripMenuItem();
			this.miViewAll = new System.Windows.Forms.ToolStripMenuItem();
			this.miViewBrailleOnly = new System.Windows.Forms.ToolStripMenuItem();
			this.miViewTextZhuyin = new System.Windows.Forms.ToolStripMenuItem();
			this.miTools = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.cboZoom = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.txtGotoPageNum = new System.Windows.Forms.ToolStripTextBox();
			this.btnGotoPage = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.statProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.statDocTitle = new System.Windows.Forms.ToolStripStatusLabel();
			this.statPageInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.mnuMain.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// brGrid
			// 
			this.brGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.brGrid.ColumnsCount = 1;
			this.brGrid.CustomSort = true;
			this.brGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.brGrid.FixedColumns = 1;
			this.brGrid.FixedRows = 1;
			this.brGrid.Location = new System.Drawing.Point(0, 49);
			this.brGrid.Name = "brGrid";
			this.brGrid.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
			this.brGrid.RowsCount = 1;
			this.brGrid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
			this.brGrid.Size = new System.Drawing.Size(753, 454);
			this.brGrid.TabIndex = 2;
			this.brGrid.TabStop = true;
			this.brGrid.ToolTipText = "";
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit,
            this.miView,
            this.miTools});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(753, 24);
			this.mnuMain.TabIndex = 3;
			this.mnuMain.Text = "menuStrip1";
			// 
			// miFile
			// 
			this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileOpen,
            this.miFileSave,
            this.miFileSaveAs,
            this.toolStripMenuItem1,
            this.miFilePrint,
            this.toolStripMenuItem2,
            this.離開XToolStripMenuItem});
			this.miFile.Name = "miFile";
			this.miFile.Size = new System.Drawing.Size(55, 20);
			this.miFile.Text = "檔案(&F)";
			// 
			// miFileOpen
			// 
			this.miFileOpen.Name = "miFileOpen";
			this.miFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.miFileOpen.Size = new System.Drawing.Size(180, 22);
			this.miFileOpen.Text = "開啟舊檔(&O)...";
			this.miFileOpen.Click += new System.EventHandler(this.miFileOpen_Click);
			// 
			// miFileSave
			// 
			this.miFileSave.Name = "miFileSave";
			this.miFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.miFileSave.Size = new System.Drawing.Size(180, 22);
			this.miFileSave.Text = "儲存檔案";
			this.miFileSave.Click += new System.EventHandler(this.miFileSave_Click);
			// 
			// miFileSaveAs
			// 
			this.miFileSaveAs.Name = "miFileSaveAs";
			this.miFileSaveAs.Size = new System.Drawing.Size(180, 22);
			this.miFileSaveAs.Text = "另存新檔(&A)";
			this.miFileSaveAs.Click += new System.EventHandler(this.miFileSaveAs_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
			// 
			// miFilePrint
			// 
			this.miFilePrint.Name = "miFilePrint";
			this.miFilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.miFilePrint.Size = new System.Drawing.Size(180, 22);
			this.miFilePrint.Text = "列印(&P)";
			this.miFilePrint.Click += new System.EventHandler(this.miFilePrint_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
			// 
			// 離開XToolStripMenuItem
			// 
			this.離開XToolStripMenuItem.Name = "離開XToolStripMenuItem";
			this.離開XToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.離開XToolStripMenuItem.Text = "離開(&X)";
			// 
			// miEdit
			// 
			this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditPageTitle,
            this.miEditFetchPageTitles,
            this.toolStripMenuItem3,
            this.尋找FToolStripMenuItem,
            this.miEditFindNext,
            this.miEditGoto});
			this.miEdit.Name = "miEdit";
			this.miEdit.Size = new System.Drawing.Size(56, 20);
			this.miEdit.Text = "編輯(&E)";
			// 
			// miEditPageTitle
			// 
			this.miEditPageTitle.Name = "miEditPageTitle";
			this.miEditPageTitle.Size = new System.Drawing.Size(154, 22);
			this.miEditPageTitle.Tag = "PageTitles";
			this.miEditPageTitle.Text = "頁標題";
			this.miEditPageTitle.Click += new System.EventHandler(this.miEdit_Click);
			// 
			// miEditFetchPageTitles
			// 
			this.miEditFetchPageTitles.Name = "miEditFetchPageTitles";
			this.miEditFetchPageTitles.Size = new System.Drawing.Size(154, 22);
			this.miEditFetchPageTitles.Tag = "FetchPageTitles";
			this.miEditFetchPageTitles.Text = "重新抓取頁標題";
			this.miEditFetchPageTitles.Click += new System.EventHandler(this.miEdit_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(151, 6);
			// 
			// 尋找FToolStripMenuItem
			// 
			this.尋找FToolStripMenuItem.Name = "尋找FToolStripMenuItem";
			this.尋找FToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.尋找FToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.尋找FToolStripMenuItem.Tag = "Find";
			this.尋找FToolStripMenuItem.Text = "尋找(&F)";
			this.尋找FToolStripMenuItem.Click += new System.EventHandler(this.miEdit_Click);
			// 
			// miEditFindNext
			// 
			this.miEditFindNext.Name = "miEditFindNext";
			this.miEditFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.miEditFindNext.Size = new System.Drawing.Size(154, 22);
			this.miEditFindNext.Tag = "FindNext";
			this.miEditFindNext.Text = "找下一筆(&N)";
			this.miEditFindNext.Click += new System.EventHandler(this.miEdit_Click);
			// 
			// miEditGoto
			// 
			this.miEditGoto.Name = "miEditGoto";
			this.miEditGoto.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.miEditGoto.Size = new System.Drawing.Size(154, 22);
			this.miEditGoto.Tag = "Goto";
			this.miEditGoto.Text = "到(&G)";
			this.miEditGoto.Click += new System.EventHandler(this.miEdit_Click);
			// 
			// miView
			// 
			this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewMode});
			this.miView.Name = "miView";
			this.miView.Size = new System.Drawing.Size(57, 20);
			this.miView.Text = "檢視(&V)";
			this.miView.Visible = false;
			// 
			// miViewMode
			// 
			this.miViewMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewAll,
            this.miViewBrailleOnly,
            this.miViewTextZhuyin});
			this.miViewMode.Name = "miViewMode";
			this.miViewMode.Size = new System.Drawing.Size(112, 22);
			this.miViewMode.Text = "模式(&M)";
			this.miViewMode.Visible = false;
			// 
			// miViewAll
			// 
			this.miViewAll.Name = "miViewAll";
			this.miViewAll.Size = new System.Drawing.Size(194, 22);
			this.miViewAll.Tag = "All";
			this.miViewAll.Text = "顯示全部(&A)";
			this.miViewAll.Click += new System.EventHandler(this.miViewMode_Click);
			// 
			// miViewBrailleOnly
			// 
			this.miViewBrailleOnly.Name = "miViewBrailleOnly";
			this.miViewBrailleOnly.Size = new System.Drawing.Size(194, 22);
			this.miViewBrailleOnly.Tag = "BrailleOnly";
			this.miViewBrailleOnly.Text = "僅顯示點字(&B)";
			this.miViewBrailleOnly.Click += new System.EventHandler(this.miViewMode_Click);
			// 
			// miViewTextZhuyin
			// 
			this.miViewTextZhuyin.Name = "miViewTextZhuyin";
			this.miViewTextZhuyin.Size = new System.Drawing.Size(194, 22);
			this.miViewTextZhuyin.Tag = "TextAndZhuyin";
			this.miViewTextZhuyin.Text = "僅顯示明眼字與注音(&C)";
			this.miViewTextZhuyin.Click += new System.EventHandler(this.miViewMode_Click);
			// 
			// miTools
			// 
			this.miTools.Name = "miTools";
			this.miTools.Size = new System.Drawing.Size(56, 20);
			this.miTools.Text = "工具(&T)";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.helpToolStripButton,
            this.cboZoom,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtGotoPageNum,
            this.btnGotoPage});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(753, 25);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton.Tag = "Open";
			this.openToolStripButton.Text = "開啟舊檔(&O)";
			this.openToolStripButton.ToolTipText = "開啟舊檔";
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton.Tag = "Save";
			this.saveToolStripButton.Text = "儲存檔案(&S)";
			this.saveToolStripButton.ToolTipText = "儲存檔案";
			// 
			// printToolStripButton
			// 
			this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
			this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripButton.Name = "printToolStripButton";
			this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.printToolStripButton.Tag = "Print";
			this.printToolStripButton.Text = "列印(&P)";
			this.printToolStripButton.ToolTipText = "列印";
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.helpToolStripButton.Text = "He&lp";
			// 
			// cboZoom
			// 
			this.cboZoom.AutoSize = false;
			this.cboZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboZoom.Items.AddRange(new object[] {
            "130%",
            "115%",
            "100%",
            "85%",
            "70%"});
			this.cboZoom.Name = "cboZoom";
			this.cboZoom.Size = new System.Drawing.Size(121, 20);
			this.cboZoom.SelectedIndexChanged += new System.EventHandler(this.cboZoom_SelectedIndexChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(41, 22);
			this.toolStripLabel1.Text = "頁號：";
			// 
			// txtGotoPageNum
			// 
			this.txtGotoPageNum.AutoSize = false;
			this.txtGotoPageNum.MaxLength = 4;
			this.txtGotoPageNum.Name = "txtGotoPageNum";
			this.txtGotoPageNum.Size = new System.Drawing.Size(100, 25);
			// 
			// btnGotoPage
			// 
			this.btnGotoPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnGotoPage.Image = ((System.Drawing.Image)(resources.GetObject("btnGotoPage.Image")));
			this.btnGotoPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGotoPage.Name = "btnGotoPage";
			this.btnGotoPage.Size = new System.Drawing.Size(33, 22);
			this.btnGotoPage.Text = "移至";
			this.btnGotoPage.Click += new System.EventHandler(this.btnGotoPage_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statMessage,
            this.statProgressBar,
            this.statDocTitle,
            this.statPageInfo});
			this.statusStrip1.Location = new System.Drawing.Point(0, 503);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(753, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statMessage
			// 
			this.statMessage.AutoSize = false;
			this.statMessage.Name = "statMessage";
			this.statMessage.Size = new System.Drawing.Size(350, 17);
			this.statMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// statProgressBar
			// 
			this.statProgressBar.Name = "statProgressBar";
			this.statProgressBar.Size = new System.Drawing.Size(100, 16);
			// 
			// statDocTitle
			// 
			this.statDocTitle.AutoSize = false;
			this.statDocTitle.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.statDocTitle.Name = "statDocTitle";
			this.statDocTitle.Size = new System.Drawing.Size(150, 17);
			// 
			// statPageInfo
			// 
			this.statPageInfo.AutoSize = false;
			this.statPageInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.statPageInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.statPageInfo.Name = "statPageInfo";
			this.statPageInfo.Size = new System.Drawing.Size(70, 17);
			// 
			// DualEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(753, 525);
			this.Controls.Add(this.brGrid);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.mnuMain);
			this.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.KeyPreview = true;
			this.MainMenuStrip = this.mnuMain;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DualEditForm";
			this.Text = "雙視編輯";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.DualEditForm_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DualEditForm_FormClosed);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DualEditForm_KeyPress);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DualEditForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DualEditForm_KeyDown);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private SourceGrid.Grid brGrid;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miTools;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFileOpen;
        private System.Windows.Forms.ToolStripMenuItem miFileSave;
        private System.Windows.Forms.ToolStripMenuItem miFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 離開XToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miFilePrint;
        private System.Windows.Forms.ToolStripComboBox cboZoom;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statMessage;
        private System.Windows.Forms.ToolStripProgressBar statProgressBar;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.ToolStripMenuItem miViewMode;
        private System.Windows.Forms.ToolStripMenuItem miViewAll;
        private System.Windows.Forms.ToolStripMenuItem miViewBrailleOnly;
        private System.Windows.Forms.ToolStripMenuItem miViewTextZhuyin;
        private System.Windows.Forms.ToolStripStatusLabel statPageInfo;
        private System.Windows.Forms.ToolStripStatusLabel statDocTitle;
        private System.Windows.Forms.ToolStripMenuItem 尋找FToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem miEditPageTitle;
		private System.Windows.Forms.ToolStripMenuItem miEditGoto;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox txtGotoPageNum;
		private System.Windows.Forms.ToolStripButton btnGotoPage;
		private System.Windows.Forms.ToolStripMenuItem miEditFindNext;
		private System.Windows.Forms.ToolStripMenuItem miEditFetchPageTitles;

	}
}