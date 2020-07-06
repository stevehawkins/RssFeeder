using Microsoft.Toolkit.Parsers.Rss;
using RssFeedReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Services
{
    public class RssService: IRssService
    {
        public RssService()
        {

        }
        public async Task<IEnumerable<RssSchema>> ParseFeedAsync(string url)
        {
            string feed = null;
            using (var client = new HttpClient())
            {
                feed = await client.GetStringAsync(url);
            }
      
            if (feed == null) return new List<RssSchema>();
            var parser = new RssParser();
            var rss = parser.Parse(feed);
            return rss;
        }

    }
}
