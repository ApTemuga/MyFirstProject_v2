using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NoName_02._05._2022
{
    class LoginData
    {
        public struct CurrentUser
        {
            public static int Id { get; set; }
            public static string Login { get; set; }
            public static string Password { get; set; }
        };

        public static bool CheckLogin(string loginString)
        {
            if (string.IsNullOrEmpty(loginString))
            {
                return false;
            }
            Regex rx = new Regex(@"^[a-zA-Z0-9-_]{3,32}$");
            return rx.IsMatch(loginString);
        }

        public static bool CheckPassword(string passwordString)
        {
            if (string.IsNullOrEmpty(passwordString))
            {
                return false;
            }
            Regex rx = new Regex(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9A-z!@#$%^&*]{6,}");
            return rx.IsMatch(passwordString);
        }

        public static bool CheckEmail(string emailString)
        {
            if (string.IsNullOrEmpty(emailString))
            {
                return false;
            }
            Regex rx = new Regex(@"^((([0-9A-z]{1}[-0-9A-z\.]{0,30}[0-9A-z]?)|([0-9A-zА-я]{1}[-0-9A-zА-я\.]{0,30}[0-9A-zА-я]?))@([-A-Za-z]{1,}\.){1,}[-A-Za-z]{2,})$");
            return rx.IsMatch(emailString);
        }

        public static bool CheckNameAd(string adName)
        {
            if (string.IsNullOrEmpty(adName))
            {
                return false;
            }
            Regex rx = new Regex(@"^[0-9A-zА-я]{3,32}$");
            return rx.IsMatch(adName);
        }

        public static bool CheckDiscription(string discription)
        {
            if (string.IsNullOrEmpty(discription))
            {
                return false;
            }
            Regex rx = new Regex(@"^[0-9A-zА-я]{10,120}$");
            return rx.IsMatch(discription);
        }

        public static bool CheckNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }
            Regex rx = new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
            return rx.IsMatch(number);
        }

        public static bool CheckPrice(string price)
        {
            if (string.IsNullOrEmpty(price))
            {
                return false;
            }
            Regex rx = new Regex(@"^[0-9]{4,10}$");
            return rx.IsMatch(price);
        }
    }
}
