using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace weekone_cst.Models.InputValidations
{
    public class 手機Attribute : DataTypeAttribute
    {
        public 手機Attribute() : base(DataType.Text)
        {
            ErrorMessage = "請輸入正確的手機格式";
        }

        public override bool IsValid(object value)
        {
            Regex rgx = new Regex(@"\d{4}-\d{6}");
            return rgx.IsMatch((string)value);
        }

    }
}