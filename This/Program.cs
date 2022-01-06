using System;

namespace This
{
    // 클래스 생성
    class Example
    {
        // 함수 안의 변수명과 클래스 안의 변수명이 같은 경우에 어떤 변수를 가리킬까?
        // data라는 변수
        private int data = 10;
        // data라는 변수명을 가진 파라미터
        public void Print(int data)
        {
            // data의 출력은 현 stack에서 가장 가까운 파라미터 data를 가리킨다
            Console.WriteLine("data - " + data);
            // this.data는 인스턴스의 data를 참조하기 때문에 멤버 변수가 된다
            Console.WriteLine("data - " + this.data);
        }
        // 인스턴스의 주소 값을 리턴한다
        public Example GetInstance()
        {
            // 자기 자신(인스턴스)를 리턴
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Example ex = new Example();
            // ex의 GetInstance 함수로 인스턴스를 받는다
            Example ex1 = ex.GetInstance();

            /*
            // 함수 호출 - 파라미터(stack 내부)로 20을 넣는다
            ex.Print(20);
            */

            // 두 변수의 해쉬 코드 값이 일치
            // 즉, 같은 인스턴스를 의미한다
            Console.WriteLine(ex.GetHashCode());
            Console.WriteLine(ex1.GetHashCode());

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
