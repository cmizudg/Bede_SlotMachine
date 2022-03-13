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
                var symbolRows = new SlotSymbol[4, 3]
                {
                    { Calculations.PickSlotSymbol(), Calculations.PickSlotSymbol(), Calculations.PickSlotSymbol() },
                    { Calculations.PickSlotSymbol(), Calculations.PickSlotSymbol(), Calculations.PickSlotSymbol() },
                    { Calculations.PickSlotSymbol(), Calculations.PickSlotSymbol(), Calculations.PickSlotSymbol() },
                    { Calculations.PickSlotSymbol(), Calculations.PickSlotSymbol(), Calculations.PickSlotSymbol() }
                };

                var earnings = 0f;
                for (int i = 0; i < 4; i++)
                {
                    var currentSymbolRow = new SlotSymbol[3];
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(symbolRows[i, j].Symbol);
                        currentSymbolRow[j] = symbolRows[i, j];
                    }

                    earnings += Calculations.CalculateCoefficient(currentSymbolRow) * stake;

                    Console.WriteLine();
                }

                balance += earnings - stake;
                Console.WriteLine($"You have won: {earnings.ToString("n2")}");
                Console.WriteLine($"Current balance is: {balance.ToString("n2")}\n");
                if (balance > 0)
                {
                    stake = Checks.StakeCheck(balance);
                }
            }
        }
    }
}