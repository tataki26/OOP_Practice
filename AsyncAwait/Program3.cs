using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwait
{
    // ContinueWith 함수는 Task를 연달아 붙여 사용할 때 필요하다
    // Task >> Wait >> Result >> Task >> Wait >> Result와 같은 동작이다
    // C#의 콜백 함수
    class Program3
    {
        static async Task<int> AsyncTest()
        {
            var task = new Task<int>(() =>
            {
                int sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    sum += i;

                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
                return sum;
            });

            task.Start();
            await task;

            task = new Task<int>(() =>
              {
                  int sum = 0;
                  for (int i = 10; i < 20; i++)
                  {
                      sum += i;
                      Thread.Sleep(100);
                  }
                  return sum;
              });

            task.Start();
            // await이 위에 있지만 결국에는 145가 리턴된다
            return task.Result;
        }

        static void Main(string[] args)
        {
            // AsyncTest가 끝나면 이어서 실행된다
            // 즉, AsyncTest가 종료되면 실행되는 스레드
            var continueTask = AsyncTest().ContinueWith(task =>
            {
                return task.Result;
            });
            // continueTask가 끝날 때까지 기다린다
            Console.WriteLine(continueTask.Result);

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
