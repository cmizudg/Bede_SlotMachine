using SlotMachine.Symbols;
using System;
using System.Linq;

namespace SlotMachine.Calculation
{
    public static class Calculations
    {
        /// <summary>
        /// Picks the Slot Symbols for the game, based on on their individual chance to appear.
        /// </summary>
        /// <returns>
        /// A new array of SlotSymbol subclass objects.
        /// </returns>
        public static SlotSymbol[,] PickSlotSymbols()
        {
            var slotSymbols = new SlotSymbol[4, 3];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var rnd = Convert.ToSByte(new Random().Next(1, 101));
                    slotSymbols[i, j] = rnd switch
                    {
                        <= Wildcard.ChanceToAppear => new Wildcard(),
                        <= Pineapple.ChanceToAppear + Wildcard.ChanceToAppear => new Pineapple(),
                        <= Banana.ChanceToAppear + Pineapple.ChanceToAppear + Wildcard.ChanceToAppear => new Banana(),
                        _ => new Apple()
                    };
                }
            }
            return slotSymbols;
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
            // Sort the Array and find how many Wildcards we have to simplify the 'If' checks. If we have Wildcards, which are '*',
            // we know they'll always come first after sort, so we can determine which cells' coefficient to sum or return.

            var sortedSymbols = symbolsRow.OrderBy(s => s.Symbol).ToArray();
            var wildcardsCount = Array.FindAll(sortedSymbols, x => x.Symbol == new Wildcard().Symbol).Count();

            var coefficient = 0f;

            if (wildcardsCount == 3)
            {
                return coefficient;
            }
            else if (wildcardsCount == 2)
            {
                coefficient += sortedSymbols[2].Coefficient;
            }
            else if (wildcardsCount == 1 && (sortedSymbols[1].Symbol == sortedSymbols[2].Symbol))
            {
                coefficient += sortedSymbols[1].Coefficient + sortedSymbols[2].Coefficient;
            }
            else if (sortedSymbols[0].Symbol == sortedSymbols[1].Symbol && sortedSymbols[0].Symbol == sortedSymbols[2].Symbol)
            {
                coefficient += sortedSymbols[0].Coefficient + sortedSymbols[1].Coefficient + sortedSymbols[2].Coefficient;
            }

            return MathF.Round(coefficient, 2);
        }
    }
}