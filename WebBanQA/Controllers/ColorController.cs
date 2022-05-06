using Microsoft.AspNetCore.Mvc;
using WebBanQA.Models;

namespace WebBanQA.Controllers
{
    [ApiController]
    public class ColorController : Controller
    {
        //public IEnumerable<Color> GetColorByProdut(string Pid)
        //{
        //    QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
        //    var res = from co in db.Colors
        //              join pr in db.Products
        //              on co.ColPid equals pr.PId
        //              where pr.PId == Pid
        //              group co by new { co.ColSlug, co.ColName } into temp

        //              select new Color()
        //              {
        //                  ColSlug = temp.Key.ColSlug,
        //                  ColName = temp.Key.ColName
        //              };
        //    return res.ToList();
        //}

        [HttpGet]
        [Route("api/getColor/{style}")]
        public IEnumerable<Color> GetColor(string style)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var res = from co in db.Colors
                      join pr in db.Products
                      on co.ColPid equals pr.PId
                      join ca in db.Catalogs
                      on pr.PCaid equals ca.CaId
                      join st in db.Styles
                      on ca.CaStid equals st.StId

                      where st.StSlug == style
                      group co by new { co.ColSlug, co.ColName } into temp
                      select new Color()
                      {
                          ColSlug = temp.Key.ColSlug,
                          ColName = temp.Key.ColName
                      };
            return res.ToList();
        }
    }
}
