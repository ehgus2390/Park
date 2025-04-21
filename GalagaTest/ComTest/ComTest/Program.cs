using System;
using System.Collections.Generic;
using System.Threading;
 /**********************************************************************
 [�ٽɷ���]
 -  �÷��̾� ������(�Ѿ�, �� �Ѿ�, �� ��ü) �浹�˻�� ����Ʈ���� �ε������� for���� ����Ͽ� �������� ��ȸ��
 �� ����) for���� ������� ��ȸ������(�Ѿ��̳� �� ��ü) ������ �ε����� ��ġ�� ������ ��ȸ�� �ε����� ��ĭ�� �и��� �ȴ�
 �� �׷��� �Ǹ� ������ �߻��ϰ� ��.(���� : a= [1,2,3,4]�� ����Ʈ�� �ִٰ� ����. [1]�� ��ġ�� �ִ� 2�� �������� �� 3�� 2�� ��ġ�� ���Ե�)
 �� �̷��� �Ǹ� �ڵ����� 3�� �ǳʶٰ� 4(�ε���[2]�� ��ġ)�� ��ȸ�ϰ� ��.-->���� �߻�
 �� �������� ����Ʈ ������ ��ȸ���� �� ������ �߻����� ����--> ����) a = [1,2,3,4] �� �� [3]����ġ�� 4�� ��ȸ. ����[2]����ġ�� 3, [1]�� ��ġ�� 2�� ���� ���� ���� �� ���� ������ 1[0]�� ��ȸ
 
  **********************************************************************/
 
class GallagaGame
{
    private const int WIDTH = 60;
    private const int HEIGHT = 20;
    private const int FRAME_DELAY = 50;

    private int playerX;
    private int score;
    private bool isGameOver;
    private List<(int x, int y)> bullets;
    private List<(int x, int y)> enemies;
    private List<(int x, int y)> enemyBullets;
    private Random random;

    public GallagaGame()
    {
        playerX = WIDTH / 2;                           //��ü ȭ���� 1/2 ���� ����
        score = 0;                                     //���ھ� 0������ ���� �� ��ü ���߽�+=100
        isGameOver = false;
        bullets = new List<(int x, int y)>();          //List<(x,y)>�� bullets������ �Ҵ�
        enemies = new List<(int x, int y)>();           //List<(x,y)>�� enemies������ �Ҵ�
        enemyBullets = new List<(int x, int y)>();     //List<(x,y)>�� enemyBullets������ �Ҵ�
        random = new Random();


        // �ʱ� �� ����
        for (int i = 0; i < 9; i++)
        {
            enemies.Add((random.Next(5, WIDTH - 5), random.Next(2, 8)));        //�� ?���� ���� random��ġ(x��ǥ 5�̻� WIDTH-5����),(Y��ǥ 2�̻� 8����)
        }
    }

    public void Run()
    {
        Console.CursorVisible = false;                                      //Ŀ����ġ ����
        Console.WindowHeight = HEIGHT + 2;
        Console.WindowWidth = WIDTH + 2;                            //�ܼ�â�� ���̸� �����Ҷ� Player��ü�� �������� ����ؼ� ��ü ����(WIDTH)�� +2�� ���� 
                                                                           //�ܼ�â�� ũ��� ����
        while (!isGameOver)                                       //!isGameOver�� ���� ������ ������ �ʾ��� �� while���� ����
        {
            if (Console.KeyAvailable)                           //����ڰ� Ű�� �Է��ߴ��� Ȯ���ϴ� �Լ�
            {
                HandleInput();                                        //Ű�� ���ȴٸ� HandleInput�Լ� ����
            }
            
            Update();                               //Update �Լ� ���泻�� ����(�Ѿ���ġ, �� �Ѿ���ġ, �� �̵�����, �浹üũ(checkCollision), �� ����)
                                                    //Update�Լ� �ȿ� CheckCollisions�Լ� �Է�(CheckCollisions�Լ��� �÷��̾��� X,Y��ǥ��)�� �Ѿ��� X,Y��ǥ �˻� ��
                                                    //isgameOver = True �� �� GameOver();�Լ� ȣ��
            Draw();                                                     //Draw�Լ�(�� ���, �÷��̾� ��ü, �Ѿ�, ����ȭ�� ���/�ʱ�ȭ)

            Thread.Sleep(FRAME_DELAY);                              //���� ��� �װ� �ٽ� ���ο� ���� ������ �� 1�ʵ��� ȭ������ �� �����
        }

        GameOver();                                                 //Update�Լ� isgameOver = true �� �� gameOver�Լ� ȣ��
    }                                                               

