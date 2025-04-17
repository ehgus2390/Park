using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int playerX = 40;
    static int playerY = 20;
    static List<(int x, int y)> bullets = new List<(int x, int y)>();      //bullet ������ x,y��ǥ �Ҵ�
    static List<(int x, int y)> enemies = new List<(int x, int y)>();     //enemies������ ���� ��ǥ�Ҵ� Random ������ ������ ��ġ�� ����Ұ���
    static int score = 0;                                                //�� ���϶����� 10�� ���
    static bool gameOver = false;                                        //GameOver = false�� �ƴϸ� ���� �ߴ�
    static Random random = new Random();                                 //�� ��ġ �����Ҵ� ����

    static void Main()
    {
        Console.CursorVisible = false;                               //���콺 Ŀ�� ������ ���ֱ�
        Console.WindowHeight = 120;                                    //�ܼ�â ����
        Console.WindowWidth = 200;                                   //�ܼ�â ���� ��������

        for (int i = 0; i < 5; i++)
        {
            enemies.Add((random.Next(0, Console.WindowWidth), random.Next(0,10)));        //random.Next�� 0�̻� WindowWidth�̸��� X��ǥ�� �׸��� Y��ǥ(0�̻� 10�̸�)�� ������ġ�� �� ����
        }

        while (!gameOver)
        {
            if(Console.KeyAvailable)                                  //KeyAvailable ���ؾȵ� : �ܼ� �Է� ���ۿ� ���� ������ ���� Ű �Է��� �ִ��� ���θ� ��Ÿ���� �Ҹ��� �Ӽ�
            {
                HandleInput();
            }
            UpdateGame();
            DrawGame();
            Thread.Sleep(50);                                     //���� �������� �����带 0.05�� ���� ����(500�� 0.5�� 5000�� 5��)

        }

        //���� ����ȭ��
        Console.Clear();                                              //ȭ�� Ŭ����
        Console.SetCursorPosition(35, 12);                             //SetCursorPosition -->Ŀ���� ��ġ�� X35, Y�� 12��ġ�� �̵�
        Console.WriteLine("============���ӿ���============");
        Console.SetCursorPosition(35, 13);                               //���ӿ��� �޼��� ����ϰ� �ٽ��ѹ� ��
    }

    static void HandleInput()                                  //����� ������ ����Ű ���ۿ���
    {
        var key = Console.ReadKey(true).Key;                     //ReadKey�� true �Ҵ������ν� �������� ȭ�鿡 ǥ������ ���� (���ؾȵ�)

        switch(key)
        {
            case ConsoleKey.LeftArrow:
                if (playerX > 0) playerX--;                    //����Ű �������� 0���� X�� 40�� �����ϴϱ� PlayerX��ġ --;
                break;
            case ConsoleKey.RightArrow:
                if (playerX < Console.WindowWidth -1) playerX++;     // ConsoleKey.RightArrow�� ������ �� ȭ�� ���̺��� playerX�� ��ġ���� �۴ٸ� (200���ϱ���)++;
                break;
            //case ConsoleKey.Spacebar:
            //    if 
        }

    }

    static void UpdateGame()
    {
        for (int i = bullets.Count - 1; i >= 0; i--)               //for bullets.Count -1���� i �� �ΰ�(bullets.Count(�Ӽ���)�� ), i ���� 0���� ũ�ų����� i���� ����??
        {
            var bullet = bullets[i];                      //i���� List�� bullets�� �ְ� �� ���� bullet������ �Ҵ�, x���� ������ ������ y���� 1�� �����ϴ� ����
            bullets[i] = (bullet.x, bullet.y -1);

            if (bullet.y < 0)
            {
                bullets.RemoveAt(i);                       //bullet���� ȭ������� ������ ��(<0)bullets��List�� �ִ� i�� ����(RemoveAt)
                continue;                                  
            }

            for (int j = enemies.Count -1; i >0; i--)                   //���� ���ŵ� �� �ε��� ������ �����ϱ� ����?(���ؾȵ�)
            {
                if (bullets[i].x == enemies[j].x  && bullets[i].y == enemies[j].y)            //�Ѿ��� x,y ��ǥ�� ���� x,y��ǥ�� ������ �� ���� ���ٸ�
                {
                    score += 10;                                                          //���ھ� +10
                    enemies.RemoveAt(j);                                                   //�� ���� �Ѿ� ����
                    bullets.RemoveAt(i);
                    enemies.Add((random.Next(0, Console.WindowWidth), 0));                 //�� �����ϰ� �� �߰� X��ǥ(0,Console.WindowWidth), Y��ǥ0
                    break;
                }
            }
        }

        for (int i = enemies.Count-1; i >=0; i--)
        {
            var enemy = enemies[i];
            enemies[i] = (enemy.x, enemy.y + 1);

            if(enemy.y >= Console.WindowHeight)
            {
                enemies[i] = (random.Next(0, Console.WindowWidth), 0);
            }

            if (enemy.x == playerX && enemy.y == playerY)                                  //�÷��̾� ��ǥ���� ���� ��ǥ�� ���ٸ� �׿���
            {
                gameOver = true;
            }
        }
    }

    static void DrawGame()
    {
        Console.Clear();
        //�÷��̾�
        Console.SetCursorPosition(playerY, playerX);
        Console.Write("A");
        //�Ѿ�
        foreach (var bullet in bullets)
        {
            Console.SetCursorPosition(bullet.x, bullet.y);
            Console.Write("I");
        }
        //��
        foreach (var enemy in enemies)
        {
            Console.SetCursorPosition(enemy.x, enemy.y);
            Console.Write("V");
        }
        //����ǥ��
        Console.SetCursorPosition(0, 0);
        Console.Write($" ���� : {score}");

    }
}
