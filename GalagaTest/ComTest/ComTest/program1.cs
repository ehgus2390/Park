using static System.Formats.Asn1.AsnWriter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Media;
using BulletManagement;


class GallagaGame
{
    private BulletManager bulletManager;
    private Bullet bullet;
    private const int WIDTH = 60;
    private const int HEIGHT = 20;
    private const int FRAME_DELAY = 50;
    private const int frame_delay = 16;
    

    private int bossX;
    private int playerX;
    private int playerY;
    private int score;
    private bool isGameOver;
    //private List<(int x, int y)> bullets;
    private List<(int x, int y)> enemies;
    //private List<(int x, int y)> enemyBullets;
    
    private List<(int x, int y)> Boss;

    private DateTime lastMoveTime = DateTime.Now; 
                                                  
    private const double MOVE_INTERVAL = 0.01;    
    private bool isMoving = false;


    private bool bossSpawned = false;
    private Stopwatch gameTimer;
    private Random random;

    public GallagaGame()
    {
        // 기존 초기화 코드...
        bulletManager = new BulletManager(WIDTH, HEIGHT);
        bossX = WIDTH / 2;
        playerY = HEIGHT - 2;
        playerX = WIDTH / 2;                           
        score = 0;                                     
        isGameOver = false;
        //bullets = new List<(int x, int y)>();          
        enemies = new List<(int x, int y)>();          
        //enemyBullets = new List<(int x, int y)>();     
        Boss = new List<(int x, int y)>();
        //SoundManager.StartBackgroundMusic();
        gameTimer = new Stopwatch();
        random = new Random();
        

        for (int i = 0; i < 9; i++)
        {
            enemies.Add((random.Next(5, WIDTH - 5), random.Next(2, 6)));        
        }
    }

    public void Run()
    {
        Console.CursorVisible = false;                                      
        Console.WindowHeight = HEIGHT + 2;
        Console.WindowWidth = WIDTH + 2;                            
        Console.WriteLine("갤러그 게임을 시작합니다!");               
        Console.WriteLine("조작법:");
        Console.WriteLine("← : 왼쪽 이동");
        Console.WriteLine("→ : 오른쪽 이동");
        Console.WriteLine("스페이스바 : 발사");
        Console.WriteLine("60초 후 보스가 등장합니다!");
        Console.WriteLine("아무 키나 누르면 시작합니다...");
        Console.ReadKey(true);

        gameTimer.Start();


        while (!isGameOver)                        
        {
            if (Console.KeyAvailable)              
            {
                HandleInput();                     
            }

            Update();                               
                                                   
                                                   
            Draw();                                

            Thread.Sleep(FRAME_DELAY);             
        }

        GameOver();
    }

    private void HandleInput()
    {
        // 스페이스바 처리 부분 수정
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);                     
        var currentTime = DateTime.Now;                                     
        
