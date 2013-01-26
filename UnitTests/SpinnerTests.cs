using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpSpin;

namespace UnitTests
{
    [TestClass]
    public class SpinnerTests
    {
        /// <summary>
        /// Used to manually choose the "random" item
        /// </summary>
        private static int FakeRandChoice = 0;

        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [TestInitialize()]
        public void Initialize()
        {
            //set fake randomizer
            Spinner.Randomizer = new FakeRandom();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MissingTextParam()
        {
            //arrange
            string text = null;

            //act
            var result = Spinner.Spin(text);

            //assert - none should throw a ArgumentException
        }

        [TestMethod]
        public void MissingStartBrace()
        {
            //arrange
            var text = "}";
            var expected = text;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should ignore when a single starting brace is missing.");
        }

        [TestMethod]
        public void MissingEndBrace()
        {
            //arrange
            var text = "{";
            var expected = text;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should ignore when a single ending brace is missing.");
        }

        [TestMethod]
        public void FlatPipeFirst()
        {
            //arrange
            var text = "{one|two}";
            var expected = "one";
            FakeRandChoice = 0;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 1st pipe option.");
        }

        [TestMethod]
        public void FlatPipeSecond()
        {
            //arrange
            var text = "{one|two}";
            var expected = "two";
            FakeRandChoice = 1;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 2nd pipe option.");
        }

        [TestMethod]
        public void FlatPipeOptionalFirst()
        {
            //arrange
            var text = "{|two}";
            var expected = "";
            FakeRandChoice = 0;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 1st pipe option.");
        }

        [TestMethod]
        public void FlatPipeOptionalSecond()
        {
            //arrange
            var text = "{|two}";
            var expected = "two";
            FakeRandChoice = 1;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 2nd pipe option.");
        }

        [TestMethod]
        public void DoubleFlatPipeFirst()
        {
            //arrange
            var text = "The {quick|fast} {gray|red} fox jumped over the lazy dog.";
            var expected = "The quick gray fox jumped over the lazy dog.";
            FakeRandChoice = 0;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 1st of each pipe option.");
        }

        [TestMethod]
        public void DoubleFlatPipeSecond()
        {
            //arrange
            var text = "The {quick|fast} {gray|red} fox jumped over the lazy dog.";
            var expected = "The fast red fox jumped over the lazy dog.";
            FakeRandChoice = 1;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 2nd of each pipe option.");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void MissingNestedEndBrace()
        {
            //arrange
            var text = "{test {one|two }";

            //act
            var result = Spinner.Spin(text);

            //assert - none should throw a FormatException
        }

        [TestMethod]
        public void SimpleNestedPipeFirst()
        {
            //arrange
            var text = "The {quick {red|gray}|smart} fox jumped over the lazy dog.";
            var expected = "The quick red fox jumped over the lazy dog.";
            FakeRandChoice = 0;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 1st pipe options.");
        }

        [TestMethod]
        public void SimpleNestedPipeSecond()
        {
            //arrange
            var text = "The {quick {red|gray}|smart} fox jumped over the lazy dog.";
            var expected = "The smart fox jumped over the lazy dog.";
            FakeRandChoice = 1;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 2nd pipe options.");
        }

        [TestMethod]
        public void ComplexNestedPipeFirst()
        {
            //arrange
            var text = "{The {quick|fast|speedy} brown fox {jumped|leaped|hopped} {over|right over|over the top of} the {lazy|sluggish|care-free|relaxing} dog.|{While|Although} just {taking|having} a{| little| quick} {siesta|nap} the dog was {startled|shocked|surprised} by a {quick|fast|speedy} {brown|dark brown|brownish} fox that {leaped|jumped} right {over|over the top of} him.}";
            var expected = "The quick brown fox jumped over the lazy dog.";
            FakeRandChoice = 0;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 1st pipe options.");
        }

        [TestMethod]
        public void ThirteenNestedPipeSecond()
        {
            //arrange
            var text = "{a|b{c|d{e|f{g|h{i|j{k|l{m|n{o|p{q|r{s|t{u|v{w|x{y|z}}}}}}}}}}}}}";
            var expected = "bdfhjlnprtvxz";
            FakeRandChoice = 1;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 2nd pipe options.");
        }

        [TestMethod]
        public void ComplexNestedPipeSecond()
        {
            //arrange
            var text = "{The {quick|fast|speedy} brown fox {jumped|leaped|hopped} {over|right over|over the top of} the {lazy|sluggish|care-free|relaxing} dog.|{While|Although} just {taking|having} a{| little| quick} {siesta|nap} the dog was {startled|shocked|surprised} by a {quick|fast|speedy} {brown|dark brown|brownish} fox that {leaped|jumped} right {over|over the top of} him.}";
            var expected = "Although just having a little nap the dog was shocked by a fast dark brown fox that jumped right over the top of him.";
            FakeRandChoice = 1;

            //act
            var result = Spinner.Spin(text);

            //assert
            Assert.AreEqual<string>(expected, result, "Should choose the 2nd pipe options.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MissingPermutationsParam()
        {
            //arrange
            string text = null;

            //act
            var result = Spinner.Permutations(text);

            //assert - none should throw a ArgumentException
        }

        [TestMethod]
        public void SingleFlatPipePermutations()
        {
            //arrange
            var text = "The {quick|fast} red fox jumped over the lazy dog.";
            var expected = 2;
            FakeRandChoice = 0;

            //act
            var result = Spinner.Permutations(text);

            //assert
            Assert.AreEqual<int>(expected, result, "Should be 2 permutations.");
        }

        [TestMethod]
        public void DoubleFlatPipePermutations()
        {
            //arrange
            var text = "The {quick|fast} {gray|red} fox jumped over the lazy dog.";
            var expected = 4;
            FakeRandChoice = 0;

            //act
            var result = Spinner.Permutations(text);

            //assert
            Assert.AreEqual<int>(expected, result, "Should be 4 permutations.");
        }

        [TestMethod]
        public void SimpleNestedPipePermutations()
        {
            //arrange
            var text = "The {quick {red|gray}|smart} fox jumped over the lazy dog.";
            var expected = 4;
            FakeRandChoice = 0;

            //act
            var result = Spinner.Permutations(text);

            //assert
            Assert.AreEqual<int>(expected, result, "Should be 4 permutations.");
        }
        
        [TestMethod]
        public void ThirteenNestedPipePermutations()
        {
            //arrange
            var text = "{a|b{c|d{e|f{g|h{i|j{k|l{m|n{o|p{q|r{s|t{u|v{w|x{y|z}}}}}}}}}}}}}";
            var expected = 8192;
            FakeRandChoice = 0;

            //act
            var result = Spinner.Permutations(text);

            //assert
            Assert.AreEqual<int>(expected, result, "Should be 8,192 permutations.");
        }

        [TestMethod]
        public void ComplexNestedPipePermutations()
        {
            //arrange
            var text = "{The {quick|fast|speedy} brown fox {jumped|leaped|hopped} {over|right over|over the top of} the {lazy|sluggish|care-free|relaxing} dog.|{While|Although} just {taking|having} a{| little| quick} {siesta|nap} the dog was {startled|shocked|surprised} by a {quick|fast|speedy} {brown|dark brown|brownish} fox that {leaped|jumped} right {over|over the top of} him.}";
            var expected = 559872; //nice!
            FakeRandChoice = 0;

            //act
            var result = Spinner.Permutations(text);

            //assert
            Assert.AreEqual<int>(expected, result, "Should be 559,872 permutations.");
        }

        #region Helpers

        private class FakeRandom : IRandomizer
        {
            public int Generate(int number)
            {
                //return the value set in the test
                return SpinnerTests.FakeRandChoice;
            }
        }

        #endregion
    }
}
