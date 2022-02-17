using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threads
{
    // 사양에 따라 두 for문을 병렬로 동시에 실행해야 할 때가 있다
    class Program2
    {
        static void bMain(string[] args)
        {
            // 첫 번째 스레드 생성
            var thread1 = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine("a = " + i);
                }
            });

            // 두 번째 스레드 생성
            var thread2 = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine("b = " + i);
                }
            });

            // 두 스레드가 동시에 실행되면서 콘솔에 무작위 출력된다
            // 하나의 프로세스에 두 개의 스레드가 작동한 것(총 세 개의 병렬 처리)
            // press any key... 가 중간에 실행된 것은 스레드를 실행하면서 약간의 딜레이가 발생하여 프로세스 처리가 먼저 되었기 때문

            // 첫 번째 스레드 실행
            thread1.Start();
            // 두 번째 스레드 실행
            thread2.Start();

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
