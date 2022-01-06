using System;
using System.Collections.Generic;
using System.Linq;

namespace Inheritance02
{
    // 상속
    // 유사한 객체끼리 부모 클래스와 인터페이스를 정의하여 공통화한 다음, 상속 받아서 객체를 좀 더 다루기 쉽게 하는 특징
    // 중복으로 인한 긴 코드를 줄일 수 있어 가독성을 높일 수 있다

    // 과목 인터페이스
    interface ISubject
    {
        int GetScore();
    }
    // 과목 추상 클래스
    abstract class AbstractSubject : ISubject
    {
        // 점수
        private int score;
        // 생성자로 점수를 받는다
        public AbstractSubject(int score)
        {
            this.score = score;
        }
        // 점수 취득 함수
        public int GetScore()
        {
            return this.score;
        }
    }

    // 국어 클래스
    class Korean : AbstractSubject
    {
        // 생성자
        public Korean(int score) : base(score) { }
    }
    // 영어 클래스
    class English : AbstractSubject
    {
        public English(int score) : base(score) { }
    }
    // 수학 클래스
    class Math : AbstractSubject
    {
        public Math(int score) : base(score) { }
    }
    // 학생 클래스
    class People
    {
        // 이름
        private String name;
        // 0: 국어, 1: 영어, 2: 수학
        private List<ISubject> subjects = new List<ISubject>();
        // 총점
        private int total;
        // 평균
        private int avg;
        // 생성자로 이름과 점수를 받는다
        public People(String name, int korean, int english, int math)
        {
            this.name = name;
            this.subjects.Add(new Korean(korean));
            this.subjects.Add(new English(english));
            this.subjects.Add(new Math(math));
            // 총점 구하기
            this.total = this.subjects.Sum(x => x.GetScore());
            // 평균 구하기
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
            foreach(People p in peoples.OrderByDescending(x => x.GetTotal()))
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
            // 학생들을 추가한다
            peoples.Add(new People(name, korean, english, math));
        }
        // 출력 함수
        public void Print()
        {
            // 학생들의 이름과 총점, 평균, 석차를 구한다
            foreach (People p in peoples)
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
