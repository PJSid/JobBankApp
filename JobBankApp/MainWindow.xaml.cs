using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace JobBankApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        //Sql Connection String
        String cn = "data source=SID;initial catalog=JobBank;integrated security=True;";

        //Save Button Implementation
        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            //Bool variable used for Validations of Main Page       
            bool b;
            b = string.IsNullOrWhiteSpace(txtbox_organization.Text) || string.IsNullOrWhiteSpace(txtbox_position.Text) || string.IsNullOrWhiteSpace(txtbox_location.Text) || txt_SubmitDate.SelectedDate == null;

            if (b)
            {
                ValidateFields();              
            } else
              {
            //Textbox Values Passed as parameters to InsertData method
            InsertData(txtbox_organization.Text,
                    txtbox_login.Text,
                    txtbox_password.Text,
                    txtbox_position.Text,
                    txtbox_jobid.Text,
                    txt_SubmitDate.Text,
                    txtbox_location.Text,
                    txtbox_Status.Text,
                    txtbox_other.Text);
                }
         }

        //Insert Data method implementation
        public void InsertData(string Organization, string Login, string Password,
                                string Position, string Jobid, string Submitteddtae, string Location, string Status, string Other)
        {
            //Implementing the method using Try, catch and throw to catch the exceptions occured through SQL Operations 
            try
            {
                              
                // SQL INSERT Query
                string Insertquery = "INSERT Into JobSave VALUES (@Organization,@Login,@Password,@Position,@Jobid,@Submitteddate,@Location,@Status,@Other)";


                using (SqlConnection cnn = new SqlConnection(cn))
                using (SqlCommand cmd = new SqlCommand(Insertquery, cnn))
                {

                    //Adding the values into database using parameterized operations
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
                    MessageBox.Show("Record Saved");
                    Clearboxes();
                    

                }


            }
            catch (SqlException e)
            {
                string msg = "Sql Error:";
                msg += e.Message;
                throw new Exception(msg);
            }
        }

       // Method Used for Validations 
        private void ValidateFields( )
        {
            if (string.IsNullOrWhiteSpace(txtbox_organization.Text))
            {
                MessageBox.Show("Please Enter a Organization Name");
            }
           else  if(string.IsNullOrWhiteSpace(txtbox_position.Text))
            {
                MessageBox.Show("Please Enter a Position");
            }
            else if(string.IsNullOrWhiteSpace(txtbox_location.Text))
            {
                MessageBox.Show("Please enter the location");
            }
           else if(txt_SubmitDate.SelectedDate == null)
            {
                MessageBox.Show("Select a date");
            }
        }

        //Method used to clear the textbox values once the record is saved
        private void Clearboxes()
        {
            txtbox_organization.Clear();
            txtbox_login.Clear();
            txtbox_password.Clear();
            txtbox_position.Clear();
            txtbox_jobid.Clear();
            txtbox_location.Clear();
            txtbox_Status.Clear();
            txtbox_other.Clear();
        }
    
        // directing the See Report buton to its respective window
        private void button_seereport_Click(object sender, RoutedEventArgs e)
        {
            var window = new SeeReport();
            window.ShowDialog();

        }

        // directing the Search Window buton to its respective window
        private void button_search_Click(object sender, RoutedEventArgs e)
        {
            var window1 = new SearchWindow();
            window1.ShowDialog();
        }
    }
}
    

    

