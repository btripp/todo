using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo
{
    public partial class App : Application
    {
        //Some notes
         //- Didn't use an IoC container for brevity but did inject a dependency
         //- Didn't opt for MVVM helper like prism or something to keep it simple
         //- Edit and delete items using context actions(swipe left iOS / hold down Android)
         //- Used synchronous db calls for simplicity, I understand that larger data sets and longer load times
         //  would benefit from asynchronous calls, and would probably call for a UI loading indicator
         //- Most of the TodoItems stuff is just inherited from Todo


        public App()
        {
            DatabaseService.Initialize();

            InitializeComponent();

            MainPage = new NavigationPage(new TodoPage());
        }
    }
}
