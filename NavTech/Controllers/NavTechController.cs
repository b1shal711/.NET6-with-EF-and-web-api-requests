using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace NavTech.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NavTechController : ControllerBase
    {
        private static List<navTech> order = new List<navTech>
        {
            new navTech
            {
                Id = 1,
                customer_name = "a",
                item_name = "b",
                order_amount = 1000
            }
            
        };
        private readonly DataContext dataContext;

        public NavTechController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
   
        [Authorize]
        [HttpGet("{customer_name}/{pageno}/{pagelim}")]
        public async Task<ActionResult<navTech>> getorder(string customer_name , int pageno , int pagelim)
        {
            
            List<navTech> temp = dataContext.orderdb.ToList<navTech>();
            List<navTech> a = new List<navTech>();
            for(int i = 0; i < temp.Count; i++)
            {
                if (temp[i].customer_name == customer_name)
                {
                    a.Add(temp[i]);
                }
            }
            if (a.Count < ((pageno * pagelim) - pagelim))
            {
                throw new NullReferenceException("The page is empty, Plz add more items to view them or change your page no. and page limit");
                return null;
            }
            List<navTech> b = new List<navTech>();
            for(int j = ((pageno * pagelim) - pagelim); j < pageno*pagelim; j++)
            {
                Console.WriteLine(j);
                if (j == a.Count)
                    break;
                b.Add(a[j]);

            }
            return Ok(b);
            
        }
        [Authorize]
        [HttpPost]

        public async Task<ActionResult<string>> addorder(navTech ord)
        {
            dataContext.orderdb.Add(ord);
            await dataContext.SaveChangesAsync();
            return "Successfully added";
        }
    }
}
