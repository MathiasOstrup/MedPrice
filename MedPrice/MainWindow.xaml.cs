using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace MedPrice
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // Hide the default system title bar.
            ExtendsContentIntoTitleBar = true;

            // Replace system title bar with the WinUI TitleBar.
            SetTitleBar(MedPrice);
        }

        private void MedPrice_BackRequested(TitleBar sender, object args)
        {
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }
    }
}
