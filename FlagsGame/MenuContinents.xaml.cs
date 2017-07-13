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
    /// Lógica de interacción para MenuContinents.xaml
    /// </summary>
    public partial class MenuContinents : Window
    {
        string tipoJuego;
        public MenuContinents(string tipoJuego)
        {
            this.tipoJuego = tipoJuego;
            InitializeComponent();
        }

        private void Btn_europe(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default["mode"].ToString() == "country_flag")
            {
                GameCountryFlag countryFlag = new GameCountryFlag(1, tipoJuego);
                countryFlag.Show();
                this.Close();
            }
            else if (Properties.Settings.Default["mode"].ToString() == "flag_country")
            {
                GameFlagCountry flagCountry = new GameFlagCountry(1, tipoJuego);
                flagCountry.Show();
                this.Close();
            }

        }



        private void Btn_africa(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default["mode"].ToString() == "country_flag")
            {
                GameCountryFlag countryFlag = new GameCountryFlag(2, tipoJuego);
                countryFlag.Show();
                this.Close();
            }
            else if (Properties.Settings.Default["mode"].ToString() == "flag_country")
            {
                GameFlagCountry flagCountry = new GameFlagCountry(2, tipoJuego);
                flagCountry.Show();
                this.Close();
            }

        }

        private void Btn_america(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default["mode"].ToString() == "country_flag")
            {
                GameCountryFlag countryFlag = new GameCountryFlag(3, tipoJuego);
                countryFlag.Show();
                this.Close();
            }
            else if (Properties.Settings.Default["mode"].ToString() == "flag_country")
            {
                GameFlagCountry flagCountry = new GameFlagCountry(3, tipoJuego);
                flagCountry.Show();
                this.Close();
            }

        }

        private void Btn_asia_oceania(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default["mode"].ToString() == "country_flag")
            {
                GameCountryFlag countryFlag = new GameCountryFlag(4, tipoJuego);
                countryFlag.Show();
                this.Close();
            }
            else if (Properties.Settings.Default["mode"].ToString() == "flag_country")
            {
                GameFlagCountry flagCountry = new GameFlagCountry(4, tipoJuego);
                flagCountry.Show();
                this.Close();
            }

        }


        private void Btn_all(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default["mode"].ToString() == "country_flag")
            {
                GameCountryFlag countryFlag = new GameCountryFlag(6, tipoJuego);
                countryFlag.Show();
                this.Close();
            }
            else if (Properties.Settings.Default["mode"].ToString() == "flag_country")
            {
                GameFlagCountry flagCountry = new GameFlagCountry(6, tipoJuego);
                flagCountry.Show();
                this.Close();
            }

        }

    }
}
