namespace ArtemisWest.Demos.Calculator
{
    public interface IOperation
    {
        double Value { get; }
        string Expression { get; }
    }
}