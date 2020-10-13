using System;

namespace MediatorPatternSample
{
    public class ConcreteUser : User
    {
        public ConcreteUser(IMediator mediator, string userName) : base(mediator, userName) { }

        public override void Receive(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\t{UserName} (Received Message) > {message}");
        }

        public override void Send(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{UserName} (Sending Message) > {message}");
            Mediator.SendMessage(this, message);
        }
    }
}
