using System.Collections.Generic;
using System.Linq;

namespace Production
{
    public class CalculateurScoreLancer
    {
        public enum CaseSuperieure
        {
            AS = 1,
            DEUX = 2,
            TROIS = 3,
            QUATRE = 4,
            CINQ = 5,
            SIX = 6
        }

        public enum CaseInferieure
        {
            BRELAN,
            CARRE,
            YAHTZEE,
            FULL,
            PETITE_SUITE
        }

        private Dictionary<CaseInferieure, CalculateurCaseInferieure> calculateursCasesInferieures = new Dictionary<CaseInferieure, CalculateurCaseInferieure>()
        {
            [CaseInferieure.BRELAN] = new CalculateurCaseInferieure(new VerificationBrelan(), new SommeDes()),
            [CaseInferieure.CARRE] = new CalculateurCaseInferieure(new VerificationCarre(), new SommeDes()),
            [CaseInferieure.YAHTZEE] = new CalculateurCaseInferieure(new VerificationYahtzee(), new ScoreFixe(50)),
            [CaseInferieure.FULL] = new CalculateurCaseInferieure(new VerificationFull(), new ScoreFixe(25)),
        };

        public int calculerScore(CaseSuperieure caseSuperieure, int[] lancerDes)
        {
            int value = (int)caseSuperieure;
            return lancerDes.Count(s => s == value) * value;
        }



        public int calculerScore(CaseInferieure caseInferieure, int[] lancerDes)
        {
            if(calculateursCasesInferieures.TryGetValue(caseInferieure, out var value)) {
                if(value.verificateurFigure.figureRealisee(lancerDes)) {
                    return value.calculScore.score(lancerDes);
                }
            }
            return 0;
        }
    }

    internal class CalculateurCaseInferieure
    {
        public VerificationFigure verificateurFigure;
        public CalculScore calculScore;

        public CalculateurCaseInferieure(VerificationFigure verificateurFigure, CalculScore calculScore)
        {
            this.verificateurFigure = verificateurFigure;
            this.calculScore = calculScore;
        }

        public bool figureRealisee(int[] lancerDes)
        {
            return verificateurFigure.figureRealisee(lancerDes);
        }

    }
}
