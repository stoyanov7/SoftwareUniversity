namespace GraphicEditor.Models
{
    using Contracts;

    public class Circle : IShape
    {
        public string Draw() => $"I'm {this.GetType().Name}";
    }
}
