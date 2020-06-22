using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    [Route("profilestatuses")]
    [ApiController]
    public class ProfileStatusesController : ControllerBase
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
                    total = x.total,
                    status = x.status
                })
            };
        }

        private static IList<ProfileStatus> items = new List<ProfileStatus>()
        {
            new ProfileStatus()
            {
                id=1,
                title="Basic Information",
                total=18,
                status=12,
            },
            new ProfileStatus()
            {
                id=2,
                title="Portfolio",
                total=8,
                status=1,
            },
            new ProfileStatus()
            {
                id=3,
                title="Billing Details",
                total=6,
                status=2,
            },
            new ProfileStatus()
            {
                id=4,
                title="Interests",
                total=10,
                status=0,
            },
            new ProfileStatus()
            {
                id=5,
                title="Legal Documents",
                total=2,
                status=1,
            }
        };
    }
}