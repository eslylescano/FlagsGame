using FlagsGame.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlagsGame
{
    /// <summary>
    /// Lógica de interacción para Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        static string connection = Settings.Default["connection"].ToString();
        SqlConnection cn = new SqlConnection(connection);
        SqlCommand cmd = new SqlCommand();

        public Configuration()
        {
            InitializeComponent();
        }

        public void Btn_back(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        public void Btn_reset(object sender, EventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("All results will be erased. Do you still want to do the operation?", "Alert", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = "DELETE FROM Players";
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Successful deletion of results");
            }

        }

        public void evaluateRadioButton(object sender, EventArgs e)
        {
            if ((Boolean)radButton1.IsChecked)
            {
                Settings.Default["mode"] = "country_flag";
                MessageBox.Show("Mode: Country/Flgas activated");
            }

            if ((Boolean)radButton2.IsChecked)
            {
                Settings.Default["mode"] = "flag_country";
                MessageBox.Show("Mode: Flags/Country activated");
            }
        }


    }
}
