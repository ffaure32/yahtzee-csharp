using System;
using System.Collections.Generic;
using System.Linq;
using Production;
using Xunit;

namespace Unit.Test
{
    public class CalculScoreFigureTest
    {


        [Fact]
        public void UnScoreDeTypeSommeRenvoieLaSommeDesDes()
        {
            CalculScore calculScore = new SommeDes();

            var lancerDes = new int[] {3, 3, 3, 4, 6};
            int score = calculScore.score(lancerDes);

            Assert.Equal(19, score);
        }

        [Fact]
        public void UnScoreDeTypeFixeRenvoieSaValeur()
        {
            CalculScore calculScore = new ScoreFixe(50);

            var lancerDes = new int[] {3, 3, 3, 3, 3};
            int score = calculScore.score(lancerDes);

            Assert.Equal(50, score);
        }


    }
}
