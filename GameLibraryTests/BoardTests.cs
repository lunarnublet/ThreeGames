using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Tests
{
    [TestClass()]
    public class BoardTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            string expected = "x | \0 | x\n" +
                              "o | \0 | o\n" + 
                              "\0 | \0 | \0";
            Board b = new Board(3, 3, " | ");
            b.TakeSquare(0, 0, 'x');
            b.TakeSquare(0, 2, 'x');
            b.TakeSquare(1, 0, 'o');
            b.TakeSquare(1, 2, 'o');

            Assert.AreEqual(expected, b.ToString());
        }

        [TestMethod()]
        public void TakeSquareTest()
        {
            Board b = new Board(3, 3, " | ");
            b.TakeSquare(1, 1, 'x');
            char expected = 'x';
            Assert.AreEqual(expected, b.GetSquare(1,1));
        }

        [TestMethod()]
        public void GetSquareTest()
        {
            Board b = new Board(3, 3, " | ");
            b.TakeSquare(1, 1, 'x');
            char expected = 'x';
            Assert.AreEqual(expected, b.GetSquare(1, 1));
        }
    }
}