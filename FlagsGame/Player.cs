using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsGame
{
    public class Player
    {

        private string name;
        private int hits;
        private int time;
        private DateTime date;
        private string continent;

        public Player() { }



        public string getName()
        {
            return name;
        }

        public string getContinent()
        {
            return continent;
        }

        public int getHits()
        {
            return hits;
        }

        public int getTime()
        {
            return time;
        }

        public DateTime getDate()
        {
            return date;
        }



        public void setName(string name)
        {
            this.name = name;
        }

        public void setHits(int hits)
        {
            this.hits = hits;
        }

        public void setTime(int time)
        {
            this.time = time;
        }

        public void setDate(DateTime date)
        {
            this.date = date;
        }


        public void setContinent(string continent)
        {
            this.continent = continent;
        }



    }
}
