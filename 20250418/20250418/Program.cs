/*******************************************************
[Observer Pattern]
- 객체 간 1 : N관계를 설정하여 한 객체의 상태가 변경될때 여러 객체에 자동으로 알림을 보내는 디자인 패턴
- 이벤트와 델리게이트를 사용하여 옵저버 패턴을 쉽게 구현


*******************************************************/

using System.Security.Cryptography.X509Certificates;

namespace _20250418
{
    //1. 옵저버 패턴을 사용하지 않은 경우라면
    //객체간의 직접적인 의존성이 강해짐. 변경이 있을때마다 직접수정
    //새로운 옵저버를 추가할때마다 Subject코드를 수정
    //Subject가 옵저버들을 직접 호출해야 하므로 결합도가 높아짐
    class Observer
    {
        public void Notify()
        {
            Console.WriteLine("옵저버가 변경하항을 감지");
        }
    }

    class Subject
    {
        private Observer observer;

        public void RegisterObserver(Observer observer)
        {
            this.observer = observer;
        }

        public void ChangeState()
        {
            Console.WriteLine("Subject상태가 변경됨");
            observer?.Notify();
        }
    }
    //2.만약 옵저버 패턴을 적용한다면

    class Observer1
    {
        private string name;

        public Observer1(string name, Subject1 subject1)
        {
            this.name = name;
            subject1.StateChange += Notify;
        }
        public void Notify()
        {
            Console.WriteLine($"옵저버 : {name}변경사항을 감지");
        }


    }
    

    class Subject1
    {
        public event Action StateChange;// 이벤트선언

        public void ChangeState()
        {
            Console.WriteLine("Subject 상태가 변경됨");
            StateChange?.Invoke();
        }
    }
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
        }
    }
}
