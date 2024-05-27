using dvr_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvr_api_tests
{
    [TestClass]
    public class ManagersTests
    {
        [TestMethod]
        public void test_HeapObjectPool()
        {
            int cap = 100;
            int val = 88;
            var hop = new HeapObjectPool<int>(cap);
            for (int i=0; i < cap; i++)
            {
                hop.Push(val);
            }
            int total = 0;
            for (int i=0; i < cap; i++) 
            { 
                int v = hop.Pop();
                total += v;
            }
            Assert.AreEqual(cap*val, total);
        }
    }
}
