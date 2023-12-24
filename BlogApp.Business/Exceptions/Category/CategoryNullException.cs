using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Category
{
    internal class CategoryNullException:Exception 

    {

        public CategoryNullException():base("Category null ola bilmez") {}
        public CategoryNullException(string message):base(message)
        {
                
        }
    }
}
