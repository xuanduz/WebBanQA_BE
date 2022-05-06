using Microsoft.AspNetCore.Mvc;
using WebBanQA.Models;

namespace WebBanQA.Controllers
{
    [ApiController]
    public class StyleController : Controller
    {
        [HttpGet]
        [Route("api/getStyle")]
        public IEnumerable<Style> GetStyle()
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            return db.Styles.ToList();
        }
    }
}
