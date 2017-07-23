using System;

public class Rectangle
{
   public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
    {
        this.Id = id;
        this.Width = Math.Abs(width);
        this.Height = Math.Abs(height);
        this.TopLeftX = topLeftX;
        this.TopLeftY = topLeftY;
    }

    public string Id { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double TopLeftX { get; set; }

    public double TopLeftY { get; set; }

    public bool IsThereIntersection(Rectangle rectangle)
    {
        return rectangle.TopLeftX + rectangle.Width >= this.TopLeftX &&
               rectangle.TopLeftX <= this.TopLeftX + this.Width &&
               rectangle.TopLeftY >= this.TopLeftY - this.Height &&
               rectangle.TopLeftY - rectangle.Height <= this.TopLeftY;
    }
}