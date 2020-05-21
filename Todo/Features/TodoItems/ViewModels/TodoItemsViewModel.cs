using System;

using Xamarin.Forms;

namespace Todo
{
    public class TodoItemsViewModel : TodoViewModel
    {
        public TodoItemsViewModel(ITodoRepoService repoService, int todoId, string title) : base(repoService, todoId)
        {
            AddEditText = "What would you like to call this item?";
            EmptyText = "You haven't added any items to this list yet. Tap \"Add Item\" in the top right corner to add your first item.";
            ListTitle = title;
        }

        public override void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var viewModel = e.Item as TodoCellViewModel;
            viewModel.Model.Complete = !viewModel.Model.Complete;
            RepoService.Update(viewModel.Model);
            viewModel.Complete = !viewModel.Complete;
        }

        string listTitle;
        public string ListTitle
        {
            get => listTitle;
            set => SetObservableProperty(ref listTitle, value);
        }
    }
}

