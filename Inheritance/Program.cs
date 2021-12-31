using System;

namespace Inheritance
{
    class Example
    {
        public void Print()
        {
            Console.WriteLine("Call Print function");
        }
    }
    // Example 클래스를 상속한 CopyExample(파생 클래스)
    class CopyExample : Example
    {
        public void Print2()
        {
            Console.WriteLine("Call Print2 function");
        }

        // 반환자, 함수명, 파라미터를 같은 이름으로 하면 함수가 재정의(override)된다
        // 접근 제한자 뒤에는 재정의 키워드 new를 넣는다(상위 클래스의 일반 함수를 재정의 할 경우)
        // 함수를 재정의 하면 상의 클래스 함수가 아닌 재정의된 함수가 호출된다
        public new void Print()
        {
            Console.WriteLine("Call new Print function");
        }

        /*
        // 상위 클래스에서 재정의를 허락한 경우(abstract와 virtual)에는 override 키워드를 사용한다
        // virtual이 없는 상태에서 override를 사용하면 에러 발생
        public override void Print()
        {
            Console.WriteLine("Call new print function");
        }
        */

    }
    class Program
    {
        static void Main(string[] args)
        {
            CopyExample ce = new CopyExample();
            // Example 클래스를 상속받았기 때문에 내부에서 함수를 정의하지 않아도 사용 가능하다
            ce.Print();
            // 파생 클래스에서 추가된 함수
            ce.Print2();

            Console.Write("Press any key...");
            Console.ReadLine();
        }
    }
}
