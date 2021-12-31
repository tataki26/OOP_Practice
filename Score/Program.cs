using System;

namespace Score
{
    // 성적을 위한 사람 클래스
    class Person
    {
        // 인적 사항과 성적과 관련된 모든 멤버 변수는 private
        // 만약 변수가 모두 public이라면 Init 함수와 Print 함수는 필요없다
        // OOP 코딩 표준: 멤버 변수는 무조건 private, 외부에서 호출하는 함수는 public, 나머지 함수는 모두 protected로 설정(캡슐화)
        private string name;

        private int kor;
        private int math;
        private int eng;

        private int total;
        private int avg;

        // 초기화 함수
        protected void Init()
        {
            // 총점 계산
            this.total = this.kor + this.math + this.eng;
            // 평균 계산
            this.avg = this.total / 3;
        }

        // 생성자
        public Person(string name, int kor, int math, int eng)
        {
            // 멤버 변수 설정
            this.name = name;
            this.kor = kor;
            this.math = math;
            this.eng = eng;

            // 총점, 평균 계산
            Init();
        }

        // 출력 함수
        public void Print()
        {
            Console.WriteLine($"{this.name} = {this.kor}, {this.math}, {this.eng} = {this.total} : {this.avg}");
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            // 인스턴스 생성
            Person p = new Person("a", 100, 60, 70);

            p.Print();

            Console.Write("Press any key...");
            Console.ReadLine();
        }
    }
}
