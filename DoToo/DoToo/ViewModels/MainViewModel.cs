using DoToo.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DoToo.Views;
using Xamarin.Forms;
using System.Windows.Input;
using System.Linq;
using System.Collections.ObjectModel;

namespace DoToo.ViewModels
{
    public class MainViewModel : ViewModel 
    {
        private readonly TodoItemRepository repository;

        public MainViewModel(TodoItemRepository repository)
        {
            this.repository = repository;
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {

        }

        // Evento de click do botao para acicionar item

        public ICommand AddItem => new Command(async () =>
        {
            var itemView = Resolver.Resolve<ItemView>();
            await Navigation.PushAsync(itemView);

        });
    }
}
