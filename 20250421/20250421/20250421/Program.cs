using static System.Formats.Asn1.AsnWriter;

namespace _20250421
{
    class Game
    {
        private int WIDTH = 60;
        private int HEIGHT = 20;
        private List<(int x, int y)> enemies;
        private List<(int x, int y)> bullets;
        private List<(int x, int y)> enemyBullets;
        private Random random;

        public Game()
        {
            bullets = new List<(int x, int y)>();
            enemyBullets = new List<(int x, int y)>();
            random = new Random();


            for (int i = 0; i < 5; i++)
            {
                enemies.Add((random.Next(5, WIDTH - 5), random.Next(2, 8)));
            }
        }
        private void Update()
        {   //총알이동
            for (int i = bullets.Count; i < 0; i++)
            {
                var bullet = bullets[i];
                bullets[i] = (bullet.x, bullet.y - 1);
                if (bullet.y <0)
                {
                    bullets.RemoveAt(i);
                }
            }
            //적 총알이동
            for (int i = bullets.Count -1; i >= 0; i--)
            {
                var bullet = bullets[i];
                if (bullet.y >= HEIGHT)
                {
                    enemyBullets.RemoveAt(i);
                }
            }

            //적 이동 및 발사
            for (int i = enemies.Count -1; i >= 0; i--)
            {
                var enemy = enemies[i];
                if (random.Next(100) < 2)
                {
                    enemyBullets.Add((enemy.x, enemy.y + 1));
                }

                if (random.Next(100) < 40)
                {
                    int newX = enemy.x + (random.Next(2) * 2 - 1);
                    if (newX >0 && newX < WIDTH -1)
                    {
                        enemies[i] = (newX, enemy.y);
                    }
                }
            }
            // 충돌 체크
            CheckCollisions();

            // 적이 모두 죽었다면 새로운 적 생성
            if (enemies.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    enemies.Add((random.Next(5, WIDTH - 5), random.Next(2, 8)));
                }
            }
        }
    }

    private void CheckCollisions()
        {
            // 플레이어 총알과 적 충돌
            for (int i = bullets.Count - 1; i >= 0; i--)         //플레이어의 총알[i]가 순서대로 순회하고 삭제했을 때 삭제된 총알인덱스안의 요소를 건너뛰어서(리스트의 인덱스요소가 한칸씩 땡겨짐)
            {                                                      //오류가 생김 그래서 총알의 리스트를 역순으로 출력하면 앞에 없어진 인덱스의 값에 오류가 없음
                for (int j = enemies.Count - 1; j >= 0; j--)
                {
                    if (bullets[i].x == enemies[j].x && bullets[i].y == enemies[j].y)   //사용자 총알의 위치와 적 기체X,Y좌표 일치시 
                    {
                        bullets.RemoveAt(i);                                  //i값일치시 현재 총알을 제거
                        enemies.RemoveAt(j);                                 //j값 일치시 현재 적 제거
                        score += 100;                                         //스코어 +=100
                        goto NextBullet;                            //NextBullet으로 즉시 이동
                    }
                }
            }
        NextBullet:

            // 적 총알과 플레이어 충돌
            foreach (var bullet in enemyBullets)                                     //enemyBullets의 모든 총알을 순회
            {
                if (bullet.x == playerX && bullet.y == HEIGHT - 1)                       //플레이어의 X좌표와 적bullet의X좌표가 같고 bullet.y좌표가 플레이어 Y(HEIGHT -1)좌표와 같다면
                {                                                                         //HEIGHT-1(플레이어의 Y좌표)의 좌표와 일치하는지 검사(플레이어의Y좌표는 HEIGHT-2)
                    isGameOver = true;                                                  //일치한다면 isGameOver = true를 반환
                    return;
                }
            }
        }
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in enemies)
            {
                
            }
        }
    }
}
