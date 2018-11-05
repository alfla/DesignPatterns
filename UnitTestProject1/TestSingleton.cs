using Microsoft.VisualStudio.TestTools.UnitTesting;
using SingletonPattern;

namespace UnitTestProject1
{
    [TestClass]
    public class TestSingleton
    {
        [TestMethod]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.AreSame(db, db2);
            Assert.AreEqual(SingletonDatabase.Count, 1);
        }

        [TestMethod]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.GetTotalPopulation(names);
            Assert.AreEqual(tp, (17500000 + 17400000));
            
        }

    }


}
