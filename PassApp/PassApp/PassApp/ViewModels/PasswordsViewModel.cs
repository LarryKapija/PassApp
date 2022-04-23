using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PassApp.Models;
using PassApp.Utils;
using Prism.Navigation;
using Prism.Commands;
using PassApp.Services.Interfaces;
using Xamarin.Essentials;

namespace PassApp.ViewModels
{
    public class PasswordsViewModel : BaseViewModel
    {
        public ObservableCollection<Password> PasswordList
        {
            get;
            private set;
        }

        private readonly ICloudDBService cloudDBService;

        public DelegateCommand GoToAddPasswordPageCommmand { get; set; }
        public DelegateCommand<Password> CopyPasswordCommand { get; set; }

        public PasswordsViewModel(INavigationService navigationService, ICloudDBService cloudDBService) : base(navigationService)
		{
            PasswordList = new ObservableCollection<Password>();

            this.cloudDBService = cloudDBService;

            cloudDBService.GetPasswords().Subscribe(dbEvent =>
            {
                if (dbEvent.Object != null)
                {
                    PasswordList.Add(dbEvent.Object);
                }
            });

            GoToAddPasswordPageCommmand = new DelegateCommand(async () => await GoToAddPasswordPage());
            CopyPasswordCommand = new DelegateCommand<Password>(async (pass) => await CopyPassword(pass));

        }

        private async Task CopyPassword(Password password)
        {
            await Clipboard.SetTextAsync(password.Pass);
        }

        private async Task GoToAddPasswordPage()
        {
            await navigationService.NavigateAsync(Constants.Pages.addPassPage);
        }

    }
}

