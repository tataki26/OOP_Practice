using System;

namespace Lambda
{
    // 함수를 포인터로 관리할 수 있다
    // = 함수의 이름을 선언하지 않고 함수를 작성할 수 있다

    // 람다: 익명 함수, 함수의 이름 없이 생성 가능한 함수
    class Program
    {
        // 델리게이트 선언
        // 반환값은 없고 String의 파라미터를 받는 델리게이트
        private delegate void Print(string val);
        // 델리게이트 리스트
        private static Print list;
        
        // 실행 함수
        static void cMain(string[] args)
        {

            // 람다 형식: (인자)=>{}
            // 인자의 자료형: 델리게이트에서 선언한 string의 데이터
            // 반환 값이 없기 때문에 return이 필요하지 않다
            // 중괄호({})의 스택 영역에는 함수 호출 시 실행되는 프로그램 명령어를 구현한다
            // 함수가 실행되면 list의 델리게이트를 실행하여 등록되어 있는 람다식 두 개가 실행된다
            
            // 익명 함수 추가
            list += (val) =>
              {
                  Console.WriteLine("Lambda1 " + val.ToString());
              };

            // 익명 함수 추가
            list += (val) =>
            {
                Console.WriteLine("Lambda2 " + val.ToString());
            };
            // 델리게이트 리스트
            // 함수의 인자를 공통으로 넘겨준다
            list("Hello World!");

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
