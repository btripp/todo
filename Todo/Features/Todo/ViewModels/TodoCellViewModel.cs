using System;

using Xamarin.Forms;

namespace Todo
{
    public class TodoCellViewModel : BaseViewModel
    {
        public Todo Model { get; set; }

        public TodoCellViewModel()
        {

        }

        public TodoCellViewModel(Todo model)
        {
            Model = model;
            Name = model.Name;
            Complete = model.Complete;
            Count = model.UnfinishedCount;
        }
        public ImageSource Image => Complete ? "check" : "circle";

        string name;
        public string Name
        {
            get => name;
            set => SetObservableProperty(ref name, value);
        }

        bool complete;
        public bool Complete
        {
            get => complete;
            set
            {
                SetObservableProperty(ref complete, value);
                OnPropertyChanged(nameof(Image));
            }
        }

        int count;
        public int Count
        {
            get => count;
            set => SetObservableProperty(ref count, value);
        }

        Command editCommand;
        public Command EditCommand
        {
            get => editCommand;
            set => SetObservableProperty(ref editCommand, value);
        }

        Command deleteCommand;
        public Command DeleteCommand
        {
            get => deleteCommand;
            set => SetObservableProperty(ref deleteCommand, value);
        }
    }
}

