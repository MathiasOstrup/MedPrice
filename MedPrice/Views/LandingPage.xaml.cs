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
            Debug.WriteLine("Trykket");
            var input1 = InputField1.Text;
            // handle input1
        }

        private async void AktivtStof_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button Pressed!");
            var aktivtStof = InputField2.Text;
            Debug.WriteLine(aktivtStof);
            await DrugList.getDrugs(aktivtStof);
        }

        
    }
}
