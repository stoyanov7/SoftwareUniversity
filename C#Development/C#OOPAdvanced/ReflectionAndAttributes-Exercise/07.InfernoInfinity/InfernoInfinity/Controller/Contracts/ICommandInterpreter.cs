namespace InfernoInfinity.Controller.Contracts
{
    using System.Collections.Generic;

    public interface ICommandInterpreter
    {
        void Add(IReadOnlyList<string> line);
        void Create(IEnumerable<string> line);
        void Print(IReadOnlyList<string> line);
        void Remove(IReadOnlyList<string> line);
    }
}