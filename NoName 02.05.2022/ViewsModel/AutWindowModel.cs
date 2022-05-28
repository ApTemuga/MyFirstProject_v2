using NoName_02._05._2022.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows;
using NoName_02._05._2022.Models;
using System.Data;

namespace NoName_02._05._2022.ViewsModel
{
    class AutWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler EventCloseWindow;

        private BaseCommands changeToRegWindow;

        private BaseCommands changeToStoreWindow;

        private BaseCommands getCarList;

        public static string userLogin;
        private int userId;
        public static int wallet;

        private bool correctEnter;

        public static List<Car> carList = new List<Car>();

        public BaseCommands ChangeToRegWindow
        {
            get
            {
                return changeToRegWindow ?? (changeToRegWindow = new BaseCommands(obj =>
                {
                    WindowsBuilder.ShowRegWindow();
                    CloseWindow();
                }));
            }
        }

        public BaseCommands ChangeToStoreWindow
        {
            get
            {
                return changeToStoreWindow ?? (changeToStoreWindow = new BaseCommands(obj =>
                {
                    /*string prPath = @"D:\Подгорный Владислав\MyFirstProject-master\NoName 02.05.2022\CarStoreDB.mdf";
                    string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={prPath};Integrated Security=True";*/

                    string prPath = @"Z:\Мои документы\Влад\C#\MyFirstProject_v2\MyFirstProject_v2\MyFirstProject_v2\NoName 02.05.2022\CarStoreDB.mdf";
                    string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={prPath};Integrated Security=True";

                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        PasswordBox pb = (PasswordBox)obj;
                        string password = pb.Password;

                        con.Open();
                        SqlCommand checkEnter = new SqlCommand($@"SELECT * FROM [Users] WHERE CONVERT(VARCHAR, UserName) = '{userLogin}' AND CONVERT(VARCHAR, UserPassword) = '{password}'", con);

                        using (SqlDataReader reader = checkEnter.ExecuteReader())
                        {
                            if (reader.Read() && (string)reader.GetValue(1) == userLogin && (string)reader.GetValue(3) == password)
                            {
                                WindowsBuilder.ShowStoreWindow();
                                CloseWindow();
                                userId = (int)reader.GetValue(0);
                                wallet = (int)reader.GetValue(5);
                                correctEnter = true;
                            }
                            else
                            {
                                MessageBox.Show("Данные введены неверно!");
                                correctEnter = false;
                            }
                        }
                        con.Close();
                    }
                    if (correctEnter)
                    {
                        using (SqlConnection con = new SqlConnection(strCon))
                        {
                            SqlCommand getCarId = new SqlCommand($@"SELECT * FROM [Cars] Join [Users] ON [Cars].Id = [Users].CarId WHERE [Users].Id = '{userId}'", con);
                            SqlCommand getCars = new SqlCommand($@"SELECT * FROM Cars JOIN Users ON Cars.Id = Users.CarId", con);
                            con.Open();
                            using (SqlDataReader dr = getCars.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    Car car = new Car();
                                    car.Id = dr.GetInt32(0);
                                    car.Model = dr.GetString(1);
                                    car.Price = dr.GetInt32(2);
                                    carList.Add(car);
                                }
                                con.Close();
                            }
                        }
                    }
                }));
            }
        }

        public BaseCommands GetCarList
        {
            get
            {
                return getCarList ?? (getCarList = new BaseCommands(obj =>
                {
                    if (correctEnter)
                    {
                        string prPath = @"D:\Подгорный Владислав\MyFirstProject-master\NoName 02.05.2022\CarStoreDB.mdf";
                        string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={prPath};Integrated Security=True";
                        using (SqlConnection con = new SqlConnection(strCon))
                        {
                            SqlCommand getCarId = new SqlCommand(@"SELECT * FROM [Cars] Join [Users] ON Cars.Id = Users.CarId WHERE [User].Id = '{userId}'");

                            using (SqlDataReader dr = getCarId.ExecuteReader())
                            {
                                foreach (Car car in carList)
                                {
                                    carList.Add(car);
                                }
                            }
                        }
                    }
                }));
            }
        }

        public string UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; OnPropertyChanged("UserLogin"); }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);
    }
}
