using NoName_02._05._2022.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NoName_02._05._2022.ViewsModel
{
    class SellWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler EventCloseWindow;

        private BaseCommands changeToStoreWindow;

        private BaseCommands createAd;

        private string nameAd;
        private string discriptionAd;
        private string priceAd;
        private string numberAd;
        private string carIdAd;

        private bool test1;
        private bool test2;
        private bool test3;
        private bool test4;
        private bool test5;

        public BaseCommands ChangeToStoreWindow
        {
            get
            {
                return changeToStoreWindow ?? (changeToStoreWindow = new BaseCommands(obj =>
                {
                    CloseWindow();
                }));
            }
        }

        public BaseCommands CreateAd
        {
            get
            {
                return createAd ?? (createAd = new BaseCommands(obj =>
                {
                    string prPath = @"D:\Подгорный Владислав\MyFirstProject_v2\NoName 02.05.2022\CarStoreDB.mdf";
                    string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={prPath};Integrated Security=True";

                    /*string prPath = @"Z:\Мои документы\Влад\C#\MyFirstProject_v2\MyFirstProject_v2\MyFirstProject_v2\NoName 02.05.2022\CarStoreDB.mdf";
                    string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={prPath};Integrated Security=True";*/

                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        con.Open();
                        SqlCommand setOrder = new SqlCommand(@"INSERT INTO[Orders](NameAd, DiscriptionAd, PriceAd, NumberAd, CarId)" + $"VALUES('{nameAd}', '{discriptionAd}', '{priceAd}', '{numberAd}', '{carIdAd}')", con);

                        test1 = LoginData.CheckNameAd(nameAd);
                        test2 = LoginData.CheckDiscription(discriptionAd);
                        test3 = LoginData.CheckPrice(priceAd);
                        test4 = LoginData.CheckNumber(numberAd);
                        test5 = LoginData.CheckId(carIdAd);
                        if (LoginData.CheckNameAd(nameAd) &&
                        LoginData.CheckDiscription(discriptionAd) &&
                        LoginData.CheckPrice(priceAd) &&
                        LoginData.CheckNumber(numberAd) && 
                        LoginData.CheckId(carIdAd))
                        {
                            using (SqlDataReader dr = setOrder.ExecuteReader())
                            {
                                MessageBox.Show("Объявление создано!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Данные указаны неверно!");
                        }
                    }
                }));
            }
        }

        public string NameAd
        {
            get { return nameAd; }
            set { nameAd = value; OnPropertyChanged("NameAd"); }
        }
        public string DiscriptionAd
        {
            get { return discriptionAd; }
            set { discriptionAd = value; OnPropertyChanged("DiscriptionAd"); }
        }
        public string PriceAd
        {
            get { return priceAd; }
            set { priceAd = value; OnPropertyChanged("PriceAd"); }
        }
        public string NumberAd
        {
            get { return numberAd; }
            set { numberAd = value; OnPropertyChanged("NumberAd"); }
        }
        public string CarIdAd
        {
            get { return carIdAd; }
            set { carIdAd = value; OnPropertyChanged("CarIdAd"); }
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
