namespace SlotMachine.Symbols
{
    public class Wildcard : SlotSymbol
    {
        public const sbyte ChanceToAppear = 5;

        public Wildcard()
        {
            Symbol = '*';
            Coefficient = 0f;
        }
    }
}