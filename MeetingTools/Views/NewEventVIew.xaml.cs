using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Reactive;
using Parse;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace MeetingTools
{
    public partial class NewEventVIew : PhoneApplicationPage
    {

        bool pcb = false;
        public NewEventVIew()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
        }

        private void TapBack(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
        }

        private async void PushToDb(object sender, GestureEventArgs e)
        {
            DateTime myDate = ((DateTime)EventDate01.Value).Date.Add(((DateTime)EventTime01.Value).TimeOfDay);
            int result = DateTime.Compare(myDate, DateTime.Now);
            if (EventName.Text == "")
            {
                EmptyField("Name");
            }
            else if(EventPlace01.Text == "")
            {
                EmptyField("Place");
            }
            else if (EventDetails.Text == "")
            {
                EmptyField("Details");
            }
            else if (EventGuest01.Text == "")
            {
                EmptyField("Friends");
            }
            else if (result < 0)
            {
                EmptyField("Date");
            }
            else
            {
                var eventObject = new ParseObject("NewEvent");
                eventObject["EventName"] = EventName.Text;
                eventObject["Place"] = EventPlace01.Text;
                //DateTime myDate = ((DateTime)EventDate01.Value).Date.Add(((DateTime)EventTime01.Value).TimeOfDay);
                eventObject["DateTime"] = myDate;
                eventObject["Friends"] = EventGuest01.Text;
                eventObject["Public"] = pcb;
                eventObject["Details"] = EventDetails.Text;
                await eventObject.SaveAsync();
                NavigationService.Navigate(new Uri("/ManageEventsView.xaml", UriKind.Relative));
            }
            MessageBox.Show("Rien :(");
        }


        private void EmptyField(string error)
        {
            if (error == "Place") 
            { 
                MessageBox.Show("Your event must be somewhere, pick a place");

            }
            if (error == "Name") 
            { 
                MessageBox.Show("Your event need a name so you can have an idea of what it is");

            }
            if (error == "Friends") 
            { 
                MessageBox.Show("Unless is a one-man-event, you need to invite your friends");

            }
            if (error == "Details") 
            { 
                MessageBox.Show("Add some details to your event");

            }
            if (error == "Date") 
            { 
                MessageBox.Show("Unless you have a time machine, you cannot create an event for a previous date");
            }
        }

        private void CheckPublic(object sender, RoutedEventArgs e)
        {
            pcb = true;
        }
    }
}