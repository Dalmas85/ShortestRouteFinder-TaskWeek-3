using ShortestRouteFinder.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;

namespace ShortestRouteFinder.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Route> Routes { get; set; }

        private Route? _selectedRoute;
        public Route? SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                _selectedRoute = value;
                OnPropertyChanged(nameof(SelectedRoute));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            // Initialize the Routes collection with data from LoadRoutes
            Routes = new ObservableCollection<Route>(LoadRoutes());
        }

        // Method to load routes from a JSON file
        private static List<Route> LoadRoutes()
        {
            var filePath = "EuropeRoutes.json";
            if (!File.Exists(filePath))
            {
                return [];
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Route>>(json) ?? [];

        }

        // Raise the PropertyChanged event to notify UI about updates
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
