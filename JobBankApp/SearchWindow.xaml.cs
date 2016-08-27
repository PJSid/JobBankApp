using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace JobBankApp
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
        }
        
        public void btn_SrchByOrganization_Click(object sender, RoutedEventArgs e)
        {

            
            if (string.IsNullOrWhiteSpace(txt_SrchByOrganization.Text) && string.IsNullOrWhiteSpace(txt_SrchByJobID.Text) && string.IsNullOrWhiteSpace(txt_Location.Text))
            {
                MessageBox.Show("Please enter in any one of the Search Criteria's");
            } else
            { 
            try
            {
                if (!string.IsNullOrWhiteSpace(txt_SrchByOrganization.Text))
                {
                    string SrchQuery = "SELECT * from JobSave where Organization like '%'+ @Name + '%'";
                    SetSearchDisplay(SrchQuery, txt_SrchByOrganization.Text);
                }
                else if (!string.IsNullOrWhiteSpace(txt_SrchByJobID.Text))
                {
                    string SrchQuery = "SELECT * from JobSave where Jobid like '%'+ @Name + '%'";
                    SetSearchDisplay(SrchQuery, txt_SrchByJobID.Text);
                }
                else if (!string.IsNullOrWhiteSpace(txt_Location.Text))
                {
                    string SrchQuery = "SELECT * from JobSave where Location like '%'+ @Name + '%'";
                    SetSearchDisplay(SrchQuery, txt_Location.Text);
                }

            }
            catch (Exception ex)
            {
                string msg = "Sql Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }            
        }
       }


        private void SetSearchDisplay(string SrchQuery,string TextboxValue)
        {
            String cn = "data source=SID;initial catalog=JobBank;integrated security=True;";
           // string SrchQuery = "SELECT * from JobSave where Organization like or Jobid like or Location like '%' + @Name + '%'";
            using (SqlConnection cnn = new SqlConnection(cn))
            using (SqlCommand cmd2 = new SqlCommand(SrchQuery, cnn))
            {                
                cmd2.Parameters.Add("@Name", SqlDbType.VarChar, 20).Value = TextboxValue;
                cnn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable("JobSave");
                sda.Fill(dt);
                searchdataGrid.ItemsSource = dt.DefaultView;
                cnn.Close();

                clearTextValues();
            }
        }

        private void clearTextValues()
        {
            txt_Location.Clear();
            txt_SrchByJobID.Clear();
            txt_SrchByOrganization.Clear();
        }                      
    }
}
