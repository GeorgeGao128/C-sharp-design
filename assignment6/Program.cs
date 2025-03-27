using Week6;

public static class Program
{
    public static OrderService orderService = new OrderService();
    static void Main()
    {
        
        orderService.AddOrder("Mike","milk");
        orderService.AddOrder("Jack","water");
        orderService.AddOrder("George","computer");
        orderService.AddOrder("Linda","candy");
        orderService.AddOrder("Tina","phone");
        Application.Run(new Form1()); 
    }
}