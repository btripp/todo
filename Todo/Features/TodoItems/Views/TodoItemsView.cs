using System;

using Xamarin.Forms;

namespace Todo
{
    public class TodoItemsView : TodoView
    {
        public TodoItemsView()
        {
            TodoListView.ItemTemplate = new DataTemplate(typeof(TodoItemsCell));

            //maybe not really worth the performance implication but wanted to keep it in the view model
            TitleLabel.SetBinding(Label.TextProperty, nameof(TodoItemsViewModel.ListTitle));
        }
    }
}

