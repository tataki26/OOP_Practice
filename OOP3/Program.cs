using System;

namespace OOP3
{
    class Example
    {
        // 변수에 static 설정
        private static int data;

        // static.data에 값 설정
        public void SetData(int data)
        {
            // static은 할당과 관계가 없기 때문에 this가 아닌 클래스 명으로 참조
            Example.data = data;
        }
        // 인스턴스 생성 없이(HEAP 메모리에 등록하지 않아도 = STACK 메모리에 등록) 호출할 수 있는 함수
        
        /*
        public static void Print()
        {
            Console.WriteLine("Hello World");
        }
        */
        public void Print()
        {
            Console.WriteLine("Data - " + Example.data);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // 인스턴스를 생성하지 않고 클래스 명을 가지고 클래스 내 함수 호출
            // Example.Print();

            Example ex1 = new Example();
            Example ex2 = new Example();

            ex1.SetData(10);
            ex2.SetData(20);

            // ex1과 ex2가 20으로 같은 값 출력
            // Example.data는 인스턴스와 관계 없이 프로그램이 실행될 때 생성되는 변수
            // 그런데 왜 Main 함수에서 직접 참조가 안될까?
            // 접근 제한자가 private(private를 포함한 클래스 내에서만 접근 가능)이기 때문!!
            ex1.Print();
            ex2.Print();

            Console.Write("Press any key...");
            Console.ReadLine();
        }
    }
}
