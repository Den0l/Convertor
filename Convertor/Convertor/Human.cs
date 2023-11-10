using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertor
{
    public class Human
    {
        public string name;
        public string country;
        public int age;

        public Human()
        {
          
            name = "";
            country = "";
            age = 0;
        }

        public Human (string get_name, string get_country, int get_age)
        {
            name = get_name;
            country = get_country;
            age = get_age;
        }
    }
}
