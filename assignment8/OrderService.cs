namespace Assignment8;

using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Data;
using System.Diagnostics;


public class OrderService
{
    List<Order> Orders=new List<Order>();
    static int anID = 0;
    static Random random = new Random();

    private void EnsureConnectionOpen(MySqlConnection connection)
    {
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }
    }

    public void AddOrder(string customerName,string goodsName)
    {
        
        const string sql = @"INSERT INTO orders (order_customerName, order_goodsName, order_ID,order_price,order_date) 
                         VALUES (@name, @product,@ID,@price,@date)";
        using (var connection = DatabaseHelper.CreateNewConnection())
        using (var cmd = new MySqlCommand(sql, connection))
        {
            EnsureConnectionOpen(connection);
            cmd.Parameters.AddWithValue("@name", customerName);
            cmd.Parameters.AddWithValue("@product", goodsName);
            anID++;
            cmd.Parameters.AddWithValue("@ID", anID);
            cmd.Parameters.AddWithValue("@price", random.Next(100, 1000) );
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.ExecuteNonQuery();
            
          

        }

    }

    public bool DeleteOrder(int thisOrderId)
    {
        // 使用事务确保操作原子性
        using (var connection = DatabaseHelper.CreateNewConnection())
        {
            try
            {
                EnsureConnectionOpen(connection);

                // 检查订单是否存在
                const string checkSql = "SELECT COUNT(*) FROM orders WHERE order_ID = @id";
                bool orderExists;

                using (var checkCmd = new MySqlCommand(checkSql, connection))
                {
                    checkCmd.Parameters.AddWithValue("@id", thisOrderId);
                    orderExists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                }

                if (orderExists)
                {
                    // 删除订单
                    const string deleteSql = "DELETE FROM orders WHERE order_ID = @delete_id";
                    using (var deleteCmd = new MySqlCommand(deleteSql, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@delete_id", thisOrderId);
                        deleteCmd.ExecuteNonQuery();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }

    public Order FindAOrderById(int orderId)
    {
        const string sql = "SELECT * FROM orders WHERE order_ID = @id";

        using (var connection = DatabaseHelper.CreateNewConnection())
        using (var cmd = new MySqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@id", orderId); // 修正参数名

            try
            {
                EnsureConnectionOpen(connection);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Order
                        {
                            OrderId = reader.GetInt32("order_ID"),
                            OrderDetails = new OrderDetails
                            {
                                CustomerName = reader.GetString("order_customerName"),
                                GoodsName = reader.GetString("order_goodsName"),
                                OrderDate = reader.GetDateTime("order_date"),
                                OrderPrice = reader.GetInt32("order_price")
                            }
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show($"查询失败: {ex.Message}");
                throw; // 根据需求选择是否抛出异常
            }
        }
        return null;
    }


    public Order FindAOrderByGoodsname(string thisgoodsName)
    {
        const string sql = "SELECT * FROM orders WHERE order_goodsName = @name";

        using (var connection = DatabaseHelper.CreateNewConnection())
        using (var cmd = new MySqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@name", thisgoodsName); // 修正参数名

            try
            {
                EnsureConnectionOpen(connection);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Order
                        {
                            OrderId = reader.GetInt32("order_ID"),
                            OrderDetails = new OrderDetails
                            {
                                CustomerName = reader.GetString("order_customerName"),
                                GoodsName = reader.GetString("order_goodsName"),
                                OrderDate = reader.GetDateTime("order_date"),
                                OrderPrice = reader.GetInt32("order_price")
                            }
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }
        return null;
    }


    public Order FindAOrderByCustomer(string thisCustomerName)
    {
        const string sql = "SELECT * FROM orders WHERE order_customerName = @name";

        using (var connection = DatabaseHelper.CreateNewConnection())
        using (var cmd = new MySqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@name", thisCustomerName); // 修正参数名

            try
            {
                EnsureConnectionOpen(connection);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Order
                        {
                            OrderId = reader.GetInt32("order_ID"),
                            OrderDetails = new OrderDetails
                            {
                                CustomerName = reader.GetString("order_customerName"),
                                GoodsName = reader.GetString("order_goodsName"),
                                OrderDate = reader.GetDateTime("order_date"),
                                OrderPrice = reader.GetInt32("order_price")
                            }
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show($"查询失败: {ex.Message}");
                throw; // 根据需求选择是否抛出异常
            }
        }
        return null;
    }
    public Order FindAOrderByPrice(int thisPrice)
    {
        const string sql = "SELECT * FROM orders WHERE order_price = @price";

        using (var connection = DatabaseHelper.CreateNewConnection())
        using (var cmd = new MySqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@price", thisPrice); // 修正参数名

            try
            {
                EnsureConnectionOpen(connection);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Order
                        {
                            OrderId = reader.GetInt32("order_ID"),
                            OrderDetails = new OrderDetails
                            {
                                CustomerName = reader.GetString("order_customerName"),
                                GoodsName = reader.GetString("order_goodsName"),
                                OrderDate = reader.GetDateTime("order_date"),
                                OrderPrice = reader.GetInt32("order_price")
                            }
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw; // 根据需求选择是否抛出异常
            }
        }
        return null;
    }
    public Order ChangeAOrderById(int thisOrderId,string newCustomerName,string newGoodsName)
    {
        const string sql = @"UPDATE orders 
                        SET order_customerName = @customerName, 
                            order_goodsName = @productName
                        WHERE order_ID = @id";

        using (var connection = DatabaseHelper.CreateNewConnection())
        using (var cmd = new MySqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("@customerName", newCustomerName);
            cmd.Parameters.AddWithValue("@productName", newGoodsName);
            cmd.Parameters.AddWithValue("@id", thisOrderId);

            try
            {
                EnsureConnectionOpen(connection);
                int affectedRows = cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                if (reader.Read())
                {
                    return new Order
                    {
                        OrderId = reader.GetInt32("order_ID"),
                        OrderDetails = new OrderDetails
                        {
                            CustomerName = reader.GetString("order_customerName"),
                            GoodsName = reader.GetString("order_goodsName"),
                            OrderDate = reader.GetDateTime("order_date"),
                            OrderPrice = reader.GetInt32("order_price")
                        }
                    };
                }
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }
        return null;
    }
}