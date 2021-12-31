using System;

namespace OOP01
{
    class Example
    {
        //생성자
        public Example()
        {
            Console.WriteLine("파라미터 없는 생성자 호출");
        }
        public Example(int a)
        {
            Console.WriteLine("파라미터 있는 생성자 호출" + a);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 인스턴스 생성(클래스 호출) - 클래스를 메모리에 등록한다
            Example example = new Example();
            Example example1 = new Example(1);
            
            Console.Write("Press any key...");
            Console.ReadLine();
        }
    }
}
