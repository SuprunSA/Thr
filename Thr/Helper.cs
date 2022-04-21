namespace Thr
{
    public class Helper
    {
        private static readonly IEnumerable<int> cargo = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static Semaphore port;
        private static Semaphore tunnel;
        public static void CreateShips(int n, int p, int t, int seed = 0)
        {
            var rnd = new Random(seed);

            port = new(p, p);
            tunnel = new(t, t);
            List<Brigade> brigades = new();

            for (int i = 0; i < p / 2; i++)
            {
                brigades.Add(new(i + 1));
            }

            var num = brigades.Count;
            List<int> parametrs = new();

            for (int i = 0; i < brigades.Count; i++)
            {
                parametrs.Add(rnd.Next(num + 1));
            }

            for (int i = 1; i < parametrs.Count; i++)
            {
                parametrs[i] += parametrs[i - 1];
            }

            var sum = parametrs.Last();

            for (int i = 0; i < n; i++)
            {
                var next = rnd.Next(sum + 1);
                var number = parametrs.First(x => x >= next);
                number = parametrs.IndexOf(number) + 1;
                new TunnelShip(cargo.ElementAt(rnd.Next(8)), i + 1, port, tunnel, brigades, number);
            }
        }

        public static void ReadParams(out int n, out int p, out int t)
        {
            Console.Write("Введите воличество кораблей >> ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Введите поличество разгрузочных мест в порту >> ");
            p = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Введите максимальное количество мест в туненеле >> ");
            t = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }
    }
}
