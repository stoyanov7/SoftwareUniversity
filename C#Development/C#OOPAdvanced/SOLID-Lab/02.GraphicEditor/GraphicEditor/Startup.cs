namespace GraphicEditor
{
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var circle = new Circle();
            var rect = new Rectangle();
            var square = new Square();

            GraphicEditor.DrawShape(circle);
            GraphicEditor.DrawShape(rect);
            GraphicEditor.DrawShape(square);
        }
    }
}
