using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatorDemo.App.ChatDemo
{
    //Abstract Mediator
    public abstract class ChatRoom
    {
        public abstract void Register(ChatRoomMember member);
        public abstract void Send(string from, string message);
        public abstract void SendTo<T>(string from, string message) where 
            T: ChatRoomMember;
    }

    //Concrete Mediator (e.g. TeamChatRoom)
    public class GeneralChatRoom : ChatRoom
    {
        private List<ChatRoomMember> members = new List<ChatRoomMember>();

        public override void Register(ChatRoomMember member)
        {
            //bi-directional references
            member.SetChatRoom(this);
            this.members.Add(member);
        }
        public override void Send(string from, string message)
        {
            this.members.ForEach(m => m.Recieve(from, message));
        }

        //convenince method to register multiple members
        public void RegisterMembers(params ChatRoomMember[] teamMembers)
        {
            foreach(var member in teamMembers)
            {
                this.Register(member);
            }
        }

        public override void SendTo<T>(string from, string message)
        {
            this.members.OfType<T>()
                .ToList()
                .ForEach(m => m.Recieve(from, message));
        }
    }


    //Abstract Collegue
    public abstract class ChatRoomMember
    {
        public string Name { get; }
        private ChatRoom _chatRoom;
        public ChatRoomMember(string name)
        {
            this.Name = name;
        }
        internal void SetChatRoom(ChatRoom chatRoom)
        {
            this._chatRoom = chatRoom;
        }
        public void Send(string message)
        {
            this._chatRoom.Send(this.Name, message);
        }
        public void SendTo<T>(string message) where 
            T: ChatRoomMember
        {
            this._chatRoom.SendTo<T>(this.Name, message);
        }
        public virtual void Recieve(string from, string message)
        {
            Console.WriteLine($"----Received Action for Member: {this.Name} in baseClass ----");       
        }
    }

    //Concerte Collegues
    public class Developer: ChatRoomMember
    {
        public Developer(string name):base(name)
        {
        }

        public override void Recieve(string from, string message)
        {
            Console.WriteLine($"{this.Name} ({nameof(Developer)}) has recieved {message} ");
            base.Recieve(from, message);
        }

    }
    public class Tester: ChatRoomMember
    {
        public Tester(string name):base(name)
        {
        }
    }

}
