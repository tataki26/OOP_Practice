using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwait
{
    // void로 사용하는 방법
    // 단독으로 사용할 때는 void를 사용한다
    

    class Program
    {
        // async 메서드에 task를 넣고 실행
        // 이 방법은 비동기와 같다
        // 즉, ThreadPool로 만드는 것과 차이가 없다
        // 따라서, 이렇게 사용할 바에는 그냥 async 없이 Task 클래스만 사용하는 것이 맞다
        // visual studio에서도 경고를 준다
        static async void AsyncTest()
        {
            var task = new Task<int>(() =>
            {
                int sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    sum += i;
                    //0.1초 단위로 1씩 증감
                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
                return sum;
            });
            task.Start();
        }
        static void eMain(string[] args)
        {
            // Task 리턴식이 없기 때문에 제어할 수가 없다
            AsyncTest();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
