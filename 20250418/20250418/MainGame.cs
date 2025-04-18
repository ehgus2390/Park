using System.Net.Http.Headers;
using Game.enums;
using Game.Player;
using Game.Shop;



namespace Game.MainGame
{

    internal class MianGame
    {
        private Shop shop;
        private Player player;

        private int gold;
        private int selectNum;

        public MainGame()
        {
            shop = new Shop();

            player = new Player();
            gold = 10000;
            selectNum = 0;

            SetMainPage();
        }

        public void SetMainPage()
        {
            Console.Clear();
            Console.WriteLine("=====================위치==================");
            Console.WriteLine("1.상점 2. 인벤토리[판매] 3. 인벤토리[장착]");

            if (int.TryParse(Console.ReadLine(), out selectNum))
            {
                SetLocation(selectNum);
            }
        }

        public void SetLocation(int number)
        {
            switch((LOCATION)number)
            {
                case LOCATION.SHOP:
                    SetShopPage();
                break;
                case LOCATION.INVENTORY:
                    SetInventoryPage();
                break;
                case LOCATION.SELL_INVENTORY:
                    SetSellInventoryPage();
                    break;
                default:
                    SetMainPage();
                    break;
            }
        }

        public void SetInventoryPage()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============상점===============");
                Console.WriteLine("1. 방어구 2. 무기 3. 악세서리 4. 포션");
                Console.WriteLine("=============메인화면으로 나가길 원하면 0번============");
            }
        }

        public void SetSellInventoryPage()
        {

        }
        public void SetShopPage()
        {

        }
        public void 
        //static void Main(string[] args)
        //{
            
        //}
    }
}
