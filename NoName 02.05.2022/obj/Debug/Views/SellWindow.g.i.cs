// Updated by XamlIntelliSenseFileGenerator 28.05.2022 12:08:54
#pragma checksum "..\..\..\Views\SellWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "806E7494E07ACA9231844D35E43ECD2FDA16E6B40A9B4A018C6E07F782F82751"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using NoName_02._05._2022.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace NoName_02._05._2022.Views
{


    /// <summary>
    /// SellWindow
    /// </summary>
    public partial class SellWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 24 "..\..\..\Views\SellWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateAd;

#line default
#line hidden


#line 52 "..\..\..\Views\SellWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NoName 02.05.2022;component/views/sellwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Views\SellWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.CreateAd = ((System.Windows.Controls.Button)(target));
                    return;
                case 2:
                    this.SellProfile = ((System.Windows.Controls.Grid)(target));
                    return;
                case 3:
                    this.Cancel = ((System.Windows.Controls.Button)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Label lSellNameAd;
        internal System.Windows.Controls.TextBox tSellNameAd;
        internal System.Windows.Controls.Label lSellDescriptionAd;
        internal System.Windows.Controls.TextBox tSellDescriptionAd;
        internal System.Windows.Controls.Label lSellPriceAd;
        internal System.Windows.Controls.TextBox tSellPriceAd;
        internal System.Windows.Controls.Label lSellNumAd;
        internal System.Windows.Controls.TextBox tSellNumAd;
        internal System.Windows.Controls.StackPanel SellProfile;
        internal System.Windows.Controls.Grid SellProfileG;
        internal System.Windows.Controls.StackPanel SellAds;
        internal System.Windows.Controls.Label StoreNickname;
        internal System.Windows.Controls.Label StoreWallet;
    }
}

