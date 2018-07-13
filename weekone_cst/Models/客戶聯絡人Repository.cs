using System;
using System.Linq;
using System.Collections.Generic;
	
namespace weekone_cst.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{

        public IQueryable<客戶聯絡人> All(bool isAll = false)
        {
            if (isAll)
            {
                return base.All();
            }
            return base.All();
        }

        public IQueryable<客戶聯絡人> 搜尋名稱(string qname)
        {
            var 客戶聯絡人 = this.All();

            if (!String.IsNullOrEmpty(qname))
            {
                客戶聯絡人 = 客戶聯絡人.Where(p => p.姓名.Contains(qname));
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