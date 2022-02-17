using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    // 람다(lambda): 익명 함수, 이름이 없는 함수
    // 델리게이트를 기반으로 만들어짐
    // 함수명이 존재하지 않기 때문에 함수 포인터만 존재한다
    // 람다식을 사용하기 위해서는 델리게이트로 함수의 포인터를 가지고 있어야 한다
   
    class Example3
    {
        public delegate void PrintDelegate(String str);
        private PrintDelegate list;

        public void AddDelegate(PrintDelegate func)
        {
            list += func;
        }
        public void RemoveDelegate(PrintDelegate func)
        {
            list -= func;
        }
        public void Print(String str)
        {
            list(str);
        }
    }
   
    class Program4
    {
        static void Main(string[] args)
        {
            Example3 example3 = new Example3();
            example3.AddDelegate((str) =>
            {
                Console.WriteLine("Lambda - " + str);
            });

            example3.Print("Test");

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
