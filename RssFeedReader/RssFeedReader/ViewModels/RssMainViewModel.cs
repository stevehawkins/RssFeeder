using Microsoft.Toolkit.Parsers.Rss;
using RssFeedReader.Interfaces;
using RssFeedReader.Models;
using RssFeedReader.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RssFeedReader.ViewModels
{
    public class RssMainViewModel:BaseViewModel
    {

        private IRssService serv;
        public ICommand SelectSourceCommand { get; set; }
        public RssMainViewModel(IRssRepo _repo, IRssService _serv)
        {
            serv = _serv;
            MyFeeds = new ObservableCollection<RssFeedParent>(_repo.GetAvailableRssFeeds());

            SelectSourceCommand = new Command(SelectSourceCommandHandler);

            // load first feed in back ground
            Selectedfeed = MyFeeds[0];
            
        }

        private void SelectSourceCommandHandler(object obj)
        {
            MessagingCenter.Send<RssMainViewModel>(this, "FocusPicker");
        }

        private RssFeedParent _Selectedfeed;

        public RssFeedParent Selectedfeed
        {
            get { return _Selectedfeed; }
            set { 
                if(value==null)
                        return;

                _Selectedfeed = value;
                OnPropertyChanged();

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await LoadFeed(value.RssFeedUrl);
                });
            }
        }

       

        private ObservableCollection<RssFeedParent> _MyFeeds;

        public ObservableCollection<RssFeedParent> MyFeeds
        {
            get { return _MyFeeds; }
            set { _MyFeeds = value;
                OnPropertyChanged();
            }
        }

        private RssSchema _SelectedArticle;

        public RssSchema SelectedArticle
        {
            get { return _SelectedArticle;; }
            set {
                if (value == null)
                    return;

                // send via shell
                var artcl = new RssArticle
                {
                    Title = value?.Title,
                    Url = value.FeedUrl
                };

                string parm = Helpers.JsonHelper.SerialiseObject<RssArticle>(artcl);
                Shell.Current.GoToAsync($"//ArticleDetail?Article={parm}");

                _SelectedArticle = null;

            }
        }


        private ObservableCollection<RssSchema> _SchemaItemList;

        public ObservableCollection<RssSchema> SchemaItemList
        {
            get
            {
                return _SchemaItemList;
            }
            set
            {
                if (value == null)
                    return; 

                _SchemaItemList = new ObservableCollection<RssSchema>(value.OrderBy(x => x.PublishDate));

                OnPropertyChanged();
            }
        }


        // should really be true async
        public async Task LoadFeed(string url)
        {
            IsBusy = true; 
            var feed = await serv.ParseFeedAsync(url);
            SchemaItemList = new ObservableCollection<RssSchema>(feed);
            IsBusy = false;
        }

    }
}
