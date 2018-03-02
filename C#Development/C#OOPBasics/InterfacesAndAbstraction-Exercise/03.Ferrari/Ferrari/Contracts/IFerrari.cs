namespace Ferrari.Contracts
{
    public interface IFerrari
    {
        string Driver { get; set; }

        string PushGasPedal();
        string UseBrake();
        string ToString();
    }
}