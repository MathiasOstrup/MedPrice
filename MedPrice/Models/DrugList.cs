using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MedPrice.Models
{
    public class DrugList : INotifyPropertyChanged
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string baseUrlHead = "http://api.medicinpriser.dk/v1/produkter/virksomtstof/";
        private static readonly string baseUrlTail = "?format=xml";

        public event PropertyChangedEventHandler? PropertyChanged;
        private Drug _selectedDrug;
        public ObservableCollection<Drug> Drugs { get; set; } = new ObservableCollection<Drug>();
        public Drug SelectedDrug
        {
            get { return _selectedDrug; }
            set
            {
                if (_selectedDrug != value)
                {
                    _selectedDrug = value;
                    OnPropertyChanged(nameof(SelectedDrug));  // Notify change
                }
            }
        }

        public DrugList() 
        {
            Drugs = new ObservableCollection<Drug>();
            _selectedDrug = new Drug("","","","","","");
        }

        
        public async Task getDrugs(string apiUrl)
        {
            try
            {
                string fullUrl = baseUrlHead + apiUrl + baseUrlTail;
                HttpResponseMessage response = await client.GetAsync(fullUrl);
                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();
                XDocument apiResponse = XDocument.Parse(responseData);

                Drugs.Clear();

                var produktItems = apiResponse.Descendants("Produkt")
                                      .Select(x => new Drug(
                                          x.Element("Navn")?.Value,
                                          x.Element("Varenummer")?.Value,
                                          x.Element("Firma")?.Value,
                                          x.Element("Styrke")?.Value,
                                          x.Element("DetaljerUrl")?.Value,
                                          x.Element("Pakning")?.Value
                                      )).ToList();
                foreach (var drug in produktItems)
                {
                    Drugs.Add(drug);
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error calling API: {ex.Message}");
                Drugs = new ObservableCollection<Drug>();
            }

        }

        
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
