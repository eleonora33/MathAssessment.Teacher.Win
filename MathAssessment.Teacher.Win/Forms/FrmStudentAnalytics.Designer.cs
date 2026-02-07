namespace MathAssessment.Teacher.Win.Forms
{
    partial class FrmStudentAnalytics
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtStudentCode = new DevExpress.XtraEditors.TextEdit();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.gcExams = new DevExpress.XtraGrid.GridControl();
            this.gvExams = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTasks = new DevExpress.XtraGrid.GridControl();
            this.gvTasks = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudentCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gcExams);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gcTasks);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(816, 435);
            this.splitContainerControl1.SplitterPosition = 249;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnLoad);
            this.panelControl1.Controls.Add(this.txtStudentCode);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(816, 100);
            this.panelControl1.TabIndex = 0;
            // 
            // txtStudentCode
            // 
            this.txtStudentCode.Location = new System.Drawing.Point(30, 25);
            this.txtStudentCode.Name = "txtStudentCode";
            this.txtStudentCode.Properties.NullValuePrompt = "\"Student Code\"";
            this.txtStudentCode.Size = new System.Drawing.Size(218, 22);
            this.txtStudentCode.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(154, 53);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // gcExams
            // 
            this.gcExams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcExams.Location = new System.Drawing.Point(0, 100);
            this.gcExams.MainView = this.gvExams;
            this.gcExams.Name = "gcExams";
            this.gcExams.Size = new System.Drawing.Size(816, 149);
            this.gcExams.TabIndex = 1;
            this.gcExams.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExams});
            // 
            // gvExams
            // 
            this.gvExams.GridControl = this.gcExams;
            this.gvExams.Name = "gvExams";
            this.gvExams.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvExams_FocusedRowChanged);
            // 
            // gcTasks
            // 
            this.gcTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTasks.Location = new System.Drawing.Point(0, 0);
            this.gcTasks.MainView = this.gvTasks;
            this.gcTasks.Name = "gcTasks";
            this.gcTasks.Size = new System.Drawing.Size(816, 174);
            this.gcTasks.TabIndex = 0;
            this.gcTasks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTasks});
            // 
            // gvTasks
            // 
            this.gvTasks.GridControl = this.gcTasks;
            this.gvTasks.Name = "gvTasks";
            // 
            // FrmStudentAnalytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 435);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FrmStudentAnalytics";
            this.Text = "FrmStudentAnalytics";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtStudentCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtStudentCode;
        private DevExpress.XtraGrid.GridControl gcExams;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExams;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraGrid.GridControl gcTasks;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTasks;
    }
}