using System;

namespace Base02
{
    class Example
    {
        // 생성자
        public Example()
        // public Example(int data)
        {
            //Console.WriteLine("call Example constructor - " + data);
            Console.WriteLine("call Example constructor - ");
        }
    }
    // Example을 상속한 SubExample 클래스
    class SubExample : Example // base를 넣지 않아도 부모 생성자가 호출 되는 것 확인 가능
    {
        // 생성자 (단, 생성자 파라미터가 없을 경우 생략 가능)
        // 상속과 유사한 형태로 콜론을 넣고 base를 넣어 부모 클래스의 생성자 호출 가능
        /*
        public SubExample(int data) : base(10)
        {
            Console.WriteLine("call SubExample constructor - " + data);
        }
        */
        public SubExample()
        {
            Console.WriteLine("call SubExample constructor");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // SubExample ex = new SubExample(10);
            SubExample ex = new SubExample();

            Console.WriteLine("Press any key..");
            Console.ReadLine();
        }
    }
}
