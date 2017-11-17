using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ecooljie.DB.Redis;

namespace ecooljie.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mse = RedisHelper.StringGet("A");
            Console.Write(mse);
            var bol=RedisHelper.StringSet("A", "88888");
            RedisHelper.KeyDelete("A");
            mse = RedisHelper.StringGet("A");
            Console.Write(mse);
          Assert.IsTrue(bol);
        }
    }
}
