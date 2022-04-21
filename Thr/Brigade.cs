namespace Thr
{
    public class Brigade
    {
        public Brigade(int number)
        {
            Number = number;
            brigade = new (1, 1);
        }

        public int Number { get; set; }
        public Semaphore brigade { get; set; }
    }
}
