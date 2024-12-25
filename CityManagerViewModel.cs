using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace CityManagerApp.ViewModels
{
    public class CityManagerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<City> cities;
        private ObservableCollection<string> countries;

        public CityManagerViewModel()
        {
            // Инициализация данных
            Cities = new ObservableCollection<City>
            {
                new City { ID = 1, Name = "Moscow", Country = "Russia" },
                new City { ID = 2, Name = "New York", Country = "USA" },
                new City { ID = 3, Name = "Paris", Country = "France" }
            };

            Countries = new ObservableCollection<string>
            {
                "Russia", "USA", "France", "Germany", "Japan"
            };
        }

        public ObservableCollection<City> Cities
        {
            get => cities;
            set
            {
                cities = value;
                OnPropertyChanged(nameof(Cities));
            }
        }

        public ObservableCollection<string> Countries
        {
            get => countries;
            set
            {
                countries = value;
                OnPropertyChanged(nameof(Countries));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddCity()
        {
            int newId = Cities.Any() ? Cities.Max(c => c.ID) + 1 : 1;
            Cities.Add(new City { ID = newId, Name = "New City", Country = Countries.FirstOrDefault() });
        }

        public void RemoveCity(City city)
        {
            if (city != null)
            {
                Cities.Remove(city);
            }
        }
    }
}
