using System;
using System.Collections.Generic;
using System.Text;

namespace Lambda
{
    // 람다식을 사용하기 위해 항상 그에 맞는 델리게이트를 선언해야 하는 것은 아니다
    // Func 함수와 Action 함수를 이용하면 델리게이트를 선언할 필요가 없다

    // Func 함수: 반환값이 있는 익명 함수
    // Action 함수: 반환값이 없는 익명 함수

    // 람다식은 문법 규약을 파괴하는 방법
    // 사용하기 편리하다는 장점
    // but 람다식이 많아지면 소스가 매우 복잡해지고 가독성이 떨어진다
    // 따라서, 일반 함수를 사용할 수 있으면 되도록 함수명을 작성하고 람다식 사용을 자제하는 것이 좋다

    class Program2
    {
        static void dMain(string[] args)
        {
            // 익명 함수
            // 가장 마지막 파라미터는 반환값
            Func<int, string> func = (val) =>
            {
                // int 값을 받아 100을 곱한다
                int ret = val * 100;
                // string 형식으로 반환한다
                return ret.ToString();
            };

            // 반환값이 없는 익명 함수
            Action<string> action = (val) =>
            {
                Console.WriteLine("Action = " + val);
            };

            // 익명 함수 func를 호출 -> 파라미터는 int 형을 넘기고 반환값은 string 값
            string data = func(10);
            // 익명 함수 action을 호출 -> 파라미터 string 형을 넘긴다
            action(data);

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
