using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        IBasketDal _basketDal;
        IProductService _productService;

        //public BasketManager(IBasketDal basketDal, IProductService productService)
        //{
        //    _basketDal = basketDal;
        //    _productService = productService;
        //}
        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        //    _productService = productService;
        }
        public IResult Add(Basket basket)
        {
            //if (_productService.CheckStock(basket.ProductId)>0)
            //{

            //}
            _basketDal.Add(basket);
            return new SuccessResult("Ürün sepete eklendi");
        }

        public IDataResult<List<Basket>> GetAll()
        {
            return new SuccessDataResult<List<Basket>>(_basketDal.GetAll());
        }
    }
}
