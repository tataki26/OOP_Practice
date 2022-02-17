using System;
using System.Collections.Generic;
using System.Text;

namespace Lambda
{
    // 클로저(closure)
    // 람다식을 통해 소스 상에서 바로 위 스택 영역의 값을 가져올 수 있는 기능(수정도 가능)
    // 함수의 복잡도를 상당히 줄일 수 있다
    // 파라미터로 넘겨야 하는 데이터 혹은 멤버 변수로 만들어야 하는 값들을 로컬 변수 클로저로 단순하게 만들 수 있다
    // but 지나칠 경우 가독성을 떨어뜨리므로 상황에 맞게 사용하는 것을 권장

    // 일반 함수로는 불가능한 기능
    /*
    static void Print()
    {
        Console.WriteLine(val);
    }
    */

    class Program4
    {
        // Action 함수를 통해 익명 함수 작성 = 파라미터가 존재하지 않는다
        // Main 함수(다른 스택 영역)에서 선언한 val 값을 끌어와서 사용 가능
        static void aMain(string[] args)
        {
            string val = "Hello World!";
            
            // 익명 함수 생성
            Action action = () =>
            {
                Console.WriteLine(val);
            };

            // 함수 호출
            action();

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
