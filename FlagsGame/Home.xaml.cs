using FlagsGame;
using FlagsGame.Properties;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FlagsGame
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {




        public Home()
        {
            InitializeComponent();
            setUpDataBase();

        }

        //go to the play view
        private void Btn_play(object sender, RoutedEventArgs e)
        {

            Play play = new Play();
            play.Show();
            this.Close();

        }
        //go to the configuration view
        private void Btn_configuration(object sender, RoutedEventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.Show();
            this.Close();
        }

        //go to the results view
        private void Btn_results(object sender, RoutedEventArgs e)
        {
            Results results = new Results();
            results.Show();
            this.Close();
        }

        //go to the help view
        private void Btn_help(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.Show();
            this.Close();
        }


        private void setUpDataBase() {
   
            string initialPart = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
            string finalPart = @";Integrated Security=True";
            string databaseName = "FlagsGameData.mdf";

            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            path = Directory.GetParent(path).FullName;
            path = Directory.GetParent(path).FullName;
            path = Directory.GetParent(path).FullName;
            path=path+@"\";


             Settings.Default["connection"]= initialPart + path + databaseName + finalPart;
        }

    }
}
