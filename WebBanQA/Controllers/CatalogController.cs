using Microsoft.AspNetCore.Mvc;
using WebBanQA.Models;

namespace WebBanQA.Controllers
{
    [ApiController]
    public class CatalogController : Controller
    {
        [HttpGet]
        [Route("api/getCatalog/{style}")]
        public IEnumerable<Catalog> getCatalog(string style)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var res = from ca in db.Catalogs
                      join st in db.Styles
                      on ca.CaStid equals st.StId
                      where st.StSlug == style
                      group ca by new { ca.CaName } into temp

                      select new Catalog()
                      {
                          CaName = temp.Key.CaName
                      };
            return res.ToList();
        }
    }
}
