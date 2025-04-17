using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int playerX = 40;
    static int playerY = 20;
    static List<(int x, int y)> bullets = new List<(int x, int y)>();      //bullet 변수에 x,y좌표 할당
    static List<(int x, int y)> enemies = new List<(int x, int y)>();     //enemies변수에 적의 좌표할당 Random 변수로 무작위 위치에 출력할거임
    static int score = 0;                                                //적 죽일때마다 10점 상승
    static bool gameOver = false;                                        //GameOver = false가 아니면 게임 중단
    static Random random = new Random();                                 //적 위치 랜덤할당 예정

    static void Main()
    {
        Console.CursorVisible = false;                               //마우스 커서 깜빡임 없애기
        Console.WindowHeight = 120;                                    //콘솔창 높이
        Console.WindowWidth = 200;                                   //콘솔창 넓이 조정가능

        for (int i = 0; i < 5; i++)
        {
            enemies.Add((random.Next(0, Console.WindowWidth), random.Next(0,10)));        //random.Next는 0이상 WindowWidth미만의 X좌표에 그리고 Y좌표(0이상 10미만)에 랜덤위치에 적 생성
        }

        while (!gameOver)
        {
            if(Console.KeyAvailable)                                  //KeyAvailable 이해안됨 : 콘솔 입력 버퍼에 아직 읽히지 않은 키 입력이 있는지 여부를 나타내는 불리언 속성
            {
                HandleInput();
            }
            UpdateGame();
            DrawGame();
            Thread.Sleep(50);                                     //현재 진행중인 스레드를 0.05초 동안 중지(500은 0.5초 5000은 5초)

        }

        //게임 오버화면
        Console.Clear();                                              //화면 클리어
        Console.SetCursorPosition(35, 12);                             //SetCursorPosition -->커서의 위치를 X35, Y를 12위치로 이동
        Console.WriteLine("============게임오버============");
        Console.SetCursorPosition(35, 13);                               //게임오버 메세지 출력하고 다시한번 더
    }

    static void HandleInput()                                  //비행기 조종시 방향키 조작예정
    {
        var key = Console.ReadKey(true).Key;                     //ReadKey에 true 할당함으로써 눌린값을 화면에 표시하지 않음 (이해안됨)

        switch(key)
        {
            case ConsoleKey.LeftArrow:
                if (playerX > 0) playerX--;                    //왼쪽키 눌렀을때 0보다 X값 40씩 증가하니까 PlayerX위치 --;
                break;
            case ConsoleKey.RightArrow:
                if (playerX < Console.WindowWidth -1) playerX++;     // ConsoleKey.RightArrow을 눌렀을 때 화면 넓이보다 playerX의 위치값이 작다면 (200이하까지)++;
                break;
            //case ConsoleKey.Spacebar:
            //    if 
        }

    }

    static void UpdateGame()
    {
        for (int i = bullets.Count - 1; i >= 0; i--)               //for bullets.Count -1값을 i 에 두고(bullets.Count(속성값)는 ), i 값은 0보다 크거나같고 i값이 감소??
        {
            var bullet = bullets[i];                      //i값을 List의 bullets에 넣고 그 값을 bullet변수에 할당, x값은 변하지 않으나 y값은 1씩 감소하는 루프
            bullets[i] = (bullet.x, bullet.y -1);

            if (bullet.y < 0)
            {
                bullets.RemoveAt(i);                       //bullet값이 화면밖으로 나갔을 때(<0)bullets의List에 있는 i값 제거(RemoveAt)
                continue;                                  
            }

            for (int j = enemies.Count -1; i >0; i--)                   //적이 제거될 때 인덱스 오류를 방지하기 위함?(이해안됨)
            {
                if (bullets[i].x == enemies[j].x  && bullets[i].y == enemies[j].y)            //총알의 x,y 좌표와 적의 x,y좌표를 비교했을 때 둘이 같다면
                {
                    score += 10;                                                          //스코어 +10
                    enemies.RemoveAt(j);                                                   //적 제거 총알 제거
                    bullets.RemoveAt(i);
                    enemies.Add((random.Next(0, Console.WindowWidth), 0));                 //적 제거하고 적 추가 X좌표(0,Console.WindowWidth), Y좌표0
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

            if (enemy.x == playerX && enemy.y == playerY)                                  //플레이어 좌표값이 적의 좌표와 같다면 겜오버
            {
                gameOver = true;
            }
        }
    }

    static void DrawGame()
    {
        Console.Clear();
        //플레이어
        Console.SetCursorPosition(playerY, playerX);
        Console.Write("A");
        //총알
        foreach (var bullet in bullets)
        {
            Console.SetCursorPosition(bullet.x, bullet.y);
            Console.Write("I");
        }
        //적
        foreach (var enemy in enemies)
        {
            Console.SetCursorPosition(enemy.x, enemy.y);
            Console.Write("V");
        }
        //점수표시
        Console.SetCursorPosition(0, 0);
        Console.Write($" 점수 : {score}");

    }
}
