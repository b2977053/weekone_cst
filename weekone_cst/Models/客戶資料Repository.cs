using System;
using System.Linq;
using System.Collections.Generic;
	
namespace weekone_cst.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public IQueryable<客戶資料> All(bool isAll = false)
        {
            if (isAll)
            {
                return base.All();
            }
            return base.All();
        }

        public IQueryable<客戶資料> 搜尋名稱(string qname)
        {
            var 客戶資料 = this.All();

            if (!String.IsNullOrEmpty(qname))
            {
                客戶資料 = 客戶資料.Where(p => p.客戶名稱.Contains(qname));
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