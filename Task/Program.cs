using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task
{
    // 정리
    // 스레드를 생성할 때는 시스템 상에서 여러 가지 리소스를 사용하게 된다
    // 따라서, 지나치게 많이 사용할 경우 시스템의 성능이 느려진다

    // 스레드 풀을 생성하면 스레드의 개수 제한과 스레드 리소스의 재활용을 통해 시스템 성능을 향상시킬 수 있다
    // but 스레드 상태를 제어할 수 없어서 스레드가 종료할 때까지 기다리는 것을 별도로 구현해야 하는 불편함 존재

    // Task
    // ThreadPool 안에서 움직이는 스레드
    // 스레드처럼 쉽게 생성 가능하며 Join 기능도 사용 가능하다
    // lock을 사용하지 않아도 각 스레드에서 결과 값을 받아서 각 메인 프로세스에서 사용 가능하다

    class Node
    {
        public string Text { get; set; }
        public int Count { get; set; }
        public int Tick { get; set; }
    }

    class Program
    {
        static void eMain(string[] args)
        {
            // ThreadPool의 최소 스레드는 0, 최대 스레드는 2개로 설정
            // ThreadPool에서 설정하는 스레드 제한 설정이 Task로 선언한 thread에도 영향을 미친다
            // 구현은 스레드처럼 간단하지만 내용은 ThreadPool에서 움직인다
            ThreadPool.SetMinThreads(0, 0);
            ThreadPool.SetMaxThreads(2, 0);

            // 리스트에 Task 설정
            var list = new List<Task<int>>();

            // Task에 사용될 람다식
            // 입력 값은 object 반환값은 int
            // ThreadPool과 다르게 return 값을 받을 수 있어서 1부터 5까지 더하면 15, 스레드가 총 5개이므로 총합 75의 결과가 나온다
            var func = new Func<object, int>((x) =>
            {
                // object를 Node 타입으로 강제 캐스팅
                var node = (Node)x;
                var sum = 0;

                for (int i = 0; i <= node.Count; i++)
                {
                    sum += i;

                    Console.WriteLine(node.Text + " = " + i);

                    Thread.Sleep(node.Tick);
                }
                Console.WriteLine("Completed " + node.Text);
                return sum;
            });

            // 리스트에 Task 추가
            list.Add(new Task<int>(func, new Node { Text = "A", Count = 5, Tick = 1000 }));
            list.Add(new Task<int>(func, new Node { Text = "B", Count = 5, Tick = 10 }));
            list.Add(new Task<int>(func, new Node { Text = "C", Count = 5, Tick = 500 }));
            list.Add(new Task<int>(func, new Node { Text = "D", Count = 5, Tick = 300 }));
            list.Add(new Task<int>(func, new Node { Text = "E", Count = 5, Tick = 200 }));

            // 리스트에 넣은 Task 실행
            list.ForEach(x => x.Start());
            // 리스트에 넣은 Task가 종료될 때까지 실행
            list.ForEach(x => x.Wait());
            // 스레드의 합 출력
            Console.WriteLine("Sum = " + list.Sum(x => x.Result));

            Console.WriteLine("Press any key...");
            Console.ReadLine();
            
        }
    }
}
