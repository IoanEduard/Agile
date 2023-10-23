using static System.Formats.Asn1.AsnWriter;

namespace BowlingGame
{
    public class Game
    {
        private int score;
        private int currentFrame = 1;
        private bool isFirstThrow = true;
        private Scorer scorer = new Scorer();
        public int Score
        {
            get { return ScoreForFrame(currentFrame - 1); }
        }
        public int CurrentFrame
        {
            get { return currentFrame; }
        }
        private bool Strike(int pins)
        {
            return (isFirstThrow && pins == 10);
        }
        private bool LastBallInFrame(int pins)
        {
            return Strike(pins) || (!isFirstThrow);
        }


        public void Add(int pins)
        {
            scorer.AddThrow(pins);
            score += pins;
            AdjustCurrentFrame(pins);
        }
        private void AdjustCurrentFrame(int pins)
        {
            if (LastBallInFrame(pins))
                AdvanceFrame();
            else
                isFirstThrow = false;
        }


        private void AdvanceFrame()
        {
            currentFrame++;
            if (currentFrame > 10)
                currentFrame = 10;
        }
        private bool AdjustFrameForStrike(int pins)
        {
            if (pins == 10)
            {
                AdvanceFrame();
                return true;
            }
            return false;
        }


        public int ScoreForFrame(int theFrame)
        {
            return scorer.ScoreForFrame(theFrame);
        }
    }
    //Scorer.cs----------------------------------
    public class Scorer
    {
        private int ball;
        private int[] throws = new int[21];
        private int currentThrow;
        public void AddThrow(int pins)
        {
            throws[currentThrow++] = pins;
        }
        public int ScoreForFrame(int theFrame)
        {
            ball = 0;
            int score = 0;
            for (int currentFrame = 0;
            currentFrame < theFrame;
            currentFrame++)
            {
                if (Strike())
                {
                    score += 10 + NextTwoBallsForStrike;
                    ball++;
                }
                else if (Spare())
                {
                    score += 10 + NextBallForSpare;
                    ball += 2;
                }
                else
                {
                    score += TwoBallsInFrame;
                    ball += 2;
                }
            }
            return score;
        }
        private int NextTwoBallsForStrike
        {
            get { return (throws[ball + 1] + throws[ball + 2]); }
        }
        private int NextBallForSpare
        {
            get { return throws[ball + 2]; }
        }
        private bool Strike()
        {
            return throws[ball] == 10;
        }
        private int TwoBallsInFrame
        {
            get { return throws[ball] + throws[ball + 1]; }
        }
        private bool Spare()
        {
            return throws[ball] + throws[ball + 1] == 10;
        }
    }

}
