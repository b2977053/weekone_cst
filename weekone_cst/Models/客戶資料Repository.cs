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
            var 客戶資料 = base.All();
            客戶資料 = 客戶資料.Where(r => r.isHidden != true);
            switch (orderby)
            {
                case "ID":
                    return 客戶資料.OrderBy(r => r.Id);
                case "IDdesc":
                    return 客戶資料.OrderByDescending(r => r.Id);
                case "客戶分類":
                    return 客戶資料.OrderBy(r => r.客戶分類);
                case "客戶分類desc":
                    return 客戶資料.OrderByDescending(r => r.客戶分類);
                case "客戶名稱":
                    return 客戶資料.OrderBy(r => r.客戶名稱);
                case "客戶名稱desc":
                    return 客戶資料.OrderByDescending(r => r.客戶名稱);
                case "統一編號":
                    return 客戶資料.OrderBy(r => r.統一編號);
                case "統一編號desc":
                    return 客戶資料.OrderByDescending(r => r.統一編號);
                case "電話":
                    return 客戶資料.OrderBy(r => r.電話);
                case "電話desc":
                    return 客戶資料.OrderByDescending(r => r.電話);
                case "傳真":
                    return 客戶資料.OrderBy(r => r.傳真);
                case "傳真desc":
                    return 客戶資料.OrderByDescending(r => r.傳真);
                case "地址":
                    return 客戶資料.OrderBy(r => r.地址);
                case "地址desc":
                    return 客戶資料.OrderByDescending(r => r.地址);
                case "Email":
                    return 客戶資料.OrderBy(r => r.Email);
                case "Emaildesc":
                    return 客戶資料.OrderByDescending(r => r.Email);
                default:
                    return 客戶資料;
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