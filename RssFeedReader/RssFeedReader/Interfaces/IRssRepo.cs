using RssFeedReader.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RssFeedReader.Interfaces
{
    public interface IRssRepo
    {
        List<RssFeedParent> GetAvailableRssFeeds();

    }
}
