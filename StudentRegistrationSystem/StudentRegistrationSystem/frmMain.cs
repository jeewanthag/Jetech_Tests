using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentRegistrationSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void newRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentDetails frm = new frmStudentDetails();
            frm.MdiParent = ActiveForm.MdiParent;
            frm.ShowDialog();
        }
    }
}
