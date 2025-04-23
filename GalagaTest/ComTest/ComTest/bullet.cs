namespace BulletManagement
{
    public class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; private set; }
        public bool IsPlayerBullet { get; private set; }

        public Bullet(int x, int y, bool isPlayerBullet)
        {
            X = x;
            Y = y;
            IsPlayerBullet = isPlayerBullet;
            Symbol = isPlayerBullet ? '|' : '*';  // 플레이어 총알은 '|', 적 총알은 '*'
        }

        public void Move()
        {
            if (IsPlayerBullet)
            {
                Y--; // 위로 이동
            }
            else
            {
                Y++; // 아래로 이동
            }
        }
    }

    public class BulletManager
    {
        private List<Bullet> playerBullets;
        private List<Bullet> enemyBullets;
        private readonly int screenWidth;
        private readonly int screenHeight;
        private Random random;

        public BulletManager(int width, int height)
        {
            playerBullets = new List<Bullet>();
            enemyBullets = new List<Bullet>();
            screenWidth = width;
            screenHeight = height;
            random = new Random();
        }

        public void AddPlayerBullet(int x, int y)
        {
            playerBullets.Add(new Bullet(x, y, true));
        }

        public void AddEnemyBullet(int x, int y)
        {
            // 적 총알에 랜덤 방향 추가
            int direction = random.Next(5) - 2; // -2 ~ 2 사이의 값
            enemyBullets.Add(new Bullet(x + direction, y, false));
        }

        public void UpdateBullets()
        {
            // 플레이어 총알 업데이트
            for (int i = playerBullets.Count - 1; i >= 0; i--)
            {
                playerBullets[i].Move();

                // 화면 밖으로 나간 총알 제거
                if (playerBullets[i].Y < 0)
                {
                    playerBullets.RemoveAt(i);
                }
            }

            // 적 총알 업데이트
            for (int i = enemyBullets.Count - 1; i >= 0; i--)
            {
                enemyBullets[i].Move();

                // 화면 밖으로 나간 총알 제거
                if (enemyBullets[i].Y >= screenHeight)
                {
                    enemyBullets.RemoveAt(i);
                    continue;
                }

                // 적 총알 좌우 이동
                int newX = enemyBullets[i].X + (random.Next(3) - 1);
                if (newX >= 0 && newX < screenWidth)
                {
                    enemyBullets[i].X = newX;
                }
            }
        }

        public bool CheckPlayerCollision(int playerX, int playerY)
        {
            return enemyBullets.Any(bullet =>
                bullet.X == playerX && bullet.Y == playerY);
        }

        public bool CheckEnemyCollision(int enemyX, int enemyY)
        {
            for (int i = playerBullets.Count - 1; i >= 0; i--)
            {
                if (playerBullets[i].X == enemyX && playerBullets[i].Y == enemyY)
                {
                    playerBullets.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void DrawBullets(char[,] screen)
        {
            // 플레이어 총알 그리기
            foreach (var bullet in playerBullets)
            {
                if (bullet.Y >= 0 && bullet.Y < screenHeight)
                {
                    screen[bullet.Y, bullet.X] = bullet.Symbol;
                }
            }

            // 적 총알 그리기
            foreach (var bullet in enemyBullets)
            {
                if (bullet.Y >= 0 && bullet.Y < screenHeight)
                {
                    screen[bullet.Y, bullet.X] = bullet.Symbol;
                }
            }
        }

        public void Clear()
        {
            playerBullets.Clear();
            enemyBullets.Clear();
        }
    }

}