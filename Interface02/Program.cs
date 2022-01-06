using System;

namespace Interface02
{
    interface IRun
    {
        void Run();
    }
    interface IEat
    {
        void Eat();
    }
    interface ISleep
    {
        void Sleep();
    }

    class Horse : IRun, IEat, ISleep
    {
        public void Run()
        {
            Console.WriteLine("말이 달린다");
        }
        public void Eat()
        {
            Console.WriteLine("말이 먹는다");
        }
        public void Sleep()
        {
            Console.WriteLine("말이 잠을 잔다");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Horse horse = new Horse();
            horse.Run();
            horse.Eat();
            horse.Sleep();

        }
    }
}
