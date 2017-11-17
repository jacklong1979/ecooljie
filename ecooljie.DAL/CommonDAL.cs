using ecooljie.Common;
using ecooljie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecooljie.DAL
{
   public class CommonDAL
    {
        public static T CreateIDA<T>() where T : new()
        {
            T t =new T();
            return t;
        }
        public static IDAL<T> d 
        {
            get
            {
               IDAL<T> bll = new T();
                return new T();
            }
        }
    }
}
