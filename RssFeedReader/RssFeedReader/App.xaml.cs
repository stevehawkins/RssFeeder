using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RssFeedReader.Services;
using RssFeedReader.Views;
using GalaSoft.MvvmLight.Ioc;
using RssFeedReader.Repos;
using RssFeedReader.Interfaces;
using RssFeedReader.ViewModels;

namespace RssFeedReader
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            InitContainer();
            MainPage = new AppShell();
            Shell.Current.GoToAsync("//RssFeeds");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void InitContainer()
        {
            // repos & services
            SimpleIoc.Default.Reset();

            // create repo here that we can inject into viewmodels
            SimpleIoc.Default.Register<IRssRepo>(() => new RssRepo());
            SimpleIoc.Default.Register<IRssService>(() => new RssService());

            // reg view models
            SimpleIoc.Default.Register<RssDetailViewModel>();
            SimpleIoc.Default.Register<RssMainViewModel>();            
        }
    }
}
