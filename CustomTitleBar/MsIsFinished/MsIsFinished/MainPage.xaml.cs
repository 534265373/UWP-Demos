using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MsIsFinished
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //EnableBackButtonOnTitleBar((sender, args) =>
            //{
            //    TxtMessage.Text += DateTime.Now + Environment.NewLine;
            //});

            //ApplyColorToTitleBar();

            CustomTitleBar();
        }

        void EnableBackButtonOnTitleBar(EventHandler<BackRequestedEventArgs> onBackRequested)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += onBackRequested;
        }

        void ApplyColorToTitleBar()
        {
            var view = ApplicationView.GetForCurrentView();

            // active
            view.TitleBar.BackgroundColor = Colors.DarkBlue;
            view.TitleBar.ForegroundColor = Colors.White;

            // inactive
            view.TitleBar.InactiveBackgroundColor = Colors.LightGray;
            view.TitleBar.InactiveForegroundColor = Colors.Gray;

            // button
            view.TitleBar.ButtonBackgroundColor = Colors.DodgerBlue;
            view.TitleBar.ButtonForegroundColor = Colors.White;

            view.TitleBar.ButtonHoverBackgroundColor = Colors.LightSkyBlue;
            view.TitleBar.ButtonHoverForegroundColor = Colors.White;

            view.TitleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 0, 0, 120);
            view.TitleBar.ButtonPressedForegroundColor = Colors.White;

            view.TitleBar.ButtonInactiveBackgroundColor = Colors.DarkGray;
            view.TitleBar.ButtonInactiveForegroundColor = Colors.Gray;
        }

        void CustomTitleBar()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(GridTitleBar);

            var view = ApplicationView.GetForCurrentView();
            view.TitleBar.ButtonBackgroundColor = Colors.SteelBlue;
            view.TitleBar.ButtonForegroundColor = Colors.White;

            view.TitleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 92, 157, 211);
            view.TitleBar.ButtonHoverForegroundColor = Colors.White;

            view.TitleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 92, 157, 211);
            view.TitleBar.ButtonPressedForegroundColor = Colors.White;

            view.TitleBar.ButtonInactiveBackgroundColor = Color.FromArgb(129, 70, 130, 180);
            view.TitleBar.ButtonInactiveForegroundColor = Colors.WhiteSmoke;

            Window.Current.Activated += (sender, args) =>
            {
                if (args.WindowActivationState != CoreWindowActivationState.Deactivated)
                {
                    GridTitleBar.Opacity = 1;
                    TxtSearchBox.Opacity = 1;
                }
                else
                {
                    GridTitleBar.Opacity = 0.5;
                    TxtSearchBox.Opacity = 0.5;
                }
            };
        }
    }
}
