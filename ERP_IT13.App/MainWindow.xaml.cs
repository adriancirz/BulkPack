using ERP_IT13.App.ViewModels;
using ERP_IT13.App.Views;
using System.Windows;
using System.Windows.Controls;

namespace ERP_IT13.App
{
    public partial class MainWindow : Window
    {
        private readonly ShellViewModel _vm = new ShellViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;

            NavList.SelectionChanged += NavList_SelectionChanged;
            ContentRegion.Content = new DashboardView();
        }

        private void NavList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NavList.SelectedItem is ListBoxItem item && item.Tag is string tag)
            {
                switch (tag)
                {
                    case "Dashboard":
                        _vm.NavigateDashboardCommand.Execute(null);
                        ContentRegion.Content = new DashboardView();
                        break;
                    case "Users":
                        _vm.NavigateUsersCommand.Execute(null);
                        ContentRegion.Content = new TextBlock { Text = "Users", Margin = new Thickness(16) };
                        break;
                    case "Inventory":
                        _vm.NavigateInventoryCommand.Execute(null);
                        ContentRegion.Content = new TextBlock { Text = "Inventory", Margin = new Thickness(16) };
                        break;
                    case "Sales":
                        _vm.NavigateSalesCommand.Execute(null);
                        ContentRegion.Content = new TextBlock { Text = "Sales", Margin = new Thickness(16) };
                        break;
                    case "Reports":
                        _vm.NavigateReportsCommand.Execute(null);
                        ContentRegion.Content = new TextBlock { Text = "Reports", Margin = new Thickness(16) };
                        break;
                    case "Logout":
                        _vm.LogoutCommand.Execute(null);
                        break;
                }
            }
        }
    }
}