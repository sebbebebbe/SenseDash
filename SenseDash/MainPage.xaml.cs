using Windows.UI.Xaml.Controls;
using SenseDash.Shared.ViewModel;

namespace SenseDash
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public MainPageViewModel Vm
        {
            get { return this.DataContext as MainPageViewModel; }
        }
    }
}
