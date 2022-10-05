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
            ProductManager productManager = new ProductManager(new EfProductDal()); //dbden çağır

            //foreach (var produc in productManager.GetAll())
            //{
            //    Console.WriteLine(produc.ProductName);
            //}
                     
            //foreach (var produc in productManager.GetAllByCategoryId(2))
            //{
            //    Console.WriteLine(produc.ProductName);
            //}
                     
            foreach (var produc in productManager.GetAllByUnitPrice(40,100))
            {
                Console.WriteLine(produc.ProductName);
            }
          
        }
    }
}
