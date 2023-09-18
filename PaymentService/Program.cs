using System;
using System.Collections.Generic;
using Handlers.Abstraction;
using Handlers.Animals;
using Handlers.Flows;

namespace PaymentService
{
    internal static class Client
    {
        // The client code is usually suited to work with a single handler. In
        // most cases, it is not even aware that the handler is part of a chain.
        public static void ClientCode(AbstractHandler handler)
        {
            foreach (var food in new List<string> { "Nut", "Banana", "Cup of coffee" })
            {
                Console.WriteLine($"Client: Who wants a {food}?");

                var result = handler.Handle(food);

                if (result != null)
                {
                    Console.Write($"   {result}");
                }
                else
                {
                    Console.WriteLine($"   {food} was left untouched.");
                }
            }
        }
        
        public static void ClientCode(IFlow handler)
        {
            foreach (var food in new List<string> { "Nut", "Banana", "Cup of coffee" })
            {
                Console.WriteLine($"Client: Who wants a {food}?");

                var result = handler.TriggerFlow(food);

                if (result != null)
                {
                    Console.Write($"   {result}");
                }
                else
                {
                    Console.WriteLine($"   {food} was left untouched.");
                }
            }
        }
    }
    
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var monkey = new HasParseableContentHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();
            var animalFlow = new MonkeySquirrelDogFlow(monkey, squirrel, dog);
            
            Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
            Client.ClientCode(animalFlow);
            Console.WriteLine();

            Console.WriteLine("Subchain: Squirrel > Dog\n");
            Client.ClientCode(squirrel);
        }
    }
}