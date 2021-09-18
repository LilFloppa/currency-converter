using CurrencyConverter.Models;
using CurrencyConverter.ViewModels;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace CurrencyConverter.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            DataContext = (MainViewModel)e.Parameter;
        }

        private void OnChangeFromCurrencyButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)DataContext;
            Frame.Navigate(typeof(ChangeCurrencyPage), new ChangeCurrencyViewModel(vm.CurrencyList, vm.FromCurrency, (c) => vm.FromCurrency = c));
        }

        private void OnChangeToCurrencyButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)DataContext;
            Frame.Navigate(typeof(ChangeCurrencyPage), new ChangeCurrencyViewModel(vm.CurrencyList, vm.ToCurrency, (c) => vm.ToCurrency = c));
        }
    }
}
