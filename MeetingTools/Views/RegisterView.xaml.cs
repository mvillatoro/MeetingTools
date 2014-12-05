using System;
using System.Text.RegularExpressions;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace MeetingTools.Views
{
    public partial class RegisterView : PhoneApplicationPage
    {
        public RegisterView()
        {
            InitializeComponent();

        }


        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                   @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }


        private void BackToLogIn(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LoginView.xaml", UriKind.Relative));
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/LoginView.xaml", UriKind.Relative));
        }


        private void RegisterUser(object sender, GestureEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}