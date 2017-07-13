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
    /// Lógica de interacción para Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        Player player;
        static string conexion = Settings.Default["connection"].ToString();
        SqlConnection cn = new SqlConnection(conexion);
        SqlCommand cmd = new SqlCommand();
        private String playMode;

        public Result(Player player, String playMode)
        {
            InitializeComponent();
            this.player = player;
            aciertos.Content = player.getHits();
            tiempo.Content = player.getTime();
            fecha.Content = player.getDate();
            continent.Content = player.getContinent();
            this.playMode = playMode;

            switch (playMode)
            {
                case "Competition":
                    Btn.Content = "Save";
                    break;
                case "Training":
                    labelName.Visibility = Visibility.Hidden;
                    nameTextBox.Visibility = Visibility.Hidden;
                    Btn.Content = "Back";
                    break;
            }

        }


        private void Btn_click(object sender, RoutedEventArgs e)
        {
            Play play = new Play();
            switch (playMode)
            {
                case "Competition":
                    if (nameTextBox.Text == "")
                    {
                        MessageBox.Show("Name field can not be empty");
                    }
                    else
                    {
                        player.setName(nameTextBox.Text);

                        cmd.Connection = cn;
                        cn.Open();
                        cmd.CommandText = "INSERT INTO Players (name,hits,duration,date,continent) VALUES (" + "'" + player.getName() + "'" + "," + player.getHits() + "," + player.getTime() + ",'" + player.getDate() + "'," + "'" + player.getContinent() + "'" + ")";

                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                        cn.Close();




                        play.Show();
                        this.Close();
                    }
                    break;

                case "Training":
                    play.Show();
                    this.Close(); ;
                    break;
            }





        }


    }
}
