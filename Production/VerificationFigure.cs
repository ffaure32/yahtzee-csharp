using System.Collections.Generic;
using System.Linq;

namespace Production
{
    public interface VerificationFigure
    {
        bool figureRealisee(int[] lancerDes);
    }

    public class VerificationYahtzee : VerificationFigure
    {
        public bool figureRealisee(int[] lancerDes)
        {
            return lancerDes.GroupBy(s => s).Select(s => s.Count()).Max() >=5;
        }
    }

    public class VerificationCarre : VerificationFigure
    {
        public bool figureRealisee(int[] lancerDes)
        {
            return lancerDes.GroupBy(s => s).Select(s => s.Count()).Max() >=4;
        }
    }

    public class VerificationBrelan : VerificationFigure
    {
        public bool figureRealisee(int[] lancerDes)
        {
            return lancerDes.GroupBy(s => s).Select(s => s.Count()).Max() >=3;
        }
    }

    public class VerificationFull : VerificationFigure
    {
        public bool figureRealisee(int[] lancerDes)
        {
            return !lancerDes.GroupBy(s => s).Select(s => s.Count()).Contains(1);
        }
    }
}