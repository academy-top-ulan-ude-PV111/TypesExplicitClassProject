namespace TypesExplicitClassProject
{
    class StopWatch
    {
        public int Seconds { set; get; }

        public static implicit operator StopWatch(int number)
        {
            return new StopWatch { Seconds = number };
        }

        public static explicit operator int(StopWatch obj)
        {
            return obj.Seconds;
        }

        public static explicit operator StopWatch(Timer timer)
        {
            int s = timer.Hours * 3600 + timer.Minutes * 60 + timer.Seconds;
            return new StopWatch { Seconds = s };
        }

        public static implicit operator Timer(StopWatch obj)
        {
            int hours = obj.Seconds / 3600;
            int minutes = (obj.Seconds % 3600) / 60;
            int seconds = obj.Seconds % 60;
            return new Timer { Hours = hours, Minutes = minutes, Seconds = seconds };
        }

        public override string ToString()
        {
            return $"stopwatch: {Seconds}s";
        }
    }

    class Timer
    {
        public int Hours { set; get; }
        public int Minutes { set; get; }
        public int Seconds { set; get; }

        public override string ToString()
        {
            return $"timer: {Hours}h:{Minutes}m:{Seconds}s";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StopWatch stopWatch = new StopWatch();

            stopWatch = 5000;

            int n = (int)stopWatch + 10;

            Console.WriteLine(stopWatch);

            Timer timer = new Timer();

            timer = stopWatch;

            StopWatch stopWatch1 = (StopWatch)timer;

            Console.WriteLine(timer);

            Console.WriteLine(stopWatch.Seconds);
        }
    }
}