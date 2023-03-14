using System;
using System.Collections.Generic;

namespace WorkingWithPriorityQueues
{
    public class Resturaunt
    {
        public string Menu { get; set; } = string.Empty;
        public int List { get; set; }
        public Resturaunt(string menu, int list)
        {
            Menu = menu;
            List = list;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var food = new List<(Resturaunt, int)>()
            {
             (new("Steak", 5), 4),
             (new("Bread", 8), 5),
             (new("Water", 2), 1),
             (new("Fish", 1), 2),
             (new("Shrimp", 6), 3)
            };
            
            var resturauntQueue = new PriorityQueue<Resturaunt, int>(food);
            int selection = Menu();
            string menu;
            int list, priority;
            while (selection != 4)
            {
                switch (selection)
                {
                    case 1: 
                        Console.WriteLine("Item name: ");
                        menu = Console.ReadLine();
                        Console.WriteLine("Item Number: ");
                        list = int.Parse(Console.ReadLine());
                        Console.WriteLine(" Priority: ");
                        priority = int.Parse(Console.ReadLine());
                        resturauntQueue.Enqueue(new Resturaunt(menu, list), priority);
                        break;
                    case 2:
                        resturauntQueue.TryPeek(out Resturaunt nextItem, out int Priority);
                        Console.WriteLine($"Highest priority item: {nextItem.Menu}, Listing Number {nextItem.List}");
                        break;
                    case 3: 
                        resturauntQueue.TryDequeue(out Resturaunt eatFood, out int dischargePriority);
                        Console.WriteLine($"You ate: {eatFood.Menu}, Listing Number {eatFood.List}");
                        break;
                    default:
                        Console.WriteLine("You have made an invalid selection, please try again");
                        break;
                }
                selection = Menu();
            }

        }
        static int Menu()
        {
            Console.WriteLine("Menu Priority Queue");
            Console.WriteLine("1 to Add a Food Item\n2 to View the Highest Priority Food Item\n3 to Eat\n4 to Quit");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}
