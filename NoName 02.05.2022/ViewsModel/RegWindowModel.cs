using NoName_02._05._2022.Command;
using NoName_02._05._2022.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NoName_02._05._2022.ViewsModel
{
    class RegWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler EventCloseWindow;

        private BaseCommands changeToAutWindow;
        private BaseCommands regNewUser;

        private string newUserLogin;
        private string newUserEmail;

        public BaseCommands ChangeToAutWindow
        {
            get
            {
                return changeToAutWindow ?? (changeToAutWindow = new BaseCommands(obj =>
                {
                    WindowsBuilder.ShowAutWindow();
                    CloseWindow();
                }));
            }
        }

        public BaseCommands RegNewUser
        {
            get
            {
                return regNewUser ?? (regNewUser = new BaseCommands(obj =>
                {
                    string prPath = @"D:\Подгорный Владислав\MyFirstProject-master\NoName 02.05.2022\CarStoreDB.mdf";
                    string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={prPath};Integrated Security=True";
                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        PasswordBox pb = (PasswordBox)obj;
                        string password = pb.Password;
                        SqlCommand checkUser = new SqlCommand(@"SELECT * FROM [Users] WHERE CONVERT(VARCHAR, UserName) = '{newUserLogin}'", con);
                        con.Open();
                        using (SqlDataReader dr = checkUser.ExecuteReader())
                        {
                            if (dr.Read() && (string)dr.GetValue(1) == newUserLogin)
                            {
                                MessageBox.Show("Такой профиль уже существует!");
                            }
                            else
                            {
                                if (LoginData.CheckLogin(newUserLogin) &&
                                LoginData.CheckEmail(newUserEmail) &&
                                LoginData.CheckPassword(password))
                                {
                                    string sqlExpression = @"INSERT INTO [Users](UserName, UserEmail, UserPassword)" + $"VALUES('{newUserLogin}', '{newUserEmail}', '{password}')";
                                    SqlCommand command = new SqlCommand(sqlExpression, con);
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Запись создана!");
                                }
                                else
                                {
                                    MessageBox.Show("Данные введены неверно!");
                                }
                            }
                        }
                        con.Close();
                    }
                }));
            }
        }

        public string NewUserLogin
        {
            get { return newUserLogin; }
            set { newUserLogin = value; OnPropertyChanged("NewUserLogin"); }
        }

        public string NewUserEmail
        {
            get { return newUserEmail; }
            set { newUserEmail = value; OnPropertyChanged("NewUserLogin"); }
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
