using System;

namespace Threads
{
    // 프로세스
    // 프로그램을 작성하여 실행하면 소스의 순서대로 실행되는 것이 기본 흐름
    // 프로그램의 실행부터 종료까지는 하나의 프로세스가 실행

    class Program
    {
        // 일반적인 프로그램(하나의 프로세스)은 a의 출력이 먼저 실행되고 a가 종료될 때 b의 출력 실행
        static void eMain(string[] args)
        {
            // 반복문 0부터 9까지
            for(var i = 0; i < 10; i++)
            {
                Console.WriteLine("a = " + i);
            }

            for(var i = 0; i < 10; i++)
            {
                Console.WriteLine("b = " + i);
            }

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
