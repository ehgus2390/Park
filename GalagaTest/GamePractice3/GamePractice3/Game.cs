using System;
using System.Data;
using System.Numerics;

public class Game
{
    private Player player;
    private List<Enemy> enemies;
    private List<Bullet> bullets;
    private Random random;
    private int score;
    private bool gameOver;

    public Game()
    {
        player = new Player(Console.WindowWidth / 2, Console.WindowHeight - 2);
        enemies = new List<Enemy>();
        bullets = new List<Bullet>();
        random = new Random();
        score = 0;
        gameOver = false;

        InitializeEnemies();
    }

    private void InitializeEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            enemies.Add(new Enemy(random.Next(0, Console.WindowWidth), random.Next(0, 10)));
        }
    }

    public void Run()
    {
        Console.CursorVisible = false;
        Console.WindowHeight = 25;
        Console.WindowWidth = 80;

        while (!gameOver)
        {
            if (Console.KeyAvailable)
            {
                HandleInput();
            }
            Update();
            Draw();
            //Tread.Sleep(50);
        }
        ShowGameOver();
    }

    private void HandleInput()
    {
        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                player.Move(-1);
                break;
            case ConsoleKey.RightArrow:
                player.Move(1);
                break;
            case ConsoleKey.Spacebar:
                bullets.Add(new Bullet(player.X, player.Y - 1));
                break;
            case ConsoleKey.Escape:
                gameOver = true;
                break;
        }
    }

    private void Update()
    {
        //총알 제작
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            bullets[i].Move();

            if (bullets[i].Y < 0)
            {
                bullets.RemoveAt(i);
                continue;
            }

            //충돌체크
            for (int j = enemies.Count - 1; j >= 0; j--)
            {
                if (bullets[i].X == enemies[j].X && bullets[i].Y == enemies[j].Y)
                {
                    score += 10;
                    enemies.RemoveAt(j);
                    bullets.RemoveAt(i);
                    enemies.Add(new Enemy(random.Next(0, Console.WindowWidth), 0));
                    break;
                }
            }

            // Update enemies
            foreach (var enemy in enemies)
            {
                enemy.Move();

                if (enemy.Y >= Console.WindowHeight)
                {
                    enemy.Y = 0;
                    enemy.X = random.Next(0, Console.WindowWidth);
                }

                if (enemy.X == player.X && enemy.Y == player.Y)
                {
                    gameOver = true;
                }
            }
        }
    }

    private void Draw()
    {
        Console.Clear();


        Console.SetCursorPosition(player.X, player.Y);
        Console.Write(player.Symbol);


        foreach (var bullet in bullets)
        {
            Console.SetCursorPosition(bullet.X, bullet.Y);
            Console.Write(bullet.Symbol);
        }


        foreach (var enemy in enemies)
        {
            Console.SetCursorPosition(enemy.X, enemy.Y);
            Console.Write(enemy.Symbol);
        }


        Console.SetCursorPosition(0, 0);
        Console.Write($"Score: {score}");
    }

    private void ShowGameOver()
    {
        Console.Clear();
        Console.SetCursorPosition(35, 12);
        Console.WriteLine("Game Over!");
        Console.SetCursorPosition(35, 13);
        Console.WriteLine($"Score: {score}");
    }
}