    private void HandleInput()
    {//�÷��̾� �̵�Ű
        var key = Console.ReadKey(true).Key;                        //ReadKey�� Ű �Է��� ��ٸ�. true�� ���� Ű�� ȭ�鿡 ǥ������ �ʱ� ����.
        
        switch (key)                                                //var key������ switch�� �Ҵ�
        {
            case ConsoleKey.LeftArrow:
                if (playerX > 1) playerX--;                         //playerX�� ��ġ�� ���� X��ǥ 1���ٸ� ũ�ٸ� PlayerX��ġ�� 1�� ���ҽ�ŵ�ϴ�
                break;
            case ConsoleKey.RightArrow:
                if (playerX < WIDTH - 2) playerX++;                 //playerX�� ��ü �ܼ� ȭ���� ũ�⺸�� -2�۴ٸ� ���������� ++(1)�� ����
                break;
            case ConsoleKey.Spacebar:
                bullets.Add((playerX, HEIGHT - 2));                 //bullet(�Ѿ�)�� ������ġ�� playerX�� ����, ������ġ�� �ܼ�ȭ�鿡��-2�� ����
                break;                                                  //�̷��� ���� ���� �� playerX�� �Ѿ��� �߻��ϴ� ��ó�� ����
        }
    }

    private void Update()
    {
        // �Ѿ� �̵�
        for (int i = bullets.Count-1; i >= 0; i--)              //bullets����Ʈ�� ������ ��Һ��� �������� ��ȸ
        {                                                     //�÷��̾��� �Ѿ�[i]�� ������� ��ȸ���� �� ������ �Ѿ��� ����Ʈ �ε����� ȣ������ �ʰԵǰ�
            var bullet = bullets[i];                        //������ ���� �׷��� �Ѿ��� ����Ʈ�� �������� ����ϸ� �տ� ������ �ε����� ������ --->
            bullets[i] = (bullet.x, bullet.y - 1);              //�ٸ� ����� �ε����� ������ ��ġ�� �ʾ� ������ ����
            if (bullet.y < 0)
            {
                bullets.RemoveAt(i);
            }
        }

        // �� �Ѿ� �̵�
        for (int i = enemyBullets.Count-1; i >= 0; i--)
        {
            var bullet = enemyBullets[i];                       //enemyBullets[i]����Ʈ�� bullet�� �ְ�
            int direction = random.Next(3) - 1;         //int direction = random.Next(3) - 1; ====>-1 , 0 , 1
            int newX = bullet.x + direction;          //-1(����),0(���),1(������)���������� bullet.x��� ���ϰ� newX������ �Ҵ�
            int newY = bullet.y + 1;                            //bullet.x�� �ش��ϴ� bullet.y��ǥ�� +1�� ����
            if (newX >=0 && newX < WIDTH)               //ȭ�� �ȿ� ������ ���ؼ� x���� 0���� ũ�� ȭ���� ����(WIDTH=60)���� �۾ƾ� ��
            {
                enemyBullets[i] = (newX, newY);             //
            }
            else
            {
                enemyBullets[i] = (bullet.x, newY);
            }
            if (bullet.y >= HEIGHT)                             //�Ѿ��� y��ǥ�� HEIGHT(Y��ǥ20)���� ũ�ų� ������ 
            {
                enemyBullets.RemoveAt(i);                       //�����Ѿ�(enemyBullets)�� i����Ʈ���� ������
            }
        }

        // �� �̵� �� �߻�
        for (int i = enemies.Count-1; i >= 0; i--)
        {   // �� �Ѿ˹߻� ��
            var enemy = enemies[i];
            if (random.Next(100) < 25) // 2% Ȯ���� �߻�(��������)   //Ȯ�� ��������(30���� ������ random.Next�� ���ڰ� 30���� ������ �Ѿ˹߻�)
            {
                enemyBullets.Add((enemy.x, enemy.y + 1));  //���� x��ǥ,y��ǥ+1(1ĭ �Ʒ�)�� ��ġ�� ���� �Ѿ˻��� 
            }
            
            // �¿� ���� �̵�
            if (random.Next(100) < 60)                   //0���� 99������ �����߿� �������� ������ ���ڸ� ���-->�� ���ڰ� 30���� ������
            {                                       //enemy.x ��ǥ�� random.Next(2) * 2 - 1�� -1 �Ǵ� 1�� �������� �����ؼ� ���� �Ǵ� ������ �̵� -->int newX�� ������ �Ҵ�
                int newX = enemy.x + (random.Next(2) * 2 - 1);   //���� ���� X��ǥ�� -1�Ǵ�1�� ���ϰ� ���ο� X��ǥ(newX)�� �Ҵ�
                if (newX > 0 && newX < WIDTH - 1)           //ȭ���� �ִ�ġ ��ǥ(X�� 0���� ũ�� && WIDTH���� -1 �۴�)��
                {
                    enemies[i] = (newX, enemy.y);           //newX(���ο���ǥ)�� enemy(2,8)��ǥ�� enemies����Ʈ�� ����
                }
            }
        }

        // �浹 üũ
        CheckCollision();

        // ���� ��� �׾��ٸ� ���ο� �� ����
        if (enemies.Count == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                enemies.Add((random.Next(5, WIDTH - 5), random.Next(2, 8)));
            }
        }
    }
    
    private void CheckCollision()
    {
        // �÷��̾� �Ѿ˰� �� �浹
        for (int i = bullets.Count - 1; i >= 0; i--)         //�÷��̾��� �Ѿ�[i]�� ������� ��ȸ�ϰ� �������� �� ������ �Ѿ��ε������� ��Ҹ� �ǳʶپ(����Ʈ�� �ε�����Ұ� ��ĭ�� ������)
        {                                                      //������ ���� �׷��� �Ѿ��� ����Ʈ�� �������� ����ϸ� �տ� ������ �ε����� ���� ������ ����
            for (int j = enemies.Count - 1; j >= 0; j--)
            {
                if (bullets[i].x == enemies[j].x && bullets[i].y == enemies[j].y)   //����� �Ѿ��� ��ġ�� �� ��üX,Y��ǥ ��ġ�� 
                {
                    bullets.RemoveAt(i);                                  //i����ġ�� ���� �Ѿ��� ����
                    enemies.RemoveAt(j);                                 //j�� ��ġ�� ���� �� ����
                    score += 100;                                         //���ھ� +=100
                    goto NextBullet;                            //NextBullet���� ��� �̵�
                }
            }
        }
    NextBullet:

        // �� �Ѿ˰� �÷��̾� �浹
        foreach (var bullet in enemyBullets)                                     //enemyBullets�� ��� �Ѿ��� ��ȸ
        {
            if (bullet.x == playerX && bullet.y == HEIGHT - 1)                       //�÷��̾��� X��ǥ�� ��bullet��X��ǥ�� ���� bullet.y��ǥ�� �÷��̾� Y(HEIGHT -1)��ǥ�� ���ٸ�
            {                                                                         //HEIGHT-1(�÷��̾��� Y��ǥ)�� ��ǥ�� ��ġ�ϴ��� �˻�(�÷��̾���Y��ǥ�� HEIGHT-2)
                isGameOver = true;                                                  //��ġ�Ѵٸ� isGameOver = true�� ��ȯ
                return;
            }
        }
    }

    private void Draw()
    {
        Console.SetCursorPosition(0, 0);

        // ���� ȭ�� �ʱ�ȭ
        var screen = new char[HEIGHT, WIDTH];                                   //�� �迭�� char������ 2���� �迭�� ����(���� ȭ���� �� ��ġ�� ����ڸ� ������� ����)
        for (int y = 0; y < HEIGHT; y++)
            for (int x = 0; x < WIDTH; x++)
                screen[y, x] = ' ';

        // �÷��̾�
        //Console.SetCursorPosition(playerX, HEIGHT);
        //Console.ForegroundColor = ConsoleColor.White;
        screen[HEIGHT - 1, playerX] = 'A';                                  //�÷��̾�'A'��ġ HEIGHT(�ִ�20)-1 --->Y��ǥ , X��ǥ--->2/60
        //Console.Write(playerX.Symbol);
        

        // �Ѿ�
        foreach (var bullet in bullets)                                     //foreach���� ����Ͽ� bullets����Ʈ���� ��� bullet�� ��ȸ
            if (bullet.y >= 0 && bullet.y < HEIGHT)                     //�Ѿ��� ��ġ�� y�࿡�� 0���� ũ�ų����� HEIGHT(20)���� ���� ���ǿ���
                screen[bullet.y, bullet.x] = '|';                      //screen�迭�� ��ġ�� '��'���� ���

        // �� �Ѿ�
        
        foreach (var bullet in enemyBullets)                        //enemyBullets����Ʈ�� ��� �Ѿ� ��ȸ
            if (bullet.y >= 0 && bullet.y < HEIGHT)             //�Ѿ��� ��ġ�� y�࿡�� 0���� ũ�ų����� HEIGHT(20)���� ���� ���ǿ���
                screen[bullet.y, bullet.x] = '*';                   //screen�迭�� ��ġ�� '��'���� ���(�Ѿ��� ȭ������� ������ ������� ����)

        // �� ��ü
        //Console.ForegroundColor = ConsoleColor.Red;
        foreach (var enemy in enemies)
            screen[enemy.y, enemy.x] = 'W';

        // ȭ�� ���
        for (int y = 0; y < HEIGHT; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                if (screen[y,x]=='A')
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (screen[y,x]=='W')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (screen[y,x] =='*')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                //else
                //{
                //    Console.ForegroundColor = ConsoleColor.Gray;
                //}
                Console.Write(screen[y, x]);
            }
            Console.WriteLine();
        }

        // ���� ���
        Console.WriteLine($"Score: {score}");
    }

    private void GameOver()
    {
        Console.Clear();                                                //���� �Ѿ��� ������ �ܼ�â clear
        Console.WriteLine($"Game Over! Final Score: {score}");          //�� ���ھ� Ȯ��
        Console.WriteLine("Press any key to exit...");                      //�������� Ű
        Console.ReadKey();                                          
    }

    static void Main(string[] args)
    {
        var game = new GallagaGame();
        game.Run();
    }
}
