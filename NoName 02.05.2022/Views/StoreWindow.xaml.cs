﻿using NoName_02._05._2022.Models;
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
    /// Логика взаимодействия для StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        List<Car> carList = new List<Car>();
        public StoreWindow()
        {
            InitializeComponent();
            DataContext = new StoreWindowModel();
            CarsList.ItemsSource = carList;
        }
    }
}