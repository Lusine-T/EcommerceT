using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStringsWithTesting;

namespace MyStringsWithTests_Test
{
    [TestClass]
    public class StringAnalyzerTests
    {
        #region MaxUnequalConsecutiveChars

        [DataTestMethod]
        [DataRow(null, 0)]
        [DataRow("", 0)]
        [DataRow("A", 1)]
        [DataRow("AAAAAA", 1)]
        [DataRow("ABCDE", 5)]
        [DataRow("AAABCDEFBB", 7)]
        [DataRow("ABABABAB", 8)]
        [DataRow("AABBCCDD", 2)]
        public void MaxUnequalConsecutiveChars_VariousInputs_ReturnsExpected(
            string input,
            int expected)
        {
            int result = StringAnalyzer.MaxUnequalConsecutiveChars(input);
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region MaxConsecutiveIdenticalLatinLetters

        [DataTestMethod]
        [DataRow(null, 0)]
        [DataRow("", 0)]
        [DataRow("123456!!!", 0)]
        [DataRow("A", 1)]
        [DataRow("aaabbccccXYZ", 4)]
        [DataRow("AAAaaa", 3)]
        [DataRow("111aa22bbb!!", 3)]
        [DataRow("ABCD", 1)]
        [DataRow("ZZZZZZ", 6)]
        public void MaxConsecutiveIdenticalLatinLetters_VariousInputs_ReturnsExpected(
            string input,
            int expected)
        {
            int result = StringAnalyzer.MaxConsecutiveIdenticalLatinLetters(input);
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region MaxConsecutiveIdenticalDigits

        [DataTestMethod]
        [DataRow(null, 0)]
        [DataRow("", 0)]
        [DataRow("ABCDEF", 0)]
        [DataRow("7", 1)]
        [DataRow("112233333221", 5)]
        [DataRow("aa1111bb222", 4)]
        [DataRow("999999", 6)]
        [DataRow("123456", 1)]
        [DataRow("11aa22bb3333", 4)]
        public void MaxConsecutiveIdenticalDigits_VariousInputs_ReturnsExpected(
            string input,
            int expected)
        {
            int result = StringAnalyzer.MaxConsecutiveIdenticalDigits(input);
            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}