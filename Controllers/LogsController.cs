using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    [Route("logs")]
    [ApiController]
    public class LogsController : ControllerBase
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
                    color = x.color,
                    date = x.date
                })
            };
        }

        private static IList<Log> items = new List<Log>() {
            new Log()
            {
                id=1,
                title="New user registiration",
                date="14:12",
                color="border-theme-1"
            },
            new Log()
            {
                id=2,
                title="New sale: Soufflé",
                date="13:20",
                color="border-theme-2"
            },
            new Log()
            {
                id=3,
                title="14 products added",
                date="12:55",
                color="border-danger"
            },
            new Log()
            {
                id=4,
                title="New sale: Napoleonshat",
                date="12:44",
                color="border-theme-2"
            },
            new Log()
            {
                id=5,
                title="New sale: Cremeschnitte",
                date="12:30",
                color="border-theme-2"
            },
            new Log()
            {
                id=6,
                title="New sale: Soufflé",
                date="12:00",
                color="border-theme-2"
            },
            new Log()
            {
                id=7,
                title="2 categories added",
                date="10:20",
                color="border-danger"
            },
            new Log()
            {
                id=8,
                title="New sale: Chocolate Cake",
                date="09:28",
                color="border-theme-2"
            },
            new Log()
            {
                id=9,
                title="New sale: Magdalena",
                date="09:25",
                color="border-theme-2"
            },
            new Log()
            {
                id=10,
                title="New sale: Fat Rascal",
                date="09:20",
                color="border-theme-2"
            },
            new Log()
            {
                id=11,
                title="New sale: Parkin",
                date="09:10",
                color="border-theme-1"
            }
        };
    }
}