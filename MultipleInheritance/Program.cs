using System;

namespace MultipleInheritance
{
    // ATypeAbstractClass 추상 클래스
    abstract class ATypeAbstractClass
    {
        // 추상 메서드
        public abstract string GetATypeName();
    }
    // BTypeAbstractClass 추상 클래스
    abstract class BTypeAbstractClass
    {
        // 추상 메서드
        public abstract string GetBTypeName();
    }

    // 위 두 개의 추상 클래스를 상속 받는다
    // 다중 상속 에러: Print 함수가 Example이 아닌 추상 클래스에 있으면 Print 함수 호출 시, 출처가 모호해지는 문제
    // C#에서는 다중 상속 금지
    class Example : ATypeAbstractClass, BTypeAbstractClass
    {
        // ATypeAbstractClass의 추상 클래스 함수 재정의
        public override string GetATypeName()
        {
            return "A";
        }
        // BTypeAbstractClass의 추상 클래스 함수 재정의
        public override string GetBTypeName()
        {
            return "B";
        }
        public void Print()
        {
            Console.WriteLine("GetATypeName - " + GetATypeName());
            Console.WriteLine("GetBTypeName - " + GetBTypeName());
        }
    }
    class Program
    {
        static void eMain(string[] args)
        {
            // 인스턴스 생성
            Example ex = new Example();
            ex.Print();

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }

}
