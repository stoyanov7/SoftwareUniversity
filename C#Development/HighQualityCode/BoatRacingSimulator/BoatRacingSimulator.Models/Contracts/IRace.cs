namespace BoatRacingSimulator.Models.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the behaviour of the <see cref="Race"/> class.
    /// </summary>
    public interface IRace
    {
        int Distance { get; }

        int WindSpeed { get; }

        int OceanCurrentSpeed { get; }

        bool AllowMotorboats { get; }

        void AddParticipant(IBoat boat);
        IList<IBoat> GetParticipants();
    }
}