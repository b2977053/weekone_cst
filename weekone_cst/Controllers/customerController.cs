﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using weekone_cst.Models;

namespace weekone_cst.Controllers
{
    public class customerController : Controller
    {
        客戶資料Repository repo;
        客戶資料Repository occuRepo;

        public customerController()
        {
            repo = RepositoryHelper.Get客戶資料Repository();
            occuRepo = RepositoryHelper.Get客戶資料Repository(repo.UnitOfWork);
        }

        //private 客戶資料Entities db = new 客戶資料Entities();

        // GET: customer
        public ActionResult Index(string orderby, string qtype, string qname)
        {
            ViewBag.qtype = new SelectList(repo.SelectList(orderby), "客戶分類", "客戶分類", qtype);

            if (string.IsNullOrWhiteSpace(qtype) && string.IsNullOrWhiteSpace(qname))
            {
                return View("Index", repo.All(orderby).ToList());
            }
            else
            {
                return View("Index", repo.搜尋名稱(orderby, qtype, qname));
            }
        }

        // GET: customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶分類,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                repo.Add(客戶資料);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            ViewBag.客戶分類 = getSelect(客戶資料.客戶分類);

            return View(客戶資料);
        }

        private dynamic getSelect(string select = "")
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Value = "", Text = "請選擇" });
            items.Add(new SelectListItem() { Value = "分類1", Text = "分類1" });
            items.Add(new SelectListItem() { Value = "分類2", Text = "分類2" });
            items.Add(new SelectListItem() { Value = "分類3", Text = "分類3" });

            if (string.IsNullOrWhiteSpace(select))
            {
                items[0].Selected = true;
            }
            else
            {
                items.Where(r => r.Value == select).First().Selected = true;
            }
            return items;
        }

        // POST: customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶分類,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                var db = repo.UnitOfWork.Context;
                db.Entry(客戶資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            客戶資料 客戶資料 = repo.Find(id);
            //repo.Delete(客戶資料);
            //repo.UnitOfWork.Commit();

            客戶資料.isHidden = true;
            var db = repo.UnitOfWork.Context;
            db.Entry(客戶資料).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
