namespace MathAssessment.Teacher.Win
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.accMenu = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.grpExams = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.itemImport = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.panelContent = new DevExpress.XtraEditors.PanelControl();
            this.accStudentAnalytics = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.accMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.SuspendLayout();
            // 
            // accMenu
            // 
            this.accMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.accMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.grpExams});
            this.accMenu.Location = new System.Drawing.Point(0, 0);
            this.accMenu.Name = "accMenu";
            this.accMenu.Size = new System.Drawing.Size(260, 342);
            this.accMenu.TabIndex = 0;
            // 
            // grpExams
            // 
            this.grpExams.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.itemImport,
            this.accStudentAnalytics});
            this.grpExams.Expanded = true;
            this.grpExams.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("grpExams.ImageOptions.SvgImage")));
            this.grpExams.Name = "grpExams";
            this.grpExams.Text = "Exams";
            // 
            // itemImport
            // 
            this.itemImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("itemImport.ImageOptions.SvgImage")));
            this.itemImport.Name = "itemImport";
            this.itemImport.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.itemImport.Text = "Import Exams";
            this.itemImport.Click += new System.EventHandler(this.itemImport_Click);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(260, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(477, 342);
            this.panelContent.TabIndex = 1;
            // 
            // accStudentAnalytics
            // 
            this.accStudentAnalytics.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accStudentAnalytics.ImageOptions.Image")));
            this.accStudentAnalytics.Name = "accStudentAnalytics";
            this.accStudentAnalytics.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accStudentAnalytics.Text = "Student Analytics";
            this.accStudentAnalytics.Click += new System.EventHandler(this.accStudentAnalytics_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 342);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.accMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.accMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.AccordionControl accMenu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement grpExams;
        private DevExpress.XtraEditors.PanelControl panelContent;
        private DevExpress.XtraBars.Navigation.AccordionControlElement itemImport;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accStudentAnalytics;
    }
}

