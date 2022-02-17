using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threads
{
    // 사양에 따라 Thread의 처리를 늦출 수 있다
    class Program5
    {
        static void Main(string[] args)
        {
            var thread1 = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    // 현재 시간을 콘솔 출력
                    Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ssss"));
                    
                    // Sleep 함수를 통해 스레드를 일정 시간동안 멈추는 처리 가능
                    // 밀리초 단위로 설정(1초=1000밀리초)
                    // 1초 대기
                    Thread.Sleep(1000);
                }
            });

            thread1.Start();
            thread1.Join();

            Console.WriteLine("Press any key...");
            Console.ReadLine();
       
        }

        // 스레드 = 병렬 처리
        // 스레드도 하나의 자원이기 때문에 한계가 존재
        // 스레드를 무한히 만들면 시스템이 느려지기도 한다

        // 간단히 처리하는 계산식의 경우 스레드 생성과 관리 부분 때문에 스레드를 사용하지 않는 것이 더 빠르다

        // 주로 프로그램에서 리소스(파일, 통신) 관리 혹은 유저의 이벤트를 기다리는 처리 등으로 많이 사용된다
        // 이유: 프로세스 속도와 리소스 간 처리 속도 사이에 차이가 있기 때문
    }
}
