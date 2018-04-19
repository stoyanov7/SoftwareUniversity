public abstract class Ammunition : IAmmunition
{
    private const int wearLevelMultiplier = 100;

    protected Ammunition()
    {
        this.WearLevel = this.Weight * wearLevelMultiplier;
    }

    public string Name => this.GetType().Name;

    public abstract double Weight { get; }

    public double WearLevel {get; private set;}

    public void DecreaseWearLevel(double wearAmount) => this.WearLevel -= wearAmount;
}