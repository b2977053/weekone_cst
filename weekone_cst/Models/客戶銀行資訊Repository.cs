using System;
using System.Linq;
using System.Collections.Generic;
	
namespace weekone_cst.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public IQueryable<客戶銀行資訊> All(bool isAll = false)
        {
            if (isAll)
            {
                return base.All();
            }
            return base.All();
        }

        public IQueryable<客戶銀行資訊> 搜尋名稱(string qname)
        {
            var 客戶銀行資訊 = this.All();

            if (!String.IsNullOrEmpty(qname))
            {
                客戶銀行資訊 = 客戶銀行資訊.Where(p => p.銀行名稱.Contains(qname));
            }

            return 客戶銀行資訊;
        }

        public 客戶銀行資訊 Find(int? id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}