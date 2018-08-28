namespace ByTheCake.Views.Home
{
    using System;
    using System.IO;
    using WebServer.Contracts;

    public class About : IView
    {
        public string View()
        {
            return string.Join(Environment.NewLine, File.ReadAllLines(@"../../../Resources/Home/About.html"));
        }
    }
}