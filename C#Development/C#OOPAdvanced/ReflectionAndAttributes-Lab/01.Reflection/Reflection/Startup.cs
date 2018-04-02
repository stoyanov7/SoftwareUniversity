namespace Reflection
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var spy = new Spy();
            var sb = new StringBuilder();

            sb.AppendLine("01. Stealer:")
                .AppendLine(spy.StealFieldInfo("Hacker", "username", "password"))
                .AppendLine();

            sb.AppendLine("02. High Quality Mistakes:")
                .AppendLine(spy.AnalyzeAcessModifiers("Hacker"))
                .AppendLine();

            sb.AppendLine("03. Mission Private Impossible:")
                .AppendLine(spy.RevealPrivateMethods("Hacker"))
                .AppendLine();

            sb.AppendLine("04. Collector")
                .AppendLine(spy.CollectGettersAndSetters("Hacker"))
                .AppendLine();

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}