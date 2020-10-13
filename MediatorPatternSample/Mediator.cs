using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatorPatternSample
{
    public class Mediator : IMediator
    {
        private string _groupName = String.Empty;
        private List<User> _users = new List<User>();

        public Mediator(string groupName) => _groupName = groupName;

        public string GetGroupName() => _groupName;

        public void RegisterUser(User user)
        {
            var userIsFound = _users.Where(q => q == user).Count() > 0 ? true : false;

            if (!userIsFound)
            {
                _users.Add(user);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{user.GetUserName()} (has joined to the group '{_groupName}'!)");
            }
        }

        public void SendMessage(User user, string message)
        {
            foreach (var userGroup in _users)
                if (userGroup != user)
                    userGroup.Receive(message);
        }

        public void UnregisterUser(User user)
        {
            foreach (var userGroup in _users)
            {
                if (userGroup == user)
                {
                    _users.Remove(user);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{user.GetUserName()} (has left the group '{_groupName}'!)");
                    break;
                }
            }
        }
    }
}