        switch (keyInfo.Key)
        {

            case ConsoleKey.LeftArrow:

                if ((currentTime - lastMoveTime).TotalSeconds >= MOVE_INTERVAL)   
                {                                                           
                    if (playerX > 1) playerX--;                             
                    lastMoveTime = currentTime;                              
                }                                                            
                break;

            case ConsoleKey.RightArrow:
                if ((currentTime - lastMoveTime).TotalSeconds >= MOVE_INTERVAL)  
                {                                                                
                    if (playerX < WIDTH - 2) playerX++;                          
                    lastMoveTime = currentTime;                                  
                }                                                               
                break;                                                          
            case ConsoleKey.UpArrow:
                if ((currentTime - lastMoveTime).TotalSeconds >= MOVE_INTERVAL)
                {
                    if (playerY > 1) playerY--;
                    lastMoveTime = currentTime;
                }
                break;
            case ConsoleKey.DownArrow:
                if ((currentTime - lastMoveTime).TotalSeconds >= MOVE_INTERVAL)
                {
                    if (playerY < HEIGHT - 2) playerY++;
                    lastMoveTime = currentTime;
                }
                break;
            case ConsoleKey.Spacebar:
                bulletManager.AddPlayerBullet(playerX, playerY - 1);        
                break;                                      

        }
    }

    private void Update()
    {
        // 총알 업데이트
        bulletManager.UpdateBullets();
        int gameTime = (int)gameTimer.Elapsed.TotalSeconds;

        if (gameTime >= 60 && !bossSpawned)                     //60초 보다 gameTime이 크거나 같을 때 = 60초 후 bossSpawned
        {
            Boss.Add((random.Next(5, WIDTH - 5), random.Next(1, 2)));
            bossSpawned = true;

            //UpdateBoss();
        }


        //적 이동 및 발사
        for (int i = enemies.Count -1; i >= 0; i--)
        {
            foreach (var enemy in enemies)
            {
                if (random.Next(100) < 70)                   
                {                                           
                    int newX = enemy.x + (random.Next(2) * 2 - 1);   
                    if (newX > 0 && newX < WIDTH - 1)           
                    {
                        enemies[i] = (newX, enemy.y);           
                    }
                }
            }

            // 적 총알 발사 로직
            foreach (var enemy in enemies)
            {
                if (random.Next(100) < 10)
                {
                    bulletManager.AddEnemyBullet(enemy.x, enemy.y + 1);
                }
            }
        }

        for (int i = Boss.Count-1; i >= 0; i--)
        {
            // 보스 총알 발사 로직
            foreach (var boss in Boss)
            {
                if (random.Next(100) < 20)
                {
                    bulletManager.AddEnemyBullet(boss.x, boss.y + 1);
                    bulletManager.AddEnemyBullet(boss.x - 1, boss.y);
                    bulletManager.AddEnemyBullet(boss.x + 1, boss.y);
                }
            }
            // 보스 이동 로직
            foreach (var boss in Boss)
            {
                if (random.Next(100) < 80)                         
                {                                                  
                    int newX = boss.x + (random.Next(7) - 3);      
                    if (newX > 0 && newX < WIDTH - 1)             
                    {
                        Boss[i] = (newX, boss.y);
                    }
                }
            }
        }
        

        // 충돌 체크
        if (bulletManager.CheckPlayerCollision(playerX, playerY))
        {
            isGameOver = true;
        }

        // 적과 총알 충돌 체크
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (bulletManager.CheckEnemyCollision(enemies[i].x, enemies[i].y))
            {
                enemies.RemoveAt(i);
                score += 100;
            }
        }

        // 적이 모두 죽었다면 새로운 적 생성
        if (enemies.Count == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                enemies.Add((random.Next(5, WIDTH - 5), random.Next(2, 8)));
            }
        }
    }

    private void Draw()
    {
        Console.SetCursorPosition(0, 0);
        int timeAttack = Math.Max(0, 60 - (int)gameTimer.Elapsed.TotalSeconds);
        // 기존 화면 초기화 코드...
        var screen = new char[HEIGHT, WIDTH];                                   
        for (int y = 0; y < HEIGHT; y++)
            for (int x = 0; x < WIDTH; x++)
                screen[y, x] = ' ';
        // 총알 그리기
        bulletManager.DrawBullets(screen);

        // 나머지 그리기 코드...
        screen[playerY, playerX] = 'A';
        foreach (var enemy in enemies)
            screen[enemy.y, enemy.x] = 'W';

        foreach (var boss in Boss)
            screen[boss.y, boss.x] = 'B';
        for (int y = 0; y < HEIGHT; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                if (screen[y, x] == 'A')
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (screen[y, x] == 'W')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (screen[y, x] == '*')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (screen[y, x] == 'B')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(screen[y, x]);
            }
            Console.WriteLine();
        }


        Console.WriteLine($"Score: {score} 남은 시간: {timeAttack}초");
    }

    private void GameOver()
    {
        bulletManager.Clear();
        // 나머지 게임오버 코드...
        Console.Clear();                                                
        Console.WriteLine($"Game Over! Final Score: {score}");          
        Console.WriteLine("Press any key to exit");                     
        Console.ReadKey();
    }
    static void Main(string[] args)
    {
        var game = new GallagaGame();
        game.Run();
    }
}
