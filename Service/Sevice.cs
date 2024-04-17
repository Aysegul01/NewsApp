using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Service
{
    public class Sevice
    {
        public interface INewsService
        {
            List<NewsModel> GetAllNews();
        }

        public class NewsService : INewsService
        {
            private List<NewsModel> _cachedNews = new List<NewsModel>();

            public List<NewsModel> GetAllNews()
            {
                if (_cachedNews.Any())
                {
                    return _cachedNews;
                }
                else
                {
                    // Veritabanından haberleri al
                    List<NewsModel> newsFromDatabase = GetNewsFromDatabase();

                    // Cache'e al
                    _cachedNews = newsFromDatabase;

                    return newsFromDatabase;
                }
            }

            private List<NewsModel> GetNewsFromDatabase()
            {
                // Veritabanından haberleri almak için gerekli kod
                // Örnek olarak:
                // using (var context = new NewsDbContext())
                // {
                //     return context.News.ToList();
                // }

                // Bu örnekte doğrudan listeyi döndürelim:
                return new List<NewsModel>();
            }
        }

    }
}
