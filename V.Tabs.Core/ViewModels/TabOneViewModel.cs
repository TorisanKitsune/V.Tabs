// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the TabOneViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace V.Tabs.Core.ViewModels
{
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Define the TabOneViewModel type.
    /// </summary>
    public class TabOneViewModel : MvxViewModel
    {
        /// <summary>
        /// Backing field for my property.
        /// </summary>
        private String myProperty = "Tab One";
        private readonly IMvxNavigationService _navigationService;


        /// <summary>
        /// Gets or sets my property.
        /// </summary>
        public String MyProperty
        {
            get => myProperty;
            set => SetProperty(ref myProperty, value);
        }

        public ICommand ShowFullScreenViewCommand => new MvxCommand(() => _navigationService.Navigate<DetailFullScreenViewModel>());
        public TabOneViewModel(IMvxNavigationService navigationService) => _navigationService = navigationService;
    }
}

