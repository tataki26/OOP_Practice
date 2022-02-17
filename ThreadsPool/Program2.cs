using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadsPool
{
    // ThreadPool은 Thread가 종료할 때까지 기다리는 Join 함수가 없다

    class Node2
    {
        public string Text { get; set; }
        public int Count { get; set; }
        public int Tick { get; set; }
    }

    class Program2
    {
        static void ThreadProc(Object callBack)
        {
            if (callBack.GetType() != typeof(Node)) return;

            var node = (Node)callBack;

            for(int i = 0; i < node.Count; i++)
            {
                Console.WriteLine(node.Text + " = " + i);

                Thread.Sleep(node.Tick);
            }
            Console.WriteLine("Complete " + node.Text);
        }

        // ThreadPool의 Join 설정
        static void ThreadPoolJoin(int size)
        {
            // 무한 루프
            while (true)
            {
                // 1초 대기
                Thread.Sleep(1000);
                // 현재 대기 중인 스레드의 갯수를 취득하기 위한 변수
                int count = 0;
                int iocount = 0;

                // 현재 사용 가능한 스레드 개수 취득
                ThreadPool.GetAvailableThreads(out count, out iocount);

                // Max Thread와 같으면 무한 루프 종료
                if (count == size) break;
            }
        }

        static void Main(string[] args)
        {
            if(ThreadPool.SetMinThreads(0,0) && ThreadPool.SetMaxThreads(2, 0))
            {
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node { Text = "A", Count = 3, Tick = 100 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node { Text = "B", Count = 5, Tick = 10 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node { Text = "C", Count = 2, Tick = 500 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node { Text = "D", Count = 7, Tick = 300 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node { Text = "E", Count = 4, Tick = 200 });
            }

            // 총 2개의 스레드가 대기 상태가 될 때까지 대기
            ThreadPoolJoin(2);

            Console.WriteLine("Press any key...");
            Console.ReadLine();

        }

    }

}
