using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwait
{
    // 동기
    // 두 가지 프로그램이 돌고 있을 때, 한 프로그램에 대한 처리를 끝낸 후에 다른 프로그램을 처리하는 것

    // 비동기
    // 두 가지 프로그램이 돌고 있을 때, 두 프로그램에 대한 처리가 동시에 이루어지는 것

    // 비동기 vs 멀티 스레딩
    // 비동기는 한 사람이 여러 작업을 동시에 하는 것
    // 멀티 스레딩은 여러 사람이 각자 맡은 작업을 하는 것

    // 결국, async 키워드는 리턴값을 Task로 사용해야 한다

    // 스레드를 만들 때, 실제 호출하는 쪽에서 스레드 내부 제어를 하기가 쉽지 않다 (동기화 문제)
    // 이때, async-await을 활용하면 제어를 할 수 있다
    class Program2
    {
        // AsyncTest 메서드 안에서 task 실행(비동기)
        // 여기에서 스레드를 잠깐 멈추기 위해 Wait 함수를 부른다
        // 이때, await 키워드로 멈추는 포인터를 지정할 수 있다
        // 결과적으로 pass await 1 >> 45 >> pass await2 >> 10 순서로 출력된다
        static async Task<int> AsyncTest()
        {
            var task = new Task<int>(() =>
              {
                  int sum = 0;
                  for (int i = 0; i < 10; i++)
                  {
                      sum += i;
                      Thread.Sleep(100);
                  }
                  return sum; // 결과 45
              });

            task.Start();
            // 외부 await에서 기다린다
            await task;
            // Wait이 호출되면 통과된다
            Console.WriteLine(task.Result);
            return 10; // 결과 10
        }

        // main에서 async-await 호출
        static void cMain(string[] args)
        {
            var task = AsyncTest();

            Console.WriteLine("pass await 1");

            // Wait
            task.Wait();

            Console.WriteLine("pass await 2");

            // return까지 기다린다
            int result = task.Result;

            // 결과: 같은 10이다
            Console.WriteLine(result);

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

    }
}
