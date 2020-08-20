using NUnit.Framework;
using QuickHash.Gen;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickHash.Test
{
    public class HashGeneratorTests
    {
        [Test]
        public void HashIt_Variable_Data()
        {
            var hasher = new HashGenerator("test");
            var expectedHash = "9571870d1dd63e023e01dce722cd132fad187cd185f902dd79d72589edaa4c21".ToUpper();

            var actualHash = hasher.HashIt("20200820");

            Assert.AreEqual(expectedHash, actualHash);
        }
    }
}
