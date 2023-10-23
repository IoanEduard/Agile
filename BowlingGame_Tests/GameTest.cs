

using BowlingGame;

namespace BowlingGame_Tests
{
    [TestFixture]
    public class GameTest
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }

        // Used to ramp up
        //[Test]
        //public void TestOneThrow()
        //{
        //    _game.Add(5);
        //    Assert.That(_game.Score, Is.EqualTo(5));
        //    Assert.That(_game.CurrentFrame, Is.EqualTo(1));
        //}

        [Test]
        public void TestTwoThrowsNoMark()
        {
            _game.Add(5);
            _game.Add(4);
            Assert.That(_game.Score, Is.EqualTo(9));
        }

        [Test]
        public void TestFourThrowsNoMark()
        {
            _game.Add(5);
            _game.Add(4);
            _game.Add(7);
            _game.Add(2);
            Assert.That(_game.Score, Is.EqualTo(18));
            Assert.That(_game.ScoreForFrame(1), Is.EqualTo(9));
            Assert.That(_game.ScoreForFrame(2), Is.EqualTo(18));
        }

        [Test]
        public void TestSimpleSpare()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            Assert.That(_game.ScoreForFrame(1), Is.EqualTo(13));
        }

        [Test]
        public void TestSimpleFrameAfterSpare()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            _game.Add(2);
            Assert.That(_game.ScoreForFrame(1), Is.EqualTo(13));
            Assert.That(_game.ScoreForFrame(2), Is.EqualTo(18));
            Assert.That(_game.Score, Is.EqualTo(18));
        }

        [Test]
        public void TestSimpleStrike()
        {
            _game.Add(10);
            _game.Add(3);
            _game.Add(6);

            Assert.That(_game.ScoreForFrame(1), Is.EqualTo(19));
            Assert.That(_game.Score, Is.EqualTo(28));
        }

        [Test]
        public void TestPerfectGame()
        {
            for(int i =0; i < 12; i++)
            {
                _game.Add(10);
            }
            Assert.That(_game.Score, Is.EqualTo(300));
        }

        [Test]
        public void TestEndOfArray()
        {
            for (int i = 0; i < 9; i++)
            {
                _game.Add(0);
                _game.Add(0);
            }
            _game.Add(2);
            _game.Add(8); // 10th frame spare
            _game.Add(10); // Strike in last position of array.
            Assert.That(_game.Score, Is.EqualTo(20));
        }

        [Test]
        public void TestSampleGame()
        {
            _game.Add(1);
            _game.Add(4);
            _game.Add(4);
            _game.Add(5);
            _game.Add(6);
            _game.Add(4);
            _game.Add(5);
            _game.Add(5);
            _game.Add(10);
            _game.Add(0);
            _game.Add(1);
            _game.Add(7);
            _game.Add(3);
            _game.Add(6);
            _game.Add(4);
            _game.Add(10);
            _game.Add(2);
            _game.Add(8);
            _game.Add(6);
            Assert.That(_game.Score, Is.EqualTo(133));
        }

        [Test]
        public void TestHeartBreak()
        {
            for (int i = 0; i < 11; i++)
                _game.Add(10);
            _game.Add(9);
            Assert.That(_game.Score, Is.EqualTo(299));
        }

        [Test]
        public void TestTenthFrameSpare()
        {
            for (int i = 0; i < 9; i++)
                _game.Add(10);
            _game.Add(9);
            _game.Add(1);
            _game.Add(1);
            Assert.That(_game.Score, Is.EqualTo(270));
        }
    }
}
