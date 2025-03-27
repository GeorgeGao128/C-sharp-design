namespace Week6;
using System.Diagnostics;

public class OrderService
{
    List<Order> Orders=new List<Order>();

    public void AddOrder(string customerName,string goodsName)
    {
        Orders.Add(new Order(customerName, goodsName));
    }

    public void DeleteOrder(int thisOrderId)
    {
        var sameOrder = from ord in Orders
            where ord.OrderId == thisOrderId
            select ord;
        if (!sameOrder.Any())
        {
            MessageBox.Show("未查询到相关订单");
        }
        else {
            MessageBox.Show("删除订单成功");
        Orders.Remove(sameOrder.Single()); }
    }

    public void FindAOrderById(int thisOrderId)
    {
        var sameOrder = from ord in Orders
            where ord.OrderId == thisOrderId
            select ord;
        if (!sameOrder.Any())
        {
            MessageBox.Show("未查询到相关订单");
        }
        else
            MessageBox.Show($"订单已找到：\n" +
                          $"OrderID: {sameOrder.Single().OrderId}\n" +
                          $"Customer Name: {sameOrder.Single().OrderDetails.CustomerName}\n" +
                          $"Product Name: {sameOrder.Single().OrderDetails.GoodsName}\n" +
                          $"Order Date: {sameOrder.Single().OrderDetails.OrderDate}\n" +
                          $"Order Price: {sameOrder.Single().OrderDetails.OrderPrice}");
    }
    public void FindAOrderByGoodsname(string thisgoodsName)
    {
        var sameOrder = from ord in Orders
            where ord.OrderDetails.GoodsName == thisgoodsName
            select ord;
        if (!sameOrder.Any())
        {
            MessageBox.Show("未查询到相关订单");
        }
        else
            MessageBox.Show($"订单已找到：\n" +
                          $"OrderID: {sameOrder.Single().OrderId}\n" +
                          $"Customer Name: {sameOrder.Single().OrderDetails.CustomerName}\n" +
                          $"Product Name: {sameOrder.Single().OrderDetails.GoodsName}\n" +
                          $"Order Date: {sameOrder.Single().OrderDetails.OrderDate}\n" +
                          $"Order Price: {sameOrder.Single().OrderDetails.OrderPrice}");
    }
    public void FindAOrderByCustomer(string thisCustomerName)
    {
        var sameOrder = from ord in Orders
            where ord.OrderDetails.CustomerName == thisCustomerName
            select ord;
        if (!sameOrder.Any())
        {
            MessageBox.Show("未查询到相关订单");
        }
        else
            MessageBox.Show($"订单已找到：\n" +
                          $"OrderID: {sameOrder.Single().OrderId}\n" +
                          $"Customer Name: {sameOrder.Single().OrderDetails.CustomerName}\n" +
                          $"Product Name: {sameOrder.Single().OrderDetails.GoodsName}\n" +
                          $"Order Date: {sameOrder.Single().OrderDetails.OrderDate}\n" +
                          $"Order Price: {sameOrder.Single().OrderDetails.OrderPrice}");
    }
    public void FindAOrderByPrice(int thisPrice)
    {
        var sameOrder = from ord in Orders
            where ord.OrderDetails.OrderPrice == thisPrice
            select ord;
        if (!sameOrder.Any())
        {
            MessageBox.Show("未查询到相关订单");
        }
        else
            MessageBox.Show($"订单已找到：\n" +
                          $"OrderID: {sameOrder.Single().OrderId}\n" +
                          $"Customer Name: {sameOrder.Single().OrderDetails.CustomerName}\n" +
                          $"Product Name: {sameOrder.Single().OrderDetails.GoodsName}\n" +
                          $"Order Date: {sameOrder.Single().OrderDetails.OrderDate}\n" +
                          $"Order Price: {sameOrder.Single().OrderDetails.OrderPrice}");
    }
    public void ChangeAOrderById(int thisOrderId,string newCustomerName,string newGoodsName)
    {
        var sameOrder = from ord in Orders
            where ord.OrderId == thisOrderId
            select ord;
        if (!sameOrder.Any())
        {
            MessageBox.Show("未查询到相关订单");
        }
        else
        {
            sameOrder.Single().OrderDetails.CustomerName = newCustomerName;
            sameOrder.Single().OrderDetails.GoodsName = newGoodsName;
            MessageBox.Show($"订单已修改，新的信息是：\n" +
                              $"OrderID: {sameOrder.Single().OrderId}\n" +
                              $"Customer Name: {sameOrder.Single().OrderDetails.CustomerName}\n" +
                              $"Product Name: {sameOrder.Single().OrderDetails.GoodsName}\n" +
                              $"Order Date: {sameOrder.Single().OrderDetails.OrderDate}\n" +
                              $"Order Price: {sameOrder.Single().OrderDetails.OrderPrice}");
        }
    }
}