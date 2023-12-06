using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {

        class Profile
        {
            public string name;
            public float height;
            public int age;
        }

        class Class
        {
            public string Name { get; set; }
            public int[] Scores { get; set; }
        }

        class Item
        {
            public string name;
            public int price;
            public int power;
            public int defence;

            public Item(string name, int price, int power, int defence)
            {
                this.name = name;
                this.price = price;
                this.power = power;
                this.defence = defence;
            }
        }

        static void Main(string[] args)
        {
            if (false)
            {

                // LINQ(링크)
                // => 데이터 검색 

                // Query문 (질의문)
                // = 데이터에 대해서 물어본다.
                // Form : 어떤 데이터 집합에서 찾을 것인가?
                // Where : 어떤 값의 데이터를 찾을 것인가?
                // Select : 어떤 항목을 추출할 것인가?

                Profile[] profiles =
                {
                new Profile(){name = "학생A", age = 25,  height = 135.5f},
                new Profile(){name = "학생B", age = 20,  height = 155.5f},
                new Profile(){name = "학생C", age = 19,  height = 98.7f},
                new Profile(){name = "학생D", age = 15,  height = 200.1f},
                new Profile(){name = "학생E", age = 34,  height = 178.6f},
                new Profile(){name = "학생F", age = 11, height = 183.2f},
                new Profile(){name = "학생G", age = 8,  height = 165.5f },
                new Profile(){name = "학생H", age = 43,  height = 159.8f}
            };

                // LINQ문은 IEnumerable을 기반으로 작동한다.
                // 쿼리문은 대상이 될 데이터의 원본과 각 요소 데이터를 나타내는 범위 변수를 지정해줘야한다.

                var result = from profile in profiles                       // from : 어디에서 가져올 것인가?
                             where profile.height < 170f              // where : 조건식. 필터(만족하면 가져간다)
                             orderby profile.height                     // orderby : 정렬 기준
                             select profile;                               // select : 어떤 데이터로 추출할 것인가?

                foreach (Profile p in result)
                    Console.WriteLine($"{p.name}({p.height})");

                // 1~10의 숫자 배열에서 짝수만 선택하고 싶다
                int[] array = Enumerable.Range(1, 100).ToArray();       // 1부터 연속적인 데이터를 100개 반환해라.
                var result2 = from arr in array
                              where arr % 2 == 0
                              select arr;
                Console.WriteLine(string.Join(", ", result2));

                // 프로필 중에서 나이가 25살 이하고 키가 170이상인 데이터를 취합
                // select는 최종적으로 데이터를 어떻게 가공해서 내보낼 것이냐라는 쿼리문이라
                // 무명형식으로도 내보낼 수 있다.
                var result3 = from profile in profiles
                              where profile.age <= 25
                              where profile.height >= 170f
                              select $"{profile.name} {profile.age}살 {profile.height}cm";
                //select new { name = profile.name, inch = profile.height * 0.393 };  //무명형식
                Console.WriteLine(string.Join(", ", result3));

                //무명형식
                foreach (var data in result3)
                    Console.WriteLine();
            }
            if (false)
            {

                Class[] classes =
                {
                new Class(){Name = "1반", Scores = new int[]{57,66,74,20}},
                new Class(){Name = "2반", Scores = new int[]{60,70,80,30}},
                new Class(){Name = "3반", Scores = new int[]{68,58,66,71}},
                new Class(){Name = "4반", Scores = new int[]{33,22,11,19}}
            };

                // 여러개의 데이터 원본에 대해 질의하기
                // 점수가 30점 미만인 학생이 소속된 학급과 학생의 점수를 뽑아보자.
                var result4 = from c in classes                                                 //classes 배열 안에서 c를 하나 가져온다     
                              from score in c.Scores                                        // c내부의 Scores에서 score를 하나 가져온다
                              where score < 30                                              // 해당 값에 대한 질의문
                              select new { c.Name, Lowest = score };             // 데이터 가공

                foreach (var data in result4)
                    Console.WriteLine($"{data.Name}({data.Lowest})");
            }

            Item[] items =
            {
                new Item("나무검", 200,3,0),
                new Item("철검", 800,5,1),
                new Item("다이아검", 3500,12,2),
                new Item("나무투구", 300,0,3),
                new Item("철투구", 700,1,5),
                new Item("다이아투구", 3400,3,10),
                new Item("나무신발", 400,0,4),
                new Item("철신발", 2900,0,8),
                new Item("다이아신발", 4000,0,19),
            };

            // 가격이 1000원 이하인 아이템을 공격력 순으로 정렬해서 추출
            // 확장메서드와 일반화 그리고 람다식을 이용해 데이터 질의.
           items.Where((item) => item.price <= 1000).OrderBy((item) => item.power).ToArray();
        }

        // 1부터 n까지의 데이터 집합중 k의 배수만 부분집합으로 반환
        public static int[] solution(int n, int k)
        {
            List<int> list = new List<int>();
            for(int i=1; i<=n; i++)
            {
                if(i%k==0)
                {
                    list.Add(i);
                }
            }

            int[] result = new int[list.Count];
            for(int i=0; i<list.Count; i++)
                result[i] = list[i];

            return result;
        }

        public static int[] solution2(int n, int k)
        {
            // Range를 통해 1부터 n까지의 데이터 집합을 만든다
            // 해당 집합에서 k의 배수만 취합하고 배열로 리턴한다.
            return Enumerable.Range(1,n).Where((i) => i%k==0).ToArray();
        }

        // 키가 170미만인 학생들만 묶어서 출력해보자.
        static Profile[] Find(Profile[] profiles, float height)
        {
            List<Profile> list = new List<Profile>();

            foreach (Profile p in profiles)
            {
                if (p.height < height)
                    list.Add(p);
            }
            return list.ToArray();



        }
    }
}
