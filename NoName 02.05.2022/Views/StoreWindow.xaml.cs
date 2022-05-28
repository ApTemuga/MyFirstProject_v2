using NoName_02._05._2022.Models;
using NoName_02._05._2022.ViewsModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoName_02._05._2022.Views
{
    /// <summary>
    /// Логика взаимодействия для StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        private List<Car> carList { get; set; }
        public StoreWindow()
        {
            string prPath = @"D:\Подгорный Владислав\MyFirstProject_v2\NoName 02.05.2022\CarStoreDB.mdf";
            string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={prPath};Integrated Security=True";
            if (AutWindowModel.correctEnter)
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    carList = new List<Car>();
                    SqlCommand getCars = new SqlCommand($@"SELECT * FROM Cars JOIN Users ON Cars.Id = Users.CarId WHERE Users.Id = '{AutWindowModel.userId}'", con);
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
                InitializeComponent();
            DataContext = new StoreWindowModel();
            CarsList.ItemsSource = carList;
            StoreNickname.Content = "Ваше имя: " + AutWindowModel.userLogin;
            StoreWallet.Content = "Ваш счёт: " + AutWindowModel.wallet;
        }
    }
}
