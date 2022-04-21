using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Thr
{
    public class TunnelShip : Ship
    {
        public TunnelShip(int quantity, int counter, Semaphore port, Semaphore tunnel, List<Brigade> brigades, int number) :
            base(quantity, counter, port, tunnel, brigades, number)
        { }

        public override void Handle()
        {
            Tunnel.WaitOne();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(string.Format("Корабль №{0} прибыл в туннель", Counter));
            Thread.Sleep(1000 * Quantity); //симуляцияя прохода через туннель
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(string.Format("Корабль №{0} прошел туннель", Counter));
            Map(this);
        }

        public PortShip Map(TunnelShip tunnelShip)
        {
            return new(tunnelShip.Quantity, tunnelShip.Counter, Port, Tunnel, tunnelShip.Brigades, tunnelShip.Number);
        }
    }
}
