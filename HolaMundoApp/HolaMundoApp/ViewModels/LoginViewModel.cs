﻿using HolaMundoApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        private string _username;
        private string _password;
        private bool _ShowMessage;
        private string _WelcomeMessage;
        private Color _ColorMessage;

        public string UserName { get => _username; set => SetProperty(ref _username, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public bool ShowMessage { get => _ShowMessage; set => SetProperty(ref _ShowMessage, value); }
        public string WelcomeMessage { get => _WelcomeMessage; set => SetProperty(ref _WelcomeMessage, value); }
        public Color ColorMessage { get => _ColorMessage; set => SetProperty(ref _ColorMessage, value); }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if (ValidateFields())
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                ShowMessage = false;
                UserName = string.Empty;
                Password = string.Empty;
            }
            else{
                ShowMessage = true;
                ColorMessage = Color.Red;
                WelcomeMessage = "Usuario o Contraseña incorrectos";
            }
        }
        private bool ValidateFields()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }

       
    }
}
