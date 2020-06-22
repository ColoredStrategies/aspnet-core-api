using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    [Route("notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            return new
            {
                status = true,
                data = items.Select(x => new
                {
                    id = x.id,
                    title = x.title,
                    img = x.img,
                    date = x.date.ToString("dd.MM.yyyy - HH:mm")
                })
            };
        }

        private static IList<Notification> items = new List<Notification>() {
            new Notification()
            {
                 id=1,
                 title="Joisse Kaycee just sent a new comment!",
                 img="/assets/img/profile-pic-l-2.jpg",
                 date=DateTime.Now.AddHours(-3)
            },
            new Notification()
            {
                 id=2,
                 title="1 item is out of stock!",
                 img="/assets/img/notification-thumb.jpg",
                 date=DateTime.Now.AddHours(-8)
            },
            new Notification()
            {
                 id=3,
                 title="New order received! It is total $147,20.",
                 img="/assets/img/notification-thumb-2.jpg",
                 date=DateTime.Now.AddHours(-13)
            },
            new Notification()
            {
                 id=4,
                 title="3 items just added to wish list by a user!",
                 img="/assets/img/notification-thumb-3.jpg",
                 date=DateTime.Now.AddHours(-23)
            },

        };
    }
}