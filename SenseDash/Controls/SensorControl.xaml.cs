using Windows.UI.Xaml.Controls;
using SenseDash.Shared.ViewModel;

namespace SenseDash.Controls
{
    public sealed partial class SensorControl : UserControl
    {
        public SensorControl()
        {
            this.InitializeComponent();
        }

        public SensorViewModel Vm
        {
            get
            {
                return this.DataContext as SensorViewModel;
            }
        }
    }
}
