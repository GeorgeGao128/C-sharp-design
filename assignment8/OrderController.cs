using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Assignment8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                using (var connection = DatabaseHelper.CreateNewConnection())
                {
                    string query = "SELECT * FROM orders";
                    var command = new MySqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    var orders = new List<Dictionary<string, object>>();
                    while (reader.Read())
                    {
                        var order = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            order[reader.GetName(i)] = reader.GetValue(i);
                        }
                        orders.Add(order);
                    }

                    return Ok(orders);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}