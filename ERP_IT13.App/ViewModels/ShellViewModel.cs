using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace ERP_IT13.App.ViewModels
{
    public partial class ShellViewModel : BaseViewModel
    {
        [ObservableProperty]
        object? currentViewModel;

        public IRelayCommand NavigateDashboardCommand { get; }
        public IRelayCommand NavigateUsersCommand { get; }
        public IRelayCommand NavigateInventoryCommand { get; }
        public IRelayCommand NavigateSalesCommand { get; }
        public IRelayCommand NavigateReportsCommand { get; }
        public IRelayCommand LogoutCommand { get; }

        public ShellViewModel()
        {
            NavigateDashboardCommand = new RelayCommand(() => CurrentViewModel = new DashboardViewModel());
            NavigateUsersCommand = new RelayCommand(() => CurrentViewModel = new UsersViewModel());
            NavigateInventoryCommand = new RelayCommand(() => CurrentViewModel = new InventoryViewModel());
            NavigateSalesCommand = new RelayCommand(() => CurrentViewModel = new SalesViewModel());
            NavigateReportsCommand = new RelayCommand(() => CurrentViewModel = new ReportsViewModel());
            LogoutCommand = new RelayCommand(() => Application.Current.Shutdown());

            CurrentViewModel = new DashboardViewModel();
        }
    }

    public class DashboardViewModel : BaseViewModel { }
    public class UsersViewModel : BaseViewModel { }
    public class InventoryViewModel : BaseViewModel { }
    public class SalesViewModel : BaseViewModel { }
    public class ReportsViewModel : BaseViewModel { }
}
