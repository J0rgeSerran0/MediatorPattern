using System;

namespace MediatorPatternSample
{
    public abstract class User
    {
        protected IMediator Mediator;
        protected string UserName = String.Empty;

        public User(IMediator mediator, string userName)
        {
            Mediator = mediator;
            UserName = userName;
        }

        public abstract void Send(string message);
        public abstract void Receive(string message);

        public string GetUserName() => UserName;
    }
}
