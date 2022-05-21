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

namespace NoName_02._05._2022.ViewsModel
{
    class AutWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler EventCloseWindow;

        private BaseCommands changeToRegWindow;

        private BaseCommands changeToStoreWindow;

        private string userLogin;

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
                    string prPath = @"D:\Подгорный Владислав\MyFirstProject-master\NoName 02.05.2022\CarStoreDB.mdf";
                    string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={prPath};Integrated Security=True";
                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        PasswordBox pb = (PasswordBox)obj;
                        string password = pb.Password;

                        SqlCommand com = new SqlCommand("SELECT * FROM Cars", con);
                        SqlCommand checkEnter = new SqlCommand(@"SELECT * FROM [Users]" + $"WHERE CONVERT(VARCHAR, UserLogin) = '{userLogin}' AND CONVERT(VARCHAR, UserPassword) = '{password}'", con);

                        using (SqlDataReader reader = checkEnter.ExecuteReader())
                        {
                            if (reader.Read() && (string)reader.GetValue(1) == userLogin && (string)reader.GetValue(2) == password)
                            {
                                WindowsBuilder.ShowStoreWindow();
                                CloseWindow();
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
