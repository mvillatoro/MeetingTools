using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Parse;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace MeetingTools.Views
{
    public partial class TermsView : PhoneApplicationPage
    {
        public TermsView()
        {
            InitializeComponent();
        }

        private void TapNotAccept(object sender, GestureEventArgs e)
        {
            MessageBox.Show("That's a shame :(");
            NavigationService.Navigate(new Uri("/Views/LoginView.xaml", UriKind.Relative));
        }

        private void TapAccept(object sender, GestureEventArgs e)
        {
            MessageBox.Show("Thanks, you're Awesome :D");
            NavigationService.Navigate(new Uri("/Views/LoginView.xaml", UriKind.Relative));

        }
    }
}