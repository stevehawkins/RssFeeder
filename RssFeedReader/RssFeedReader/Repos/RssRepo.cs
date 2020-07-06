using RssFeedReader.Interfaces;
using RssFeedReader.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RssFeedReader.Repos
{
    public class RssRepo : IRssRepo
    {
        public List<RssFeedParent> GetAvailableRssFeeds()
        {
            // demo so no db just static data
            var retList = new List<RssFeedParent>
            {
                new RssFeedParent{RssFeedUrl="https://feeds.bbci.co.uk/news/uk/rss.xml",RssTitle="BBC News" },
                new RssFeedParent{RssFeedUrl="https://feeds.bbci.co.uk/news/technology/rss.xml",RssTitle="BBC Tech News" },
                new RssFeedParent{RssFeedUrl="https://www.theguardian.com/uk/rss",RssTitle="The Guardian News" },
                new RssFeedParent{RssFeedUrl="http://feeds.feedburner.com/venturebeat/SZYF",RssTitle="Venture beat Tech News" }
            };

            return retList;
        }
    }
}
