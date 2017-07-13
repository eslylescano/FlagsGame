using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsGame
{
    class Country
    {
        private int id;
        private string name;
        private string image;

        public Country(int _id, string _name, string _image)
        {
            id = _id;
            name = _name;
            image = _image;
        }

        public int getId()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public string getImage()
        {
            return image;
        }



    }
}
