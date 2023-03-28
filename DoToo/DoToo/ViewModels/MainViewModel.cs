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
using Caliburn.Micro; 
using SQLite;
using DoToo.Models;

namespace DoToo.ViewModels
{
    public class MainViewModel : ViewModel 
    {
        private readonly TodoItemRepository repository;

        public ObservableCollection<TodoItemViewModel> Items { get; set; }   

        public MainViewModel(TodoItemRepository repository)

        {

            repository.OnItemAdded += (sender, item) =>
            Items.Add(CreateTodoItemViewModel(item));

            repository.OnItemUpdate += (sender, item) =>
                Task.Run(async () => await LoadData());

            this.repository = repository;
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            var items = await repository.GetItems();
            var itemViewModels = items.Select(i => CreateTodoItemViewModel(i) );
            Items = new ObservableCollection<TodoItemViewModel>(itemViewModels);  

        }
        private TodoItemViewModel CreateTodoItemViewModel(TodoItem item)
        {
            var itemViewModel = new TodoItemViewModel(item);
            itemViewModel.ItemStatusChanged += ItemStatusChanged;
            return itemViewModel;

        }

        private void ItemStatusChanged(object sender, EventArgs e)
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
