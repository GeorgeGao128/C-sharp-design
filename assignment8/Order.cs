namespace Assignment8;
using System.Diagnostics;
public class Order
{
    public int OrderId;
    public OrderDetails OrderDetails;
    
    public static event Action<Order> OrderCreated;
    
    public object show(){
       
    return new
    {
        OrderId = this.OrderId,
        CustomerName = this.OrderDetails?.CustomerName,
        ProductName = this.OrderDetails?.GoodsName,
        OrderDate = this.OrderDetails?.OrderDate,
        OrderPrice = this.OrderDetails?.OrderPrice
    };
}
    
    
}