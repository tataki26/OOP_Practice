using System;
using System.Collections.Generic;
using System.Text;

namespace Lambda
{
    // 람다식의 활용
    // 디자인 패턴의 옵저버 패턴 구현
    // = 이벤트나 콜백 함수를 구현할 때 사용

    class Program3
    {
        // 출력 함수
        // 뒤의 Action 함수는 콜백 함수로, 함수가 끝나는 타이밍에 호출된다
        // 파라미터를 넣지 않으면 기본값인 null이 된다

        // 콜백 함수
        // 객체 지향 클래스에서 데이터를 객체화(Object)할 때 필요한 콜백 형식이나 이벤트 형식
        // 특정 함수가 호출되었을 때 연계되는 함수가 호출 되는 형식으로 작성할 때 사용

        // 디자인 패턴의 옵저버 패턴을 활용한 예시
        static void Print(string data, Action<string> cb = null)
        {
            // 파라미터 data의 값에 문자열 추가
            string ret = "Print " + data;
            // 콘솔 출력
            Console.WriteLine(ret);

            // 콜백 함수가 null이 아니면
            if (cb != null)
            {
                // 콜백 함수 호출
                cb(ret);
            }
        }

        static void Main(string[] args)
        {
            // Print 함수 호출
            Print("Test");
            // 개행
            Console.WriteLine();
            // Print 함수 호출, 함수 처리가 끝나면 콜백 함수가 호출된다
            Print("Hello World!", (val) =>
            {
                // 데이터를 받고 문자열을 추가하고
                string ret = val + " Call back!";
                // 콘솔 출력
                Console.WriteLine(ret);
            });

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
