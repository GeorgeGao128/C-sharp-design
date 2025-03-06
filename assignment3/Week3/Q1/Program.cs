using System;
using System.Reflection.Metadata;

namespace Week3;
using System.Collections.Generic;
class Program
{
    public class Shape
    {
        public Shape(int le,int he)
        {
            length = le;
            height = he;
        }
        protected int length{get;set;}
        protected int height{get;set;}
        public int GetArea() => (length * height);

        public bool IsLegal()
        {
            if (length < 1 || length > 100) return false;
            if (height < 1 || height > 100) return false;
            return true;
        }
    }

    public class Triangle : Shape
    {
        public Triangle(int a, int b) : base(a, b)
        {
            length = a;
            height = b;
        }
        new public int GetArea() => (length * height) / 2;
    }
    
    public class Rectangle : Shape
    {
        public Rectangle(int a, int b) : base(a, b)
        {
            length = a;
            height = b;
        }
        
    }
    
    public class Square : Shape
    {
        public Square(int a, int b) : base(a, b)
        {
            length = a;
            height = b;
        }
        public new bool IsLegal()
        {
            if (length!=height) return false;
            if (length < 1 || length > 100) return false;
            if (height < 1 || height > 100) return false;
            return true;
        }
    }
    private static void Main()
    {
        Console.WriteLine("请输入你要创建的形状\n如：Square, Triangle, Rectangle");
        string shape = Console.ReadLine();
        Console.WriteLine("请输入该形状的长和高,用空格分开");
        string [ ] inputs = Console . ReadLine ( ) . Split ( ) ;
        int leng = int . Parse ( inputs [ 0 ] ) ;
        int heig = int . Parse ( inputs [ 1 ] ) ;
        switch (shape)
        {
            case "Square":
                Square s= new Square(leng,heig);
                if(s.IsLegal())
                    Console.WriteLine($"面积为：{s.GetArea()}");
                else
                {
                    Console.WriteLine("输入的数值不合法");
                    return;
                }
                break;
            case "Rectangle":
                Rectangle r= new Rectangle(leng,heig);
                if(r.IsLegal())
                    Console.WriteLine($"面积为：{r.GetArea()}");
                else
                {
                    Console.WriteLine("输入的数值不合法");
                    return;
                }
                break;
            case "Triangle":
                Triangle t= new Triangle(leng,heig);
                if(t.IsLegal())
                    Console.WriteLine($"面积为：{t.GetArea()}");
                else
                {
                    Console.WriteLine("输入的数值不合法");
                    return;
                }
                break;
        }
        
        
        
        
    }
}

