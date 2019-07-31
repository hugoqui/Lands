namespace Lands.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using Xamarin.Forms;

    public class LoginViewModel: BaseViewModel
    {
        

        #region Atributes
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email { get; set; }

        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }

        public bool IsRunning {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }

        public bool IsRemembered { get; set; }

        public bool IsEnabled {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }

        #endregion

        #region Commands
        public ICommand LoginCommand {
            get {
                return new RelayCommand(Login);
            }
            
        }

        async private void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter an email", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter a password", "Ok");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            if (this.Email != "hugo2555@gmail.com" || this.Password != "123")
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "Email or password incorrect", "Ok");
                this.Password = string.Empty;
                return;
            }

            IsRunning = false;
            IsEnabled = true;
            // await Application.Current.MainPage.DisplayAlert("Correct", "Great!!", "Ok");

            var mainViewModel = MainViewModel.GetInstance();            
            mainViewModel.Lands = new LandsViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
            
        }

        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;

            Email = "hugo2555@gmail.com";
            Password = "123";

        }        
        #endregion
    }
}
