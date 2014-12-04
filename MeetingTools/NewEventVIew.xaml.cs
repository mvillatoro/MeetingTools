using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace MeetingTools
{
    public partial class NewEventVIew : PhoneApplicationPage
    {
        public NewEventVIew()
        {
            InitializeComponent();
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