using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MeetingTools.Resources;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace MeetingTools
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void OpenNewEvent(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/NewEventView.xaml", UriKind.Relative));
        }
        private void OpenManageEvent(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/ManageEventsView.xaml", UriKind.Relative));
        }
        private void OpenMyEvents(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/MyEventsView.xaml", UriKind.Relative));            
        }

        private void OpenAbout(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/AboutView.xaml", UriKind.Relative));
        }
    }
}