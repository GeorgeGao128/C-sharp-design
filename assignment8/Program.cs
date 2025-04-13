using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using MySql.Data.MySqlClient;
using Assignment8;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<DatabaseHelper>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var orderService = new OrderService();
orderService.AddOrder("Mike","milk");
orderService.AddOrder("Jack","water");
orderService.AddOrder("George","computer");
orderService.AddOrder("Linda","candy");
orderService.AddOrder("Tina","phone");
// 添加订单
app.MapPost("/orders/post/{customerName}/{goodsName}", async context =>
{
    string customerName=context.Request.RouteValues["customerName"].ToString();
    string goodsName=context.Request.RouteValues["goodsName"].ToString();
      
    if (customerName != null&&goodsName!=null)
    {
        orderService.AddOrder(customerName,goodsName);
        await context.Response.WriteAsJsonAsync("成功添加！");
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("添加失败：不合法的输入");
    }
});


// 根据 ID 获取订单
app.MapGet("/orders/get/{orderId}", async context =>
{
    if (int.TryParse(context.Request.RouteValues["orderId"]?.ToString(), out int orderId))
    {
        var order = orderService.FindAOrderById(orderId);
        if (order != null)
        {
            await context.Response.WriteAsJsonAsync(order.show());
        }
        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("未找到订单：请检查您的输入");
        }
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("输入的ID不合法");
    }
});

// 更新订单
app.MapPut("/orders/put/{orderId}/{customerName}/{goodsName}", async context =>
{
    if (int.TryParse(context.Request.RouteValues["orderId"]?.ToString(), out int orderId))
    {
        string customerName=context.Request.RouteValues["customerName"].ToString();
        string goodsName=context.Request.RouteValues["goodsName"].ToString();
        if (customerName!=null&&goodsName!=null)
        {
            
            orderService.ChangeAOrderById(orderId,customerName,goodsName);
            await context.Response.WriteAsJsonAsync("修改成功！");
        }
        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("修改失败：非法的输入");
        }
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("修改失败：非法的ID");
    }
});

// 删除订单
app.MapDelete("/orders/delete/{orderId}", async context =>
{
    int.TryParse(context.Request.RouteValues["orderId"]?.ToString(), out int orderId);
    if(orderService.DeleteOrder(orderId)){
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("删除成功！");
    }
    else{
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("删除失败！");
    }
});


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run("http://0.0.0.0:5293" );

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
