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
using System.Windows.Threading;

namespace FlagsGame
{
    /// <summary>
    /// Lógica de interacción para GameCountryFlag.xaml
    /// </summary>
    public partial class GameCountryFlag : Window
    {
        private List<Country> countries= new List<Country>();
        private List<Boolean> countriesNoSelected= new List<Boolean>();

        private int actualQuestion = 0;
        private int timeCounter = 120;
        private int totalTime = 120;
        private int pointsCounter = 0;
        private string actualCountry = "";
        private string continent = "";


        private string country1 = "";
        private string country2 = "";
        private string country3 = "";
        private string country4 = "";
        DispatcherTimer timer;
        private string gameType;
        static string conexion = Settings.Default["connection"].ToString();
        SqlConnection cn = new SqlConnection(conexion);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        public GameCountryFlag(int continentCode, string gameType)
        {
            InitializeComponent();
            this.gameType = gameType;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();

            getCountries(continentCode);
            playGame();
            this.continent = getContinent(continentCode);

        }

        private void evaluateRadioButton(object sender, RoutedEventArgs e)
        {

            if (timeCounter > -1 && actualQuestion < 15)
            {

                if ((Boolean)radButtonCountry1.IsChecked)
                {

                    if (actualCountry == country1)
                    {
                        pointsCounter++;
                    }
                    radButtonCountry1.IsChecked = false;

                }
                if ((Boolean)radButtonCountry2.IsChecked)
                {
                    if (actualCountry == country2)
                    {
                        pointsCounter++;
                    }
                    radButtonCountry2.IsChecked = false;

                }
                if ((Boolean)radButtonCountry3.IsChecked)
                {
                    if (actualCountry == country3)
                    {
                        pointsCounter++;
                    }
                    radButtonCountry3.IsChecked = false;

                }
                if ((Boolean)radButtonCountry4.IsChecked)
                {
                    if (actualCountry == country4)
                    {
                        pointsCounter++;
                    }
                    radButtonCountry4.IsChecked = false;

                }


                playGame();
            }
            else
            {
                Player player = new Player();
                player.setHits(pointsCounter);
                player.setDate(DateTime.Now);
                player.setTime(totalTime - timeCounter);
                player.setName("name");
                player.setContinent(continent);


                if (gameType == "Training")
                {
                    Result result = new Result(player, "Training");
                    result.Show();
                }
                else if (gameType == "Competition")
                {
                    Result result = new Result(player, "Competition");
                    result.Show();
                }

                this.Close();
            }






        }



        private void timer_Tick(object sender, EventArgs e)
        {
            if (timeCounter > -1 && actualQuestion < 15)
            {
                time.Content = timeCounter;
                timeCounter--;
            }
        }


        private void getCountries(int continent)
        {

            cmd.Connection = cn;
            cn.Open();
            if (continent < 4)
            {
                cmd.CommandText = "SELECT * FROM Countries WHERE IdContinent=" + continent;
            }
            else if (continent == 4 || continent == 5)
            {
                cmd.CommandText = "SELECT * FROM Countries WHERE IdContinent=4 OR IdContinent=5";
            }
            else if (continent == 6)
            {
                cmd.CommandText = "SELECT * FROM Countries";
            }
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Country country = new Country(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    countries.Add(country);
                    countriesNoSelected.Add(true);
                }

            }
            cn.Close();
        }



        private void playGame()
        {
            Random rnd = new Random();
            List<int> countriesIndex = new List<int>();
            int countriesQuestion = 4;
            while (countriesQuestion > 0)
            {

                int indice = rnd.Next(countries.Count);
                if (countriesNoSelected.ElementAt(indice))
                {
                    countriesIndex.Add(indice);
                    countriesNoSelected.RemoveAt(indice);
                    countriesNoSelected.Insert(indice, false);
                    countriesQuestion--;
                }

            }
            countriesQuestion = 4;
            actualQuestion++;
            int paisSeleccionado = countriesIndex.ElementAt(rnd.Next(countriesQuestion));

            for (int i = 0; i < countriesIndex.Count; i++)
            {
                if (countriesIndex.ElementAt(i) != paisSeleccionado)
                {
                    countriesNoSelected.RemoveAt(countriesIndex.ElementAt(i));
                    countriesNoSelected.Insert(countriesIndex.ElementAt(i), true);
                }

            }


            numberQuestion.Content = actualQuestion;
            actualCountry = countries.ElementAt(paisSeleccionado).getName();
            countryText.Content = actualCountry;
            countryImage1.Source = new BitmapImage(new Uri(@"\images\" + countries.ElementAt(countriesIndex.ElementAt(0)).getImage(), UriKind.RelativeOrAbsolute));
            countryImage2.Source = new BitmapImage(new Uri(@"\images\" + countries.ElementAt(countriesIndex.ElementAt(1)).getImage(), UriKind.RelativeOrAbsolute));
            countryImage3.Source = new BitmapImage(new Uri(@"\images\" + countries.ElementAt(countriesIndex.ElementAt(2)).getImage(), UriKind.RelativeOrAbsolute));
            countryImage4.Source = new BitmapImage(new Uri(@"\images\" + countries.ElementAt(countriesIndex.ElementAt(3)).getImage(), UriKind.RelativeOrAbsolute));

            country1 = countries.ElementAt(countriesIndex.ElementAt(0)).getName();
            country2 = countries.ElementAt(countriesIndex.ElementAt(1)).getName();
            country3 = countries.ElementAt(countriesIndex.ElementAt(2)).getName();
            country4 = countries.ElementAt(countriesIndex.ElementAt(3)).getName();



        }


        private string getContinent(int continentCode)
        {

            if (continentCode == 1)
            {
                return "Europe";
            }
            else if (continentCode == 2)
            {
                return "Africa";
            }
            else if (continentCode == 3)
            {
                return "America";
            }
            else if (continentCode == 4)
            {
                return "Asia";
            }
            else if (continentCode == 5)
            {
                return "Oceania";
            }
            else
            {
                return "All";
            }

        }


    }
}
