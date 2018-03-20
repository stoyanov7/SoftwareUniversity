namespace GraphicEditor.Models
{
    using Contracts;

    public class Square : IShape
    {
        public string Draw() => $"I'm {this.GetType().Name}";
    }
}
