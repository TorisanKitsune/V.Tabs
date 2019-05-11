// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the App type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using V.Tabs.Wpf.Utilities;

namespace V.Tabs.Wpf
{
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Platform;
    using MvvmCross.Wpf.Views;
    using System;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Setup complete indicator.
        /// </summary>
        private Boolean setupComplete;

        /// <summary>
        /// Does the setup.
        /// </summary>
        private void DoSetup()
        {
            TabPresenter presenter = new TabPresenter(MainWindow);

            Setup setup = new Setup(Dispatcher, presenter);
            setup.Initialize();

            IMvxAppStart start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            setupComplete = true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Activated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnActivated(EventArgs e)
        {
            if (!setupComplete)
            {
                DoSetup();
            }

            base.OnActivated(e);
        }
    }
}
