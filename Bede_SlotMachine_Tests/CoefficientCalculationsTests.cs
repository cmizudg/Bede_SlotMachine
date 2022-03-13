using SlotMachine.Symbols;
using System;
using System.Linq;
using Xunit;

namespace Bede_SlotMachine_Tests
{
    public class CoefficientCalculationsTests
    {
        [Fact]
        public void CalculateCoefficientForThreeMatchingSymbols()
        {
            var matchingApples = new SlotSymbol[3] { new Apple(), new Apple(), new Apple() };
            var matchingBananas = new SlotSymbol[3] { new Banana(), new Banana(), new Banana() };
            var matchingPineapples = new SlotSymbol[3] { new Pineapple(), new Pineapple(), new Pineapple() };
            var matchingWildcards = new SlotSymbol[3] { new Wildcard(), new Wildcard(), new Wildcard() };

            var appleCoefficient = MathF.Round(matchingApples[0].Coefficient + matchingApples[1].Coefficient + matchingApples[2].Coefficient, 2);
            var bananaCoefficient = MathF.Round(matchingBananas[0].Coefficient + matchingBananas[1].Coefficient + matchingBananas[2].Coefficient, 2);
            var pineappleCoefficient = MathF.Round(matchingPineapples[0].Coefficient + matchingPineapples[1].Coefficient + matchingPineapples[2].Coefficient, 2);
            var wildcardCoefficient = MathF.Round(matchingWildcards[0].Coefficient + matchingWildcards[1].Coefficient + matchingWildcards[2].Coefficient, 2);

            Assert.Equal(1.2f, appleCoefficient);
            Assert.Equal(1.8f, bananaCoefficient);
            Assert.Equal(2.4f, pineappleCoefficient);
            Assert.Equal(0f, wildcardCoefficient);
        }

        [Fact]
        public void CalculateCoefficientWithOneWildcard()
        {
            var twoApplesAndWildcard = new SlotSymbol[3] { new Apple(), new Apple(), new Wildcard() };
            var sortedSymbols = twoApplesAndWildcard.OrderBy(s => s.Symbol).ToArray();
            var wildcardsCount = Array.FindAll(sortedSymbols, s => s.Symbol == '*').Count();

            Assert.Equal(1, wildcardsCount);
            Assert.Equal(sortedSymbols[1].Symbol, sortedSymbols[2].Symbol);
            var coefficient = MathF.Round(sortedSymbols[1].Coefficient + sortedSymbols[2].Coefficient,2);

            Assert.Equal(0.8f, coefficient);
        }

        [Fact]
        public void CalculateCoefficientWithTwoWildcards()
        {
            var twoApplesAndWildcard = new SlotSymbol[3] { new Apple(), new Wildcard(), new Wildcard() };
            var sortedSymbols = twoApplesAndWildcard.OrderBy(s => s.Symbol).ToArray();
            var wildcardsCount = Array.FindAll(sortedSymbols, s => s.Symbol == '*').Count();

            Assert.Equal(2, wildcardsCount);
            var coefficient = MathF.Round(sortedSymbols[2].Coefficient,2);

            Assert.Equal(0.4f, coefficient);
        }
    }
}