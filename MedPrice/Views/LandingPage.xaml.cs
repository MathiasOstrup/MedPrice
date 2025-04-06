using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using MedPrice.Models;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MedPrice.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LandingPage : Page
    {
        private DrugList drugListModel = new DrugList();

        public LandingPage()
        {
            this.InitializeComponent();
            this.DataContext = (new DrugList());
            
        }

        private void PræperatNavn_Click(object sender, RoutedEventArgs e)
        {
            //var input1 = InputField1.Text;
        }

        private async void AktivtStof_Click(object sender, RoutedEventArgs e)
        {
            var aktivtStof = InputField2.Text;
            await DrugList.getDrugs(aktivtStof);
        }

        private void ItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("SelectedChange " + e.AddedItems.LastOrDefault());
            Drug? selected = e.AddedItems.LastOrDefault(new Drug("", "", "", "", "", "")) as Drug;
            DrugList.SelectedDrug = selected;
            
        }
    }
}
