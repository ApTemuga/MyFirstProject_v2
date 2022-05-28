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

        public static string userLogin;
        public static int userId;
        public static int wallet;

        public static bool correctEnter;

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
                    string prPath = @"D:\Подгорный Владислав\MyFirstProject_v2\NoName 02.05.2022\CarStoreDB.mdf";
                    string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={prPath};Integrated Security=True";

                    /*string prPath = @"Z:\Мои документы\Влад\C#\MyFirstProject_v2\MyFirstProject_v2\MyFirstProject_v2\NoName 02.05.2022\CarStoreDB.mdf";
                    string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={prPath};Integrated Security=True";*/

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
                                userId = (int)reader.GetValue(0);
                                wallet = (int)reader.GetValue(6);
                                correctEnter = true;
                                WindowsBuilder.ShowStoreWindow();
                                CloseWindow();
                            }
                            else
                            {
                                MessageBox.Show("Данные введены неверно!");
                                correctEnter = false;
                            }
                        }
                        con.Close();
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
