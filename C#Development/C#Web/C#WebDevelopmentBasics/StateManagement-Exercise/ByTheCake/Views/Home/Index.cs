namespace ByTheCake.Views.Home
{
    using System;
    using System.IO;
    using WebServer.Contracts;

    public class Index : IView
    {
        public string View()
        {
            return string.Join(Environment.NewLine, File.ReadAllLines(@"../../../Resources/Home/Index.html"));
        }
    }
}