using System;

namespace Base
{
    class Example
    {
        // 멤버 변수
        private int data = 10;
        // 멤버 변수 data를 반환하는 함수
        public virtual int GetData()
        {
            // this는 Example 클래스의 멤버 변수
            return this.data;
        }
    }
    // Example을 상속한 SubExample 클래스
    class SubExmaple : Example
    {
        // 멤버 변수
        private int data = 20;
        // 멤버 변수 data를 반환하는 함수
        public override int GetData()
        {
            // this는 SubExample 클래스의 멤버 변수
            return this.data;
        }
        public void Print()
        {
            // this를 사용했기 때문에 SubExample 클래스의 GetData 함수를 호출하여 SubExample 클래스의 멤버 변수를 반환 받는다
            Console.WriteLine("data - " + this.GetData());
            // base를 사용했기 때문에 부모 클래스의 GetData 함수를 호출하여 Example 클래스의 멤버 변수를 반환 받는다
            // base는 인스턴스 반환이 불가능하다 >> return base 불가능
            Console.WriteLine("data - " + base.GetData());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Example 클래스 인스턴스 생성
            SubExmaple ex = new SubExmaple();
            // Print 함수 호출
            ex.Print();

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
