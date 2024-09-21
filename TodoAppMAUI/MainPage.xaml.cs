using TodoAppMAUI.ViewModels;

namespace TodoAppMAUI
{
    public partial class MainPage:ContentPage
    {

        public MainPage(TodoViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

        }
        
    }

}
