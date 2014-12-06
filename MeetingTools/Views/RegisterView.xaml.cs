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


        public static bool IsValidEmail(string mailString)
        {
            const string mFormat = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(mailString, mFormat))
            {
                if (Regex.Replace(mailString, mFormat, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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
            else if (ULastname.Text == "")
                ShowError("Last Name");
            else if (UUsername.Text == "")
                ShowError("User Name");
            else if (Uemail.Text == "")
                ShowError("Email");
            else if (!IsValidEmail(Uemail.Text))
                MessageBox.Show("Please enter a valid email");
            else if (Upassword.Password == "")
                ShowError("Password");
            else if (UconfirmPassword.Password == "")
                ShowError("Confirm password");
            else if (!checkPassword(Upassword.Password, UconfirmPassword.Password))
                MessageBox.Show("Passwords does not match");
            else
            {
                NavigationService.Navigate(new Uri("/Views/TermsView.xaml", UriKind.Relative));
                //RegisterUser();
            }
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