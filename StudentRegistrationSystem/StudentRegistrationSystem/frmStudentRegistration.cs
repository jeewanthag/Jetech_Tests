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
    public partial class frmStudentRegistration : Form
    {

        public string newId="",stuId = "", stuName = "",stuDob="", stuStatus = "";
        public decimal stuGpa = 0;
        public bool IsSaved=false;

        public frmStudentRegistration(string nId)
        {
            InitializeComponent();
            newId = nId;
        }

        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {
            txtStudentId.Text = newId.ToString();
            dtpDOB.Value = DateTime.Today;
            txtStudentId.ReadOnly = true;
            txtName.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            decimal deciVal=0;
            if (txtName.Text == "")
            {
                MessageBox.Show("Student name is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
            }
            else if(dtpDOB.Value==DateTime.Today) {
                MessageBox.Show("Student's date of birth is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpDOB.Focus();
            }
            else if (txtGPA.Text=="." || txtGPA.Text.Length!=4)
            {
                MessageBox.Show("Student's grade point avarage is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtGPA.Focus();
            }
            else if (decimal.TryParse(txtGPA.Text, out deciVal) == false)
            {
                MessageBox.Show("Student's grade point avarage is invalid.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtGPA.Focus();
            }
            else
            {
                IsSaved = true;
                stuId = txtStudentId.Text;
                stuName = txtName.Text;
                stuGpa = deciVal;
                stuDob = dtpDOB.Value.ToString("dd-MMM-yyyy");


                CheckBox stuCB = cbStatus as CheckBox;
                if (stuCB != null && stuCB.Checked)
                {
                    stuStatus = "Active";
                }
                else {
                    stuStatus = "Not Active";
                }
                this.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            stuId = "";
            Name = "";
            stuGpa = 0;
            stuStatus = "";
            this.Close();
        }
    }
}
