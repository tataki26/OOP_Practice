using System;

namespace Delegate
{
    // 델리게이트(delegate)
    // - 대리자
    // - C++의 함수 포인터와 유사한 개념

    // 함수 포인터
    // - 함수식(function)을 인스턴스의 포인터처럼 인식하여 변수에 값을 저장하거나 파라미터로 넘겨서 대리로 실행하는 역할

    class Program
    {
        // 델리게이트 선언
        // 델리게이트의 반환 타입, 파라미터가 메소드와 일치해야 한다
        delegate void PrintDelegate(String str);

        // 출력 함수
        public void Print(String str)
        {
            Console.WriteLine(str);
        }

        public Program()
        {
            // 델리게이트에 메소드를 넣는다
            // 델리게이트를 사용해서 Print 함수를 인스턴스의 포인터로 변환하고 pd의 변수를 인스턴스의 값처럼 사용 가능
            PrintDelegate pd = new PrintDelegate(Print);
            
            // 델리게이트 실행
            // 델리게이트의 pd 변수는 함수를 호출하듯이 파라미터 값을 넣어 실행 가능
            pd("Hello World!");
        }

        static void cMain(string[] args)
        {
            new Program();

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
