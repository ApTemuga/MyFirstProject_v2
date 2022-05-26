using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace NoName_02._05._2022.Models
{
    class Car
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Model { get; set; }
        private List<User> Users { get; set; }

        public Car()
        {
            Id = 0;
            Price = 0;
            Model = "";
            Users = new List<User>(0);
        }

        public Car(int id, int price, string model, List<User> list)
        {
            Id = id;
            Price = price;
            Model = model;
            Users = list;
        }
    }
}
