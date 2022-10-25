using System.Collections.Generic;

namespace FriendsTown.WebApi.Models
{
    public class FriendListPresentation
    {
        public IEnumerable<FriendPresentation> FriendList { get; set; }
    }
}
