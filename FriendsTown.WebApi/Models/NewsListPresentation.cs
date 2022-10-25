using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTown.WebApi.Models
{
    public class NewsListPresentation
    {
        public IEnumerable<NewsPresentation> NewsList { get; set; }
    }
}
