using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Play.xaml
    /// </summary>
    public partial class Play : Window
    {
        public Play()
        {
            InitializeComponent();
        }


        private void Btn_competition(object sender, RoutedEventArgs e)
        {

            MenuContinents menuContinents = new MenuContinents("Competition");
            menuContinents.Show();
            this.Close();
        }

        private void Btn_training(object sender, RoutedEventArgs e)
        {

            MenuContinents menuContinents = new MenuContinents("Training");
            menuContinents.Show();
            this.Close();
        }




        private void Btn_back(object sender, RoutedEventArgs e)
        {
            Home main = new Home();
            main.Show();
            this.Close();
        }


    }
}