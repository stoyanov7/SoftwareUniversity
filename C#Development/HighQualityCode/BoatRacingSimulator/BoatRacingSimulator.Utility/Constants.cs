namespace BoatRacingSimulator.Utility
{
    public static class Constants
    {
        public const string IncorrectModelLenghtMessage = "Model's name must be at least {0} symbols long.";

        public const string IncorrectPropertyValueMessage = "{0} must be a positive integer.";

        public const string IncorrectSailEfficiencyMessage = "Sail Effectiveness must be between [{0}...{1}].";

        public const string IncorrectEngineTypeMessage = "Incorrect engine type.";

        public const string DuplicateModelMessage = "An entry for the given model already exists.";

        public const string NonExistantModelMessage = "The specified model does not exist.";

        public const string RaceAlreadyExistsMessage = "The current race has already been set.";

        public const string NoSetRaceMessage = "There is currently no race set.";

        public const string InsufficientContestantsMessage = "Not enough contestants for the race.";

        public const string IncorrectBoatTypeMessage = "The specified boat does not meet the race constraints.";

        #region BoatSimulatorController
        public const string SuccessfullCreateBoatEngine =
            "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.";

        public const string SuccessfullCreateBoat = "{0} with model {1} registered successfully.";

        public const string OpenRaceMessage = "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.";

        public const string SignUpBoatMessage = "Boat with model {0} has signed up for the current Race.";
        #endregion

        public const int MinBoatModelLength = 5;

        public const int MinBoatEngineModelLength = 3;

        public const int MinSailEfficiency = 1;

        public const int MaxSailEfficiency = 100;
    }
}