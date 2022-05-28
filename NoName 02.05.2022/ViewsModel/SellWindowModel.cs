using NoName_02._05._2022.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public BaseCommands ChangeToStoreWindow
        {
            get
            {
                return changeToStoreWindow ?? (changeToStoreWindow = new BaseCommands(obj =>
                {
                    WindowsBuilder.ShowStoreWindow();
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
                    if (LoginData.CheckNameAd(nameAd) &&
                    LoginData.CheckDiscription(discriptionAd) &&
                    LoginData.CheckPrice(priceAd) &&
                    LoginData.CheckNumber(numberAd))
                    {
                        MessageBox.Show("Объявление создано!");
                    }
                    else
                    {
                        MessageBox.Show("Данные указаны неверно!");
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
