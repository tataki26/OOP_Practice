using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task
{
    // Task는 async, await 키워드와 매우 밀접한 관계가 있다

    class Node2
    {
        public string Text { get; set; }
        public int Count { get; set; }
        public int Tick { get; set; }
    }

    class Program2
    {
        private static async Task<int> RunAsync(Node2 node)
        {
            var task = new Task<int>(() =>
            {
                int sum = 0;
                for (int i = 0; i <= node.Count; i++)
                {
                    sum += i;
                    Console.WriteLine(node.Text + " = " + i);
                    Thread.Sleep(node.Tick);
                }
                Console.WriteLine("Completed " + node.Text);
                return sum;
            });

            task.Start();
            // task가 종료될 때까지 대기
            await task;
            // task의 결과 리턴
            return task.Result;
        }

        // 실행 결과는 Program.cs와 같지만 Task를 다루기 쉽게 구현되었다
        // async가 선언된 함수에서 Task를 실행하고 await으로 스레드가 종료될 때까지 대기한다
        // 그리고 그 결과를 리턴하게 되면 Main 프로세스에서 결과를 합산하여 나온다

        static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(0, 0);
            ThreadPool.SetMaxThreads(2, 0);

            var list = new List<Task<int>>();

            /*
            list.Add(RunAsync(new Node2 { Text = "A", Count = 5, Tick = 1000 }));
            list.Add(RunAsync(new Node2 { Text = "B", Count = 5, Tick = 10 }));
            list.Add(RunAsync(new Node2 { Text = "C", Count = 5, Tick = 500 }));
            list.Add(RunAsync(new Node2 { Text = "D", Count = 5, Tick = 300 }));
            list.Add(RunAsync(new Node2 { Text = "E", Count = 5, Tick = 200 }));
            */

            // ContinueWith 함수
            // 스레드가 종료되면 이어서 처리되는 람다식 처리
            // 상황에 따라 다른 Task 스레드를 붙일 수도 있고 여러 가지 실행을 연결해서 구현할 수 있는 함수
            // ContinueWith 함수를 사용하여 스레드의 결과를 받으면 계산을 추가한다
            list.Add(RunAsync(new Node2 { Text = "A", Count = 5, Tick = 1000 }).ContinueWith(x => x.Result * 100));
            list.Add(RunAsync(new Node2 { Text = "B", Count = 5, Tick = 10 }).ContinueWith(x => x.Result * 100));
            list.Add(RunAsync(new Node2 { Text = "C", Count = 5, Tick = 500 }).ContinueWith(x => x.Result * 100));
            list.Add(RunAsync(new Node2 { Text = "D", Count = 5, Tick = 300 }).ContinueWith(x => x.Result * 100));
            list.Add(RunAsync(new Node2 { Text = "E", Count = 5, Tick = 200 }).ContinueWith(x => x.Result * 100));

            Console.WriteLine("Sum = " + list.Sum(x => x.Result));

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        // 결론
        // Task와 async, await 키워드를 활용하면 가독성이 높고 간편하게 병렬 처리를 구현할 수 있다
    }
}
