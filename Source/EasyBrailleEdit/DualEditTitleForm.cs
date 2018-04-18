using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BrailleToolkit;

namespace EasyBrailleEdit
{
    public partial class DualEditTitleForm : Form
    {
        private BrailleDocument m_OrgBrDoc;	// 標題列所屬的 BrailleDocument 物件
        private BrailleDocument m_TmpBrDoc;	// 把所有標題列都丟到這個暫時的 railleDocument 物件
        private List<BraillePageTitle> m_Titles;
        private int m_CellsPerLine;
        private bool m_IsDirty;   // 文件內容是否被修改過

        private DualEditController m_DualEditController;

        private DualEditTitleForm()
        {
            InitializeComponent();
        }

        public DualEditTitleForm(BrailleDocument brDoc)
            : this()
        {
            m_OrgBrDoc = brDoc;

            m_TmpBrDoc = new BrailleDocument(brDoc.Processor, brDoc.CellsPerLine);

            m_Titles = new List<BraillePageTitle>();

            // 複製所有標題列，並將標題列塞進暫存文件。
            BraillePageTitle newTitle = null;
            foreach (BraillePageTitle t in brDoc.PageTitles)
            {
                newTitle = t.Clone() as BraillePageTitle;
                m_Titles.Add(newTitle);

                m_TmpBrDoc.Lines.Add(newTitle.TitleLine);		// 塞進暫存文件。
            }

            m_DualEditController = new DualEditController(m_TmpBrDoc, brGrid);

            m_DualEditController.DataChanged += new EventHandler(DualEditControler_DataChanged);

            m_IsDirty = false;
        }

        void DualEditControler_DataChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }

        #region 屬性

        public List<BraillePageTitle> Titles
        {
            get { return m_Titles; }
        }

        public int CellsPerLine
        {
            get { return m_CellsPerLine; }
            set { m_CellsPerLine = value; }
        }

        public bool IsDirty
        {
            get { return m_IsDirty; }
            set	{ m_IsDirty = value; }
        }

        private DualEditController DualEditController
        {
            get { return m_DualEditController; }
        }

        #endregion

        private void DualEditTitleForm_Load(object sender, EventArgs e)
        {
            DualEditController.InitializeGrid(new SourceGrid.CellContextEventHandler(GridMenu_Click));

            // 隱藏禁止使用的功能。
            DualEditController.MenuController.HideMenuItem("InsertLine", true);
            DualEditController.MenuController.HideMenuItem("DeleteLine", true);
            
            DualEditController.FillGrid();
        }

        /// <summary>
        /// Grid popup menu 點擊事件處裡常式。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GridMenu_Click(object sender, SourceGrid.CellContextEventArgs e)
        {
            PopupMenuController menuCtrl = (PopupMenuController)sender;
            SourceGrid.CellContext cell = e.CellContext;
            SourceGrid.Grid grid = (SourceGrid.Grid)cell.Grid;
            int row = cell.Position.Row;
            int col = cell.Position.Column;

            switch (menuCtrl.Command)
            {
                case "Edit":
                    DualEditController.EditCell(row, col);
                    break;
                case "Insert":
                    DualEditController.InsertCell(row, col);
                    break;
                case "InsertBlank":  // 插入空方                        
                    DualEditController.InsertBlankCell(row, col, 1);
                    break;
                case "Append":  // 在列尾插入空方
                    DualEditController.AppendCell(row, col);
                    break;
                case "InsertLine":  // 插入一列
                    DualEditController.InsertLine(row, col);
                    break;
                case "Delete":
                    DualEditController.DeleteCell(row, col);
                    break;
                case "Backspace":
                    DualEditController.BackspaceCell(row, col);
                    break;
                case "DeleteLine":
                    DualEditController.DeleteLine(row, col, true);
                    break;
                default:
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnAbortEdit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}