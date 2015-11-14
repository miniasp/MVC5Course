using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        //修改取得所有資料的條件
        //利用override 特性，直接越寫
        //則以下所有方法都會參考all作法
        //這邊作法是示範只要找出所有active為true的選項
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.Active == true);
        }
        //再利用多型的作法，如果有需求要查詢真正的全部
        //按參數的bool，決定是顯示base的all還是上面的this.all
        public IQueryable<Product> All(bool isGetAll)
        {
            if (isGetAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }

        //覆寫delete方法
        public override void Delete(Product entity)
        {
            ((FabricsEntities)this.UnitOfWork.Context).OrderLine.RemoveRange(entity.OrderLine);
            base.Delete(entity);
        }

        public IQueryable Get取得前面10筆範例資料()
        {
            return this.Get取得前面N筆範例資料(10);
        }

        public IQueryable Get取得前面N筆範例資料(int N)
        {
            return this.All().Where(p => p.ProductId < N);
        }


        public IQueryable Get取得依搜尋條件名字的資料(string search)
        {
            return this.All().Where(p => p.ProductName.Contains(search));
        }
        public Product GetByID(int? id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id.Value);
        }


    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}