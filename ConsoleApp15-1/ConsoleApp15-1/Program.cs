using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15_1
{

    class Player
    {
        public string name;

        public void Receive(string message)
        {
            Console.WriteLine($"플레이어({name})가 메세지를 수신 : {message}");
        }
    }

    class Npc
    {
        public string name;

        public void GetMessage(string msg)
        {
            Console.WriteLine($"{msg}를 {name}가 받았습니다.");
        }
    }

    class User
    {
        public void GetText(string text)
        {
            Console.WriteLine($"유저가 {text}를 받았다.");
        }
    }


    delegate void ReceiveMessage(string msg);         // 반환형식이 없고 string 매개변수를 1개 받는 델리게이트


    class Terminal<T>
    {

        //event 델리게이트
        // 1. 외부에서는 등록, 해제만 가능하다
        // 2. 이벤트를 관리하는 추세는 객체 된다
        public event Action<T> messageEvent;

        public void Send(T arg)
        {
            //호출한다라는 함수
            messageEvent?.Invoke(arg);
        }
    }

    class Terminal
    {

        //event 델리게이트
        // 1. 외부에서는 등록, 해제만 가능하다
        // 2. 이벤트를 관리하는 추세는 객체 된다
        public event ReceiveMessage messageEvent;

        //public void Regested(ReceiveMessage ev)
        //{
        //    messageEvent += ev;         //델리게이트 체인을 이용해 받아온 메서드를 등록
        //}
        //public void Release(ReceiveMessage ev)
        //{
        //    messageEvent -= ev;         //등록 되어있는 메서드를 제거
        //}

        public void SendMessage(string str)
        {
            if (str.Length >= 12)
            {
                Console.WriteLine("전체 메세지는 12글자 이내만 가능합니다.");
                return;
            }
            messageEvent(str);      //모든 등록된 이벤트 호출
        }
    }

    class Button
    {
        // 버튼을 클릭한다 라는 이벤트이다
        public event Action<object, EventArgs> onClick;
        
        public void Click()
        {
            onClick?.Invoke(null, null);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            if (false)
            {

                // 델리게이트 체인
                // => +연산자를 사용해 여러개의 함수를 참조할 수 있다.
                // 호출 시 등록된 순서대로 호출된다.
                Player playerA = new Player() { name = "플레이어A" };
                Player playerB = new Player() { name = "플레이어B" };

                Npc npcA = new Npc() { name = "NPC A" };
                Npc npcB = new Npc() { name = "NPC B" };

                User user = new User();

                Terminal terminal = new Terminal();
                terminal.messageEvent += playerA.Receive;
                terminal.messageEvent += npcA.GetMessage;
                terminal.messageEvent += user.GetText;
                terminal.messageEvent -= user.GetText;

                terminal.SendMessage("@@@이 오픈되었습니다");

                // Action : 반환형이 없는 기본 델리게이트 <매개변수>
                Action<string> action = playerA.Receive;
                Action<string, string> action2 = delegate (string a, string b)
                {
                    Console.WriteLine($"입력 : {a}, 입력 : {b}");
                };

                // Func : 반환형이 있는 기본 델리게이트 < 반환형, 추가 매개변수 >
                //           마지막이 반환형이다
                Func<string> func1 = null;
                //Func<string, string> func2 = Funtion;
                Func<int, string> func3 = Funtion;

                // 일반화와 묶어서 사용할 수도 있다
                Terminal<int> terminal2 = new Terminal<int>();
                //terminal2.messagerEvent += GetNumber;
            }

            if (false)
            {

                Player p = null;

                // p값이 null이 아니면 name을 사용하고 null이면 뒤쪽 값을 사용한다
                string name = p?.name ?? "값이 없음";
                // || 위나 아래나 같은 표현
                string name2 = "값이 없음";
                if (p != null)
                {
                    name = p.name;
                }

                //튜플 타입 : 복수의 값을 리턴
                // var형 : 유추형
                string str = "100";
                var result = ToNumber(str);
                if (result.Item1)
                    Console.WriteLine($"변환 성공 : {result.Item2}");

                int number = 0;
                // out키워드를 사용할 때 임시 변수를 생성할 수 있다
                // for문의 int i 랑 비슷한 성격이다.
                if (int.TryParse("3456", out number))
                {
                    Console.WriteLine($"변환 성공 : {number}");
                }
            }

            //람다식
            // (입력 파라미터) => { 실행문장, 반환형 }
            // 예를 들어 하나의 문자열을 받아 출력하는 함수를 람다식으로 표현하면
            // str => {Console.WriteLine(str);}
            Button button = new Button();
            button.onClick += ClickEvent;
            button.onClick += delegate (object sender, EventArgs e)
            {
                Console.WriteLine("무명 메서드");
            };

            button.onClick += (sender, e) => Console.WriteLine("람다식");

            button.Click();

            // 1. 두 문자열을 이어서 출력
            // 2. 입력 받은 숫자를 제곱한 후 출력
            // 3. 입력 받은 두 숫자를 곱한 후 반환
            // 4. 두 문자열을 비교해 같은지 반환
            Action<string, string> onCall1 = delegate (string a, string b) { Console.WriteLine($"{a},{b}"); }; //무명 메서드
            onCall1 += (a, b) => Console.WriteLine($"{a},{ b}");   //람다식

            Action<int> onCall2;
            onCall2 = (a) => Console.WriteLine($"{a*a}");

            Func<int, int,int> onCall3;
            onCall3 = (a, b) =>
            {
                Console.WriteLine(a * b);
                return a * b;
            };

            Func<string, string, bool> onCall4;


            // float값을 넘겨받아 int로 형변환 후 반환하고 있다
            // =>다음에 값이 오면 반환하라는 뜻이다
            Func<float, int> onCall5 = (t) => (int)t;

           
        }


        // 만약 버튼을 눌렀을 때의 동작이 일회성이라면 함수를 선언하기가 번거롭다
        static void ClickEvent(object sender, EventArgs e)
        {
            Console.WriteLine("메서드");
        }

        // 문자열을 주면 숫자로 반환해준다. 성공여부 또한 bool값으로 준다
        // 두 자료형의 값을 튜플로 묶어서 외부로 전달한다
        static (bool isSucces, int result) ToNumber(string str)
        {
            //실제로는 무언가 연산이...
            return (true, 100);
        }

        static string Funtion(int num)
        {
            return num.ToString();
        }
        static void GetNumber(int num)
        {

        }
    }


}
