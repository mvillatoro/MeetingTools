using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;
using Parse;

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

        private void ShowError(string error)
        {
            if (error == "Name")
                MessageBox.Show("The field " + error + " cant be empty");
            if (error == "Last Name")
                MessageBox.Show("The field " + error + " cant be empty");
            if (error == "User Name")
                MessageBox.Show("The field " + error + " cant be empty");
            if (error == "Email")
                MessageBox.Show("The field " + error + " cant be empty");
            if (error == "Password")
                MessageBox.Show("The field " + error + " cant be empty");
            if (error == "Confirm password")
                MessageBox.Show("The field " + error + " cant be empty");
        }

        bool checkPassword(string pass1, string pass2)
        {
            if (pass1.Equals(pass2))
            {
                return true;
            }
            return false;
        }

        private void CreateUser(object sender, GestureEventArgs e)
        {

            if (Uname.Text == "")
                ShowError("Name");
            if (ULastname.Text == "")
                ShowError("Last Name");
            if (UUsername.Text == "")
                ShowError("User Name");
            if (Uemail.Text == "")
                ShowError("Email");
            if (IsValidEmail(Uemail.Text))
                MessageBox.Show("Please enter a valid email");
            if (Upassword.Password == "")
                ShowError("Password");
            if (UconfirmPassword.Password == "")
                ShowError("Confirm password");
            if (!checkPassword(Upassword.Password, UconfirmPassword.Password))
                MessageBox.Show("Passwords does not match");                
            else
                NavigationService.Navigate(new Uri("/Views/TermsView.xaml", UriKind.Relative));
                //RegisterUser();
        }

        private async void RegisterUser()
        {

            var userObect = new ParseObject("User");
            userObect["username"] = UUsername.Text;
            userObect["password"] = Upassword.Password;
            userObect["emailVerified"] = true;
            userObect["Name"] = Uname.Text;
            userObect["LastName"] = ULastname.Text;
            userObect["email"] = Uemail.Text;
            await userObect.SaveAsync();
            NavigationService.Navigate(new Uri("/Views/LoginView.xaml", UriKind.Relative));

        }


    }
}