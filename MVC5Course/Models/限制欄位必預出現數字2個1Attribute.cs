using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class 限制欄位必預出現數字2個1Attribute : DataTypeAttribute
    {

        public 限制欄位必預出現數字2個1Attribute(): base(DataType.Text)
        {
            this.ErrorMessage = "輸入的名稱必需有2個1以上";
        }

        public override bool IsValid(object value)
        {

            string str = Convert.ToString(value);
            var num = (from val in str
                       where val == '1'
                       select val).Count();

            if (num >= 2)
                return true;
            else
                return false;

        }


    }
}