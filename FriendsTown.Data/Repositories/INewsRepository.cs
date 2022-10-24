using FriendsTown.Domain;
using System;
using System.Collections.Generic;

namespace FriendsTown.Data
{
    public interface INewsRepository
    {
        IEnumerable<News> GetAll();
        News FindById(Guid id);
        void Add(News news);
    }
}
