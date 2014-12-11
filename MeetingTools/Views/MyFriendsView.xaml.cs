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
    public partial class MyFriendsView : PhoneApplicationPage
    {

        
        public MyFriendsView()
        {
            InitializeComponent();
            GetFriendList();
        }

        private async void GetFriendList()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Users");
            ParseObject getUser = await query.FirstOrDefaultAsync();

            if (App.GetLocalData().Equals(getUser.Get<string>("username")))
               App.FriendsList =  getUser.Get<List<string>>("FriendList");

            YourListBox.ItemsSource = App.FriendsList;

        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
        }

        private void TapBack(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
        }

        private void TapAdd(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/AddFriendPage.xaml", UriKind.Relative));
        }
    }
}