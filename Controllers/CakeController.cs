using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_api.Controllers
{
    [Route("cakes")]
    [ApiController]
    public class CakesController : ControllerBase
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
                    category = x.category,
                    status = x.status,
                    statusColor = x.statusColor,
                    description = x.description,
                    sales = x.sales,
                    stock = x.stock,
                    date = x.date.ToString("dd.MM.yyy")
                })
            };
        }

        [HttpGet("paging")]
        public object Paging(string pageSize="10", string currentPage="1", string orderBy="title", string search="")
        {
            Func<Cake, Object> orderColumn = item => item.title;
            IList<Cake> tempItems = new List<Cake>();
            switch (orderBy)
            {
                case "category":
                    orderColumn = item => item.category;
                    break;
                case "status":
                    orderColumn = item => item.status;
                    break;
                default:
                    break;
            }
            int opageSize = 10;
            int.TryParse(pageSize, out opageSize);

            int ocurrentPage = 1;

            int.TryParse(currentPage, out ocurrentPage);


            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                tempItems = items.Where(x => x.title.ToLower().Contains(search) ||
                x.category.ToLower().Contains(search) ||
                x.description.ToLower().Contains(search) ||
                x.status.ToLower().Contains(search)
                ).ToList();
            }
            else
            {
                tempItems = items;
            }
            var totalItem = tempItems.Count;
            var diffrence = totalItem % opageSize;
            int totalPage = (totalItem - diffrence) / opageSize;
            totalPage = diffrence > 0 ? totalPage + 1 : totalPage;
            ocurrentPage = ocurrentPage <= 0 ? 1 : ocurrentPage;
            if (ocurrentPage > totalPage)
            {
                return new
                {
                    status = false,
                    message = currentPage + " cannot be greater than " + totalPage,
                    totalItem = totalItem,
                    totalPage = totalPage,
                    pageSize = opageSize,
                    currentPage = currentPage,
                    data = new object[0]
                };
            }

            return new
            {
                status = true,
                totalItem = totalItem,
                totalPage = totalPage,
                pageSize = pageSize,
                currentPage = currentPage,
                data = tempItems.OrderBy(orderColumn).Skip(opageSize * (ocurrentPage - 1)).Take(opageSize).Select(x => new
                {
                    id = x.id,
                    title = x.title,
                    img = x.img,
                    category = x.category,
                    status = x.status,
                    statusColor = x.statusColor,
                    description = x.description,
                    sales = x.sales,
                    stock = x.stock,
                    date = x.date.ToString("dd.MM.yyy")
                })
            };
        }


        [HttpGet("fordatatable")]
        public object ForDataTable(string sort = "", string page = "1", string per_page = "5", string search = "")
        {
            int opageSize = 10;
            int.TryParse(per_page, out opageSize);
            int ocurrentPage = 1;
            int.TryParse(page, out ocurrentPage);

            IEnumerable<Cake> cakes = new List<Cake>();
            if (!string.IsNullOrEmpty(search) && search.Length >= 2)
            {
                cakes = items.Where(x => x.title.ToLower().Contains(search) || x.category.ToLower().Contains(search) || x.status.ToLower().Contains(search));
            }
            else
            {
                cakes = items;
            }
            Func<Cake, Object> orderColumn = item => item.title;
            bool isSorted = true;
            bool isAsc = true;
            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.IndexOf("desc") > -1)
                {
                    isAsc = false;
                }
                if (sort.IndexOf("category") > -1)
                {
                    orderColumn = item => item.category;
                }
                else if (sort.IndexOf("status") > -1)
                {
                    orderColumn = item => item.status;
                }
                else if (sort.IndexOf("sales") > -1)
                {
                    orderColumn = item => item.sales;
                }
                else if (sort.IndexOf("stock") > -1)
                {
                    orderColumn = item => item.stock;
                }
                else if (sort.IndexOf("title") > -1)
                {
                    orderColumn = item => item.title;
                }
                else
                {
                    isSorted = false;
                }
            }
            else
            {
                isSorted = false;
            }

            var totalItem = cakes.Count();
            var from = opageSize * (ocurrentPage - 1);
            var diffrence = totalItem % opageSize;
            int totalPage = (totalItem - diffrence) / opageSize;
            totalPage = diffrence > 0 ? totalPage + 1 : totalPage;
            ocurrentPage = ocurrentPage <= 0 ? 1 : ocurrentPage;

            if (isSorted)
            {
                if (isAsc)
                    cakes = cakes.OrderBy(orderColumn).Skip(from).Take(opageSize);
                else
                    cakes = cakes.OrderByDescending(orderColumn).Skip(from).Take(opageSize);
            }
            else
                cakes = cakes.Skip(from).Take(opageSize);


            string prev_page_url = null;
            string next_page_url = null;
            var apiUrl = "https://api.coloredstrategies.com/cakes/fordatatable";

            if (ocurrentPage > 1)
            {
                prev_page_url = apiUrl + "?sort=" + sort + "&page=" + (ocurrentPage - 1) + "&per_page=" + per_page;
            }
            if (ocurrentPage < totalPage)
            {
                next_page_url = apiUrl + "?sort=" + sort + "&page=" + (ocurrentPage + 1) + "&per_page=" + per_page;
            }

            if (ocurrentPage > totalPage)
            {
                return new
                {
                    status = false,
                    message = page + " cannot be greater than " + totalPage,
                    totalItem = totalItem,
                    totalPage = totalPage,
                    pageSize = opageSize,
                    currentPage = page,
                    data = new object[0]
                };
            }


            return new
            {
                status = true,
                total = totalItem,
                last_page = totalPage,
                per_page = opageSize,
                current_page = ocurrentPage,
                next_page_url = next_page_url,
                prev_page_url = next_page_url,
                from = from + 1,
                to = (from + opageSize) <= totalItem ? from + opageSize : totalItem,
                data = cakes.Select(x => new
                {
                    id = x.id,
                    title = x.title,
                    img = x.img,
                    category = x.category,
                    status = x.status,
                    statusColor = x.statusColor,
                    description = x.description,
                    sales = x.sales,
                    stock = x.stock,
                    date = x.date.ToString("dd.MM.yyy")
                })
            };


        }
        private static IList<Cake> items = new List<Cake>() {
           new Cake()
           {
            id=1,
            title ="Marble Cake",
            img="/assets/img/marble-cake-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddHours(-42),
            status="ON HOLD",
            statusColor="primary",
            description ="Wedding cake with flowers Macarons and blueberries",
            sales=1647,
            stock=62
           },
           new Cake()
           {
            id=2,
            title ="Fat Rascal",
            img="/assets/img/fat-rascal-thumb.jpg",
            category="Cupcakes",
            date= DateTime.Now.AddHours(-68),
            status="PROCESSED",
            statusColor="secondary",
            description ="Cheesecake with chocolate cookies and Cream biscuits",
            sales=1240,
            stock=48
           },
           new Cake()
           {
            id=3,
            title ="Chocolate Cake",
            img="/assets/img/chocolate-cake-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddHours(-142),
            status="PROCESSED",
            statusColor="secondary",
            description ="Homemade cheesecake with fresh berries and mint",
            sales=1080,
            stock=57
           },
           new Cake(){
            id=4,
            title ="Goose Breast",
            img="/assets/img/goose-breast-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddHours(-123),
            status="PROCESSED",
            statusColor="secondary",
            description ="Chocolate cake with berries",
            sales=1014,
            stock=41
           },
           new Cake(){
            id=5,
            title ="Petit Gâteau",
            img="/assets/img/petit-gateau-thumb.jpg",
            category="Cupcakes",
            date= DateTime.Now.AddHours(-152),
            status="ON HOLD",
            statusColor="primary",
            description ="Chocolate cake with mascarpone",
            sales=985,
            stock=23
           },
           new Cake(){
            id=6,
            title ="Salzburger Nockerl",
            img="/assets/img/salzburger-nockerl-thumb.jpg",
            category="Desserts",
            date= DateTime.Now.AddHours(-11),
            status="PROCESSED",
            statusColor="secondary",
            description ="Wedding cake decorated with donuts and wild berries",
            sales=962,
            stock=34
           },
           new Cake(){
            id=7,
            title ="Napoleonshat",
            img="/assets/img/napoleonshat-thumb.jpg",
            category="Desserts",
            date= DateTime.Now.AddHours(-111),
            status="PROCESSED",
            statusColor="secondary",
            description ="Cheesecake with fresh berries and mint for dessert",
            sales=921,
            stock=31
           },
           new Cake(){
            id=8,
            title ="Cheesecake",
            img="/assets/img/cheesecake-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddHours(-53),
            status="ON HOLD",
            statusColor="primary",
            description ="Delicious vegan chocolate cake",
            sales=887,
            stock=21
           },
           new Cake(){
            id=9,
            title ="Financier",
            img="/assets/img/financier-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddHours(-235),
            status="ON HOLD",
            statusColor="primary",
            description ="White chocolate strawberry yogurt cake decorated with fresh fruits and chocolate",
            sales=865,
            stock=53
           },
           new Cake(){
            id=10,
            title ="Genoise",
            img="/assets/img/genoise-thumb.jpg",
            category="Cupcakes",
            date= DateTime.Now.AddHours(-356),
           status="PROCESSED",
            statusColor="secondary",
            description ="Christmas fruit cake, pudding on top",
            sales=824,
            stock=55
           },
           new Cake(){
            id=11,
            title ="Gingerbread",
            img="/assets/img/gingerbread-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddHours(-276),
            status="ON HOLD",
            statusColor="primary",
            description ="Wedding cake decorated with donuts and wild berries",
            sales=714,
            stock=12
           },
           new Cake(){
            id=12,
            title ="Magdalena",
            img="/assets/img/magdalena-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddHours(-200),
            status="PROCESSED",
            statusColor="secondary",
            description ="Christmas fruit cake, pudding on top",
            sales=702,
            stock=14
           },
           new Cake(){
            id=13,
            title ="Parkin",
            img="/assets/img/parkin-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddHours(-195),
            status="ON HOLD",
            statusColor="primary",
            description ="White chocolate strawberry yogurt cake decorated with fresh fruits and chocolate",
            sales=689,
            stock=78
           },
           new Cake()
           {
            id=14,
            title ="Streuselkuchen",
            img="/assets/img/streuselkuchen-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddHours(-211),
            status="PROCESSED",
            statusColor="secondary",
            description ="Delicious vegan chocolate cake",
            sales=645,
            stock=55
           },
           new Cake()
           {
            id=15,
            title ="Tea loaf",
            img="/assets/img/tea-loaf-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddDays(-18),
            status="ON HOLD",
            statusColor="primary",
            description ="Cheesecake with fresh berries and mint for dessert",
            sales=632,
            stock=20
           },
           new Cake()
           {
            id=16,
            title ="Merveilleux",
            img="/assets/img/merveilleux-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddHours(-269),
            status="ON HOLD",
            statusColor="primary",
            description ="Chocolate cake with mascarpone",
            sales=621,
            stock=23
           },
           new Cake()
           {
            id=17,
            title ="Fruitcake",
            img="/assets/img/fruitcake-thumb.jpg",
            category="Cakes",
            date= DateTime.Now.AddDays(-9),
            status="PROCESSED",
            statusColor="secondary",
            description ="Chocolate cake with berries",
            sales=585,
            stock=19
           },
           new Cake()
           {
            id=18,
            title ="Bebinca",
            img="/assets/img/bebinca-thumb.jpg",
            category="Desserts",
            date= DateTime.Now.AddDays(-7),
            status="PROCESSED",
            statusColor="secondary",
            description ="Homemade cheesecake with fresh berries and mint",
            sales=574,
            stock=16
           },
           new Cake()
           {
            id=19,
            title ="Cremeschnitte",
            img="/assets/img/cremeschnitte-thumb.jpg",
            category="Desserts",
            date= DateTime.Now.AddDays(-8),
            status="ON HOLD",
            statusColor="primary",
            description ="Cheesecake with chocolate cookies and Cream biscuits",
            sales=562,
            stock=18
           },
           new Cake()
           {
            id=20,
            title ="Soufflé",
            img="/assets/img/souffle-thumb.jpg",
            category="Cupcakes",
            date= DateTime.Now.AddDays(-12),
            status="ON HOLD",
            statusColor="primary",
            description ="Wedding cake with flowers Macarons and blueberries",
            sales=524,
            stock=14
           }
       };
    }
}