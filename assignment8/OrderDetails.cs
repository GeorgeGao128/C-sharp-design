namespace Assignment8;

public class OrderDetails
{
    public DateTime OrderDate;
    public int OrderPrice;
    public string CustomerName;
    public string GoodsName;
    static Random random = new Random();

    public OrderDetails(string customerName,string goodsName)
    {
        OrderDate = DateTime.Now;
        OrderPrice = random.Next(100, 1000) ;
        CustomerName = customerName;
        GoodsName = goodsName;
        
    }
    public OrderDetails()
    {
        OrderDate = DateTime.Now;
        OrderPrice =0 ;
        CustomerName = null;
        GoodsName = null;
        
    }
}