using SlotMachine.Symbols;
using System;
using System.Linq;

namespace SlotMachine.Calculation
{
    public static class Calculations
    {
        /// <summary>
        /// Picks a random SlotSymbol type object, based on on their individual chance to appear and accumulating it when it doesn't match the current one.
        /// </summary>
        /// <returns>
        /// a new SlotSymbol subclass object.
        /// </returns>
        public static SlotSymbol PickSlotSymbol()
        {
            var value = Convert.ToSByte(new Random().Next(1, 101));

            return value switch
            {
                <= Wildcard.ChanceToAppear => new Wildcard(),
                <= Pineapple.ChanceToAppear + Wildcard.ChanceToAppear => new Pineapple(),
                <= Banana.ChanceToAppear + Pineapple.ChanceToAppear + Wildcard.ChanceToAppear => new Banana(),
                _ => new Apple()
            };
        }

        /// <summary>
        /// Sorts the SlotSymbol array values and checks for Wildcards. Based on matching symbols and Wildcard count, it calculates the coefficient for the current row.
        /// </summary>
        /// <param name="symbolsRow">
        /// </param>
        /// <returns>
        /// The sum of the symbols' coefficient, if there's a match on the current row.
        /// </returns>
        public static float CalculateCoefficient(SlotSymbol[] symbolsRow)
        {
            // Sort the Array and find how many Wildcards we have to simplify If checks. If we have Wildcards, which are '*',
            // we know they'll always come first, so we can determine which cells' coefficient to sum or return.

            var sortedSymbols = symbolsRow.OrderBy(s => s.Symbol).ToArray();
            var wildcardsCount = Array.FindAll(sortedSymbols, x => x.Symbol == new Wildcard().Symbol).Count();

            var coefficient = 0f;
            if (wildcardsCount == 1 && (sortedSymbols[1].Symbol == sortedSymbols[2].Symbol))
            {
                coefficient += MathF.Round(sortedSymbols[1].Coefficient + sortedSymbols[2].Coefficient, 2);
            }
            else if (wildcardsCount == 2)
            {
                coefficient += sortedSymbols[2].Coefficient;
            }
            else if (sortedSymbols[0].Symbol == sortedSymbols[1].Symbol && sortedSymbols[0].Symbol == sortedSymbols[2].Symbol)
            {
                coefficient += MathF.Round(sortedSymbols[0].Coefficient + sortedSymbols[1].Coefficient + sortedSymbols[2].Coefficient, 2);
            }

            return coefficient;
        }
    }
}