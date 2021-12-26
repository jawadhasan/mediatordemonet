using MediatorDemo.App.ChatDemo;
using MediatorDemo.App.LocationDemo;
using System;

namespace MediatorDemo.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //mediator
            var markerMediator = new MarkerMediator();

            //colleauges
            var marker1 = markerMediator.CreateMarker();
            var marker2 = markerMediator.CreateMarker();

            //Messaging
            marker1.SendLocation(new LocationData {
                TimeStamp = DateTime.UtcNow,
                Latitude = 1134,
                Longitude = 1123                
            });


            //ChatRoomDemo();
            //ControlCenterDemo();
            Console.ReadLine();
        }


        public static void ChatRoomDemo()
        {
            //Create a ChatRoom
            var breakingBadChatRoom = new GeneralChatRoom();

            //ChatRoom Members
            var walter = new Developer("Walter White");
            var jessy = new Developer("Jesse Pinkman");
            var gustavo = new Tester("Gustavo Fring");
            var badger = new Tester("Badger Mayhew");

            //Register Members
            breakingBadChatRoom.RegisterMembers(walter, jessy, gustavo, badger);

            //Messaging
            walter.Send("Hay everyone...."); // on public window

            Console.WriteLine($"==================SendTo<T>Demo==================");
            walter.SendTo<Tester>("Hi"); //to Testers only
        }

        public static void ControlCenterDemo()
        {
            var vehicle1 = new Vehicle("Reg1");
            var vehicle2 = new Vehicle("Reg2");
            var vehicle3 = new Vehicle("Reg3");

            var controlCenter = new ControlCenter();

            vehicle1.Move();
            vehicle2.Move();
            vehicle3.Move();
        }
    }
}
