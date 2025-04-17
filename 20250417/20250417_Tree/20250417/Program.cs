/**************************************************
 [strategy Pattern]
 - 행동(알고리즘)을 객체로 캡슐화해서 런타임에 변경할수 있도록 하는 디자인 패턴
 - 어떤 기능을 수행하는 여러가지 방법이 있을때 해당 기능을 직접구현하는게 아니라 전략객체를 만들어서 교체
 
 
 
 **************************************************/
namespace _20250417
{
    class Monster
    {
        public string name { get; }
        private string atkType;//공격방식

        public Monster(string name, string atkType)
        {
            this.name = name;
            this.atkType = atkType; 
        }
        public void Attack()
        {
            if(atkType=="총")
            {
                Console.WriteLine($"{name}이 총으로 공격한다");
            }
            else if(atkType=="마법")
            {
                Console.WriteLine($"{name}이 강려크한 마법공격한다");
            }
        }
    }
    //공격전략 인터페이스
    interface IAttackStrategy
    {
        void Attack(string name);
    }
    class GunAttack : IAttackStrategy
    {
       public void Attack(string name) 
        {
            Console.WriteLine($"{name}이 총으로 공격한다");
        }
    }
    class MagicAttack : IAttackStrategy
    {
        public void Attack(string name)
        {
            Console.WriteLine($"{name}이 강력크한 마법 공격한다");
        }
    }
    class Monster1
    {
        public string name { get; }
        private IAttackStrategy attackStrategy;

        public Monster1(string name, IAttackStrategy attackStrategy)
        {
            this.name = name;
            this.attackStrategy = attackStrategy;   
        }
        //공격수행
        public void Attack()
        {
            attackStrategy.Attack(name);
        }
        //동적으로 공격전략 변경 가능
        public void SetAttackStrategy(IAttackStrategy attackStrategy)
        {
            this.attackStrategy = attackStrategy;
            Console.WriteLine($"{name}의 공격방식이 바뀌었다");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Monster1 goblin = new Monster1("블린이", new GunAttack());

            goblin.Attack();

            goblin.SetAttackStrategy(new MagicAttack());
            goblin.Attack();
        }
    }
}
