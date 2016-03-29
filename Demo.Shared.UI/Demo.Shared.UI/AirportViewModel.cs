using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo.Shared.UI
{

    public class Airport
    {
        public string IATA { get; set; }
        public string Name { get; set; }
    }


    public class AirportViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private string name;
        public string Name
        {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }


        private ObservableCollection<string> airport;
        public ObservableCollection<string> Airports
        {
            get { return airport; }
            set
            {
                airport = value;
                OnPropertyChanged("Airports");
                OnPropertyChanged("TotalAirport");
            }
        }

        public int TotalAirport { get { return airport.Count; } }

        private Command loadAirportCommand;

        public Command LoadAirportCommand
        {
            get { return loadAirportCommand ?? (loadAirportCommand = new Command(LoadAirport)); }
        }

        public bool CanExecute()
        {
            return !string.IsNullOrEmpty(Name);
        }

        public async void LoadAirport()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("empno", "6127");
            client.DefaultRequestHeaders.Add("token", "9762a770-2c9a-4e3e-893a-d7b6607bf798");
            var response = await client.GetStringAsync(@"http://hmg.itgs.com.br/CrewMemberManager/CrewMemberManager.ServiceCrewMember.svc/findStations");
            var airports = JsonConvert.DeserializeObject<IEnumerable<Airport>>(response);

            Airports = new ObservableCollection<string>(airports.Select(a => a.Name).Where( a=> a.Contains(Name)));

        }

    }
}
