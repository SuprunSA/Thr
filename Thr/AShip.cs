using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Thr
{
    public abstract class AShip
    {
        public Thread Handler { get; set; }
        public static Semaphore Tunnel { get; set; }
        public static Semaphore Port { get; set; }
        public int Quantity { get; }
        public int Counter { get; }
        public int Number { get; }
        public List<Brigade> Brigades { get; set; }

        public AShip(int quantity, int counter, Semaphore port, Semaphore tunnel, List<Brigade> brigades, int number)
        {
            Quantity = quantity;
            Counter = counter;
            Port = port;
            Tunnel = tunnel;
            Brigades = brigades;
            Number = number;

            Handler = new(Handle);
            Handler.Start();
        }

        public abstract void Handle();
    }
}
