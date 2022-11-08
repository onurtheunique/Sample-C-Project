using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); // --> Buradan IProductService çağırılırsa IProductManager instancesi geri gönder. Eskiden bunu Startup da services.AddSingelton olarak belirliyorduk. Sonra o servisi çağırınca GetType ve GetMethod yapıyorduk. Bundan sonra gerek yok bunları yapmaya
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
