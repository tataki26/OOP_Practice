using System;

namespace OOP2
{
    class Example
    {
        // 멤버 변수
        private int data;
        // 생성자
        public Example(int data)
        {
            // 멤버 변수 설정
            this.data = data;
        }
        // 함수
        public void Print()
        {
            // 콘솔 출력
            Console.WriteLine("Data - " + data);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 인스턴스 생성 - 클래스를 HEAP 메모리에 등록(이후 클래스의 함수를 사용할 수 있다)
            Example ex = new Example(10); 
            // Example 타입에는 Example의 인스턴스가 들어가야 한다
            // Example ex는 할당된 메모리 주소를 가르키는 것(포인트 변수) - 메모리 주소의 값이 있다
            // Example ex는 Stack 메모리(중괄호 영역)에 있고 new Example은 Heap 메모리(프로그램)에 있다
            // stack은 정형화된 자료구조에 매우 좁은 공간
            // heap은 자유롭지만 주소값이 있어야만 데이터를 찾을 수 있는 공간
            // 따라서 stack에 heap의 데이터를 찾을 수 있는 주소값만을 저장한다
            ex.Print();

            Console.Write("Press any key...");
            Console.ReadLine();
        }
    }
}
