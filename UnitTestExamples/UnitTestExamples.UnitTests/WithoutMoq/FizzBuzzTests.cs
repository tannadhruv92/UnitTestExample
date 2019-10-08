using Fundamentals.WithoutMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExamples.UnitTests.WithoutMoq
{
    [TestClass]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [TestInitialize]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [TestCleanup]
        public void Flush()
        {
            _fizzBuzz = null;
        }

        [TestMethod]
        public void GetOutPut_NotDivisibleBy3Or5_ReturnsTheSameNumber()
        {
            string result = _fizzBuzz.GetOutPut(7);

            Assert.AreEqual("7", result);
        }

        [TestMethod]
        public void GetOutPut_DivisibleByOnly3_ReturnsFizz()
        {
            string result = _fizzBuzz.GetOutPut(6);

            Assert.AreEqual("Fizz", result);
        }

        [TestMethod]
        public void GetOutPut_DivisibleBy5Only_ReturnsBuzz()
        {
            string result = _fizzBuzz.GetOutPut(10);

            Assert.AreEqual("Buzz", result);
        }

        [TestMethod]
        public void GetOutPut_DivisibleBy3And5_ReturnsFizzBuzz()
        {
            string result = _fizzBuzz.GetOutPut(15);

            Assert.AreEqual("FizzBuzz", result);
        }
    }
}
