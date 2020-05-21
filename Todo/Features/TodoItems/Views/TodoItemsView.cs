using System;

using Xamarin.Forms;

namespace Todo
{
    public class TodoItemsView : TodoView
    {
        public TodoItemsView()
        {
            TodoListView.ItemTemplate = new DataTemplate(typeof(TodoItemsCell));

            TitleLabel.SetBinding(Label.TextProperty, nameof(TodoItemsViewModel.ListTitle));
        }
    }
}

