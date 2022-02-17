using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingPool
{
    // 큰 프로그램의 경우, ThreadPool 클래스 특성이 static이기 때문에 어느 곳에서 사용되는지 확인하기 어렵다
    // 설계하고 있는 곳에서 ThreadPool 사용이 종료되었다고 해도 다른 라이브러리나 클래스에서 ThreadPool을 사용한다고 하면,
    // 대기 상태의 개수만으로 대기를 만드는 것은 예상치 못한 버그를 발생시킬 수 있다

    // 이를 해결하기 위해 Task에서 사용되는 EventWaitHandle을 통해 부분적으로 ThreadPool을 제어할 수 있다

    // 스레드로 넘기는 파라미터 클래스
    // EventWaitHandle 클래스의 상속
    public class Node3: EventWaitHandle
    {
        // 생성자 설정
        public Node3() : base(false, EventResetMode.ManualReset) { }
        
        public string Text { get; set; }
        public int Count { get; set; }
        public int Tick { get; set; }
       
    }

    class Program3
    {
        static void ThreadProc(Object callBack)
        {
            if (callBack.GetType() != typeof(Node3)) return;

            var node = (Node3)callBack;

            for(int i = 0; i < node.Count; i++)
            {
                Console.WriteLine(node.Text + " = " + i);
                Thread.Sleep(node.Tick);
            }
            Console.WriteLine("Complete " + node.Text);
            // EventWaitHandle의 Join 설정 종료
            node.Set();

        }

        // Node 클래스의 인스턴스를 추가한 후 List에 등록
        static EventWaitHandle AddNode(List<EventWaitHandle> list, string text, int count, int tick)
        {
            // 인스턴스 생성
            var node = new Node3 { Text = text, Count = count, Tick = tick };
            
            // 리스트에 등록
            list.Add(node);

            return node;
        }

        static void Main(string[] args)
        {
            // Join을 위한 EventWaitHandle 리스트
            var list = new List<EventWaitHandle>();

            if (ThreadPool.SetMinThreads(0, 0) && ThreadPool.SetMaxThreads(2, 0))
            {
                ThreadPool.QueueUserWorkItem(ThreadProc, AddNode(list, "A", 3, 1000));
                ThreadPool.QueueUserWorkItem(ThreadProc, AddNode(list, "B", 5, 10));
                ThreadPool.QueueUserWorkItem(ThreadProc, AddNode(list, "C", 2, 500));
                ThreadPool.QueueUserWorkItem(ThreadProc, AddNode(list, "D", 7, 300));
                ThreadPool.QueueUserWorkItem(ThreadProc, AddNode(list, "E", 4, 200));
            }

            // list를 로컬 변수로 지정해서 WaitHandle.WaitAll에서 배열로 변환하게 되면 ThreadPool이 종료될 때까지 제어 가능
            // list에 있는 EventWaitHandle 함수에서 전부 Set이 호출되면 Join 해제
            WaitHandle.WaitAll(list.ToArray());

            // ThreadPool이 전체 사용 중인 스레드 개수를 제어할 수 있다는 점은 편리하지만
            // 생성한 스레드를 기다리는 것을 설정하는 작업이 불편하다
            // 따라서, 성능을 위해서는 스레드를 그대로 사용하는 것보다 ThreadPool을 이용하는 것이 시스템 성능을 위해 더 나은 선택일 수 있다

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
