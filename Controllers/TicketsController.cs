using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    [Route("tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
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

        private static IList<Ticket> items = new List<Ticket>() {
            new Ticket()
            {
                 id=1,
                 title="Mayra Sibley",
                 img="/assets/img/profile-pic-l.jpg",
                 date=DateTime.Now.AddHours(-3)
            },
            new Ticket()
            {
                 id=2,
                 title="Mimi Carreira",
                 img="/assets/img/profile-pic-l-2.jpg",
                 date=DateTime.Now.AddHours(-8)
            },
            new Ticket()
            {
                 id=3,
                 title="Philip Nelms",
                 img="/assets/img/profile-pic-l-3.jpg",
                 date=DateTime.Now.AddHours(-13)
            },
            new Ticket()
            {
                 id=4,
                 title="Terese Threadgill",
                 img="/assets/img/profile-pic-l-4.jpg",
                 date=DateTime.Now.AddHours(-23)
            },
             new Ticket()
            {
                 id=5,
                 title="Kathryn Mengel",
                 img="/assets/img/profile-pic-l-5.jpg",
                 date=DateTime.Now.AddHours(-29)
            },
              new Ticket()
            {
                 id=6,
                 title="Esperanza Lodge",
                 img="/assets/img/profile-pic-l-2.jpg",
                 date=DateTime.Now.AddHours(-38)
            },
               new Ticket()
            {
                 id=7,
                 title="Laree Munsch",
                 img="/assets/img/profile-pic-l.jpg",
                 date=DateTime.Now.AddHours(-49)
            },

        };
    }
}