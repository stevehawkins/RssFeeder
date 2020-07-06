using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RssFeedReader.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RssMainContent : ContentView
    {
        private bool HasAnimated = false;
        public RssMainContent()
        {
            InitializeComponent();
            if (!HasAnimated)
            {
                HasAnimated = true;

                Device.InvokeOnMainThreadAsync(async () =>
                {
                   await  Effectx();
                });

            }
        }

        private async Task Effectx()
        {
            var stk = this.FindByName<StackLayout>("Stacker");
            stk.Opacity = 0;

            await Task.WhenAny<bool>
            (
                stk.FadeTo(1, 1000),
                stk.ScaleTo(1, 1000)
            );
        }
    }
}