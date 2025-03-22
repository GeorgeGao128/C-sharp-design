using Week5;

public class Program
{
    static void Main()
    {
        OrderService orderService = new OrderService();
        orderService.AddOrder("Mike","milk");
        Thread.Sleep(1000);
        orderService.AddOrder("Jack","water");
        Thread.Sleep(1000);
        orderService.AddOrder("George","computer");
        Thread.Sleep(1000);
        orderService.AddOrder("Linda","candy");
        Thread.Sleep(1000);
        orderService.AddOrder("Tina","phone");
        Thread.Sleep(1000);
        orderService.FindAOrderByCustomer("George");
        Thread.Sleep(1000);
        orderService.FindAOrderById(2);
        Thread.Sleep(1000);
        orderService.FindAOrderByGoodsname("candy");
        Thread.Sleep(1000);
        orderService.FindAOrderByPrice(100);
        Thread.Sleep(1000);
        orderService.ChangeAOrderById(5,"Nimo","fish");
    }
}