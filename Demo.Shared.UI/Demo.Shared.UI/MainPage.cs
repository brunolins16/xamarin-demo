using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Demo.Shared.UI
{
    internal class MainPage : TabbedPage
    {
        public MainPage()
        {
            this.BindingContext = new AirportViewModel();

            var filter = new Editor() { };
            filter.SetBinding(Editor.TextProperty, "Name", BindingMode.TwoWay);

            var reloadButton = new Button() { Text = "Recarregar" };
            reloadButton.SetBinding(Button.CommandProperty, "LoadAirportCommand");

            var airporList = new ListView() { };
            airporList.SetBinding(ListView.ItemsSourceProperty, "Airports");

            var tab1 = new ContentPage()
            {
                Title = "Aeroportos",
                Content = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Children = {
                        filter,
                        airporList,
                        reloadButton
                    }
                }
            };
            var tab2 = new ContentPage()
            {
                Title = "Tab2",
                Content = new Label() { Text = "Tab 2" }
            };


            Children.Add(tab1);
            Children.Add(tab2);

        }
    }
}