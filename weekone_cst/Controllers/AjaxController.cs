using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using weekone_cst.Models;

namespace weekone_cst.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult bankCount(int? cid)
        {
            客戶銀行資訊Repository repo = RepositoryHelper.Get客戶銀行資訊Repository();
            var 銀行資訊 = repo.All();
            銀行資訊 = 銀行資訊.Where(r => r.客戶Id == cid);

            return Json(new
            {
                isOK = true, count = 銀行資訊.Count()
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ContactCount(int? cid)
        {
            客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();
            var 聯絡人 = repo.All();
            聯絡人 = 聯絡人.Where(r => r.客戶Id == cid);

            return Json(new
            {
                isOK = true,
                count = 聯絡人.Count()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}