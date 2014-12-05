using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace MeetingTools
{
    public partial class LoginView : PhoneApplicationPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void TapRegister(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/RegisterView.xaml", UriKind.Relative));
        }
    }
}