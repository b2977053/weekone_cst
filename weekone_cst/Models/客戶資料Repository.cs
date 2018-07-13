using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace weekone_cst.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public IQueryable<客戶資料> All(string orderby = "ID")
        {
            switch (orderby)
            {
                case "ID":
                    return base.All().OrderBy(r => r.Id);
                case "IDdesc":
                    return base.All().OrderByDescending(r => r.Id);
                case "客戶分類":
                    return base.All().OrderBy(r => r.客戶分類);
                case "客戶分類desc":
                    return base.All().OrderByDescending(r => r.客戶分類);
                case "客戶名稱":
                    return base.All().OrderBy(r => r.客戶名稱);
                case "客戶名稱desc":
                    return base.All().OrderByDescending(r => r.客戶名稱);
                case "統一編號":
                    return base.All().OrderBy(r => r.統一編號);
                case "統一編號desc":
                    return base.All().OrderByDescending(r => r.統一編號);
                case "電話":
                    return base.All().OrderBy(r => r.電話);
                case "電話desc":
                    return base.All().OrderByDescending(r => r.電話);
                case "傳真":
                    return base.All().OrderBy(r => r.傳真);
                case "傳真desc":
                    return base.All().OrderByDescending(r => r.傳真);
                case "地址":
                    return base.All().OrderBy(r => r.地址);
                case "地址desc":
                    return base.All().OrderByDescending(r => r.地址);
                case "Email":
                    return base.All().OrderBy(r => r.Email);
                case "Emaildesc":
                    return base.All().OrderByDescending(r => r.Email);
                default:
                    return base.All();
            }
        }

        public IEnumerable SelectList(string orderby)
        {
            var 客戶資料 = this.All(orderby);
            List<客戶資料> 客戶資料list = 客戶資料.ToList();
            客戶資料list.Insert(0, new 客戶資料() { 客戶分類 = "請選擇" });
            return 客戶資料list;
        }

        public IQueryable<客戶資料> 搜尋名稱(string orderby, string qtype, string qname)
        {
            var 客戶資料 = this.All(orderby);

            if (!String.IsNullOrEmpty(qname))
            {
                客戶資料 = 客戶資料.Where(p => p.客戶名稱.Contains(qname));
            }
            if (!String.IsNullOrEmpty(qtype) && qtype != "請選擇")
            {
                客戶資料 = 客戶資料.Where(p => p.客戶分類.Contains(qtype));
            }

            return 客戶資料;
        }

        public 客戶資料 Find(int? id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}