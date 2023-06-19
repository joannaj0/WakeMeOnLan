using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeMeOnLan
{
    public class DataContextSingleton
    {
        private static readonly DataClassesDataContext instance = new DataClassesDataContext();

        public static DataClassesDataContext GetInstance()
        {
            return instance;
        }
    }
}
