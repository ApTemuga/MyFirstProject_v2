using NoName_02._05._2022.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NoName_02._05._2022.ViewsModel
{
    class RegWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler EventCloseWindow;

        private BaseCommands changeToAutWindow;

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
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);



        /*private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            string login = userName.Text;
            string email = userEmail.Text;
            string password1 = userPassword.Password;
            string password2 = repiteUserPassword.Password;
            bool dataCorrect = true;

            Regex regexLog = new Regex(@"^[\w\d!*]{1,15}$");
            Regex regexPas = new Regex(@"^[\w\d\-_!*$#]{5,25}$");
            Regex regexEmail = new Regex(@"^[\w\d\._\-]{3,20}@[\w\d]{3,6}\.[\w]{2,3}$");

            if (regexLog.IsMatch(login))
            {
                userName.Foreground = Brushes.Green;
            }
            else
            {
                userName.Foreground = Brushes.Red;
                dataCorrect = false;
            }

            if (regexEmail.IsMatch(email))
            {
                userEmail.Foreground = Brushes.Green;
            }
            else
            {
                userEmail.Foreground = Brushes.Red;
                dataCorrect = false;
            }

            if (regexPas.IsMatch(password1))
            {
                userPassword.Foreground = Brushes.Green;
            }
            else
            {
                userPassword.Foreground = Brushes.Red;
                dataCorrect = false;
            }

            if (regexPas.IsMatch(password2))
            {
                repiteUserPassword.Foreground = Brushes.Green;
            }
            else
            {
                repiteUserPassword.Foreground = Brushes.Red;
                dataCorrect = false;
            }

            if(password1 != password2)
            {
                userPassword.Foreground = Brushes.Red;
                repiteUserPassword.Foreground = Brushes.Red;
                dataCorrect = false;
            }

            if(dataCorrect)
            {
                string sqlExpression = @"INSERT INTO [users](login, password, email)" + $"VALUES('{userName.Text}', '{userPassword.Password}', '{userEmail.Text}')";
                SqlCommand command = new SqlCommand(sqlExpression, workshopDB.con);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись создана!");

            }
        }

        private void EnterBut_Click(object sender, RoutedEventArgs e)
        {
            Autorizationxaml autorization = new Autorizationxaml();
            autorization.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            autorization.Show();
            this.Close();
        }*/
    }
}
