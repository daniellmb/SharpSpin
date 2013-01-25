using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpSpin;

namespace UnitTests
{
    [TestClass]
    public class RandomizerTests
    {
        /// <summary>
        /// Instance of the "real" randomizer
        /// </summary>
        private static RealRandom randomizer;

        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [TestInitialize()]
        public void Initialize()
        {
            //init spinner
            randomizer = new RealRandom();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidMaxParam()
        {
            //arrange
            int max = -1;

            //act
            var result = randomizer.Generate(max);

            //assert - none should throw a ArgumentOutOfRangeException
        }

        [TestMethod]
        public void GenerateInt()
        {
            //arrange
            int max = 2;

            //act
            var result = randomizer.Generate(max);

            //assert
            Assert.IsInstanceOfType(result, typeof(int), "Should generate random int");
            Assert.IsTrue(result < max, "Should be less than the max");
        }
    }
}
