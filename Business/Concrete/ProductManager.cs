using Business.Abstract;
using Business.Constants;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ILogger = Business.CSS.ILogger;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))] //--> Bu metodu ProductValidator kullanarak doğrula
        public IResult Add(Product product)
        {


            /*-----------Burası yerine Fluent Validation kullandık
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            ---------------------------------------*/
            // ValidationTool.Validate(new ProductValidator(), product); -->bunun gibi loglama vb için bir sürü kod yazmak yerine bunu attribute yaptık 

            var result = BusinessRules.Run(CheckIfProductCategoryCorrect(product.CategoryId), CheckIfProductNameCorrect(product.ProductName));
                if (result!=null)
            {
                return result;
            }
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
          
          
        }

        public  IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed );
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return  new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product> (_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos());
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfProductCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result>=15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
           return new SuccessResult();
        }     
        private IResult CheckIfProductNameCorrect(string pName)
        {
            var result = _productDal.GetAll(p => p.ProductName == pName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
           return new SuccessResult();
        }
        private IResult CheckIfCategoryCountValid()
        {
            // burada doğrudan category service dple bağlanmak yerine category service i kullandık
            var result = _categoryService.GetAll().Data.Select(s => s.CategoryName).Distinct().Count();

            if (result > 15)
            {
                return new ErrorResult(Messages.CategoryLimitAxcedeed);
            }
            return new SuccessResult();
        }
    }

 
}