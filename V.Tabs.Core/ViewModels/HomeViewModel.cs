// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the HomeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace V.Tabs.Core.ViewModels
{
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using System.Windows.Input;

    /// <summary>
    /// Define the HomeViewModel type.
    /// </summary>
    public class HomeViewModel : MvxViewModel
    {

        private MvxCommand showTabOneCommand;
        private readonly IMvxNavigationService _navigationService;

        public MvxCommand ShowTabOneCommand => new MvxCommand(() => _navigationService.Navigate<TabOneViewModel>());
        public ICommand ShowTabTwoCommand => new MvxCommand(() => _navigationService.Navigate<TabTwoViewModel>());
        public ICommand ShowTabThreeCommand => new MvxCommand(() => _navigationService.Navigate<TabThreeViewModel>());

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}

