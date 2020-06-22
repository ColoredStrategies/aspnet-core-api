using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    [Route("comments")]
    [ApiController]
    public class CommentsController : ControllerBase
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
                    detail = x.detail
                })
            };
        }

        private static IList<Comment> items = new List<Comment>()
        {
            new Comment()
            {
                id=1,
                title="Very informative content, thank you.",
                detail="Mayra Sibley | Tea Loaf with Fresh Oranges | 17.09.2018 - 04:45",
                img = "/assets/img/profile-pic-l.jpg"
            },
            new Comment()
            {
                id=2,
                title="This article was delightful to read. Please keep them coming.",
                detail="Barbera Castiglia | Cheesecake with Chocolate Cookies | 15.08.2018 - 01:18",
                img = "/assets/img/profile-pic-l-2.jpg"
            },
            new Comment()
            {
                id=3,
                title="Your post is bad and you should feel bad.",
                detail="Bao Hathaway | Homemade Cheesecake | 26.07.2018 - 11:14",
                img = "/assets/img/profile-pic-l-3.jpg"
            },
            new Comment()
            {
                id=4,
                title="Very original idea!",
                detail="Lenna Majeed | Tea Loaf with Fresh Oranges | 17.06.2018 - 09:20",
                img = "/assets/img/profile-pic-l-4.jpg"
            },
            new Comment()
            {
                id=5,
                title="This article was delightful to read. Please keep them coming.",
                detail="Esperanza Lodge | Cheesecake with Fresh Berries | 16.06.2018 - 16:45",
                img = "/assets/img/profile-pic-l-5.jpg"
            },
            new Comment()
            {
                id=6,
                title="Nah, did not like it.",
                detail="Lenna Majeed | Tea Loaf with Fresh Oranges | 16.06.2018 - 16:45 ",
                img = "/assets/img/profile-pic-l-2.jpg"
            },
            new Comment()
            {
                id=7,
                title="Laree Munsch",
                detail="Brynn Bragg | Wedding Cake with Flowers | 12.04.2018 - 12:45",
                img = "/assets/img/profile-pic-l.jpg"
            }
        };
    }
}