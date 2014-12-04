using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Parse;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

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


        public async void OnLaunched()
        {

            var testObject = new ParseObject("TestObject");
            testObject["foo"] = "bar";
            await testObject.SaveAsync();

        }

        private async void PushToDb(object sender, GestureEventArgs e)
        {

            var eventObject = new ParseObject("NewEvent");
            eventObject["EventName"] = EventName.Text;
            eventObject["Place"] = EventPlace01.Text;
            
            //TODO parse date
            eventObject["DateTime"] = DateTime.Now;
            eventObject["Friens"] = EventGuest01.Text;
            
            //TODO check public checkbox value
            eventObject["Public"] = false;
            eventObject["Details"] = EventDetails.Text;

            await eventObject.SaveAsync();
        }

        private void TapPublic(object sender, GestureEventArgs e)
        {
        
              
        }
    }
}