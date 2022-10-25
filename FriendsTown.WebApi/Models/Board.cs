using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTown.WebApi.Models
{
    public class Board
    {
        public string NewsDate { get; set; }
        public int RemainingDays { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
    }
}
