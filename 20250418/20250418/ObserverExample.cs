using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250418
{
    class Player
    {
        //아이템 수집했을때 발생하는 이벤트
        public event Action<string> onItemCollect;  //아이템을 획득했을때의 알림
        
        //이벤트을 발생시켜서 옵저버에게 알림
        public void CollectItem(string name)
        {
            Console.WriteLine($"플레이어 : {name}을 획득");
            onItemCollect?.Invoke(name);
        }
    }
    //옵저버 : UiSystem클래스는 플레이어의 아이템 수집을 알려주는 역할
    class UiSystem
    {//플레이어 객체에 자신을 구독으로 획득
        public void SubScribe(Player player)
        {
            player.onItemCollect += ShowItemMsg;
        }
        public void ShowItemMsg(string name)
        {
            Console.WriteLine($"{name}아이템을 획득");
        }
    }

    class QuestSystem
    {
        private Dictionary<string, int> item = new Dictionary<string, int>();

        public void SubScribe(Player player)
        {
            player.onItemCollect += Progress;
        }
        private void Progress(string name)
        {
            //처음 수집한 아이템이면
            if(item.ContainsKey(name))
            {
                item[name] = 0;
            }
            item[name]++;
            Console.WriteLine($"퀘스트 : {name}{item[name]}개가 수집이 되었음");

            if (item[name]>=3)
            {
                Console.WriteLine($"퀘스트 완료 : {name}이(가) 3개 수집됨");
            }
        }
    }
    internal class ObserverExample
    {
        static void Main()
        {
            Player player = new Player();

            UiSystem uiSystem = new UiSystem();
            QuestSystem questSystem = new QuestSystem();

            uiSystem.SubScribe(player);
            questSystem.SubScribe(player);

            player.CollectItem("포션");
            player.CollectItem("포션");
            player.CollectItem("포션");
            player.CollectItem("상자");
        }
    }
}
