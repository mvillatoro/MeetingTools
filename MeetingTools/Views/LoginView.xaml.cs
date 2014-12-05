using System;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace MeetingTools.Views
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