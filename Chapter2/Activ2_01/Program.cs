class Program
{
    struct Circle
    {
        public double radius { get; }

        public Circle(double Radius)
        {
            radius = Radius;
        }

        public double getArea => Math.PI * radius * radius;
    
        public static Circle operator +(Circle left, Circle right)
        {
            var area = left.getArea + right.getArea;
            var rad = Math.Sqrt((area/Math.PI));
        
            return new Circle(rad);
        }
    }

    public static void Main()
    {
        var c1 = new Circle(3);
        var c2 = new Circle(3);

        var c3 = c1 + c2;

        Console.WriteLine($"Adding circles of radius of {c1.radius} and {c2.radius} results in a new circle with a radius {c3.radius}");
    }
}