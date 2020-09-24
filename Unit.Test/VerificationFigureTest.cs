using System;
using System.Collections.Generic;
using System.Linq;
using Production;
using Xunit;

namespace Unit.Test
{
    public class VerificationFigureTest
    {


        [Fact]
        public void TroisCartesIdentiquesConstituentUnBrelan()
        {
            VerificationFigure verificationBrelan = new VerificationBrelan();

            var lancerDes = new int[] {3, 3, 3, 4, 6};
            Boolean figureRealisee = verificationBrelan.figureRealisee(lancerDes);

            Assert.True(figureRealisee);
        }

        [Fact]
        public void QuatreCartesIdentiquesConstituentUnBrelan()
        {
            VerificationFigure verificationBrelan = new VerificationBrelan();

            var lancerDes = new int[] {3, 3, 3, 3, 6};
            Boolean figureRealisee = verificationBrelan.figureRealisee(lancerDes);

            Assert.True(figureRealisee);
        }

        [Fact]
        public void QuatreCartesIdentiquesConstituentUnCarre()
        {
            VerificationFigure verificationCarre = new VerificationCarre();

            var lancerDes = new int[] {3, 3, 3, 3, 6};
            Boolean figureRealisee = verificationCarre.figureRealisee(lancerDes);

            Assert.True(figureRealisee);
        }

        [Fact]
        public void CinqCartesIdentiquesConstituentUnYahtzee()
        {
            VerificationFigure verificationYahtzee = new VerificationYahtzee();

            var lancerDes = new int[] {3, 3, 3, 3, 3};
            Boolean figureRealisee = verificationYahtzee.figureRealisee(lancerDes);

            Assert.True(figureRealisee);
        }

        [Fact]
        public void FullValideQuand3DesEt2DesIdentiques()
        {
            VerificationFigure verificationFull = new VerificationFull();

            var lancerDes = new int[] {3, 3, 3, 2, 2};
            Boolean figureRealisee = verificationFull.figureRealisee(lancerDes);

            Assert.True(figureRealisee);
        }

        [Fact]
        public void UnYahtzeeEstUnFullValide()
        {
            VerificationFigure verificationFull = new VerificationFull();

            var lancerDes = new int[] {3, 3, 3, 3, 3};
            Boolean figureRealisee = verificationFull.figureRealisee(lancerDes);

            Assert.True(figureRealisee);
        }

        [Fact]
        public void UneDoublePaireNestPasUnBrelan()
        {
            VerificationFigure verificationBrelan = new VerificationBrelan();

            var lancerDes = new int[] {3, 3, 5, 5, 1};
            Boolean figureRealisee = verificationBrelan.figureRealisee(lancerDes);

            Assert.False(figureRealisee);
        }

        [Theory]
        [InlineData(2, 3, 4, 5, 3)]
        [InlineData(1, 3, 4, 2, 2)]
        [InlineData(5, 3, 4, 6, 6)]
        public void VerificationPetiteSuite(params int[] lancerDes)
        {
            VerificationFigure verificationPetiteSuite = new VerificationPetiteSuite();

            Boolean figureRealisee = verificationPetiteSuite.figureRealisee(lancerDes);

            Assert.True(figureRealisee);
        }

        [Theory]
        [InlineData(2, 3, 4, 2, 3)]
        [InlineData(1, 3, 4, 5, 3)]
        public void VerificationPetiteSuiteEnErreur(params int[] lancerDes)
        {
            VerificationFigure verificationPetiteSuite = new VerificationPetiteSuite();

            Boolean figureRealisee = verificationPetiteSuite.figureRealisee(lancerDes);

            Assert.False(figureRealisee);
        }

    }

    internal class VerificationPetiteSuite : VerificationFigure
    {
        public bool figureRealisee(int[] lancerDes)
        {
            var desUniques =  new HashSet<int>(lancerDes);  
            var megaSuite = new HashSet<int>{1, 2, 3, 4, 5, 6};
            return desUniques.Count>=4 && 
                (megaSuite.SetEquals(desUniques.Union(new HashSet<int>{5, 6}))
                    || megaSuite.SetEquals(desUniques.Union(new HashSet<int>{1, 2}))
                    || megaSuite.SetEquals(desUniques.Union(new HashSet<int>{1, 6})));
        }
    }
}
