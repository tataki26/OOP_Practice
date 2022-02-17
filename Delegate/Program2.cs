using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    // 델리게이트는 변수처럼 사용할 수 있는 장점이 있다
    
    // 인터페이스
    interface INode
    {
        // 함수 선언
        void Print(String str);
    }

    // 델리게이트가 있는 클래스
    class Example : INode
    {
        // 반환값이 void에 String 파라미터가 하나 있는 델리게이트
        // 델리게이트를 외부에서 사용하기 위해서는 접근 제한자를 public으로 설정해야 한다
        public delegate void PrintDelegate(String str);

        // 함수 포인터를 넣기 위한 리스트
        // 리스트에 델리게이트를 넣어서 함수 포인터를 관리하도록 한다
        private List<PrintDelegate> list = new List<PrintDelegate>();

        // 리스트에 함수 추가
        public void AddDelegate(PrintDelegate func)
        {
            list.Add(func);
        }

        // Print 함수를 실행하면 리스트에 저장된 함수 실행
        public void Print(String str)
        {
            // 반복문으로 리스트에 저장된 함수를 가져온다
            foreach (var item in list)
            {
                // 함수를 실행한다
                item(str);
            }
        }
    }

    // Node1 클래스
    class Node1 : INode
    {
        // Print 함수
        public void Print(String str)
        {
            // 콘솔 출력
            Console.WriteLine("Node1 print - " + str);
        }
    }

    // Node2 클래스
    class Node2 : INode
    {
        // Print 함수
        public void Print(String str)
        {
            Console.WriteLine("Node2 print - " + str);
        }
    }

    class Program2
    {
        // 실행 함수
        static void dMain(string[] args)
        {
            // 델리게이트가 있는 클래스의 인스턴스를 생성
            Example example = new Example();

            // Node1 클래스의 인스턴스를 생성
            INode node1 = new Node1();
            // Node2 클래스의 인스턴스를 생성
            INode node2 = new Node2();

            // 디자인 패턴의 합성 패턴 활용한 예제
            // Example 클래스에 Node1 클래스의 Print 함수와 Node2 클래스의 Print 함수를 넣어
            // Example 클래스의 Print 함수를 실행하면서 동시에 두 함수를 실행하는 패턴

            // 델리게이트가 있는 클래스에 Node1 클래스의 Print 함수 등록
            example.AddDelegate(node1.Print);
            // 델리게이트가 있는 클래스에 Node2 클래스의 Print 함수 등록
            example.AddDelegate(node2.Print);

            // 델리게이트에 등록되어 있는 함수에 Test 값을 넣어 실행
            example.Print("Test");

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
