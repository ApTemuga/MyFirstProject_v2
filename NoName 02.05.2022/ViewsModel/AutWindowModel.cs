using NoName_02._05._2022.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NoName_02._05._2022.ViewsModel
{
    class AutWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler EventCloseWindow;

        private BaseCommands changeToRegWindow;

        private BaseCommands changeToStoreWindow;

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
                    string prPath = AppDomain.CurrentDomain.BaseDirectory;
                    prPath = prPath.Substring(0, prPath.Length - 1);
                    prPath = System.IO.Directory.GetParent(prPath).FullName;
                    prPath = System.IO.Directory.GetParent(prPath).FullName;
                    prPath = System.IO.Directory.GetParent(prPath).FullName;
                    string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= {prPath}\CarStoreDB.mdf; Integrated Security = True";
                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        SqlCommand com = new SqlCommand("SELECT * FROM Cars", con);
                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            WindowsBuilder.ShowStoreWindow();
                            CloseWindow();
                        }
                    }
                }));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);


        /*private void ButToReg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            this.Close();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = @"SELECT * FROM [users]" + $"WHERE CONVERT(VARCHAR, login) = '{enterUserLogin.Text}'" + $"AND CONVERT(VARCHAR, password) = '{enterUserPassword.Password}'";

            SqlCommand cmd = new SqlCommand(sqlExpression, MainWindow.workshopDB.con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read() && (string)reader.GetValue(1) == enterUserLogin.Text && (string)reader.GetValue(2) == enterUserPassword.Password)
                {
                    MainWindow.currentUser.id = (int)reader.GetValue(0);
                    MainWindow.currentUser.login = (string)reader.GetValue(1);

                    MessageBox.Show($"Добро пожаловать, {MainWindow.currentUser.login}!");
                    
                }
            }

               
        }*/
    }
}
