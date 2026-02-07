namespace MathAssessment.Teacher.Win.Forms
{
    partial class FrmImportExams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportExams));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnBrowseXml = new DevExpress.XtraBars.BarButtonItem();
            this.btnProcess = new DevExpress.XtraBars.BarButtonItem();
            this.pageImport = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.grpActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.panelBody = new DevExpress.XtraEditors.PanelControl();
            this.gcPreview = new DevExpress.XtraGrid.GridControl();
            this.gvPreview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStudentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExamCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaskCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpressionText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStudentAnswerText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCorrectAnswer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCorrect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemIsCorrect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colErrorMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBody)).BeginInit();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemIsCorrect)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnBrowseXml,
            this.btnProcess,
            this.btnSave});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageImport});
            this.ribbon.Size = new System.Drawing.Size(955, 193);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnBrowseXml
            // 
            this.btnBrowseXml.Caption = "Browse XML";
            this.btnBrowseXml.Id = 1;
            this.btnBrowseXml.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBrowseXml.ImageOptions.SvgImage")));
            this.btnBrowseXml.Name = "btnBrowseXml";
            this.btnBrowseXml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBrowseXml_ItemClick);
            // 
            // btnProcess
            // 
            this.btnProcess.Caption = "Process & Grade";
            this.btnProcess.Id = 2;
            this.btnProcess.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnProcess.ImageOptions.SvgImage")));
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProcess_ItemClick);
            // 
            // pageImport
            // 
            this.pageImport.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.grpActions});
            this.pageImport.Name = "pageImport";
            this.pageImport.Text = "Import";
            // 
            // grpActions
            // 
            this.grpActions.ItemLinks.Add(this.btnBrowseXml);
            this.grpActions.ItemLinks.Add(this.btnProcess);
            this.grpActions.ItemLinks.Add(this.btnSave);
            this.grpActions.Name = "grpActions";
            this.grpActions.Text = "Actions";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 477);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(955, 30);
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.gcPreview);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 193);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(955, 284);
            this.panelBody.TabIndex = 2;
            // 
            // gcPreview
            // 
            this.gcPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPreview.Location = new System.Drawing.Point(2, 2);
            this.gcPreview.MainView = this.gvPreview;
            this.gcPreview.MenuManager = this.ribbon;
            this.gcPreview.Name = "gcPreview";
            this.gcPreview.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemIsCorrect});
            this.gcPreview.Size = new System.Drawing.Size(951, 280);
            this.gcPreview.TabIndex = 0;
            this.gcPreview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPreview});
            // 
            // gvPreview
            // 
            this.gvPreview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStudentCode,
            this.colExamCode,
            this.colTaskCode,
            this.colExpressionText,
            this.colStudentAnswerText,
            this.colCorrectAnswer,
            this.colIsCorrect,
            this.colErrorMessage});
            this.gvPreview.GridControl = this.gcPreview;
            this.gvPreview.Name = "gvPreview";
            this.gvPreview.OptionsBehavior.Editable = false;
            this.gvPreview.OptionsFind.AlwaysVisible = true;
            this.gvPreview.OptionsSelection.MultiSelect = true;
            this.gvPreview.OptionsView.ColumnAutoWidth = false;
            this.gvPreview.OptionsView.ShowGroupPanel = false;
            // 
            // colStudentCode
            // 
            this.colStudentCode.Caption = "Student Code";
            this.colStudentCode.FieldName = "StudentCode";
            this.colStudentCode.MinWidth = 25;
            this.colStudentCode.Name = "colStudentCode";
            this.colStudentCode.Visible = true;
            this.colStudentCode.VisibleIndex = 0;
            this.colStudentCode.Width = 100;
            // 
            // colExamCode
            // 
            this.colExamCode.Caption = "Exam";
            this.colExamCode.FieldName = "ExamCode";
            this.colExamCode.MinWidth = 25;
            this.colExamCode.Name = "colExamCode";
            this.colExamCode.Visible = true;
            this.colExamCode.VisibleIndex = 1;
            this.colExamCode.Width = 60;
            // 
            // colTaskCode
            // 
            this.colTaskCode.Caption = "Task";
            this.colTaskCode.FieldName = "TaskCode";
            this.colTaskCode.MinWidth = 25;
            this.colTaskCode.Name = "colTaskCode";
            this.colTaskCode.Visible = true;
            this.colTaskCode.VisibleIndex = 2;
            this.colTaskCode.Width = 94;
            // 
            // colExpressionText
            // 
            this.colExpressionText.Caption = "Expression";
            this.colExpressionText.FieldName = "ExpressionText";
            this.colExpressionText.MinWidth = 25;
            this.colExpressionText.Name = "colExpressionText";
            this.colExpressionText.Visible = true;
            this.colExpressionText.VisibleIndex = 3;
            this.colExpressionText.Width = 150;
            // 
            // colStudentAnswerText
            // 
            this.colStudentAnswerText.Caption = "Student Answer";
            this.colStudentAnswerText.FieldName = "StudentAnswerText";
            this.colStudentAnswerText.MinWidth = 25;
            this.colStudentAnswerText.Name = "colStudentAnswerText";
            this.colStudentAnswerText.Visible = true;
            this.colStudentAnswerText.VisibleIndex = 4;
            this.colStudentAnswerText.Width = 120;
            // 
            // colCorrectAnswer
            // 
            this.colCorrectAnswer.Caption = "Correct Answer";
            this.colCorrectAnswer.FieldName = "CorrectAnswer";
            this.colCorrectAnswer.MinWidth = 25;
            this.colCorrectAnswer.Name = "colCorrectAnswer";
            this.colCorrectAnswer.Visible = true;
            this.colCorrectAnswer.VisibleIndex = 5;
            this.colCorrectAnswer.Width = 120;
            // 
            // colIsCorrect
            // 
            this.colIsCorrect.Caption = "Correct";
            this.colIsCorrect.ColumnEdit = this.repositoryItemIsCorrect;
            this.colIsCorrect.FieldName = "IsCorrect";
            this.colIsCorrect.MinWidth = 25;
            this.colIsCorrect.Name = "colIsCorrect";
            this.colIsCorrect.Visible = true;
            this.colIsCorrect.VisibleIndex = 6;
            this.colIsCorrect.Width = 80;
            // 
            // repositoryItemIsCorrect
            // 
            this.repositoryItemIsCorrect.AutoHeight = false;
            this.repositoryItemIsCorrect.Name = "repositoryItemIsCorrect";
            // 
            // colErrorMessage
            // 
            this.colErrorMessage.Caption = "Error";
            this.colErrorMessage.FieldName = "ErrorMessage";
            this.colErrorMessage.MinWidth = 25;
            this.colErrorMessage.Name = "colErrorMessage";
            this.colErrorMessage.Visible = true;
            this.colErrorMessage.VisibleIndex = 7;
            this.colErrorMessage.Width = 200;
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 3;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // FrmImportExams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 507);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.ribbonStatusBar);
            this.Name = "FrmImportExams";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Import Exams";
            this.Load += new System.EventHandler(this.FrmImportExams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBody)).EndInit();
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemIsCorrect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageImport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup grpActions;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnBrowseXml;
        private DevExpress.XtraBars.BarButtonItem btnProcess;
        private DevExpress.XtraEditors.PanelControl panelBody;
        private DevExpress.XtraGrid.GridControl gcPreview;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPreview;
        private DevExpress.XtraGrid.Columns.GridColumn colStudentCode;
        private DevExpress.XtraGrid.Columns.GridColumn colExamCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTaskCode;
        private DevExpress.XtraGrid.Columns.GridColumn colExpressionText;
        private DevExpress.XtraGrid.Columns.GridColumn colStudentAnswerText;
        private DevExpress.XtraGrid.Columns.GridColumn colCorrectAnswer;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCorrect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemIsCorrect;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorMessage;
        private DevExpress.XtraBars.BarButtonItem btnSave;
    }
}