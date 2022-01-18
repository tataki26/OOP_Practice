using System;

// 객체지향에서는 멤버 변수를 private로 지정해서 외부에서의 접근을 금지한다(캡슐화)
// 그러나 클래스 멤버 변수 값을 무조건 생성자나 내부에서만 등록하는 것은 아니다
// 함수를 통해서 변수의 값을 설정하거나 지정할 수 있다

namespace Property
{
    /*
    // getter, setter

    // getter, setter가 필요한 이유: 캡슐화를 위해 멤버 변수를 가리는 게 원칙
    // 멤버 변수에 값을 취득하거나 설정을 제한(함수의 여러 가지 제어 조건을 설정)할 수도 있다
    // 멤버 변수를 public으로 설정하면 설정, 취득 제어 불가능 

    class Program
    {
        // 멤버 변수
        private int data;
        
        // 멤버 변수의 값을 설정하는 setter
        public void SetData(int data)
        {
            this.data = data;
        }

        // 멤버 변수의 값을 가져오는 getter
        public int GetData()
        {
            return this.data;
        }

        // 실행 함수
        public static void Main(string[] args)
        {
            // 인스턴스 생성
            Program p = new Program();

            // Program 인스턴스의 멤버 변수 data를 설정
            p.SetData(10);

            // Program 인스턴스의 멤버 변수를 취득해 콘솔 출력
            Console.WriteLine("p - data = " + p.GetData());

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
    */

    /*
    // Property: getter, setter를 좀 더 편하게 사용하기 위한 문법
    // 읽기 전용(getter만 설정 - set 생략) / 쓰기 전용(setter만 설정 - get 생략) 가능
    class Program
    {
        // 멤버 변수
        private int data;

        // 멤버 변수 data의 프로퍼티
        public int Data
        {
            // getter와 같은 취득 함수
            get
            {
                return this.data;
            }
            // setter와 같은 설정 함수
            set
            {
                // 설정 값은 value의 키워드로 들어온다
                // value: set 접근자가 할당하는 값(전달 받은 인자 값)을 정의하는데 사용
                this.data = value;
            }
        }

        public static void Main(string[] args)
        {
            Program p = new Program();

            // SetData, GetData로 나눌 필요가 없다
            p.Data = 10;
            Console.WriteLine("p - data = " + p.Data);

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
    */

    /*
    // set에만 접근 제한자 설정하기
    // 프로퍼티의 접근 제한자는 기본적으로 get의 접근 제한자
    // set의 접근 제한자만 별도로 설정 가능

    // 프로퍼티의 역할: 멤버 변수의 제어
    // 멤버 변수는 private로 고정 지정이기 때문에 크게 의미가 없다
    // 따라서, C#에서는 이 멤버 변수를 생략 가능하다

    class Program
    {
        // 멤버 변수
        private int data;
        
        // 생성자
        public Program()
        {
            // 프로퍼티를 통해 멤버 변수 설정
            this.Data = 10;
        }

        // 멤버 변수 data의 프로퍼티
        public int Data
        {
            get
            {
                return this.data;
            }
            // 접근 제한자를 내부와 상속 받는 클래스만 되도록 설정
            protected set
            {
                this.data = value;
            }
        }
        public static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("p - data = " + p.Data);

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
    */

    // 멤버 변수에 값을 넣는 방법
    class Program
    {
        // 멤버 변수 생략
        public Program()
        {
            // 프로퍼티를 통해 멤버 변수 설정
            this.Data = 10;
        }
        // 프로퍼티
        public int Data
        {
            // 멤버 변수가 생략되므로 get, set을 아래와 같이 설정 가능
            // 컴파일 내부적으로는 변수가 있다
            // 단 get, set에 특별한 제어식을 넣으려면 멤버 변수를 선언해야 한다

            // Static 영역을 생략하고 get;set;만 사용
            // set은 접근 제한자 설정
            get; protected set;
        }
        public static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("p - data = " + p.Data);

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
