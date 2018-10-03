using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIScv3.Models
{
    public class Car
    {
        public Brand Brand;

        public string Model;

        public double Price;

        public string Curency = "Kč";

        public int Year;

    }

    public class Brand
    {
        int Id;

        public string Name;
    }
}
