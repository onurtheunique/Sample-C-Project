using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CSS
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("File Logger Çalıştı");      
        }
    }
}    