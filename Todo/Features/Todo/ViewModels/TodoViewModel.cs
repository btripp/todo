using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Todo
{
    public class TodoViewModel : BaseViewModel
    {
        protected string AddEditText = "What would you like to call this list?";
        protected readonly int TodoId;

        protected readonly ITodoRepoService RepoService;

        public TodoViewModel(ITodoRepoService service, int todoId = 0)
        {
            RepoService = service;
            TodoId = todoId;
            LoadData();
        }

        #region binding properties
        public Command AddCommand => new Command(() => Add());

        ObservableCollection<TodoCellViewModel> itemsSource;
        public ObservableCollection<TodoCellViewModel> ItemsSource
        {
            get => itemsSource;
            set => SetObservableProperty(ref itemsSource, value);
        }

        bool isEmpty;
        public bool IsEmpty
        {
            get => isEmpty;
            set => SetObservableProperty(ref isEmpty, value);
        }

        string emptyText = "You don't have any lists yet.\nTap \"Add List\" in the top right corner to create your first list.";
        public string EmptyText
        {
            get => emptyText;
            set => SetObservableProperty(ref emptyText, value);
        }
        #endregion

        #region methods
        public virtual void LoadData()
        {
            var items = RepoService.LoadData();
            ItemsSource = items.Select(x => GetViewModel(x)).AsObservable();
            CheckIfEmpty();
        }

        public TodoCellViewModel GetViewModel(Todo model)
        {
            return new TodoCellViewModel(model)
            {
                DeleteCommand = new Command<TodoCellViewModel>((arg) => Delete(arg)),
                EditCommand = new Command<TodoCellViewModel>((arg) => Edit(arg)),
            };
        }

        public async void Edit(TodoCellViewModel viewModel)
        {
            string name = await MainPage.DisplayPromptAsync("Edit", AddEditText, "Okay");
            if (!string.IsNullOrWhiteSpace(name))
            {
                viewModel.Model.Name = name;
                RepoService.Update(viewModel.Model);

                //force a size update
                int index = ItemsSource.IndexOf(viewModel);
                ItemsSource.Remove(viewModel);
                if (Device.RuntimePlatform == Device.iOS)
                    await Task.Delay(100);
                viewModel.Name = name;
                ItemsSource.Insert(index, viewModel);
            }
        }

        public virtual async void Add()
        {
            string name = await MainPage.DisplayPromptAsync("Add", AddEditText, "Okay");
            if (!string.IsNullOrWhiteSpace(name))
            {
                Todo model = new Todo
                {
                    TodoId = TodoId,
                    Name = name,
                };
                RepoService.Add(model);
                IsEmpty = false;
                ItemsSource.Add(GetViewModel(model));
            }
        }

        public void Delete(TodoCellViewModel viewModel)
        {
            RepoService.Delete(viewModel.Model);
            ItemsSource.Remove(viewModel);
            CheckIfEmpty();
        }

        private void CheckIfEmpty()
        {
            IsEmpty = !ItemsSource.Any();
        }
        
        public virtual async void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var viewModel = e.Item as TodoCellViewModel;
            await MainPage.Navigation.PushAsync(new TodoItemsPage(viewModel.Model.Id, viewModel.Name));
        }
        #endregion
    }
}
