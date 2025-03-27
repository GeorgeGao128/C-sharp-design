namespace Week6;
using System.Diagnostics;
public class Order
{
    public int OrderId;
    public OrderDetails OrderDetails;
    static int anID = 0;
    public static event Action<Order> OrderCreated;

    public Order(string customerName,string goodsName)
    {
        OrderId = AddAnID();
        OrderDetails = new OrderDetails(customerName, goodsName);
        OrderCreated?.Invoke(this);
    }
    

    int AddAnID()
    {
        anID++;
        return anID;
    }
}