using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using XOGame;
namespace Tests
{
    [TestClass]
    public class XOGameTests
    {
        [TestMethod]
        public void TestConstructors()
        {
            Game game = new Game();
            Assert.AreEqual<int>(3, game.Field.Rows);
            Assert.AreEqual<int>(3, game.Field.Columns);
            game = new Game(20, 20, 3);
            Assert.AreEqual<int>(20, game.Field.Rows);
            Assert.AreEqual<int>(20, game.Field.Columns);
        }
        [TestMethod]
        public void TestMovesDiagonals()
        {
            Game game = new Game(4, 4, 3);
            game.MakeStep(0, 0);
            game.MakeStep(0, 1);
            game.MakeStep(1, 1);
            game.MakeStep(1, 2);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(2, 2);
            Assert.AreEqual<bool>(true, game.CheckWin());
            Assert.AreEqual<CellType>(CellType.cross, game.Field[2, 2].value);

            game = new Game(4, 4, 3);
            game.MakeStep(1, 0);
            game.MakeStep(1, 1);
            game.MakeStep(2, 1);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(2, 2);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(3, 2);
            Assert.AreEqual<bool>(true, game.CheckWin());

            game = new Game(4, 4, 3);
            game.MakeStep(0, 3);
            game.MakeStep(0, 1);
            game.MakeStep(1, 2);
            game.MakeStep(1, 3);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(2, 1);
            Assert.AreEqual<bool>(true, game.CheckWin());

            game = new Game(4, 4, 3);
            game.MakeStep(0, 1);
            game.MakeStep(0, 2);
            game.MakeStep(1, 2);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(1, 3);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(2, 3);
            Assert.AreEqual<bool>(true, game.CheckWin());


        }
        [TestMethod]
        public void TestMovesHorizontals()
        {
            Game game = new Game(4, 4, 3);
            game.MakeStep(0, 0);
            game.MakeStep(1, 1);
            game.MakeStep(0, 2);
            game.MakeStep(2, 2);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(0, 1);
            Assert.AreEqual<bool>(true, game.CheckWin());
            

            game = new Game(4, 4, 3);
            game.MakeStep(1, 1);
            game.MakeStep(1, 0);
            game.MakeStep(1, 2);
            game.MakeStep(2, 2);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(1, 3);
            Assert.AreEqual<bool>(true, game.CheckWin());
            

            game = new Game(4, 4, 3);
            game.MakeStep(2, 2);
            game.MakeStep(1, 0);
            game.MakeStep(2, 0);
            game.MakeStep(3, 2);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(2, 3);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(2, 1);
            Assert.AreEqual<bool>(true, game.CheckWin());
            
        }
        [TestMethod]
        public void TestMovesVerticals()
        {
            Game game = new Game(4, 4, 3);
            game.MakeStep(0, 0);
            game.MakeStep(1, 1);
            game.MakeStep(1, 0);
            game.MakeStep(2, 2);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(2, 0);
            Assert.AreEqual<bool>(true, game.CheckWin());
            

            game = new Game(4, 4, 3);
            game.MakeStep(1, 1);
            game.MakeStep(2, 2);
            game.MakeStep(2, 1);
            game.MakeStep(2, 3);
            Assert.AreEqual<bool>(false, game.CheckWin());
            game.MakeStep(3, 1);
            Assert.AreEqual<bool>(true, game.CheckWin());
            

        }
    }
}
