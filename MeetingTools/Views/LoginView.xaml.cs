using System;
using System.Windows;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;
using Parse;


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

        private void TapLogin(object sender, GestureEventArgs e)
        {
            IsValidUser();
        }

        private async void IsValidUser()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Users");
            ParseObject getUser = await query.FirstOrDefaultAsync();
            


            if (UserBox.Text.Equals(getUser.Get<string>("username")) && PassBox.Password.Equals(getUser.Get<string>("password")))
            //if(true)
                NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
            else
                MessageBox.Show("Invalid User name or password");
            
        }

    }
}