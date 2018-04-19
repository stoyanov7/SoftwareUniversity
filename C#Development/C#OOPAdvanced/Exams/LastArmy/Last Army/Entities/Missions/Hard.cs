public class Hard : Mission
{
    private const string name = "Disposal of terrorists";
    private const double enduranceRequired = 80;
    private const double wearLevelDecrement = 70;

    public Hard(double scoreToComplete)
        : base(scoreToComplete)
    { }

    public override string Name => name;

    public override double EnduranceRequired => enduranceRequired;

    public override double WearLevelDecrement => wearLevelDecrement;
}
