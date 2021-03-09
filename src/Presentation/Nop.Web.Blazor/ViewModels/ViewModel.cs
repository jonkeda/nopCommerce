using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Nop.Web.ViewModels
{
    public abstract class ViewModel
    {
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            Debug.Assert(propertyName != null, "propertyName != null");
            if (!Equals(field, value))
            {
                //NotifyPropertyChanging(propertyName);

                field = value;

                //NotifyPropertyChanged(propertyName);

                return true;
            }
            return false;
        }
    }
}
