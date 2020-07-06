using RssFeedReader.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RssFeedReader
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //RegExtraRoutes();
        }

        private void RegExtraRoutes()
        {
            Routing.RegisterRoute(nameof(RssDetailView), typeof(RssDetailView));
        }
    }
}
