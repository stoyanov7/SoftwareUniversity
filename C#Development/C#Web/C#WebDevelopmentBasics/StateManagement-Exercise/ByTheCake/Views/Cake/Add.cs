namespace ByTheCake.Views.Cake
{
    using System;
    using System.IO;
    using WebServer.Contracts;

    public class Add : IView
    {
        public string View()
        {
            return string.Join(Environment.NewLine, File.ReadAllLines(@"../../../Resources/Cake/Add.html"));
        }
    }
}