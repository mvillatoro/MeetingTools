using System;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace MeetingTools
{
    public partial class ManageEventsView : PhoneApplicationPage
    {
        public ManageEventsView()
        {
            InitializeComponent();
        }

        private void OpenEvent(object sender, GestureEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        private void TapBack(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}