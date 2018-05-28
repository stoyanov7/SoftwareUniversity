namespace AirConditionerTesterSystem.Core
{
    using System;
    using Contracts;
    using Utilities;

    public class Action : IAction
    {
        public Action(string line)
        {
            try
            {
                this.Name = line.Substring(0, line.IndexOf(' '));

                this.Parameters = line
                    .Substring(line.IndexOf(' ') + 1)
                    .Split(new[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommand, ex);
            }
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }
    }
}