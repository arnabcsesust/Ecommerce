using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using Ecommerce.ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ProductManagement.BLLs
{
    public class ProductLogic
    {
        private UnitOfWork uow;
        private Product product;

        public ProductLogic(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateProduct(ProductViewModel productViewModel)
        {
            try
            {
                product = new Product
                {
                    ProductID = productViewModel.ProductID,
                    ProductName = productViewModel.ProductName,
                    ProductNo = productViewModel.ProductNo
                };

                uow.productRepository.Insert(product);
                uow.Save();
            }
            catch (Exception ex)
            { 
            }
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var result = from p in uow.productRepository.Get()
                         select new ProductViewModel
                         {
                             ProductID = p.ProductID,
                             ProductNo = p.ProductNo,
                             ProductName = p.ProductName
                         };

            return result.ToList();
        }
    }
}
