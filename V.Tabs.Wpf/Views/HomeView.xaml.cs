// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the HomeView.xaml type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using V.Tabs.Core.ViewModels;
using V.Tabs.Wpf.Utilities;

namespace V.Tabs.Wpf.Views
{
    /// <summary>
    ///    Defines the HomeView.xaml type.
    /// </summary>
    [Region(Region.BaseTab)]
    public partial class HomeView
    {

        private HomeViewModel viewModel;

        public new HomeViewModel ViewModel => viewModel ?? (viewModel = base.ViewModel as HomeViewModel);

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeView"/> class.
        /// </summary>
        public HomeView() 
        {
            InitializeComponent();
            Loaded += HomeViewLoaded;
        }

        private void HomeViewLoaded(Object sender, RoutedEventArgs e)
        {
            ViewModel.ShowTabOneCommand.Execute();
            Loaded -= HomeViewLoaded;
        }

    }
}

