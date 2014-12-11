using System;
using System.Collections.Generic;
using Microsoft.Phone.Controls;
using Parse;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace MeetingTools.Views
{
    public partial class MyEventsView : PhoneApplicationPage
    {
        public MyEventsView()
        {
            InitializeComponent();
            GetEventListList();
        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
        }
        private void TapBack(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
        }

        private async void GetEventListList()
        {
            ParseQuery<ParseObject> query = from myevent in ParseObject.GetQuery("NewEvent")
                        where myevent.Get<string>("Owner") == App.GetLocalData()
                        select myevent;


            IEnumerable<ParseObject> obj = await query.FindAsync();

            
            YourListBox.ItemsSource = obj;

        }

    }
}