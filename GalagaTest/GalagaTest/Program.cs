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

        // �ʱ� �� ����
        for (int i = 0; i < 5; i++)
        {
            enemies.Add((random.Next(0, Console.WindowWidth), random.Next(0, 10)));
        }

        // ���� ����
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

        // ���� ���� ȭ��
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
        // �Ѿ� ������Ʈ
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            var bullet = bullets[i];
            bullets[i] = (bullet.x, bullet.y - 1);

            if (bullet.y < 0)
            {
                bullets.RemoveAt(i);
                continue;
            }

            // �浹 �˻�
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

        // �� ������Ʈ
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            var enemy = enemies[i];
            enemies[i] = (enemy.x, enemy.y + 1);

            if (enemy.y >= Console.WindowHeight)
            {
                enemies[i] = (random.Next(0, Console.WindowWidth), 0);
            }

            // �÷��̾�� �浹 �˻�
            if (enemy.x == playerX && enemy.y == playerY)
            {
                gameOver = true;
            }
        }
    }

    static void DrawGame()
    {
        Console.Clear();

        // �÷��̾� �׸���
        Console.SetCursorPosition(playerX, playerY);
        Console.Write("A");

        // �Ѿ� �׸���
        foreach (var bullet in bullets)
        {
            Console.SetCursorPosition(bullet.x, bullet.y);
            Console.Write("|");
        }

        // �� �׸���
        foreach (var enemy in enemies)
        {
            Console.SetCursorPosition(enemy.x, enemy.y);
            Console.Write("V");
        }

        // ���� ǥ��
        Console.SetCursorPosition(0, 0);
        Console.Write($"Score: {score}");
    }
}
