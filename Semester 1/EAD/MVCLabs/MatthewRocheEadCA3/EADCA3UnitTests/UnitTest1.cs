
//Matthew Roche EAD CA3
//http://matthewrocheeadca3.azurewebsites.net/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatthewRocheEadCA3.Models;
using System.Collections.Generic;
using System.Linq;



namespace EADCA3UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUnique()
        {
            Lotto newLotto = new Lotto();
            newLotto.generateNumbers(30, 10);

            bool allItemsUnique = newLotto.numbers.Distinct().Count() == newLotto.numbers.Count();

            Assert.IsTrue(allItemsUnique);
        }

        [TestMethod]
        public void TestCollectionSize()
        {
            Lotto newLotto = new Lotto();
            newLotto.generateNumbers(10, 30);

            if (newLotto.numbers.Count == 10)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }

        }
    }
}
