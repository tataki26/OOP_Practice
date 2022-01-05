using System;

namespace Abstract
{
    // 추상 클래스 생성
    abstract class AbstractExample // 많은 클래스의 공통 부분을 묶어서 공통 클래스를 만드는 데 사용
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
    class Example1 : AbstractExample
    {
        // 추상 클래스에서 GetData가 완전히 구현되지 않았기 때문에 상속 받는 클래스에서 반드시 재정의 해야 한다
        protected override string GetData()
        {
            return "Example1";
        }

    }
    class Example2 : AbstractExample
    {
        protected override string GetData()
        {
            return "Example2";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            // 가상 클래스의 인스턴스를 직접 생성하지 않고 그를 상속 받은 파생 클래스의 인스턴스를 생성한다
            Example ex = new Example();
            ex.Print();
            */

            // 추상 클래스의 지시자로 배열을 선언
            AbstractExample[] array = new AbstractExample[]
            {
                new Example1(), // Example1 클래스의 인스턴스 생성
                new Example2() // Example2 클래스의 인스턴스 생성
            };

            // 인스턴스를 반복문으로 출력
            foreach (AbstractExample ex in array)
            {
                // 지시자는 추상 클래스 AbstractExample(Stack)이지만, Heap에는 Example1 또는 Example2의 클래스의 인스턴스가 할당되어 있다
                ex.Print(); // 인스턴스에서 GetData 함수를 재정의하여 나온 결과로 출력
            }

            Console.Write("Press any key...");
            Console.ReadLine();

        }
    }
}
