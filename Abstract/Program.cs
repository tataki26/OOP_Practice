using System;

namespace Abstract
{
    // 추상 클래스 생성
    abstract class AbstractExample
    {
        public void Print()
        {
            Console.WriteLine("GetData function - " + GetData());
        }
        // GetData 함수는 여기서 정의하지 않고 상속 받는 클래스에서 강제 재정의 명령한다
        // abstract 키워드를 붙인 함수는 우선 선언만 하고 내용은 구현하지 않는다
        // AbstractExample(추상 클래스) & GetData(추상 함수)
        // 추상 클래스는 독자적으로 인스턴스를 생성할 수 없고 상속을 받을 함수는 추상 함수를 모두 재정의 해야 한다
        protected abstract string GetData(); // 함수 선언문                                      
    }
    // 추상 클래스 상속
    class Example : AbstractExample
    {
        // 추상 클래스에서 GetData가 완전히 구현되지 않았기 때문에 상속 받는 클래스에서 반드시 재정의 해야 한다
        protected override string GetData()
        {
            return "Hello World";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Example ex = new Example();
            ex.Print();

            Console.Write("Press any key...");
            Console.ReadLine();

        }
    }
}
