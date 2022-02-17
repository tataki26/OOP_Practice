using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threads
{
    // Thread 함수에는 변수를 전달할 수 없다
    // 따라서, 람다식을 사용하고 클로저 기능을 이용해서 변수를 전달하는 방법 자주 사용
    class Program4
    {
        static void fMain(string[] args)
        {
            var sum = 0;

            var thread1 = new Thread(() =>
            {
                for (var i = 0; i < 1000; i++)
                {
                    sum += i;
                }
            });

            /*
            // 출력 결과: 0
            // 이유: 스레드가 종료될 때까지 기다리지 않고 프로세스가 먼저 실행되기 때문

            // 콘솔이 출력될 당시의 값은 sum의 변수 값이 0이었다
            // 병렬로 실행되기 때문에 콘솔이 출력된 후에 sum의 변수 값이 변한다
            thread1.Start();
            Console.WriteLine("Sum = " + sum);
            */

            // 해결 방법
            // thread1 변수에 Join 함수를 사용하면 프로세스에서 스레드가 종료할 때까지 대기하는 역할 수행
            // 여러 개의 스레드를 사용한다면 Join 함수를 통해 프로세스와 동기화시킴으로써 프로그램을 빠르게 처리 가능
            thread1.Start();
            // 스레드가 종료될 때까지 프로세스 중지
            thread1.Join();

            Console.WriteLine("Sum = " + sum);

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
