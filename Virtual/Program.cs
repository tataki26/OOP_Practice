using System;

namespace Virtual
{
    // 추상 클래스 생성
    abstract class AbstractExample
    {
        public void Print()
        {
            Console.WriteLine("GetData function - " + GetData());

        }
        // virtual은 가상 함수, 즉 추상 함수는 내용이 구현되지 않지만 가상 함수는 구현 가능
        protected virtual string GetData()
        {
            return "AbstractExample";
        }
    }

    // 추상 클래스 상속
    class Example1 : AbstractExample
    {
        // 추상 클래스에서 GetData가 완전히 구현되지 않았기 때문에 상속 받는 클래스에서 반드시 재정의 해야 한다
        protected override string GetData()
        {
            // String 반환
            return "Example1";
        }
    }

    class Example2 : AbstractExample
    {
        // 가상 함수는 재정의를 꼭 하지 않아도 된다
        // 재정의를 하지 않으면 구현된 내용이 실행된다
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 추상 클래스의 지시자로 배열을 선언
            AbstractExample[] array = new AbstractExample[]
            {
                new Example1(),
                new Example2()

            };
            
            foreach (AbstractExample ex in array)
            {
                ex.Print();
            }
        }
    }
}
