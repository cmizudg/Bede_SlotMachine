namespace SlotMachine.Symbols
{
    public class Apple : SlotSymbol
    {
        public const sbyte ChanceToAppear = 45;

        public Apple()
        {
            Symbol = 'A';
            Coefficient = 0.4f;
        }
    }
}