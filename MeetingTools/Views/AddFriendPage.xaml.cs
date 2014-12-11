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
    public partial class AddFriendPage : PhoneApplicationPage
    {
        private bool afc = false;
        private List<string> ShowList = new List<string>(); 
        private List<string> SearchList = new List<string>(); 


        public AddFriendPage()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/MyFriendsView.xaml", UriKind.Relative));
        }

        private void TapBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/MyFriendsView.xaml", UriKind.Relative));
        }

        private void MakeSearch(object sender, GestureEventArgs e)
        {
            SearchFriends();
        }

        private async void SearchFriends()
        {
            var query = ParseObject.GetQuery("Users")
            .WhereEqualTo("username", SearchBox.Text);
           
            ParseObject getUser = await query.FirstAsync();
            
            if (SearchBox.Text.Equals(getUser.Get<string>("username")))
            {
                if (getUser.ObjectId != null)
                {
                    var id = getUser.ObjectId;
                    var full = getUser.Get<string>("Name") + " " + getUser.Get<string>("LastName");
                    SearchList.Add(getUser.ObjectId);
                    ShowList.Add(full);
                }   
            }
            YourListBox.ItemsSource = ShowList;

            /*
            var query = ParseObject.GetQuery("Users")
    .WhereEqualTo("username", UserBox.Text);

            ParseObject obj = await query.FirstAsync();


            if (obj.Get<string>("password").Equals(PassBox.Password))
            {
                App.SetLocalData(obj.ObjectId);
                NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Invalid User name or password");
            }
        */
        }

        private async void AddtoMyFriends()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Users");
            ParseObject getUser = await query.GetAsync(SearchList[0]);
            if (afc)
            {
                var userName = getUser.Get<string>("Name") + " " + getUser.Get<string>("LastName");
                App.FriendsList.Add(userName);
                getUser.AddToList("FriendList", userName );
                await getUser.SaveAsync();
            }
            NavigationService.Navigate(new Uri("/Views/MyFriendsView.xaml", UriKind.Relative));
        }


        private void AddTolist(object sender, RoutedEventArgs e)
        {
            afc = true;
        }

        private void TapAdd(object sender, GestureEventArgs e)
        {
            AddtoMyFriends();
        }
    }
}