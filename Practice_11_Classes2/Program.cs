using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_11_Classes2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> prices = new Dictionary<string, int>()
            {
                {"Bananas", 100},
                {"Apples", 50},
                {"Laptop", 1500}
            };

            Admin admin = new Admin();
            admin.Name = "Admin";
            admin.Email = "admin@example.com";
            admin.ManageUsers();
            admin.DisplayInfo();

            Console.WriteLine();
            Customer customer = new Customer();
            customer.Name = "Vasya";
            customer.Email = "vasya@gmail.com";
            customer.Balance = 1000;
            customer.DisplayInfo();

            Console.WriteLine();
            List<string> items1 = new List<string> { "Bananas", "Apples" };
            Console.WriteLine("Оформление заказа с продуктами Bananas и Apple, общая стоимость: 150");
            customer.PlaceOrder(items1, prices);
            customer.DisplayInfo();

            Console.WriteLine();
            List<string> items2 = new List<string> { "Laptop" };
            Console.WriteLine("Оформление заказа с продуктом Laptop, стоимость: 1500");
            customer.PlaceOrder(items2, prices);

            Console.WriteLine();
            List<string> items3 = new List<string> { };
            foreach (string item in items1)
            {
                items3.Add(item);
            }
            foreach (string item in items2)
            {
                items3.Add(item);
            }
            Order order = new Order(items3, prices);
            Console.WriteLine($"Общая стоимость товаров в заказе: {order.GetTotalPrice()}");

            Console.ReadKey();
        }
    }

    public class User
    {
        public string Name;
        public string Email;
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Пользователь: {Name}, Email: {Email}");
        }
    }

    public class Customer : User
    {
        public int Balance;
        public void PlaceOrder(List<string> productNames, Dictionary<string, int> prices)
        {
            int price = 0;
            foreach (string productName in productNames)
            {
                if (prices.ContainsKey(productName))
                {
                    price += prices[productName];
                }
            }
            if (Balance >= price)
            {
                Balance -= price;
                Console.WriteLine($"Заказ оформлен! Общая стоимость: {price}. Новый баланс: {Balance}");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств. Требуется: {price}, доступно: {Balance}");
            }
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Покупатель: {Name}, Email: {Email}, Баланс: {Balance}");
        }
    }

    public class Admin : User
    {
        public void ManageUsers()
        {
            Console.WriteLine("Администратор управляет пользователями");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Администратор: {Name}, Email: {Email}");
        }
    }

    public class Product
    {
        public string Name;
        public int Price;
    }

    public class Order 
    {
        public string Customer;
        public List<string> ProductNames;
        public Dictionary<string, int> Prices;
        public Order(List<string> productNames, Dictionary<string, int> prices)
        {
            Prices = prices;
            ProductNames = productNames;
        }
        public int GetTotalPrice()
        {
            int total = 0;
            foreach (string productName in ProductNames)
            {
                if (Prices.ContainsKey(productName))
                {
                    total += Prices[productName];
                }
            }
            return total;
        }
    }
}