// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the TabTwoViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using MvvmCross.Core.ViewModels;
using System;
using System.Windows.Input;

namespace V.Tabs.Core.ViewModels
{ 

    /// <summary>
    /// Define the TabTwoViewModel type.
    /// </summary>
    public class TabTwoViewModel : MvxViewModel
    {
        /// <summary>
        /// Backing field for my property.
        /// </summary>
        private String _myProperty = "Tab Two";

        /// <summary>
        /// Gets or sets my property.
        /// </summary>
        public String MyProperty
        {
            get => _myProperty;
            set => SetProperty(ref _myProperty, value);
        }
    }
}

