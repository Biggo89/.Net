using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestMetadataAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int> myFunc = () => 10;// similar to: int myAnonMethod() { return 10; }
            Expression<Func<int>> myExpression = () => 10;
        }
    }
}
