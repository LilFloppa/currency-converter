using System.Linq;
using Windows.UI.Xaml.Controls;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace CurrencyConverter.UserControls
{
    public sealed class DoubleTextBox : TextBox
    {
        public DoubleTextBox()
        {
            BeforeTextChanging += OnBeforeTextChanging;
        }

        private void OnBeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = 
                args.NewText.Any(c => !char.IsDigit(c) && c != '.' && c != ',') || 
                args.NewText.Count(c => c == '.' || c == ',') > 1;
        }
    }
}
