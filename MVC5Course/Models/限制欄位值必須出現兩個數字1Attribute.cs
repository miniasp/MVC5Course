using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class 限制欄位值必須出現兩個數字1Attribute : DataTypeAttribute
    {
        public 限制欄位值必須出現兩個數字1Attribute() : base(DataType.Text)
        {
            this.ErrorMessage = "欄位值必須出現兩個數字1";
        }
        public override bool IsValid(object value)
        {
            string str = Convert.ToString(value);

            var num = (from p in str.ToArray()
                        where p == '1'
                        select p).Count();

            return (num == 2);
        }
    }
}