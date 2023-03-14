using DoToo.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace DoToo.ViewModels
{
    public class TodoItemViewModel : ViewModel
    {

        public TodoItem Item { get; private set; } 
        
        public TodoItemViewModel(TodoItem item) => Item = item;

        public event EventHandler ItemStatusChanged;

        public string StatusText => (Item.Completed ? "Reativar" : " Completo");

       

    }
}
