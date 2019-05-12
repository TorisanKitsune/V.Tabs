using MvvmCross.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;
using V.Tabs.Wpf.Views;
using MvvmCross.Wpf.Views.Presenters;
using MvvmCross.Wpf.Views.Presenters.Attributes;
using MvvmCross.Platform.Logging;

namespace V.Tabs.Wpf.Utilities
{
    public class TabPresenter : MvxWpfViewPresenter
    {
        private IMvxLog _log;
        private readonly ContentControl _mainWindow;
        private readonly Stack<FrameworkElement> _navigationStack = new Stack<FrameworkElement>();
        private HomeView _homeView;

        public TabPresenter(ContentControl mainWindow)
        {
            _mainWindow = mainWindow;

        }

        public override void Show(MvxViewModelRequest request)
        {
            try
            {
                IMvxWpfViewLoader loader = Mvx.Resolve<IMvxWpfViewLoader>();
                FrameworkElement view = loader.CreateView(request);
                ShowContentView(view, null, null);
            }
            catch (Exception exception)
            {
                if (_log == null)
                {
                    IMvxLogProvider provider = Mvx.Resolve<IMvxLogProvider>();
                    _log = provider.GetLogFor<TabPresenter>();
                }
                _log.ErrorException("Error seen during navigation request to {0} - error {1}", 
                    exception, request.ViewModelType.Name,exception.ToLongString());
            }
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            if (hint is MvxClosePresentationHint)
            {
                //ensure we have at least 2 items on the stack
                //this will be the base view that shows the sliding menu and another view
                //that was selected on the base sliding view
                //ensure we do not pop the base sliding view
                if (_navigationStack.Count >= 2)
                {
                    _navigationStack.Pop();
                    if (1 == _navigationStack.Count)
                    {
                        //we have navigated down to the last screen, this is a base
                        //view that shows the tab menu, show it                       
                        _homeView.ContentGrid.Children.Clear();
                        _homeView.ContentGrid.Children.Add(_navigationStack.Peek());
                        _mainWindow.Content = _homeView;
                    }                   
                }
                return;
            }
            base.ChangePresentation(hint);
        }

        protected override void ShowContentView(FrameworkElement frameworkElement, MvxContentPresentationAttribute presentationAttribute, MvxViewModelRequest request) 
        //public override void ShowContentView(FrameworkElement frameworkElement)
        {
            //grab the attribute off of the view
            Region regionName = !(frameworkElement
                                .GetType()
                                .GetCustomAttributes(typeof(RegionAttribute), true)
                                .FirstOrDefault() is RegionAttribute attribute) ? Region.Unknown : attribute.Region;

            //based on region decide where we are going to show it
            switch (regionName)
            {               
                case Region.BaseTab:
                    //set the base tab
                    _mainWindow.Content = frameworkElement;
                    _homeView = (HomeView)frameworkElement;
                    break;
                case Region.Tab:                                       
                    if (_navigationStack.Any())
                    {
                        _navigationStack.Pop();
                    }

                    _homeView.ContentGrid.Children.Clear();
                    _homeView.ContentGrid.Children.Add(frameworkElement);
                    _navigationStack.Push(frameworkElement);

                    break;
                case Region.FullScreen:
                    //view that requires full screen
                    //but can navigate backwards
                    _mainWindow.Content = frameworkElement;
                    _navigationStack.Push(frameworkElement);
                    break;
            }

        }
    }
}
