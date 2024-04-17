using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static NewsApp.Service.Sevice;

namespace NewsApp.Service
{
    public class TimerService
    {
        
            private readonly INewsService _newsService;
            private Timer _timer;

            public TimerService(INewsService newsService)
            {
                _newsService = newsService;
                _timer = new Timer(UpdateCache, null, TimeSpan.Zero, TimeSpan.FromMinutes(30)); // 30 dakikada bir güncelle
            }

            private void UpdateCache(object state)
            {
                _newsService.GetAllNews(); // Bu, haberleri cache'e alacak
            }
        

    }
}
