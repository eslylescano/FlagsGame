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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using FlagsGame.Properties;

namespace FlagsGame
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Results : Window
    {
        static string connection = Settings.Default["connection"].ToString();
        SqlConnection cn = new SqlConnection(connection);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        public Results()
        {
            InitializeComponent();
            comboBox.Items.Add("Player");
            comboBox.Items.Add("Duration");
            comboBox.Items.Add("Hits");
            comboBox.Items.Add("Continent");

            consult("id");





        }

        private void itemSelected(object sender, EventArgs e)
        {

            Object selectedItem = comboBox.SelectedItem;
            switch (selectedItem.ToString())
            {
                case "Player":
                    consult("name");
                    break;

                case "Duration":
                    consult("duration");
                    break;

                case "Hits":
                    consult("hits");
                    break;

                case "Continent":
                    consult("continent");
                    break;
            }


        }

        private void back(object sender, EventArgs e)
        {
            Home mainWindow = new Home();
            mainWindow.Show();
            this.Close();
        }


        public void consult(string query)
        {
            player.Items.Clear();
            hits.Items.Clear();
            duration.Items.Clear();
            continent.Items.Clear();


            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "SELECT name,hits,duration,continent FROM Players ORDER BY " + query;


            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    player.Items.Add(reader[0].ToString());
                    hits.Items.Add(reader[1].ToString());
                    duration.Items.Add(reader[2].ToString());
                    continent.Items.Add(reader[3].ToString());
                }

            }
            cn.Close();
        }



    }
}
