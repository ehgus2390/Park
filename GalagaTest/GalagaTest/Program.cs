using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int playerX = 40;
    static int playerY = 20;
    static List<(int x, int y)> bullets = new List<(int x, int y)>();
    static List<(int x, int y)> enemies = new List<(int x, int y)>();
    static int score = 0;
    static bool gameOver = false;
    static Random random = new Random();

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.WindowHeight = 25;
        Console.WindowWidth = 80;

        // 초기 적 생성
        for (int i = 0; i < 5; i++)
        {
            enemies.Add((random.Next(0, Console.WindowWidth), random.Next(0, 10)));
        }

        // 게임 루프
        while (!gameOver)
        {
            if (Console.KeyAvailable)
            {
                HandleInput();
            }

            UpdateGame();
            DrawGame();
            Thread.Sleep(50);
        }

        // 게임 오버 화면
        Console.Clear();
        Console.SetCursorPosition(35, 12);
        Console.WriteLine("Game Over!");
        Console.SetCursorPosition(35, 13);
        Console.WriteLine($"Score: {score}");
    }

    static void HandleInput()
    {
        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (playerX > 0) playerX--;
                break;
            case ConsoleKey.RightArrow:
                if (playerX < Console.WindowWidth - 1) playerX++;
                break;
            case ConsoleKey.Spacebar:
                bullets.Add((playerX, playerY - 1));
                break;
            case ConsoleKey.Escape:
                gameOver = true;
                break;
        }
    }

    static void UpdateGame()
    {
        // 총알 업데이트
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            var bullet = bullets[i];
            bullets[i] = (bullet.x, bullet.y - 1);

            if (bullet.y < 0)
            {
                bullets.RemoveAt(i);
                continue;
            }

            // 충돌 검사
            for (int j = enemies.Count - 1; j >= 0; j--)
            {
                if (bullets[i].x == enemies[j].x && bullets[i].y == enemies[j].y)
                {
                    score += 10;
                    enemies.RemoveAt(j);
                    bullets.RemoveAt(i);
                    enemies.Add((random.Next(0, Console.WindowWidth), 0));
                    break;
                }
            }
        }

        // 적 업데이트
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            var enemy = enemies[i];
            enemies[i] = (enemy.x, enemy.y + 1);

            if (enemy.y >= Console.WindowHeight)
            {
                enemies[i] = (random.Next(0, Console.WindowWidth), 0);
            }

            // 플레이어와 충돌 검사
            if (enemy.x == playerX && enemy.y == playerY)
            {
                gameOver = true;
            }
        }
    }

    static void DrawGame()
    {
        Console.Clear();

        // 플레이어 그리기
        Console.SetCursorPosition(playerX, playerY);
        Console.Write("A");

        // 총알 그리기
        foreach (var bullet in bullets)
        {
            Console.SetCursorPosition(bullet.x, bullet.y);
            Console.Write("|");
        }

        // 적 그리기
        foreach (var enemy in enemies)
        {
            Console.SetCursorPosition(enemy.x, enemy.y);
            Console.Write("V");
        }

        // 점수 표시
        Console.SetCursorPosition(0, 0);
        Console.Write($"Score: {score}");
    }
}
