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
    public partial class frmStudentDetails : Form
    {
        string currentId = "",newId="";
        DataTable dtStudentDetails = new DataTable();

        public frmStudentDetails()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (dtStudentDetails.Rows.Count == 0)
            {
                commonFunctions comF = new commonFunctions();
                comF.callSelectIdFromRegistration();
                currentId = comF.currentId;
                newId=calNewId(currentId);
            }
            else {
                newId=calNewId(currentId, dtStudentDetails.Rows.Count);
            }

            frmStudentRegistration frm = new frmStudentRegistration(newId);
            frm.MdiParent = ActiveForm.MdiParent;
            frm.ShowDialog();

            if (frm.IsSaved == true) {
               DataRow dr= dtStudentDetails.NewRow();
               dr["StudentId"] = frm.stuId;
               dr["Name"] = frm.stuName;
               dr["DOB"] = frm.stuDob;
               dr["GPA"] = frm.stuGpa;
               dr["Status"] = frm.stuStatus;

               dtStudentDetails.Rows.Add(dr);
               dgvStudentDetails.DataSource = dtStudentDetails;
               btnSave.Enabled = true;
               formatGrid();
            }

            
        }

        private void frmStudentDetails_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            dgvStudentDetails.ReadOnly = true;
            generateDataTable();
        }

        private void generateDataTable() {
            
            DataColumn colId = new DataColumn("StudentId",typeof(string));
            DataColumn colName = new DataColumn("Name",typeof(string));
            DataColumn colDOB = new DataColumn("DOB",typeof(DateTime));
            DataColumn colGPA = new DataColumn("GPA",typeof(decimal));
            DataColumn colStatus = new DataColumn("Status",typeof(string));


            dtStudentDetails.Columns.Add(colId);
            dtStudentDetails.Columns.Add(colName);
            dtStudentDetails.Columns.Add(colDOB);
            dtStudentDetails.Columns.Add(colGPA);
            dtStudentDetails.Columns.Add(colStatus);

        }

        private void formatGrid() {

            dgvStudentDetails.Columns["StudentId"].HeaderText = "Student Id";
            dgvStudentDetails.Columns["Name"].HeaderText="Student Name";
            dgvStudentDetails.Columns["DOB"].HeaderText="Date of Birth";
            dgvStudentDetails.Columns["GPA"].HeaderText="GPA";
            dgvStudentDetails.Columns["Status"].HeaderText="Status";

            dgvStudentDetails.Columns["StudentId"].Width = 100;
            dgvStudentDetails.Columns["Name"].Width = 200;
            dgvStudentDetails.Columns["DOB"].Width = 75;
            dgvStudentDetails.Columns["GPA"].Width = 60;
            dgvStudentDetails.Columns["Status"].Width = 100;

            dgvStudentDetails.Columns["StudentId"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStudentDetails.Columns["Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStudentDetails.Columns["DOB"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStudentDetails.Columns["GPA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStudentDetails.Columns["Status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvStudentDetails.Columns["GPA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private string calNewId(string currentId)
        {
            string newId = "";
            if (currentId != "")
            {
                newId = "S" + (Convert.ToInt32(currentId.Substring(1, 5).ToString()) + 1).ToString().PadLeft('0');
            }
            else
            {
                newId = "S00001";
            }
            return newId;
        }

        private string calNewId(string currentId,int noOfNewRecs)
        {
            string newId = "";
                newId = "S" + (Convert.ToInt32(currentId.Substring(1, 5).ToString()) + noOfNewRecs + 1).ToString().PadLeft('0');            
            return newId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            commonFunctions comF = new commonFunctions();
            if (dtStudentDetails.Rows.Count > 0)
            {
                foreach (DataRow rec in dtStudentDetails.Rows) {
                    comF.callInsertUpdateDeleteRegistration(rec["StudentId"].ToString(), rec["Name"].ToString(), rec["DOB"].ToString(), Convert.ToDecimal(rec["GPA"].ToString()), rec["Status"].ToString(), "Insert");
                }
            }
        }

    }
}
