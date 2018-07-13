namespace weekone_cst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();
            var 聯絡人 = repo.Find(this.Id);
            if (聯絡人 == null)
            {
                if (repo.checkMail(this.客戶Id, this.Email))
                {
                    yield return new ValidationResult("同一個客戶下的聯絡人，其 Email 不能重複。", new string[] { "Email" });
                }
            }
            else if (this.Email != 聯絡人.Email)
            {
                if (repo.checkMail(聯絡人.客戶Id, this.Email))
                {
                    yield return new ValidationResult("同一個客戶下的聯絡人，其 Email 不能重複。", new string[] { "Email" });
                }
            }

            
        }
    }
    
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
