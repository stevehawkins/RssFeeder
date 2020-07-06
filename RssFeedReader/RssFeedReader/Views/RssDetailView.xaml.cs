using RssFeedReader.Models;
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
    [QueryProperty("Article", "Article")]
    public partial class RssDetailView : ContentPage
    {

        public string Article
        {
            set
            {
                var converted = Uri.UnescapeDataString(value);
                var art = Helpers.JsonHelper.DeserialiseObject<RssArticle>(converted);
                var vm = (RssDetailViewModel)GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance(typeof(RssDetailViewModel));
                vm.Article = art;
                this.BindingContext = vm;
            }
        }

        public RssDetailView()
        {
            InitializeComponent();
        }
    }
}