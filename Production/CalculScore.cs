using System.Linq;

namespace Production
{
    public interface CalculScore
    {
        int score(int[] lancerDes);
    }

    public class ScoreFixe : CalculScore
    {
        private int scoreFixe;

        public ScoreFixe(int scoreFixe)
        {
            this.scoreFixe = scoreFixe;
        }

        public int score(int[] lancerDes)
        {
            return scoreFixe;
        }
    }

    public class SommeDes : CalculScore
    {
        public int score(int[] lancerDes)
        {
            return lancerDes.Sum();
        }
    }
}
