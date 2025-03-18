using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_11_Classes2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            admin.ManageUsers();
            Customer customer = new Customer();
            customer.DisplayInfo();
            Product product = new Product();

            Console.ReadKey();      
        }
    }
    public class User
    {
        public string Name;
        public string Email;
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"У пользователя {Name} почта: {Email}");
        }
    }
    public class Customer:User
    {
        public int Balance;
        public Customer()
        {
            Name = "Vasya";
            Email = "vasya@gmail.com";
            Balance = 1000;
        }
        public void PlaceOrder(List<string> product)
        {
            Product product1 = new Product();
            product1.Name = "Bananas";
            product1.Price = 100;
            Console.WriteLine("Введите название товара: ");
            string user_product = Console.ReadLine();
            if (Balance >= product1.Price && product.Contains(user_product))
            {
                Console.WriteLine("Заказ оформлен");
                Balance -= product1.Price;
            }
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"У пользователя {Name} почта: {Email}, его баланс: {Balance} рублей");
        }
    }
    public class Admin:User
    {
        public void ManageUsers()
        {
            Console.WriteLine("Admin is managing users");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"У админа {Name} почта: {Email}");
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
        public List<string> Product = new List<string> { "Bananas", "Apples"};
        public void GetTotalPrice()
        {

        }

    }
}