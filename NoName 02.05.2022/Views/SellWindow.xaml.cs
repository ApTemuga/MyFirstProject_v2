using NoName_02._05._2022.ViewsModel;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SellWindow.xaml
    /// </summary>
    public partial class SellWindow : Window
    {
        public SellWindow()
        {
            InitializeComponent();
            DataContext = new SellWindowModel();
        }
    }
}
