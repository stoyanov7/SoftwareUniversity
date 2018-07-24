namespace PhotoShare.ModelsDto
{
    using Utilities.ValidationAttributes;

    public class TagDto
    {
        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }
    }
}
