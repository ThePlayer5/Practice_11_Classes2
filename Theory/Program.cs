using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();
            Animal animal = new Animal();
            //animal.Bark();
            Console.ReadKey();
        }
    }
    public class Animal
    {
        public string Name; // Если свойство отвечает на вопрос кто? что?, то это переменная
        public Animal(string name)
        {
            name = Name;
        }
        public void Eat() // Если отвечает на вопрос что делает?, то это метод
        {
            Console.WriteLine($"{Name} eating");
        }
        public virtual void Move() // virtual - виртуальный метод, с помощью которого можно в другом классе изменять этот же метод
        {
            Console.WriteLine("Simple movements");
        }
    }
    public class Dog : Animal // Класс Dog наследует содержимое класса Animal
    {
        public Dog(string name) : base Animal(string name)
        {

        }
        public void Bark()
        {
            Console.WriteLine("Bark!");
        }
        public override void Move()
        {
            Console.WriteLine("Move like a dog");
        }
    }
}
