using System.Data;
using System.Data.SqlClient;

namespace JobBankApp
{
   public  class DBOperations
    {
        public void InsertData(string cn, int SlNo, string Organization, string Login, string Password,
                                string Position, string Jobid, string Submitteddtae, string Location, string Status, string Other)
        {
            string Insertquery = "INSERT Into JobDetails (Sl.No,Organization,Login,Password,Position,JobID,SubmittedDate,Location,Status,Other)" + " VALUES ('@SlNo','@Organization','@Login','@Password','@Position','@Jobid','@Submitteddate','@Location','@Status','@Other');";


            using (SqlConnection cnn = new SqlConnection(cn))
            using (SqlCommand cmd = new SqlCommand(Insertquery, cnn))
            {

                cmd.Parameters.Add("@SlNo", SqlDbType.Int, 50).Value = SlNo;
                cmd.Parameters.Add("@Organization", SqlDbType.VarChar, 50).Value = Organization;
                cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = Login;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password;
                cmd.Parameters.Add("@Position", SqlDbType.VarChar, 50).Value = Position;
                cmd.Parameters.Add("@Jobid", SqlDbType.VarChar, 50).Value = Jobid;
                cmd.Parameters.Add("@Submitteddate", SqlDbType.VarChar, 50).Value = Submitteddtae;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = Location;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status;
                cmd.Parameters.Add("@Other", SqlDbType.VarChar, 50).Value = Other;

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();

            }
               

        }
    }
}
