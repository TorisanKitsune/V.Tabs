// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the App type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using V.Tabs.Core.ViewModels;

namespace V.Tabs.Core
{
    /// <summary>
    /// Define the App type.
    /// </summary>
    public class App : MvxApplication
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //// Start the app with the Main View Model.
            RegisterAppStart<HomeViewModel>();
        }
    }
}