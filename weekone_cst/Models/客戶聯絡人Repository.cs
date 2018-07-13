using System;
using System.Linq;
using System.Collections.Generic;
	
namespace weekone_cst.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{

        public IQueryable<客戶聯絡人> All(string orderby = "ID")
        {
            var 客戶聯絡人 = base.All();
            客戶聯絡人 = 客戶聯絡人.Where(r => r.isHidden != true);
            switch (orderby)
            {
                case "ID":
                    return 客戶聯絡人.OrderBy(r => r.Id);
                case "IDdesc":
                    return 客戶聯絡人.OrderByDescending(r => r.Id);
                case "職稱":
                    return 客戶聯絡人.OrderBy(r => r.職稱);
                case "職稱desc":
                    return 客戶聯絡人.OrderByDescending(r => r.職稱);
                case "姓名":
                    return 客戶聯絡人.OrderBy(r => r.姓名);
                case "姓名desc":
                    return 客戶聯絡人.OrderByDescending(r => r.姓名);
                case "Email":
                    return 客戶聯絡人.OrderBy(r => r.Email);
                case "Emaildesc":
                    return 客戶聯絡人.OrderByDescending(r => r.Email);
                case "手機":
                    return 客戶聯絡人.OrderBy(r => r.手機);
                case "手機desc":
                    return 客戶聯絡人.OrderByDescending(r => r.手機);
                case "電話":
                    return 客戶聯絡人.OrderBy(r => r.電話);
                case "電話desc":
                    return 客戶聯絡人.OrderByDescending(r => r.電話);
                case "客戶Id":
                    return 客戶聯絡人.OrderBy(r => r.客戶Id);
                case "客戶Iddesc":
                    return 客戶聯絡人.OrderByDescending(r => r.客戶Id);
                default:
                    return 客戶聯絡人;
            }
        }

        public bool checkMail(int 客戶Id, string email)
        {
            var 客戶聯絡人 = this.All();
            客戶聯絡人 = 客戶聯絡人.Where(r => r.客戶Id == 客戶Id && r.Email == email);
            return 客戶聯絡人.Count() > 0;
        }

        public List<客戶聯絡人> SelectList(string orderby)
        {
            var 客戶聯絡人 = this.All(orderby);
            List<客戶聯絡人> 客戶聯絡人list = 客戶聯絡人.ToList();
            客戶聯絡人list.Insert(0, new 客戶聯絡人() { 職稱 = "請選擇" });
            return 客戶聯絡人list;
        }

        public IQueryable<客戶聯絡人> 搜尋名稱(string orderby, string qtype, string qname)
        {
            var 客戶聯絡人 = this.All(orderby);

            if (!String.IsNullOrEmpty(qname))
            {
                客戶聯絡人 = 客戶聯絡人.Where(p => p.姓名.Contains(qname));
            }
            if (!String.IsNullOrEmpty(qtype) && qtype != "請選擇")
            {
                客戶聯絡人 = 客戶聯絡人.Where(p => p.職稱.Contains(qtype));
            }

            return 客戶聯絡人;
        }

        public 客戶聯絡人 Find(int? id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}