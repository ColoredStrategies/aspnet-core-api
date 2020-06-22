using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    [Route("contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // GET: Contacts
        [HttpGet]
        public object Get(string search = "")
        {
            var tempItems = items;
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                tempItems = items.Where(x => x.title.ToLower().Contains(search)
                ).ToList();
            }
            else
            {
                tempItems = items;
            }

            return new
            {
                status = true,
                data = tempItems.Select(x => new
                {
                    id = x.id,
                    title = x.title,
                    img = x.img,
                    date = x.date
                })
            };
        }

        private static IList<Contact> items = new List<Contact>()
        {
            //new Contact()
            //{
            //    id=1,
            //    title="Sarah Kortney",
            //    img="/assets/img/profile-pic-l.jpg",
            //    date="Last seen today 15:24"
            //},
            new Contact()
            {
                id=2,
                title="Linn Ronning",
                img="/assets/img/profile-pic-l-4.jpg",
                date="Last seen today 15:24"
            },
            new Contact()
            {
                id=3,
                title="Goldie Mossman",
                img="/assets/img/profile-pic-l-3.jpg",
                date="Last seen today 13:24"
            },
            new Contact()
            {
                id=4,
                title="Laree Munsch",
                img="/assets/img/profile-pic-l-2.jpg",
                date="Last seen today 17:42"
            },
            new Contact()
            {
                id=5,
                title="Brynn Bragg",
                img="/assets/img/profile-pic-l-5.jpg",
                date="Last seen today 18:00"
            },
            new Contact()
            {
                id=6,
                title="Merle Friberg",
                img="/assets/img/profile-pic-l-4.jpg",
                date="Last seen today 22:24"
            },
            new Contact()
            {
                id=7,
                title="Velva Valdovinos",
                img="/assets/img/profile-pic-l-4.jpg",
                date="Last seen today 00:24"
            },
            new Contact()
            {
                id=8,
                title="Dusti Gioia",
                img="/assets/img/profile-pic-l-5.jpg",
                date="Last seen yesterday 10:50"
            },
            new Contact()
            {
                id=9,
                title="Philip Nelms",
                img="/assets/img/profile-pic-l-7.jpg",
                date="Last seen yesterday 06:47"
            },
            new Contact()
            {
                id=10,
                title="Marty Otte",
                img="/assets/img/profile-pic-l-8.jpg",
                date="Last seen yesterday 20:07"
            },
            new Contact()
            {
                id=11,
                title="Janene Thies",
                img="/assets/img/profile-pic-l-9.jpg",
                date="Last seen yesterday 14:14"
            },
            new Contact()
            {
                id=12,
                title="Bao Hathaway",
                img="/assets/img/profile-pic-l-10.jpg",
                date="Last seen yesterday 15:20"
            },
            new Contact()
            {
                id=13,
                title="Ramiro Roark",
                img="/assets/img/profile-pic-l-11.jpg",
                date="0"
            }
        };
    }
}