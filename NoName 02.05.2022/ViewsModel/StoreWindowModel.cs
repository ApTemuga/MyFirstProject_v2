using System;
using NoName_02._05._2022.Command;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoName_02._05._2022.ViewsModel
{
    class StoreWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler EventCloseWindow;

        private BaseCommands changeToAutWindow;

        private BaseCommands changeToTradeWindow;

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

        public BaseCommands ChangeToTradeWindow
        {
            get
            {
                return changeToTradeWindow ?? (changeToTradeWindow = new BaseCommands(obj =>
                {
                    WindowsBuilder.ShowTradeWindow();
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
    }
}
