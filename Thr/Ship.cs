using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Thr
{
    public class Ship : AShip
    {
        public Ship(int quantity, int counter, Semaphore port, Semaphore tunnel, List<Brigade> brigades, int number) :
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

            Port.WaitOne();
            Tunnel.Release();
            // освобождение места в туннеле только после того, как корабль пришел в порт

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(string.Format("Корабль №{0} прибыл в порт", Counter));

            var currentBrigade = Brigades.First(br => br.Number == Number);
            currentBrigade.brigade.WaitOne();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(string.Format("Бригада {0} начала разгрузку корабля №{1}", currentBrigade.Number, Counter));

            Thread.Sleep(1000 * Quantity); //симуляцияя разгрузки

            Console.ResetColor();
            Console.WriteLine(string.Format("Корабль №{0} был разгружен", Counter));

            currentBrigade.brigade.Release();
            Port.Release();
        }
    }
}
