using System;

namespace Override
{
    class Example
    {
        // 가상 함수
        public virtual void Print()
        {
            Console.WriteLine("Call Print function");
        }
    }
    // Example 클래스 상속
    class CopyExample1 : Example
    {
        // override 재정의
        public override void Print()
        {
            Console.WriteLine("Call new function");
        }
    }
    class CopyExample2 : Example
    {
        // new 재정의
        public new void Print()
        {
            Console.WriteLine("Call new Print function");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example 변수 타입으로 CopyExample1과 CopyExample2 클래스 인스턴스 생성
            Example ce1 = new CopyExample1();
            ce1.Print(); // 파생 클래스 함수 호출(HEAP에 들어간 인스턴스의 Print 함수 호출)

            Example ce2 = new CopyExample2();
            // 파생 클래스에서 추가된 함수
            ce2.Print(); // ***Example(상위) 클래스*** 함수 호출 = 재정의 실패
            // 변수 타입에 따라 가르키는 함수가 달라진다(Example과 CopyExample2)

            Console.Write("Press any key...");
            Console.ReadLine();
        }
    }
}
