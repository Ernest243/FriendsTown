using FriendsTown.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendsTown.Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly FriendsTownContext _contexto;

        public NewsRepository(FriendsTownContext contexto) 
        {
            _contexto = contexto;
        }

        public void Add(News news) 
        {
            _contexto.Add(news);
            _contexto.SaveChanges();
        }

        public News FindById(Guid id) 
        {
            return _contexto.News.Find(id);
        }

        public IEnumerable<News> GetAll() 
        {
            return _contexto.News.OrderBy(a => a.Date.Value);
        }

        public void Update(News news) 
        {
            var newsToUpdate = _contexto.News.Find(news.Id);
            newsToUpdate.Update(news.Date, news.Place, news.Description);
            _contexto.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var newsToDelete = _contexto.News.Find(id);
            _contexto.News.Remove(newsToDelete);
            _contexto.SaveChanges();
        }
    }
}
