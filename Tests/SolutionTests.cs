
using Jafar_Aladdin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class SolutionTests
    {
        [TestMethod]
        public void Should_Return_Five_As_MaxJump()
        {
            var actual = new[]
            {
                ".....X......",
                "............",
                ".....X......",
                "............",
                ".....X......",
                "............",
                ".....X......",
                "............",
                ".....X......",
                "............",
                ".....X.X....",
                "......O....."
            };
            var expected = Solution.GetMaxJump(actual);
            Assert.AreEqual(expected, 5, "The max jump should be 5");
        }

        [TestMethod]
        public void Should_Return_Six_As_MaxJump()
        {
            var actual = new[]
            {
                ".............",
                ".....X.......",
                ".............",
                ".....X.......",
                ".............",
                ".....X.......",
                ".............",
                ".....X.......",
                ".............",
                ".....X.......",
                ".............",
                ".....X.X.....",
                "......O......"
            };
            var expected = Solution.GetMaxJump(actual);
            Assert.AreEqual(expected, 6, "The max jump should be 6");
        }

        [TestMethod]
        public void Should_Return_Five_Jump_As_MaxJump()
        {
            var actual = new[]
            {
                ".............",
                ".............",
                ".............",
                ".....X.......",
                ".............",
                ".....X.......",
                ".............",
                ".....X.X.....",
                ".............",
                "...X.X.......",
                ".............",
                ".....X.X.....",
                "......O......"
            };
            var expected = Solution.GetMaxJump(actual);
            Assert.AreEqual(expected, 5, "The max jump should be 6");
        }

        #region Should be private Methods

        [TestMethod]
        public void Aladdin_Position()
        {
            var actual = new[]
            {
                "......",
                "......",
                "..X...",
                "......",
                "..X.X.",
                "...O.."
            };
            var expected = Solution.AladdinPostion(actual);
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected[0], 3, "X should be equal to 3");
            Assert.AreEqual(expected[1], 5, "The Y should be equal to 5");
        }

        [TestMethod]
        public void Jump()
        {
            var actual = new[]
            {
                "............",
                "............",
                "........X...",
                "............",
                "........X.X.",
                ".........O..",
                "............",
                "............",
                "............",
                "............",
                "............",
                "............"
            };

            var expected = Solution.Jump(new int[] { 9, 5 }, actual);
            Console.WriteLine("Max jump: " + expected);
            Assert.AreEqual(expected, 2, "The max jump should be 2");
        }

        [TestMethod]
        public void Jaffar_Should_Be_Able_To_Move_Left()
        {
            var actual = new[]
            {
                "......",
                "......",
                "..X...",
                "......",
                "..X.X.",
                "...O.."
            };
            var expected = Solution.CanMoveToPosition(new int[] { 3, 5 }, actual, SearchType.CanMoveLeft);
            Assert.IsTrue(expected, "The Jaffar should be ableto move left diagonal square of Aladdin");
        }

        [TestMethod]
        public void Jaffar_Should_Not_Be_Able_To_Move_Left()
        {
            var actual = new[]
            {
                "......",
                "......",
                "..X...",
                "......",
                "..X.X.",
                "...O.."
            };

            var expected = Solution.CanMoveToPosition(new int[] { 0, 0 }, actual, SearchType.CanMoveLeft);
            Assert.IsFalse(expected, "The Jaffar should on the left diagonal square of Aladdin");
        }

        [TestMethod]
        public void Jaffar_Should_Be_Able_To_Move_Right()
        {
            var actual = new[]
            {
                "......",
                "......",
                "..X...",
                "......",
                "..X.X.",
                "...O.."
            };
            var expected = Solution.CanMoveToPosition(new int[] { 3, 5 }, actual, SearchType.CanMoveRight);
            Assert.IsTrue(expected, "The Jaffar should on the right diagonal square of Aladdin");
        }

        [TestMethod]
        public void Jaffar_Should_Not_Be_Able_To_Move_Right()
        {
            var actual = new[]
            {
                "......",
                "......",
                "..X...",
                "......",
                "..X.X.",
                "...O.."
            };
            var expected = Solution.CanMoveToPosition(new int[] { 0, 0 }, actual, SearchType.CanMoveRight);
            Assert.IsFalse(expected, "The Jaffar should on the right diagonal square of Aladdin");
        }

        #endregion Should be private Methods
    }
}
