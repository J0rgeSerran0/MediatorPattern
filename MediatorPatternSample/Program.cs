using System;

namespace MediatorPatternSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IMediator mediator = new Mediator("Patterns for C# Group");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"GROUP '{mediator.GetGroupName()}' CREATED!");

            User jorge = new ConcreteUser(mediator, "Jorge");
            User maria = new ConcreteUser(mediator, "María");
            User carlos = new ConcreteUser(mediator, "Carlos");

            mediator.RegisterUser(jorge);
            mediator.RegisterUser(maria);
            mediator.RegisterUser(carlos);

            maria.Send("Hi all!");
            carlos.Send("Wow!, I love this group!");
            jorge.Send("Hi María and Carlos!");

            mediator.UnregisterUser(carlos);

            maria.Send("What happened?");

            mediator.RegisterUser(carlos);

            carlos.Send("Sorry guys, I had a problem");
            maria.Send("Oh, great!");

            Console.ResetColor();
            Console.WriteLine("\nPress any key to close\n");
            Console.ReadKey();
        }
    }
}
