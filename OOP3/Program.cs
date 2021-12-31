using System;

namespace OOP3
{
    class Example
    {
        // 인스턴스 생성 없이(HEAP 메모리에 등록하지 않아도 = STACK 메모리에 등록) 호출할 수 있는 함수
        public static void Print()
        {
            Console.WriteLine("Hello World");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 인스턴스를 생성하지 않고 클래스 명을 가지고 클래스 내 함수 호출
            Example.Print();

            Console.Write("Press any key...");
            Console.ReadLine();
        }
    }
}
