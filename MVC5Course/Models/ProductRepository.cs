using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        //�ק���o�Ҧ���ƪ�����
        //�Q��override �S�ʡA�����V�g
        //�h�H�U�Ҧ���k���|�Ѧ�all�@�k
        //�o��@�k�O�ܽd�u�n��X�Ҧ�active��true���ﶵ
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.Active == true);
        }
        //�A�Q�Φh�����@�k�A�p�G���ݨD�n�d�߯u��������
        //���Ѽƪ�bool�A�M�w�O���base��all�٬O�W����this.all
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

        //�мgdelete��k
        public override void Delete(Product entity)
        {
            ((FabricsEntities)this.UnitOfWork.Context).OrderLine.RemoveRange(entity.OrderLine);
            base.Delete(entity);
        }

        public IQueryable Get���o�e��10���d�Ҹ��()
        {
            return this.Get���o�e��N���d�Ҹ��(10);
        }

        public IQueryable Get���o�e��N���d�Ҹ��(int N)
        {
            return this.All().Where(p => p.ProductId < N);
        }


        public IQueryable Get���o�̷j�M����W�r�����(string search)
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