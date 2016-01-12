using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DeviceCloud.Models;

namespace DeviceCloud.Controllers
{
    public class NewsController : Controller
    {
        private SiteContentContext db = new SiteContentContext();
        private int countPerPage = 5;

        // GET: News1/5
        public ActionResult List(int curPage=1)
        {
            if (ViewBag.RecentNews == null)
            {
                ViewBag.RecentNews = (from news in db.News
                                      orderby news.CreateTime descending
                                      select news).Take(5);
            }
            if (ViewBag.MaxPage == null)
            {
                ViewBag.MaxPage = db.News.Count()/ countPerPage + 1;
            }
            ViewBag.NavId = "nav-item-news";
            ViewBag.CurPage = curPage;
            return View((from news in db.News
                         orderby news.CreateTime descending
                         select news).Skip((curPage - 1) * countPerPage).Take(countPerPage).ToList());
        }

        // GET: News1/Details/5
        public ActionResult Details(int id=1)
        {
            ViewBag.NavId = "nav-item-news";
            ViewBag.RelatedNews = db.News.Take(3);
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }    
}