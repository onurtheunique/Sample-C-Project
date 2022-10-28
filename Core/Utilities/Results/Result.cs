using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        /*
         * Result mesajlı veya mesajsız yaratılabilinir. 
              Eğer sadece durum gönderilirse Result(bool success) çalışır. 
                Diğer durumda Result(bool success, string message) o da kendi içinde Result(bool success) çağırıp çalıştırır
         */
        public Result(bool success)
        {
            Success = success;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public bool Success { get;}

        public string Message { get; }
    }
}
