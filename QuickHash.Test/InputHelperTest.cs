using NUnit.Framework;
using QuickHash.ConsoleNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickHash.Test
{
    public class InputHelperTest
    {
        [TestCase("2020-08-15", ExpectedResult = true)]
        [TestCase("2020-15-08", ExpectedResult = false)]
        [TestCase("20209999", ExpectedResult = false)]
        [TestCase("badinput", ExpectedResult = false)]
        public bool Validate_Input_Date(string input)
        {
            return InputHelper.ValidateDate(input);
        }

        [Test]
        public void Strip_Hyphens_From_Input()
        {
            string input = "2020-08-05";
            string expected = "20200805";

            string actual = InputHelper.StripHyphens(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
