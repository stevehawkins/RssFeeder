using Microsoft.Toolkit.Parsers.Rss;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Interfaces
{
    public interface IRssService
    {
        Task<IEnumerable<RssSchema>> ParseFeedAsync(string url);
    }
}
