using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    // 델리게이트는 자체적으로 리스트 기능을 가지고 있다
    // +=와 -=의 대입 연산자를 통해서 추가 및 제거가 가능하다

    // 인터페이스
    interface INode2
    {
        // 함수 선언
        void Print(String str);
    }

    // 델리게이트가 있는 클래스
    class Example2 : INode2
    {
        // 반환 값이 void에 String 파라미터가 하나 있는 델리게이트
        public delegate void PrintDelegate(String str);

        // 함수 포인터를 넣기 위한 리스트
        private PrintDelegate list;

        // 함수 추가
        public void AddDelegate(PrintDelegate func)
        {
            list += func;
        }

        // 함수 제거
        public void RemoveDelegate(PrintDelegate func)
        {
            list -= func;
        }

        // 리스트에 등록된 함수 실행
        public void Print(String str)
        {
            list(str);
        }
    }

    class Node3 : INode2
    {
        public void Print(String str)
        {
            Console.WriteLine("Node3 print - " + str);
        }
    }

    class Node4 : INode2
    {
        public void Print(String str)
        {
            Console.WriteLine("Node4 print - " + str);
        }
    }

    class Program3
    {
        static void eMain(string[] args)
        {
            Example2 example2 = new Example2();

            INode2 node3 = new Node3();
            INode2 node4 = new Node4();

            example2.AddDelegate(node3.Print);
            example2.AddDelegate(node4.Print);
            example2.Print("Test");

            example2.RemoveDelegate(node3.Print);
            example2.Print("Hello world!");

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
