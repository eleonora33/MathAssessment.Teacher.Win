using DevExpress.XtraEditors;

namespace MathAssessment.Teacher.Win.Forms
{
    partial class FrmImportResult
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();

            this.lblImportIdValue = new DevExpress.XtraEditors.LabelControl();
            this.lblExamsValue = new DevExpress.XtraEditors.LabelControl();
            this.lblTasksValue = new DevExpress.XtraEditors.LabelControl();
            this.lblCorrectValue = new DevExpress.XtraEditors.LabelControl();
            this.lblWrongValue = new DevExpress.XtraEditors.LabelControl();
            this.lblErrorsValue = new DevExpress.XtraEditors.LabelControl();

            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.groupImportSummary = new DevExpress.XtraLayout.LayoutControlGroup();

            this.lciImportIdValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciExamsValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTasksValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCorrectValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciWrongValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciErrorsValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciClose = new DevExpress.XtraLayout.LayoutControlItem();

            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupImportSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImportIdValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExamsValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTasksValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCorrectValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWrongValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciErrorsValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciClose)).BeginInit();
            this.SuspendLayout();

            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.lblImportIdValue);
            this.layoutControl1.Controls.Add(this.lblExamsValue);
            this.layoutControl1.Controls.Add(this.lblTasksValue);
            this.layoutControl1.Controls.Add(this.lblCorrectValue);
            this.layoutControl1.Controls.Add(this.lblWrongValue);
            this.layoutControl1.Controls.Add(this.lblErrorsValue);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(722, 331);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";

            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(28, 204);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // lblImportIdValue
            // 
            this.lblImportIdValue.Location = new System.Drawing.Point(28, 54);
            this.lblImportIdValue.Name = "lblImportIdValue";
            this.lblImportIdValue.Size = new System.Drawing.Size(80, 16);
            this.lblImportIdValue.StyleController = this.layoutControl1;
            this.lblImportIdValue.TabIndex = 10;
            this.lblImportIdValue.Text = "Import ID: -";

            // 
            // lblExamsValue
            // 
            this.lblExamsValue.Location = new System.Drawing.Point(28, 79);
            this.lblExamsValue.Name = "lblExamsValue";
            this.lblExamsValue.Size = new System.Drawing.Size(62, 16);
            this.lblExamsValue.StyleController = this.layoutControl1;
            this.lblExamsValue.TabIndex = 5;
            this.lblExamsValue.Text = "Exams: -";

            // 
            // lblTasksValue
            // 
            this.lblTasksValue.Location = new System.Drawing.Point(28, 104);
            this.lblTasksValue.Name = "lblTasksValue";
            this.lblTasksValue.Size = new System.Drawing.Size(56, 16);
            this.lblTasksValue.StyleController = this.layoutControl1;
            this.lblTasksValue.TabIndex = 11;
            this.lblTasksValue.Text = "Tasks: -";

            // 
            // lblCorrectValue
            // 
            this.lblCorrectValue.Location = new System.Drawing.Point(28, 129);
            this.lblCorrectValue.Name = "lblCorrectValue";
            this.lblCorrectValue.Size = new System.Drawing.Size(68, 16);
            this.lblCorrectValue.StyleController = this.layoutControl1;
            this.lblCorrectValue.TabIndex = 7;
            this.lblCorrectValue.Text = "Correct: -";

            // 
            // lblWrongValue
            // 
            this.lblWrongValue.Location = new System.Drawing.Point(28, 154);
            this.lblWrongValue.Name = "lblWrongValue";
            this.lblWrongValue.Size = new System.Drawing.Size(58, 16);
            this.lblWrongValue.StyleController = this.layoutControl1;
            this.lblWrongValue.TabIndex = 8;
            this.lblWrongValue.Text = "Wrong: -";

            // 
            // lblErrorsValue
            // 
            this.lblErrorsValue.Location = new System.Drawing.Point(28, 179);
            this.lblErrorsValue.Name = "lblErrorsValue";
            this.lblErrorsValue.Size = new System.Drawing.Size(54, 16);
            this.lblErrorsValue.StyleController = this.layoutControl1;
            this.lblErrorsValue.TabIndex = 9;
            this.lblErrorsValue.Text = "Errors: -";

            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.emptySpaceItem1,
                this.groupImportSummary
            });
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(722, 331);
            this.Root.TextVisible = false;

            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Location = new System.Drawing.Point(127, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(571, 307);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);

            // 
            // groupImportSummary
            // 
            this.groupImportSummary.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.groupImportSummary.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.lciImportIdValue,
                this.lciExamsValue,
                this.lciTasksValue,
                this.lciCorrectValue,
                this.lciWrongValue,
                this.lciErrorsValue,
                this.lciClose
            });
            this.groupImportSummary.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Flow;
            this.groupImportSummary.Location = new System.Drawing.Point(0, 0);
            this.groupImportSummary.Name = "groupImportSummary";
            this.groupImportSummary.Size = new System.Drawing.Size(127, 307);
            this.groupImportSummary.Text = "Import Summary";

            // 
            // lciImportIdValue
            // 
            this.lciImportIdValue.Control = this.lblImportIdValue;
            this.lciImportIdValue.Location = new System.Drawing.Point(0, 0);
            this.lciImportIdValue.MaxSize = new System.Drawing.Size(0, 25);
            this.lciImportIdValue.MinSize = new System.Drawing.Size(1, 25);
            this.lciImportIdValue.Name = "lciImportIdValue";
            this.lciImportIdValue.Size = new System.Drawing.Size(99, 25);
            this.lciImportIdValue.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciImportIdValue.TextVisible = false;

            // 
            // lciExamsValue
            // 
            this.lciExamsValue.Control = this.lblExamsValue;
            this.lciExamsValue.Location = new System.Drawing.Point(0, 25);
            this.lciExamsValue.MaxSize = new System.Drawing.Size(99, 25);
            this.lciExamsValue.MinSize = new System.Drawing.Size(99, 25);
            this.lciExamsValue.Name = "lciExamsValue";
            this.lciExamsValue.Size = new System.Drawing.Size(99, 25);
            this.lciExamsValue.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciExamsValue.TextVisible = false;

            // 
            // lciTasksValue
            // 
            this.lciTasksValue.Control = this.lblTasksValue;
            this.lciTasksValue.Location = new System.Drawing.Point(0, 50);
            this.lciTasksValue.MaxSize = new System.Drawing.Size(99, 25);
            this.lciTasksValue.MinSize = new System.Drawing.Size(99, 25);
            this.lciTasksValue.Name = "lciTasksValue";
            this.lciTasksValue.Size = new System.Drawing.Size(99, 25);
            this.lciTasksValue.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciTasksValue.TextVisible = false;

            // 
            // lciCorrectValue
            // 
            this.lciCorrectValue.Control = this.lblCorrectValue;
            this.lciCorrectValue.Location = new System.Drawing.Point(0, 75);
            this.lciCorrectValue.MaxSize = new System.Drawing.Size(99, 25);
            this.lciCorrectValue.MinSize = new System.Drawing.Size(99, 25);
            this.lciCorrectValue.Name = "lciCorrectValue";
            this.lciCorrectValue.Size = new System.Drawing.Size(99, 25);
            this.lciCorrectValue.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciCorrectValue.TextVisible = false;

            // 
            // lciWrongValue
            // 
            this.lciWrongValue.Control = this.lblWrongValue;
            this.lciWrongValue.Location = new System.Drawing.Point(0, 100);
            this.lciWrongValue.MaxSize = new System.Drawing.Size(99, 25);
            this.lciWrongValue.MinSize = new System.Drawing.Size(99, 25);
            this.lciWrongValue.Name = "lciWrongValue";
            this.lciWrongValue.Size = new System.Drawing.Size(99, 25);
            this.lciWrongValue.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciWrongValue.TextVisible = false;

            // 
            // lciErrorsValue
            // 
            this.lciErrorsValue.Control = this.lblErrorsValue;
            this.lciErrorsValue.Location = new System.Drawing.Point(0, 125);
            this.lciErrorsValue.MaxSize = new System.Drawing.Size(99, 25);
            this.lciErrorsValue.MinSize = new System.Drawing.Size(99, 25);
            this.lciErrorsValue.Name = "lciErrorsValue";
            this.lciErrorsValue.Size = new System.Drawing.Size(99, 25);
            this.lciErrorsValue.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciErrorsValue.TextVisible = false;

            // 
            // lciClose
            // 
            this.lciClose.Control = this.btnClose;
            this.lciClose.Location = new System.Drawing.Point(0, 150);
            this.lciClose.Name = "lciClose";
            this.lciClose.Size = new System.Drawing.Size(79, 31);
            this.lciClose.TextVisible = false;

            // 
            // FrmImportResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 331);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmImportResult";
            this.Text = "Import Result";
            this.Load += new System.EventHandler(this.FrmImportResult_Load);

            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupImportSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImportIdValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExamsValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTasksValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCorrectValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWrongValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciErrorsValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciClose)).EndInit();
            this.ResumeLayout(false);
        }

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;

        private LabelControl lblImportIdValue;
        private LabelControl lblExamsValue;
        private LabelControl lblTasksValue;
        private LabelControl lblCorrectValue;
        private LabelControl lblWrongValue;
        private LabelControl lblErrorsValue;

        private SimpleButton btnClose;

        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup groupImportSummary;

        private DevExpress.XtraLayout.LayoutControlItem lciImportIdValue;
        private DevExpress.XtraLayout.LayoutControlItem lciExamsValue;
        private DevExpress.XtraLayout.LayoutControlItem lciTasksValue;
        private DevExpress.XtraLayout.LayoutControlItem lciCorrectValue;
        private DevExpress.XtraLayout.LayoutControlItem lciWrongValue;
        private DevExpress.XtraLayout.LayoutControlItem lciErrorsValue;
        private DevExpress.XtraLayout.LayoutControlItem lciClose;
    } 
}
