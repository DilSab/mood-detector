using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace UnitT
{
    class Program
    {
        static void Main(string[] args)
        {
            test();
        }
        static void test()
        {
            Assert.Equal(1, 2);
        }
    }
}
