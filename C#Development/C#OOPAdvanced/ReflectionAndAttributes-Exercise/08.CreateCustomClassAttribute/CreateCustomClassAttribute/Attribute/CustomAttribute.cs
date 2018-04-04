namespace CreateCustomClassAttribute.Attribute
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    [Serializable]  
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; set; }

        public int Revision { get; set; }

        public string Description { get; set; }

        public string[] Reviewers { get; set; }

    }
}