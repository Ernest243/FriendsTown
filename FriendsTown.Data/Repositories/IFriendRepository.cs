using FriendsTown.Domain;
using System;
using System.Collections.Generic;

namespace FriendsTown.Data
{
    public interface IFriendRepository
    {
        IEnumerable<Friend> GetAll();
        Friend FindById(Guid id);
        void Add(Friend actividad);
    }
}
