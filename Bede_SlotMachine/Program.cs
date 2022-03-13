using Bede_SlotMachine.Checks;
using SlotMachine.Game;
using System;

namespace SlotMachine
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var balance = MathF.Round(Checks.BalanceCheck(), 2);
            var stake = MathF.Round(Checks.StakeCheck(balance), 2);
            Slots.PlayGame(balance, stake);
        }
    }
}