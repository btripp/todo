using System;

using Xamarin.Forms;

namespace Todo
{
    public class TodoPage : ContentPage
    {
        private readonly ToolbarItem addListItem;
        private readonly TodoView todoView;
        private bool hasShown = false;
        public TodoPage()
        {
            //I don't like my views to be tightly coupled with pages, makes them more portable...personal preference.
            Content = todoView = new TodoView()
            {
                BindingContext = new TodoViewModel(new TodoService())
            };
            BindingContext = todoView.ViewModel;

            addListItem = new ToolbarItem
            {
                Text = "Add List",
            };

            ToolbarItems.Add(addListItem);

            addListItem.SetBinding(ToolbarItem.CommandProperty, nameof(TodoViewModel.AddCommand));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!hasShown)
            {
                hasShown = true;
            }
            else
            {
                todoView.ViewModel.LoadData();
            }
           
        }
    }
   
}

