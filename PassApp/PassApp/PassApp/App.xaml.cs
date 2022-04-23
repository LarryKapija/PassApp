using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Prism;
using Prism.Ioc;
using Prism.Unity;
using PassApp.Pages;
using PassApp.ViewModels;
using PassApp.Services.Interfaces;
using PassApp.Services.Implementation;
using PassApp.Utils;

namespace PassApp
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
        {

        }

        protected override async void OnInitialized()
        {
            await   NavigationService.NavigateAsync($"{Constants.Pages.navigationPage}/{Constants.Pages.passwordsPage}/");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService>();
            containerRegistry.Register<ICacheService, MonkeyCacheService>();
            containerRegistry.Register<ICloudDBService, RealTimeDBService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<PasswordsPage, PasswordsViewModel>();
            containerRegistry.RegisterForNavigation<AddPasswordPage, AddPasswordViewModel>();
        }
    }
}

