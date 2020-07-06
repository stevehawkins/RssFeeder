using RssFeedReader.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RssFeedReader.ViewModels
{
    public class RssDetailViewModel:BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public RssDetailViewModel()
        {
            CloseCommand = new Command(CloseCommandHandler);
        }

        private async void CloseCommandHandler(object obj)
        {
            await Shell.Current.GoToAsync("//RssFeeds");
        }

        private RssArticle _Article;

        public RssArticle Article
        {
            get
            {
                return _Article;
            }

            set {
                _Article = value;
                OnPropertyChanged();
            }
        }

    }
}
