using System.Collections.Generic;

namespace _04.Websites
{
    public class Website
    {
        public string Host { get; set; }

        public string Domain { get; set; }

        public List<string> Queries { get; set; }

        public Website(string host, string domain, List<string> queries)
        {
            this.Host = host;
            this.Domain = domain;
            this.Queries = queries;
        }
    }
}
