using System;

namespace Interface
{
    // 인터페이스는 추상 클래스와 달리 내부에 멤버 변수나 일반 함수 구현 불가, 정의만 가능
    // 따라서 상속 받는 함수는 """재정의(오버라이드)를 하는 것이 아니다"""
    // STACK 메모리에 변수의 포인터를 넣고 HEAP 메모리에 클래스를 할당한다
    // 즉, 실체는 HEAP 메모리에 있고 이 실체를 객체(Object)라고 한다
    // 큰 프로그램에서는 이 객체를 리스트나 배열로 정리할 필요가 있다

    // 인터페이스는 HEAP 메모리에 인스턴스를 생성할 수는 없지만 생성된 인스턴스를 인터페이스로 분류하여 객체를 정리정돈 가능

    // IATypeInterface 인터페이스
    interface IATypeInterface
    {
        // 메서드 정의
        string GetATypeName();
        void Print();
    }
    // IBTypeInterface 인터페이스
    interface IBTypeInterface
    {
        // 메서드 정의
        string GetBTypeName();
        void Print();
    }
    // 위 두 개의 인터페이스를 상속 받는다
    // 두 인터페이스의 함수를 구현해야 한다
    class Example: IATypeInterface, IBTypeInterface
    {
        // IATypeInterface의 인터페이스 함수 정의
        public string GetATypeName()
        {
            return "A Example";
        }
        // IBTypeInterface의 인터페이스 함수 정의
        public string GetBTypeName()
        {
            return "B Example";
        }
        public void Print()
        {
            Console.WriteLine("Example - GetATypeName - " + GetATypeName());
            Console.WriteLine("Example - GetBTypeName - " + GetBTypeName());
        }
    }
    // IATypeInterface 인터페이스를 상속 받는다
    class AExample: IATypeInterface
    {
        // IATypeInterface의 인터페이스 함수 정의
        public string GetATypeName()
        {
            return "A - AExample";
        }
        public void Print()
        {
            Console.WriteLine("AExample - GetATypeName - " + GetATypeName());
        }
    }
    // IBTypeInterface 인터페이스를 상속 받는다
    class BExample: IBTypeInterface
    {
        // IATypeInterface의 인터페이스 함수 정의
        public string GetBTypeName()
        {
            return "B - BExample";
        }
        public void Print()
        {
            Console.WriteLine("BExample - GetBTypeName - " + GetBTypeName());
        }
    }

    class Program
    {
        // 세번째 방법
        // 파라미터에 따라 할당되는 클래스가 다르다
        // 함수를 이용해서 파라미터 조건에 따라 인스턴스 생성을 달리 할 수 있다
        // GetATypeClass 함수에 true일 경우 Example 클래스의 인스턴스 생성, false일 경우 AExample 클래스의 인스턴스 생성
 
        public static IATypeInterface GetATypeClass(bool type)
        {
            // true면 Example을 할당
            if (type)
            {
                return new Example();
            }
            // false면 AExample을 할당
            else
            {
                return new AExample();
            }
        }
        static void Main(string[] args)
        {
            /*
            // 첫번째 방법
            // 인스턴스 생성
            Example ex = new Example();
            ex.Print();

            AExample ex1 = new AExample();
            ex1.Print();

            BExample ex2 = new BExample();
            ex2.Print();
            */

            /*
            // 두번째 방법
            // 인스턴스 세 개를 생성하고 각 인터페이스 그룹에 따라 분류 한 후, Print 함수 호출
            Example ex = new Example();
            AExample ex1 = new AExample();
            BExample ex2 = new BExample();

            // IATypeInterface 인터페이스 그룹
            IATypeInterface[] aTypes = new IATypeInterface[]
            {
                ex,ex1
            };
            // IBTypeInterface 인터페이스 그룹
            IBTypeInterface[] bTypes = new IBTypeInterface[]
            {
                ex,ex2
            };
            // IATypeInterface 인터페이스 그룹 출력
            foreach (IATypeInterface a in aTypes)
            {
                a.Print();
            }
            foreach (IBTypeInterface b in bTypes)
            {
                b.Print();
            }
            */

            // true를 넣었기 때문에 Example 클래스의 인스턴스가 생성
            IATypeInterface aType = GetATypeClass(true);
            // Print 함수 실행
            aType.Print();

            Console.WriteLine("Press any key...");
            Console.ReadLine();

        }
    }
}
