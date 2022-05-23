using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace NoName_02._05._2022.Models
{
    class User
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public BitmapImage Avatar { get; }
        public List<Car> Cars { get; }

        public User()
        {
            Id = 0;
            Name = "";
            Email = "";
            Password = "";
            //Avatar = new byte[0];
            Cars = new List<Car>(0);
        }

        public User(int id, string name, string email, string password, /*BitmapImage avatar,*/ List<Car> list)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            //Avatar = avatar;
            Cars = list;
        }
        
    }
}
