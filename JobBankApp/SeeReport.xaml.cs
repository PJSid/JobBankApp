using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace JobBankApp
{
    /// <summary>
    /// Interaction logic for SeeReport.xaml
    /// </summary>
    public partial class SeeReport : Window
    {
        public SeeReport()
        {
            InitializeComponent();
            displayData();
        }

        String cn = "data source=SID;initial catalog=JobBank;integrated security=True;";

        public void displayData()
        {
                string DisplayQuery = "SELECT * from JobSave";
                using (SqlConnection cnn = new SqlConnection(cn))                               
                using (SqlCommand cmd1 = new SqlCommand(DisplayQuery, cnn))
                {
                    cnn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable("JobSave");
                    sda.Fill(dt);
                   display_datagrid.ItemsSource = dt.DefaultView;
        
                //display_datagrid.ItemsSource = ds.Tables[0].DefaultView;

                cnn.Close();
                       

            }
               
            
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            var window_MainMenu = new MainWindow();
            window_MainMenu.ShowDialog();

        }
    }
}
