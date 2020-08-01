using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using UIForms.Views;
using Xamarin.Forms;

namespace UIForms.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new RelayCommand(Login);

        public LoginViewModel()
        {
            this.Email = "hmillan@orionconsultores.com";
            this.Password = "1";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Email",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Password",
                    "Accept");
                return;
            }

            if (!this.Email.Equals("hmillan@orionconsultores.com") || !this.Password.Equals("1"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "User or Password wrong",
                    "Accept");
                return;
            }

            //await Application.Current.MainPage.DisplayAlert(
            //        "Ok",
            //        "You are Login!",
            //        "Accept");

            MainViewModel.GetInstance().Products = new ProductViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductPage());
        }
    }
}
