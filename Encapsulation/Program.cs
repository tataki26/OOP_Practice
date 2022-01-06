using System;
using System.Collections.Generic;
using System.Linq;

namespace Encapsulation
{
    // OOP: 객체(Object)를 중심으로 프로그램을 설계, 개발해 나가는 것
    // ex:)
    // 업무 계획서 작성 > 계획 실행 > 테스트 > 결과 확인 > 보고서 작성 > 결제 > 승인
    // 전체 업무 단위(Controller) > 계획서 데이터(Object), 테스트 데이터(Object), 결과 데이터(Object), 보고서 데이터(Objec), 결제 데이터(Object)

    // 캡슐화
    // 클래스의 접근을 제한하는 것
    // 필요한 데이터 외에는 private(내부에서만 접근 가능) 설정

    // 국어 클래스
    class Korean
    {
        // 점수
        private int score;
        // 생성자로 점수를 받는다
        public Korean(int score)
        {
            this.score = score;
        }
        // 점수 취득 함수
        public int GetScore()
        {
            return this.score;
        }
    }
    // 영어 클래스
    class English
    {
        // 점수
        private int score;
        // 생성자로 점수를 받는다
        public English(int score)
        {
            this.score = score;
        }
        // 점수 취득 함수
        public int GetScore()
        {
            return this.score;
        }
    }
    // 수학 클래스
    class Math
    {
        private int score; 
        public Math(int score)
        {
            this.score = score;
        }
        // 점수 취득 함수
        public int GetScore()
        {
            return this.score;
        }
    }

    // 학생 클래스
    class People
    {
        // 이름
        private String name;
        // 국어 성적
        private Korean korean;
        // 영어 성적
        private English english;
        // 수학 성적
        private Math math;

        // 총점과 평균을 public으로 설정하면 SchoolClass에서 총점과 평균 값 수정이 가능해진다
        // 즉, People 클래스의 캡슐화가 되지 않으면서 외부에서 수정이 가능해짐으로 인해 클래스의 데이터 무결성이 없어지고 신뢰도가 떨어지게 된다

        // 총점
        private int total;
        // 평균
        private int avg;

        // 생성자로 이름과 점수를 받는다
        public People(String name, int korean, int english, int math)
        {
            this.name = name;
            this.korean = new Korean(korean);
            this.english = new English(english);
            this.math = new Math(math);

            this.total = korean + english + math;
            this.avg = this.total / 3;
        }
        public string GetName()
        {
            return this.name;
        }
        // 총점 취득 함수
        public int GetTotal()
        {
            return this.total;
        }
        // 평균 취득 함수
        public int GetAvg()
        {
            return this.avg;
        }
        // 석차 구하기
        public int GetRank(List<People> peoples)
        {
            // 석차
            int rank = 1;
            foreach (People p in peoples.OrderByDescending(x => x.GetTotal()))
            {
                // 같은 클래스면 continue
                if (p == this)
                {
                    continue;
                }
                // 비교하는 대상이 총점이 높으면 나는 석차가 내려간다
                if (p.GetTotal() > this.GetTotal())
                {
                    rank++;
                }
            }
            // 현재 석차
            return rank;
        }
    }

    // 학급 클래스
    class SchoolClass
    {
        // 학급 인원 리스트
        private List<People> peoples = new List<People>();
        // 학생 추가 함수, 이름과 국어, 영어, 수학 성적을 받는다
        public void AddPeople(String name, int korean, int english, int math)
        {
            // 학생을 추가한다
            peoples.Add(new People(name, korean, english, math));
        }
        public void Print()
        {
            // 학생들의 이름과 총점, 평균, 석차를 구한다
            foreach(People p in peoples)
            {
                Console.WriteLine(p.GetName() + " total = " + p.GetTotal() + ", avg = " + p.GetAvg() + ", ranking = " + p.GetRank(peoples));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 학급을 할당한다
            SchoolClass schoolClass = new SchoolClass();
            // 학생을 임의로 추가한다
            schoolClass.AddPeople("A", 50, 60, 70);
            schoolClass.AddPeople("B", 70, 20, 50);
            schoolClass.AddPeople("C", 60, 70, 40);
            schoolClass.AddPeople("D", 30, 80, 30);
            schoolClass.AddPeople("E", 50, 100, 50);
            schoolClass.AddPeople("F", 70, 70, 60);
            schoolClass.AddPeople("G", 90, 40, 40);
            schoolClass.AddPeople("H", 100, 100, 90);
            schoolClass.AddPeople("I", 40, 50, 10);
            schoolClass.AddPeople("J", 60, 70, 30);
            // 출력
            schoolClass.Print();

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}
