using System;
namespace Week3;
using System.Collections.Generic;


class Program
{
    // 接口定义
    public interface IShape
    {
        int GetArea();
        string GetShapeName();
    }

// 具体类实现
    public class Triangle : IShape
    {
        public string ShapeName="Triangle";
        public string GetShapeName(){return ShapeName;}
        int area = 0;
        public Triangle()
        {
            Random random = new Random();
            int num = random.Next(1, 100);
            area = num;
        }
        public int GetArea()
        { 
            return area; 
        }
    }
    public class Circle : IShape
    {
        public string ShapeName = "Circle";
        public string GetShapeName(){return ShapeName;}
        int area = 0;
        public Circle()
        {
            Random random = new Random();
            int num = random.Next(1, 100);
            area = num;
        }
        public int GetArea() // 必须实现具体逻辑
        { 
            return area; 
        }
    }
    public class Rectangle : IShape
    {
        public string ShapeName = "Rectangle";
        public string GetShapeName(){return ShapeName;}
        int area = 0;
        public Rectangle()
        {
            Random random = new Random();
            int num = random.Next(1, 100);
            area = num;
        }
        public int GetArea() // 必须实现具体逻辑
        { 
            return area; 
        }
    }
    public class Square : IShape
    {
        public string ShapeName = "Square";
        public string GetShapeName(){return ShapeName;}
        int area = 0;
        public Square()
        {
            Random random = new Random();
            int num = random.Next(1, 100);
            area = num;
        }
        public int GetArea() // 必须实现具体逻辑
        { 
            return area; 
        }
    }

    public class ShapeFactory
    {
        public IShape CreateShape()
        {
            Random rand = new Random();
            int num = rand.Next ( ) ;
            num %= 4;
            return num switch
            {
                1 => new Triangle(),
                2 => new Circle(),
                3 => new Rectangle(),
                0 => new Square(),
                _ => throw new NotImplementedException()
            };
        }
    }
    private static void Main()
    {
        ShapeFactory factory = new ShapeFactory ( ) ;
        int SumOfArea=0;
        for (int i = 0; i < 10; i++)
        {
            IShape shape = factory . CreateShape () ;
            SumOfArea=SumOfArea + shape.GetArea();
            string str=shape.GetShapeName();
            Console.WriteLine ($"第{i+1}个创建的图形是{str},他的面积是{shape.GetArea()}");
        }
        Console.WriteLine($"这十个对象的面积之和是{SumOfArea}");
    }
}