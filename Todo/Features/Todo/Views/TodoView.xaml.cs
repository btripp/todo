using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Todo
{
    public partial class TodoView : ContentView
    {
        protected ListView TodoListView => todoListView;
        protected Label TitleLabel => titleLabel;
        public TodoViewModel ViewModel => BindingContext as TodoViewModel;
        public TodoView()
        {
            InitializeComponent();
        }

        void TodoListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.ItemTapped(sender, e);
        }
    }
}
