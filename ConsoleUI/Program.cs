using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal()); //memoryden çağır


            //foreach (var produc in productManager.GetAll())
            //{
            //    Console.WriteLine(produc.ProductName);
            //}

            //foreach (var produc in productManager.GetAllByCategoryId(2))
            //{
            //    Console.WriteLine(produc.ProductName);
            //}
            ProductTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); //dbden çağır         
            foreach (var product in productManager.GetProductDetailDtos())
            {
                Console.WriteLine(product.ProductName + "/"+ product.CategoryName);
            }
        }
    }
}
