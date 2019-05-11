// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the DetailFullScreenViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace V.Tabs.Core.ViewModels
{
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Define the DetailFullScreenViewModel type.
    /// </summary>
    public class DetailFullScreenViewModel : MvxViewModel
    {
        /// <summary>
        /// Backing field for my property.
        /// </summary>
        private String _myProperty = "Full Screen View";
        private readonly IMvxNavigationService _navigationService;

        /// <summary>
        /// Gets or sets my property.
        /// </summary>
        public String MyProperty
        {
            get => _myProperty;
            set => SetProperty(ref _myProperty, value);
        }

        public ICommand CloseCommand => new MvxCommand(() => _navigationService.Close(this));

        public DetailFullScreenViewModel(IMvxNavigationService navigationService) => _navigationService = navigationService;
    }
}

