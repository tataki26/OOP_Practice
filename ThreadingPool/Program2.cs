using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingPool
{
    // ThreadPool은 Thread가 종료할 때까지 기다리는 Join 함수가 없다
    // 따라서, a가 끝나지 않은 상태에서 b가 끝나면 c가 실행된다(2개씩 유지)

    // 간단한 프로그램의 경우, 임의의 join 함수를 통해 제어 가능
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
            if (callBack.GetType() != typeof(Node2)) return;

            var node = (Node2)callBack;

            for (int i = 0; i < node.Count; i++)
            {
                Console.WriteLine(node.Text + " = " + i);

                Thread.Sleep(node.Tick);
            }
            Console.WriteLine("Complete " + node.Text);
        }

        // ThreadPool의 Join 설정
        // ThreadPool에 사용할 수 있는 스레드 개수를 확인해서 스레드 사용 최대량과 같으면 무한 루프 종료
        // 이렇게 하면 a와 b 모두가 끝난 후에 c,d가 실행된다
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

        static void cMain(string[] args)
        {
            if (ThreadPool.SetMinThreads(0, 0) && ThreadPool.SetMaxThreads(2, 0))
            {
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node2 { Text = "A", Count = 3, Tick = 100 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node2 { Text = "B", Count = 5, Tick = 10 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node2 { Text = "C", Count = 2, Tick = 500 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node2 { Text = "D", Count = 7, Tick = 300 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node2 { Text = "E", Count = 4, Tick = 200 });
            }

            // 총 2개의 스레드가 대기 상태가 될 때까지 대기
            ThreadPoolJoin(2);

            Console.WriteLine("Press any key...");
            Console.ReadLine();

        }

    }
}
