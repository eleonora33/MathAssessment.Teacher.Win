using MathAssessment.Teacher.Win.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathAssessment.Teacher.Win
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void itemImport_Click(object sender, EventArgs e)
        {
            foreach (Control c in panelContent.Controls)
            {
                c.Dispose();
            }
            panelContent.Controls.Clear();

            var frmImportExams = new FrmImportExams
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContent.Controls.Add(frmImportExams);
            frmImportExams.Show();


        }

        private void accStudentAnalytics_Click(object sender, EventArgs e)
        {
            var frmStudentAnalytics = new FrmStudentAnalytics();
            frmStudentAnalytics.Show();
        }
    }
}
