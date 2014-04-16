using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace StudentRegistrationSystem
{
    class commonFunctions
    {
        public static string conString = "user id=sa;password=admin#1;server=swhit;database=JeTechDB;";
        public static SqlConnection conn = new SqlConnection(conString);
        public string currentId="";

        public void callInsertUpdateDeleteRegistration(string paraId,string paraName,string paraDOB,decimal paraGPA,string paraStatus,string paraType) {
            string resulquerryStatus = "";
            SqlCommand cmd = new SqlCommand();
                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText="InsertUpdateDeleteRegistration";
                    cmd.Parameters.AddWithValue("@id  ", paraId);
                    cmd.Parameters.AddWithValue("@studentName", paraName);
                    cmd.Parameters.AddWithValue("@studentGPA", paraGPA);
                    cmd.Parameters.AddWithValue("@studentDOB", paraDOB);
                    cmd.Parameters.AddWithValue("@studentStatus", paraStatus);
                    cmd.Parameters.AddWithValue("@StatementType", paraType);

                    try
                    {
                        conn.Open();
                        resulquerryStatus=cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred" + Environment.NewLine + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conn != null) conn.Close();
                    }
                

            
        }

        public void callSelectIdFromRegistration() {

            SqlCommand cmd = new SqlCommand();
                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SelectIdFromRegistration";

                    try
                    {
                        conn.Open();
                        currentId = cmd.ExecuteScalar().ToString();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred" + Environment.NewLine + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conn != null) conn.Close();
                    }
                        
        }

        public DataTable callSelectAllFromRegistration() {

            DataTable dtAllStudents = new DataTable();
            SqlCommand cmd = new SqlCommand();
                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText="SelectAllFromRegistration";

            SqlDataAdapter dAp = new SqlDataAdapter(cmd);

            try
            {
                conn.Open();
                dAp.Fill(dtAllStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred" + Environment.NewLine + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null) conn.Close();
            }

            return dtAllStudents;
            
        }
    }
}
