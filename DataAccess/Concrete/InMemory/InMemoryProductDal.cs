using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1, ProductName="bardak",UnitPrice=15,UnitsInStock=15},
            new Product{ProductId=2,CategoryId=1, ProductName="kamera",UnitPrice=500,UnitsInStock=10},
            new Product{ProductId=3,CategoryId=2, ProductName="telefon",UnitPrice=1500,UnitsInStock=2},
            new Product{ProductId=4,CategoryId=2, ProductName="klavye",UnitPrice=150,UnitsInStock=65},
            new Product{ProductId=5,CategoryId=2, ProductName="fare",UnitPrice=850,UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product) //Bütün nesneyi taşımaya gerek var mı?
        {
            _products.Remove(_products.Where(w=>w.ProductId==product.ProductId).FirstOrDefault());//benim kodum
            _products.Remove(_products.SingleOrDefault(p => p.ProductId == product.ProductId)); //Engin hoca
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void  Update(Product product)
        {
            Product toUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            toUpdate.CategoryId = product.CategoryId; ;
            toUpdate.ProductName = product.ProductName;
            toUpdate.CategoryId = product.CategoryId;
            toUpdate.UnitPrice = product.UnitPrice;
            toUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList(); //Engin Hoca versiyonu
            //return _products.FindAll(p => p.CategoryId == categoryId).ToList();
        }
    }
}
