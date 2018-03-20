namespace GraphicEditor.Models
{
    using System;
    using Contracts;

    public static class GraphicEditor
    {
        public static void DrawShape(IShape shape) => Console.WriteLine(shape.Draw());
    }
}
