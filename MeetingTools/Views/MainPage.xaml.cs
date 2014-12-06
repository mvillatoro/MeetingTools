﻿using System;
using System.Windows;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace MeetingTools.Views
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
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult x = MessageBox.Show("Do you really want to exit the app", "", MessageBoxButton.OKCancel);
            if (x == MessageBoxResult.OK)
                NavigationService.RemoveBackEntry();
            else
                e.Cancel = true;
        }

    }
}