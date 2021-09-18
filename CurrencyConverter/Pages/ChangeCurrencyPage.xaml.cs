using CurrencyConverter.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace CurrencyConverter.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ChangeCurrencyPage : Page
    {
        public ChangeCurrencyPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            DataContext = (CurrencyListViewModel)e.Parameter;
        }

        private void OnReturnButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
