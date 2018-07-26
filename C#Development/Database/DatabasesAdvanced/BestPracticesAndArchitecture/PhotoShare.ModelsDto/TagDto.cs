namespace PhotoShare.ModelsDto
{
    using Utilities;

    public class TagDto
    {
        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }
    }
}
