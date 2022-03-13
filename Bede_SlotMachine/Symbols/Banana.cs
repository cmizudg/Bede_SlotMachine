namespace SlotMachine.Symbols
{
    public class Banana : SlotSymbol
    {
        public const sbyte ChanceToAppear = 35;

        public Banana()
        {
            Symbol = 'B';
            Coefficient = 0.6f;
        }
    }
}