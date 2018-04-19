using System;

public class Engine
{
    private const string enoughPullBack = "Enough! Pull back!";
    private readonly IReader reader;
    private readonly IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.writer = writer;
        this.reader = reader;
    }

    public void Run()
    {
        var input = this.reader.ReadLine();
        var gameController = new GameController(this.writer);
        
        while (!input.Equals(enoughPullBack))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                this.writer.AppendLine(arg.Message);
            }

            input = this.reader.ReadLine();
        }

        gameController.RequestResult();
        this.writer.WriteLineAll();
    }
}
