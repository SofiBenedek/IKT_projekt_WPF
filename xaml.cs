using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        // Statikus repülőjárat adatok
        private List<Flight> availableFlights = new List<Flight>
        {
            new Flight("Budapest", "Berlin", new DateTime(2025, 2, 10), "AB123"),
            new Flight("Budapest", "London", new DateTime(2025, 2, 15), "BA456"),
            new Flight("Berlin", "New York", new DateTime(2025, 2, 18), "DL789"),
            new Flight("London", "Paris", new DateTime(2025, 2, 20), "AF101"),
            new Flight("Budapest", "Paris", new DateTime(2025, 2, 12), "FR202")
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        // Keresés gomb eseménykezelője
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string departure = DepartureTextBox.Text;
            string destination = DestinationTextBox.Text;
            DateTime? date = DatePicker.SelectedDate;

            if (string.IsNullOrEmpty(departure) || string.IsNullOrEmpty(destination) || !date.HasValue)
            {
                MessageBox.Show("Kérlek, töltsd ki az összes mezőt!");
                return;
            }

            // Keresés a repülőjáratok között
            var results = availableFlights.Where(f => f.Departure == departure &&
                                                      f.Destination == destination &&
                                                      f.Date.Date == date.Value.Date).ToList();

            // Találatok megjelenítése a ListBox-ban
            FlightsListBox.Items.Clear();
            foreach (var flight in results)
            {
                FlightsListBox.Items.Add($"{flight.FlightNumber} - {flight.Date.ToShortDateString()}");
            }

            // Ha nincs találat
            if (results.Count == 0)
            {
                FlightsListBox.Items.Add("Nincs találat a keresett adatokra.");
            }
        }
    }

    // Repülőjárat osztály
    public class Flight
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public string FlightNumber { get; set; }

        public Flight(string departure, string destination, DateTime date, string flightNumber)
        {
            Departure = departure;
            Destination = destination;
            Date = date;
            FlightNumber = flightNumber;
        }
    }
}
