using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTown.WebApi.Models
{
    public class NewsPresentation
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public PlacePresentation Place { get; set; }
        public string Description { get; set; }
    }
}
