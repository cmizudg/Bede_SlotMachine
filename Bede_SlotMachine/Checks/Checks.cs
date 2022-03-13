using System;

namespace Bede_SlotMachine.Checks
{
    public static class Checks
    {
        /// <summary>
        /// Checks whether or not the Input is a positive number
        /// </summary>
        /// <returns>
        /// A float representing the user's balance
        /// </returns>
        public static float BalanceCheck()
        {
            var balance = 0f;
            var correctFormat = false;
            Console.WriteLine("Please deposit money you would like to play with:");
            while (!correctFormat || balance <= 0f)
            {
                correctFormat = float.TryParse(Console.ReadLine(), out balance);
                if (!correctFormat || balance <= 0f)
                {
                    Console.WriteLine("Please insert only positive numeric values for balance:");
                }
            }

            return balance;
        }

        /// <summary>
        /// Checks whether or not the Input is a positive number
        /// </summary>
        /// <returns>
        /// A float representing the user's current stake
        /// </returns>
        public static float StakeCheck(float balance)
        {
            // Subject to change every spin or just once?
            var stake = 0f;
            var correctFormat = false;
            Console.WriteLine("Enter stake amount:");
            while (!correctFormat || stake <= 0 || stake > balance )
            {
                correctFormat = float.TryParse(Console.ReadLine(), out stake);
                if (stake > balance)
                {
                    Console.WriteLine("You cannot bet more than you have in your Balance!\nEnter stake amount:");
                }
                if (!correctFormat || stake <= 0f)
                {
                    Console.WriteLine("Please insert only positive numeric values for stake:");
                }
            }

            return stake;
        }
    }
}