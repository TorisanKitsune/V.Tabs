// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the Setup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using MvvmCross.Binding;
using MvvmCross.Core.ViewModels;
using MvvmCross.Wpf.Platform;
using MvvmCross.Wpf.Views;
using MvvmCross.Wpf.Views.Presenters;
using System.Windows.Threading;

namespace V.Tabs.Wpf
{
    /// <summary>
    ///  Defines the Setup type.
    /// </summary>
    public class Setup : MvxWpfSetup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Setup"/> class.
        /// </summary>
        /// <param name="dispatcher">The dispatcher.</param>
        /// <param name="presenter">The presenter.</param>
        public Setup(Dispatcher dispatcher, IMvxWpfViewPresenter presenter)
            : base(dispatcher, presenter)
        {
        }

        /// <summary>
        /// Creates the app.
        /// </summary>
        /// <returns>An instance of MvxApplication</returns>
        protected override IMvxApplication CreateApp() => new Core.App();


        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            MvxBindingBuilder builder = new MvxBindingBuilder();
            builder.DoRegistration();
        }
    }
}
