namespace BashSoft.StaticData
{
    using System.IO;

    public static class SessionData
    {
        /// <summary>
        /// Hold the data for the current session.
        /// </summary>
        public static string CurrentPath = Directory.GetCurrentDirectory();
    }
}