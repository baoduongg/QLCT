using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismTemplet.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismTemplet
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null): base(initializer)
        {
            MainPage = new HomeTabbedPage();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HomeTabbedPage>();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
        }
    }
}
