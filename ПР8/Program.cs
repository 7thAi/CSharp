using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();

        Console.Write("Введите количество заказов: ");
        int numberOfOrders = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfOrders; i++)
        {
            Console.Write($"Введите порядковый номер заказа {i + 1}: ");
            int orderId = int.Parse(Console.ReadLine());

            Console.Write("Введите имя клиента: ");
            string customerName = Console.ReadLine();

            Console.Write("Введите сумму заказа: ");
            decimal totalAmount = decimal.Parse(Console.ReadLine());

            orders.Add(new Order { OrderId = orderId, CustomerName = customerName, TotalAmount = totalAmount });
        }

        Console.WriteLine();
        Console.WriteLine("Информация о заказах:");
        foreach (var order in orders)
        {
            Console.WriteLine($"Заказ ID: {order.GetOrderId()}, Имя клиента: {order.GetCustomerName()}, Сумма заказа: {order.GetTotalAmount()}");
        }

        // Сортировка по сумме заказа
        orders.Sort();

        Console.WriteLine();
        Console.WriteLine("Заказы, отсортированные по сумме:");
        foreach (var order in orders)
        {
            Console.WriteLine($"Заказ ID: {order.GetOrderId()}, Имя клиента: {order.GetCustomerName()}, Сумма заказа: {order.GetTotalAmount()}");
        }

        Console.ReadLine();
    }
}

public interface IOrder
{
    int GetOrderId();
    string GetCustomerName();
    decimal GetTotalAmount();
}

public class Order : IOrder, IComparable<Order>
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }

    public int GetOrderId() => OrderId;
    public string GetCustomerName() => CustomerName;
    public decimal GetTotalAmount() => TotalAmount;

    // Реализация метода сравнения для сортировки по сумме заказа
    public int CompareTo(Order other)
    {
        return TotalAmount.CompareTo(other.TotalAmount);
    }
}