using Microsoft.AspNetCore.Mvc;
using WebBanQA.Models;

namespace WebBanQA.Controllers
{
    [ApiController]
    public class SizeController : Controller
    {
        //public List<Size> GetSizeByProdut(string Pid)
        //{
        //    QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
        //    var res = from si in db.Sizes
        //              join pr in db.Products
        //              on si.SPid equals pr.PId
        //              where pr.PId == Pid

        //              group si by new { si.SName } into temp
        //              select new Size()
        //              {
        //                  SName = temp.Key.SName
        //              };
        //    return res.ToList();
        //}

        [HttpGet]
        [Route("api/getSize/{style}")]
        public IEnumerable<Size> GetSize(string style)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var res = from si in db.Sizes
                      join pr in db.Products
                      on si.SPid equals pr.PId
                      join ca in db.Catalogs
                      on pr.PCaid equals ca.CaId
                      join st in db.Styles
                      on ca.CaStid equals st.StId

                      where st.StSlug == style
                      group si by si.SName into temp
                      select new Size()
                      {
                          SName = temp.Key
                      };
            return res.ToList();
        }
    }
}
