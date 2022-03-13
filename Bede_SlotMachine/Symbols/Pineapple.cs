namespace SlotMachine.Symbols
{
    public class Pineapple : SlotSymbol
    {
        public const sbyte ChanceToAppear = 15;

        public Pineapple()
        {
            Symbol = 'P';
            Coefficient = 0.8f;
        }
    }
}