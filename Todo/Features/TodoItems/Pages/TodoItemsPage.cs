using System;

using Xamarin.Forms;

namespace Todo
{
    public class TodoItemsPage : ContentPage
    {
        ToolbarItem addTodoItem;
        TodoItemsView todoView;
        public TodoItemsPage(int todoId, string title)
        {
            Content = todoView = new TodoItemsView()
            {
                BindingContext = new TodoItemsViewModel(new TodoItemService(todoId), todoId, title)
            };
            BindingContext = todoView.ViewModel;
            addTodoItem = new ToolbarItem
            {
               
                Text = "Add Item",
            };
            ToolbarItems.Add(addTodoItem);
            addTodoItem.SetBinding(ToolbarItem.CommandProperty, nameof(TodoViewModel.AddCommand));
        }
    }
}

