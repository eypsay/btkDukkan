using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if(product.CategoryId == 1)
            {

                return new ErrorResult("Bu kaegoriye Urun kbul edilmiyor");
            }
            else {
                _productDal.Add(product);
            return new SuccessResult("Urun basairyla eklendi");
        }
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),"Ürünler Listelendi");
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>
                 (_productDal.GetAll(p => p.CategoryId == categoryId),
                 "Filtereli olarak listelide");
        }
    }
}
