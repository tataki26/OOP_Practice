using System;

namespace Access
{
    class Example
    {
        // public 함수
        public void CallPublic()
        {
            Console.WriteLine("Public");
        }

        // private 함수
        private void CallPrivate()
        {
            Console.WriteLine("Private");
        }

        // protected 함수
        protected void CallProtected()
        {
            Console.WriteLine("Protected");
        }

        // 함수
        public void Call()
        {
            // 이 step은 ex 인스턴스 기준에서 Example 클래스 내부
            // public 접근 가능
            CallPublic();
            // private 접근 가능
            CallPrivate();
            // protected 접근 가능
            CallProtected();
        }
    }
    // Example 상속한 클래스
    class SubExample : Example
    {
        public void Call()
        {
            // 이 step은 ex 인스턴스 기준에서 Example 클래스 파생
            // public 접근 가능
            CallPublic();
            // private 접근 불가(private 포함 클래스X)
            // protected(파생 클래스까지) 접근 가능
            CallProtected();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Example ex = new Example();
            
            Console.WriteLine("Main");

            // 이 step은 ex 인스턴스 기준에서 Example 클래스 외부이므로 public만 접근 가능
            ex.CallPublic(); // Main 함수에서는 ex 인스턴스의 public으로 설정된 함수만 호출 가능
            Console.WriteLine();
            Console.WriteLine("Example");

            // Call 함수 호출
            ex.Call();
            Console.WriteLine();

            Console.WriteLine("SubExmple");
            // SubExample 인스턴스 생성
            SubExample sub = new SubExample();
            // Call 함수 호출
            sub.Call();

            Console.Write("Press any key....");
            Console.ReadLine();
            
        }
    }
}
