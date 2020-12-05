using System;

namespace mediatordemonet
{
    class Program
    {
        static void Main(string[] args)
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
