using Microsoft.AspNetCore.Mvc;
using WebBanQA.Models;

namespace WebBanQA.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("api/topSaleProduct/{number}")]
        public IEnumerable<Product> GetTopSaleProduct(int number)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            return db.Products.OrderByDescending(x => x.PDiscount).Take(number).ToList();
        }

        [HttpGet]
        [Route("api/detailProduct/{slug}")]
        public IEnumerable<Product> GetDetailProductBySlug(string slug)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var res = from pr in db.Products
                      join co in db.Colors on pr.PId equals co.ColPid
                      join si in db.Sizes on pr.PId equals si.SPid
                      //join ca in db.Catalogs on pr.PCaid equals ca.CaId
                      //join st in db.Styles on ca.CaStid equals st.StId
                      where pr.PSlug == slug

                      select new Product()
                      {
                          PId = pr.PId,
                          PName = pr.PName,
                          PDiscount = pr.PDiscount,
                          PPrice = pr.PPrice,
                          PImage = pr.PImage,
                          PNote = pr.PNote,
                          PAmount = pr.PAmount,
                          PContent = pr.PContent,
                          PCaid = pr.PCaid,
                          PSlug = pr.PSlug,
                          Colors = GetColorByProduct(pr.PId),
                          Sizes = GetSizeByProduct(pr.PId),
                          PCa = GetCatalogByProduct(pr.PCaid),
                      };
            return res.Take(1).ToList();
        }

        [HttpGet]
        [Route("api/randomProduct/{number}")]
        public IEnumerable<Product> GetRandomProduct(int number)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            Random rand = new Random();
            int toSkip = rand.Next(0, db.Products.Count());
            return db.Products.Skip(toSkip).Take(number).ToList();
        }

        [HttpGet]
        [Route("api/getProductByStyle/{style}")]
        public List<Product> GetListProductByStyle(string style)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var res = from pr in db.Products
                      join ca in db.Catalogs on pr.PCaid equals ca.CaId
                      join st in db.Styles on ca.CaStid equals st.StId

                      where st.StSlug == style
                      select new Product()
                      {
                          PId = pr.PId,
                          PName = pr.PName,
                          PDiscount = pr.PDiscount,
                          PPrice = pr.PPrice,
                          PImage = pr.PImage,
                          PNote = pr.PNote,
                          PAmount = pr.PAmount,
                          PContent = pr.PContent,
                          PCaid = pr.PCaid,
                          PSlug = pr.PSlug,
                          Colors = GetColorByProduct(pr.PId),
                          Sizes = GetSizeByProduct(pr.PId),
                          PCa = GetCatalogByProduct(pr.PCaid),
                      };
            return res.ToList();
        }

        public static Catalog GetCatalogByProduct(string pCAId)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            return db.Catalogs.Where(c => c.CaId == pCAId).FirstOrDefault();
        }

        public static ICollection<Color> GetColorByProduct(string pid)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            return db.Colors.Where(c => c.ColPid == pid).ToList();
        }

        public static ICollection<Size> GetSizeByProduct(string pid)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            return db.Sizes.Where(c => c.SPid == pid).ToList();
        }
    }
}
