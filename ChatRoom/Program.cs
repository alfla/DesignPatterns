using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ChatRoom
{
    public class Person
    {
        public string Name;
        public RoomChat roomChat;
        private List<string> chatLog = new List<string>();

        public Person(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Say(string message)
        {
            roomChat.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            roomChat.Message(Name, who, message);
        }

        public void Receive(string sender, string message)
        {
            string s = $"{sender}: '{message}'";
            chatLog.Add(s);
            WriteLine($"[{Name}' chat session] {s}");
        }
    }

    public class RoomChat
    {
        private List<Person> people = new List<Person>();

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            Broadcast("room", joinMsg);

            p.roomChat = this;
            people.Add(p);
        }

        public void Broadcast(string source, string message)
        {
            foreach (var p in people)
            {
                if (p.Name != source)
                    p.Receive(source, message);
            }
        }

        public void Message(string source, string destination, string message)
        {
            people.FirstOrDefault(p => p.Name == destination)
                ?.Receive(source, message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var room = new RoomChat();

            var jhon = new Person("Jhon");
            var jane = new Person("Jane");


            room.Join(jhon);
            room.Join(jane);

            jhon.Say("Hi");
            jane.Say("oh, hey jhon");

            var simon = new Person("Simon");
            room.Join(simon);

            simon.Say("hi everyone");
            jane.PrivateMessage("Simon", "glad you could join us!");


            ReadKey();
            //Console.WriteLine("Hello World!");
        }
    }
}
