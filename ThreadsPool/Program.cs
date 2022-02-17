using System;
using System.Threading;

namespace ThreadsPool
{
    // 스레드 개수를 제어하지 못하면 오히려 프로그램 성능을 떨어뜨린다
    
    // ThreadPool
    // 스레드 개수를 관리해주는 기능

    // 스레드로 넘기는 파라미터 클래스
    class Node
    {
        // 콘솔 출력 시, 사용되는 텍스트
        public string Text { get; set; }

        // 반복문 횟수
        public int Count { get; set; }

        // Sleep의 시간 틱
        public int Tick { get; set; }
    }

    class Program
    {
        // 스레드 실행 함수
        static void ThreadProc(Object callBack)
        {
            // 파라미터 값이 Node 클래스가 아니면 종료
            if (callBack.GetType() != typeof(Node)) return;

            // 노드 타입으로 강제 캐스트(자료형이 Object 타입)
            var node = (Node)callBack;

            // 설정된 반복문의 횟수만큼
            for(int i = 0; i < node.Count; i++)
            {
                // 콘솔 출력
                Console.WriteLine(node.Text + " = " + i);
                // 설정된 Sleep 시간 틱
                Thread.Sleep(node.Tick);
            }
            // 완료 콘솔 출력
            Console.WriteLine("Complete " + node.Text);

        }

        // ThreadPool 클래스를 이용하여 총 5개의 스레드 실행
        // ThreadPool에서 스레드의 개수를 0개~2개로 설정
        // 스레드를 무한히 생성하지 않고 pool 안에서 총량을 설정하여 그 이상은 대기 상태로 넘긴다
        static void eMain(string[] args)
        {
            // ThreadPool의 최소 스레드는 0, 최대 스레드는 2개로 설정
            // 참고: 두 번째 파라미터는 비동기 I/O 스레드 개수(0으로 설정해도 무방)
            if (ThreadPool.SetMinThreads(0,0) && ThreadPool.SetMaxThreads(2, 0))
            {
                // ThreadPool에 등록, 델리게이트 함수로 ThreadProc 등록
                // 파라미터로 Node 인스턴스를 생성해서 넘긴다
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node { Text = "A", Count = 3, Tick = 1000 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node { Text = "B", Count = 5, Tick = 10 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node { Text = "C", Count = 2, Tick = 500 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node { Text = "D", Count = 7, Tick = 300 });
                ThreadPool.QueueUserWorkItem(ThreadProc, new Node { Text = "E", Count = 4, Tick = 200 });

                // 결과
                // A와 B는 동시에 실행되지만 C부터는 B가 종료된 시점부터 실행

                // ThreadPool 관리
                // 스레드를 최대 2개까지 생성하고 그 이상은 실행하지 않는 설정
            }

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
