using System;
using System.Collections.Generic;
using System.Linq;
using Production;
using Xunit;
using static Production.CalculateurScoreLancer;

namespace Unit.Test
{
    public class CalculateurScoreLancerTest
    {
        [Fact]
        public void PourLaCaseUn_LeScoreVautUn_QuandLeLancerContientUnAs()
        {
            var lancerDes = new int[] { 3, 3, 2, 5, 1 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseSuperieure.AS, lancerDes);

            Assert.Equal(1, scoreCase);
        }

        [Fact]
        public void PourLaCaseUn_LeScoreVautDeux_QuandLeLancerContient2As()
        {
            var lancerDes = new int[] { 3, 3, 2, 1, 1 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseSuperieure.AS, lancerDes);

            Assert.Equal(2, scoreCase);
        }

        [Fact]
        public void PourLaCaseDeux_LeScoreVautSix_QuandLeLancerContientTroisDeux()
        {
            var lancerDes = new int[] { 3, 3, 2, 2, 2 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseSuperieure.DEUX, lancerDes);

            Assert.Equal(6, scoreCase);
        }

        [Fact]
        public void PourLaCaseTrois_LeScoreVautNeuf_QuandLeLancerContientTroisTrois()
        {
            var lancerDes = new int[] { 3, 3, 3, 2, 2 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseSuperieure.TROIS, lancerDes);

            Assert.Equal(9, scoreCase);
        }

        [Fact]
        public void PourLaCaseBrelan_LeScoreVautLAdditionDesDes_QuandUnBrelanEstRealise()
        {
            var lancerDes = new int[] { 3, 3, 3, 4, 6 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseInferieure.BRELAN, lancerDes);

            Assert.Equal(19, scoreCase);
        }

        [Fact]
        public void PourLaCaseBrelan_LeScoreVautZero_QuandUnBrelanNonRealise()
        {
            var lancerDes = new int[] { 3, 3, 2, 4, 6 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseInferieure.BRELAN, lancerDes);

            Assert.Equal(0, scoreCase);
        }

        [Fact]
        public void PourLaCaseCarre_LeScoreVautLAdditionDesDes_QuandUnCarreEstRealise()
        {
            var lancerDes = new int[] { 3, 3, 3, 3, 6 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseInferieure.CARRE, lancerDes);

            Assert.Equal(18, scoreCase);
        }

        [Fact]
        public void PourLaCaseFullCarre_LeScoreVautZero_QuandCarreNonRealise()
        {
            var lancerDes = new int[] { 5, 5, 5, 4, 4 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseInferieure.CARRE, lancerDes);

            Assert.Equal(0, scoreCase);
        }

        [Fact]
        public void PourLaCaseYahtzee_LeScoreVautLAdditionDesDes_QuandUnYahtzeeEstRealise()
        {
            var lancerDes = new int[] { 3, 3, 3, 3, 3 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseInferieure.YAHTZEE, lancerDes);

            Assert.Equal(50, scoreCase);
        }

        [Fact]
        public void PourLaCaseYahtzee_LeScoreVautZero_QuandUnYahtzeePasRealise()
        {
            var lancerDes = new int[] { 3, 3, 3, 3, 4 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseInferieure.YAHTZEE, lancerDes);

            Assert.Equal(0, scoreCase);
        }

        [Fact]
        public void PourLaCaseFull_LeScoreVaut25_QuandUnFullRealise()
        {
            var lancerDes = new int[] { 3, 3, 3, 4, 4 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseInferieure.FULL, lancerDes);

            Assert.Equal(25, scoreCase);
        }

        [Fact]
        public void UnFullEstAussiUnBrelan()
        {
            var lancerDes = new int[] { 5, 5, 5, 4, 4 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseInferieure.BRELAN, lancerDes);

            Assert.Equal(23, scoreCase);
        }

        [Fact]
        public void UnCarreEstAussiUnBrelan()
        {
            var lancerDes = new int[] { 5, 5, 5, 5, 4 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseInferieure.BRELAN, lancerDes);

            Assert.Equal(24, scoreCase);
        }

        [Fact]
        public void UnBrelanNestPasUnCarre()
        {
            var lancerDes = new int[] { 5, 5, 5, 4, 4 };
            var calculateur = new CalculateurScoreLancer();

            var scoreCase = calculateur.calculerScore(CaseInferieure.CARRE, lancerDes);

            Assert.Equal(0, scoreCase);
        }

    }
}
