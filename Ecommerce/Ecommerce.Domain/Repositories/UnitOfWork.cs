using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public class UnitOfWork
    {
        private ECOMMERCEEntities db;
        public UnitOfWork(ECOMMERCEEntities db)
        {
            this.db = db;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private IRepository<Product> productRepo;
        public IRepository<Product> productRepository
        {
            get
            {
                if (this.productRepo == null)
                {
                    this.productRepo = new Repository<Product>(db);
                }
                return productRepo;
            }
        }

        private IRepository<Category> categoryRepo;
        public IRepository<Category> categoryRepository
        {
            get
            {
                if (this.categoryRepo == null)
                {
                    this.categoryRepo = new Repository<Category>(db);
                }
                return categoryRepo;
            }
        }
    }
}
