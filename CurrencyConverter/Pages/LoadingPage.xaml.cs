using CurrencyConverter.Services;
using CurrencyConverter.ViewModels;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace CurrencyConverter.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class LoadingPage : Page
    {
        private ICurrencyService currencyService;
        public LoadingPage()
        {
            this.InitializeComponent();
            currencyService = new CurrencyService();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            try
            {
                var currencyList = await currencyService.GetCurrencyListAsync();
                Frame.Navigate(typeof(MainPage), new MainViewModel(currencyList));
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog($"Failed to load currency data from the server. {ex.Message }");
                await dialog.ShowAsync();

                App.Current.Exit();
            }
        }
    }
}
