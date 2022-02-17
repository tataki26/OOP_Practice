using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threads
{
    // 스레드를 사용하는 방법
    // 스레드 클래스의 인스턴스를 생성한다
    // 생성자 파라미터로는 반환값과 파라미터가 없는 델리게이트로 받는다
    class Program3
    {
        // 스레드에서 사용될 함수
        static void ThreadMethod1()
        {
            var sum = 0;

            // 반복문 0부터 99999까지
            for (var i = 0; i < 100000; i++)
            {
                // 변수에 더한다
                sum += i;
            }

            Console.WriteLine("Sum1 = " + sum);
        }

        static void ThreadMethod2()
        {
            var sum = 0;

            // 반복문 0부터 999까지
            for (var i = 0; i < 1000; i++)
            {
                sum += i;
            }

            Console.WriteLine("Sum2 = " + sum);
        }

        static void cMain(string[] args)
        {
            // 스레드 생성
            var thread1 = new Thread(ThreadMethod1);
            var thread2 = new Thread(ThreadMethod2);

            // 스레드 실행
            thread1.Start();
            thread2.Start();

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
