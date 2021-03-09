using System.Runtime.CompilerServices;

namespace Nop.Web.ViewModels
{
    public abstract class ConfigurationViewModel : ViewModel
    {
        protected bool CalculateProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (SetProperty(ref field, value, propertyName))
            {
                ChangeConfiguration();
                return true;
            }

            return false;
        }

        public double PriceExcludingTax { get; set; }
        public double Tax { get; set; }
        public double PriceIncludingTax { get; set; }

        public bool IsValidConfiguration { get; private set; } = true;

        public void ChangeConfiguration()
        {
            if (ValidateConfiguration())
            {
                CalculateConfiguration();
                GetImage();
                IsValidConfiguration = true;
            }
            else
            {
                IsValidConfiguration = false;
                SetPriceEmpty();
            }
        }

        private void GetImage()
        {
            //
        }

        private void SetPriceEmpty()
        {
            PriceExcludingTax = 0;
            Tax = 0;
            PriceIncludingTax = 0;
        }

        protected abstract bool ValidateConfiguration();

        protected void CalculateConfiguration()
        {
            CalculateConfiguration(out double price);

            PriceExcludingTax = price;

            Tax = price * 0.21;

            PriceIncludingTax = PriceExcludingTax + Tax;

        }

        protected abstract void CalculateConfiguration(out double price);
    }
}
