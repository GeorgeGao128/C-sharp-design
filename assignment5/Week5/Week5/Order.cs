namespace Week5;

public class Order
{
    public int OrderId;
    public OrderDetails OrderDetails;
    static int anID = 0;

    public Order(string customerName,string goodsName)
    {
        OrderId = AddAnID();
        OrderDetails = new OrderDetails(customerName, goodsName);
        Console.WriteLine($"订单已创建：\n" +
                          $"OrderID: {OrderId}\n" +
                          $"Customer Name: {OrderDetails.CustomerName}\n" +
                          $"Product Name: {OrderDetails.GoodsName}\n" +
                          $"Order Date: {OrderDetails.OrderDate}\n" +
                          $"Order Price: {OrderDetails.OrderPrice}");
    }

    int AddAnID()
    {
        anID++;
        return anID;
    }
}