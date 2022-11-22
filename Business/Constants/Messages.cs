using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi Geçersiz";
        public static string ProductsListed= "Ürünler listelendi"; // ---> Eğer kodda constant yarattırılırsa internal olarak yapıyor, biz sonradan public yapacağız.
        public static string MaintenanceTime = "Bakım zamanı";
        public static string ProductCountOfCategoryError="Bu kategoride Sınır aşılmıştır.";
        public static string ProductNameAlreadyExists = "Bu isimde ürün mevcuttur";
        public static string CategoryLimitAxcedeed = "Kategori limitine erişildi";
    }
}
