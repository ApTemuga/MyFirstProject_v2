using NoName_02._05._2022.Views;
using NoName_02._05._2022.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views.NoName_02._05._2022;

namespace NoName_02._05._2022
{
    public static class WindowsBuilder
    {
        public static void ShowRegWindow()
        {
            var window = new RegWindow();
            var viewModel = new RegWindowModel();
            window.DataContext = viewModel;
            viewModel.EventCloseWindow += (sender, args) => { window.Close(); };
            window.Show();

        }

        public static void ShowAutWindow()
        {
            var window = new MainWindow();
            var viewModel = new AutWindowModel();
            window.DataContext = viewModel;
            viewModel.EventCloseWindow += (sender, args) => { window.Close(); };
            window.Show();
        }

        public static void ShowStoreWindow()
        {
            var window = new StoreWindow();
            var viewModel = new StoreWindowModel();
            window.DataContext = viewModel;
            viewModel.EventCloseWindow += (sender, args) => { window.Close(); };
            window.Show();
        }

        public static void ShowSellWindow()
        {
            var window = new SellWindow();
            var viewModel = new SellWindowModel();
            window.DataContext = viewModel;
            viewModel.EventCloseWindow += (sender, args) => { window.Close(); };
            window.Show();
        }

        public static void ShowBuyWindow()
        {
            var window = new BuyWindow();
            var viewModel = new BuyWindowModel();
            window.DataContext = viewModel;
            viewModel.EventCloseWindow += (sender, args) => { window.Close(); };
            window.Show();
        }
    }
}
