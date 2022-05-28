using System;
using NoName_02._05._2022.Command;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NoName_02._05._2022.Views;

namespace NoName_02._05._2022.ViewsModel
{
    class StoreWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler EventCloseWindow;

        private BaseCommands changeToAutWindow;

        private BaseCommands changeToSellWindow;

        private BaseCommands changeToBuyWindow;

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

        public BaseCommands ChangeToSellWindow
        {
            get
            {
                return changeToSellWindow ?? (changeToSellWindow = new BaseCommands(obj =>
                {
                    WindowsBuilder.ShowSellWindow();
                }));
            }
        }

        public BaseCommands ChangeToBuyWindow
        {
            get
            {
                return changeToBuyWindow ?? (changeToBuyWindow = new BaseCommands(obj =>
                {
                    WindowsBuilder.ShowBuyWindow();
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
    }
}
