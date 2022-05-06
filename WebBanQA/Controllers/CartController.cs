using Microsoft.AspNetCore.Mvc;
using WebBanQA.Models;

namespace WebBanQA.Controllers
{
    [ApiController]
    public class CartController : Controller
    {
        [HttpGet]
        [Route("api/getCartByUser/{userName}")]
        public IEnumerable<Cart> GetCartByUser(string userName)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var res = from ca in db.Carts
                      join u in db.Users
                      on ca.CarUid equals u.UId

                      where u.UName == userName
                      select new Cart()
                      {
                          CarDate = ca.CarDate,
                          CarU = getUserByUsername(u.UName),
                          Cartdeta = GetCartDetail(ca.CarId, u.UId),
                      };
            return res.ToList();
        }

        [HttpPost]
        [Route("api/cart/insert")]
        public bool InsertItemAddToCart(string CD_PID, string username, string CD_COLslug, string CD_S_name, int CD_amount)
        {
            try
            {
                QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
                Cartdetum cartdeta = new Cartdetum();
                cartdeta.CdId = "";
                cartdeta.CdPid = CD_PID;
                cartdeta.CdCarId = GetCartID(username);
                cartdeta.CdColslug = CD_COLslug;
                cartdeta.CdSName = CD_S_name;
                cartdeta.CdAmount = CD_amount;
                db.Cartdeta.Add(cartdeta);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/cart/update")]
        public bool UpdateItemAddToCart(string CD_PID, string username, string CD_COLslug, string CD_S_name, int amount)
        {
            try
            {
                QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
                string CarID = GetCartID(username);
                var res = from ca in db.Cartdeta
                          where ca.CdPid == CD_PID
                          && ca.CdCarId == CarID
                          && ca.CdColslug == CD_COLslug
                          && ca.CdSName == CD_S_name
                          select ca;
                Cartdetum cartdeta = res.SingleOrDefault();
                if(cartdeta != null)
                {
                    cartdeta.CdAmount = amount;
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/cart/delete")]
        public bool DeleteItemOnCart(string CD_PID, string username, string CD_COLslug, string CD_S_name)
        {
            try
            {
                QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
                string CarID = GetCartID(username);
                var res = from ca in db.Cartdeta
                          where ca.CdPid == CD_PID
                         && ca.CdCarId == CarID
                         && ca.CdColslug == CD_COLslug
                         && ca.CdSName == CD_S_name
                          select ca;
                Cartdetum? cartdetaForRemove = res.SingleOrDefault();
                if(cartdetaForRemove != null)
                {
                    db.Cartdeta.Remove(cartdetaForRemove);
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetCartID(string username)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var carId = from u in db.Users
                        join ca in db.Carts
                        on u.UId equals ca.CarUid

                        where u.UName == username
                        select ca.CarId;
            var res = carId.SingleOrDefault().ToString();
            return res;
        }

        private static User getUserByUsername(string username)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            return db.Users.Where(u => u.UName == username).FirstOrDefault();
        }

        private static ICollection<Cartdetum> GetCartDetail(string carid, string uid)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var res = from cd in db.Cartdeta
                      join ca in db.Carts on cd.CdCarId equals ca.CarId
                      join u in db.Users on ca.CarUid equals u.UId
                      join pr in db.Products on cd.CdPid equals pr.PId

                      where cd.CdCarId == carid && u.UId == uid

                      select new Cartdetum()
                      {
                          CdId = cd.CdId,
                          CdPid = cd.CdPid,
                          CdCarId = cd.CdCarId,
                          CdColslug = cd.CdColslug,
                          CdSName = cd.CdSName,
                          CdAmount = cd.CdAmount,
                          CdP = GetProductByCartDetail(cd.CdId),
                      };
            return res.ToList();
        }

        private static Product GetProductByCartDetail(string cartid)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var res = from pr in db.Products
                      join cd in db.Cartdeta on pr.PId equals cd.CdPid
                      where cd.CdId == cartid

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
                      };
            return res.FirstOrDefault();
        }
    }
}
