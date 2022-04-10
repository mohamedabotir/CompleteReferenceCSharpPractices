using System;
using System.ComponentModel.DataAnnotations;

namespace Inheretance
{
    class Shape2D
    {
      protected double Height { get; private set; }
       protected double Width { get; private set; }
     protected   Shape2D(Shape2D form) {
            this.Height = form.Height;
            this.Width = form.Width;
        }
        public Shape2D() {
            Width = Height = 0;
        }

    }
    class Triangle : Shape2D {
        string style;
        public Triangle(string color) {
            style = color;
        }
        public Triangle(Triangle Shape) : base(Shape) {
            style = Shape.style;
        }
        public  void Display(){
            Console.WriteLine($"ShapeType:Triangle,Width:{Width},Height:{Height}");
}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangle data = new Triangle("RED");
            Triangle Copy = new Triangle(data);
            Shape2D Shaperef= new Shape2D();
            Copy.Display();
            Shaperef = data;
            int x = 2;
            Console.WriteLine(x>>1);

                }
    }
}
