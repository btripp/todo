using System;
using Xamarin.Forms;
namespace Todo
{
    public class TodoItemsCell : TodoCell
    {
        Image completeImage;
        public TodoItemsCell()
        {
            InitializeComponents();
            LayoutComponents();
            SetBindings();
        }
        private void InitializeComponents()
        {
            ItemCountLabel.IsVisible = false;
            completeImage = new Image
            {
                WidthRequest = 25,
                HeightRequest = 25
            };
        }
        private void LayoutComponents()
        {
            MasterLayout.Children.Insert(0, completeImage);
        }
        private void SetBindings()
        {
            completeImage.SetBinding(Image.SourceProperty, nameof(TodoCellViewModel.Image));
        }
    }
}
