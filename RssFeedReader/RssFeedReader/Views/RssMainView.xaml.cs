using RssFeedReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RssFeedReader.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RssMainView : ContentPage
    {
        public RssMainView()
        {
            var vm = (RssMainViewModel)GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance(typeof(RssMainViewModel));
            this.InitializeComponent();
            this.BindingContext = vm;

            MessagingCenter.Subscribe<RssMainViewModel>(this, "FocusPicker", (sender) => DisplayPicker());
        }

        private void DisplayPicker()
        {
            var pick = this.FindByName<Picker>("PickerSource");
            pick.Focus();

        }
    }
}