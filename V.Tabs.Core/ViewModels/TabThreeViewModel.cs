// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the TabThreeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using MvvmCross.Core.ViewModels;
using System;
using System.Windows.Input;

namespace V.Tabs.Core.ViewModels
{ 

    /// <summary>
    /// Define the TabThreeViewModel type.
    /// </summary>
    public class TabThreeViewModel : MvxViewModel
    {
        /// <summary>
        /// Backing field for my property.
        /// </summary>
        private String myProperty = "Tab Three";


        /// <summary>
        /// Gets or sets my property.
        /// </summary>
        public String MyProperty
        {
            get => myProperty;
            set => SetProperty(ref myProperty, value);
        }

    }
}

