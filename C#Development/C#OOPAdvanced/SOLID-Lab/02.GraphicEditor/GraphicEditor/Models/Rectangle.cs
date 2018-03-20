namespace GraphicEditor.Models
{
    using Contracts;

    public class Rectangle : IShape
    {
        public string Draw() => $"I'm {this.GetType().Name}";
    }
}
