﻿// The MIT License (MIT)
//
// Copyright (c) 2015 Xamarin
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;
using XamarinCRM.Localization;
using XamarinCRM.Pages;
<<<<<<< HEAD
using XamarinCRM.Services;
using XamarinCRM.Statics;
=======
using System.Threading.Tasks;
using Plugin.Connectivity;
using XamarinCRM.Pages.Home;
>>>>>>> parent of da9b2cd... Creato list registries

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamarinCRM
{
    public partial class App : Application
    {
        static Application app;
        public static Application CurrentApp
        {
            get { return app; }
        }

        readonly IAuthenticationService _AuthenticationService;
        public App()
        {
            InitializeComponent();

            app = this;
            _AuthenticationService = DependencyService.Get<IAuthenticationService>();

            /* if we were targeting Windows Phone, we'd want to include the next line. */
            // if (Device.OS != TargetPlatform.WinPhone) 
            TextResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();


            // If the App.IsAuthenticated property is false, modally present the SplashPage.
            if (!_AuthenticationService.IsAuthenticated)
            {
                //MainPage = new SplashPage();
                MainPage = new MyRegistriesRootPage();
            }
            else
            {
                GoToRoot();
            }

        }

        public static void GoToRoot()
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                CurrentApp.MainPage = new RootTabPage();
            }
            else
            {
                CurrentApp.MainPage = new MyRootPage();
            }
        }

        public static void GoToRegistriesRoot()
        {
            CurrentApp.MainPage = new MyRegistriesRootPage();
        }

        public static async Task ExecuteIfConnected(Func<Task> actionToExecuteIfConnected)
        {
            if (IsConnected)
            {
                await actionToExecuteIfConnected();
            }
            else
            {
                await ShowNetworkConnectionAlert();
            }
        }

        static async Task ShowNetworkConnectionAlert()
        {
            await CurrentApp.MainPage.DisplayAlert(
                TextResources.NetworkConnection_Alert_Title, 
                TextResources.NetworkConnection_Alert_Message, 
                TextResources.NetworkConnection_Alert_Confirm);
        }

        public static bool IsConnected
        {
            get { return CrossConnectivity.Current.IsConnected; }
        }

        public static int AnimationSpeed = 250;
    }
}

