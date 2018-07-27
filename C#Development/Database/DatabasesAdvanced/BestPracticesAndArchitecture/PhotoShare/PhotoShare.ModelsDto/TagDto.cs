namespace PhotoShare.ModelsDto
{
    using Utilities.Validators;

    public class TagDto
    {
        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }
    }
}
