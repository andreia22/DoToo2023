using DoToo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


// carga da tela
namespace DoToo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView
        : ContentPage
    {
        public MainView(MainViewModel viewmodel
            )
        {
            InitializeComponent();
            viewmodel.Navigation = Navigation;
            BindingContext = viewmodel;

            ItemsListView.ItemSelected += (s, e) => 
            ItemsListView.SelectedItem = null;
            
        }
    }
}