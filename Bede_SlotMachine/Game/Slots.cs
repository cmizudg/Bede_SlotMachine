using Bede_SlotMachine.Checks;
using SlotMachine.Calculation;
using SlotMachine.Symbols;
using System;

namespace SlotMachine.Game
{
    public class Slots
    {
        public static void PlayGame(float balance, float stake)
        {
            while (balance > 0f)
            {
                Console.WriteLine();
                // Create and fill an array with random symbols and their coefficients
                var slotSymbols = Calculations.PickSlotSymbols();

                var earnings = 0f;
                for (int i = 0; i < 4; i++)
                {
                    var currentRow = new SlotSymbol[3];
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(slotSymbols[i, j].Symbol);
                        currentRow[j] = slotSymbols[i, j];
                    }

                    earnings += Calculations.CalculateCoefficient(currentRow) * stake;
                    Console.WriteLine();
                }

                balance += earnings - stake;
                Console.WriteLine($"You have won: {earnings:n2}");
                Console.WriteLine($"Current balance is: {balance:n2}\n");
                if (balance > 0f)
                {
                    stake = Checks.StakeCheck(balance);
                }
            }
        }
    }
}