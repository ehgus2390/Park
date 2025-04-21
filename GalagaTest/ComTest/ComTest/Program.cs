using System;
using System.Collections.Generic;
using System.Threading;
 /**********************************************************************
 [핵심로직]
 -  플레이어 움직임(총알, 적 총알, 적 기체) 충돌검사시 리스트안의 인덱스들을 for문을 사용하여 역순으로 순회함
 ㄴ 예시) for문을 순서대로 순회했을때(총알이나 적 기체) 삭제된 인덱스의 위치로 다음에 순회할 인덱스가 한칸씩 밀리게 된다
 ㄴ 그렇게 되면 오류가 발생하게 됨.(순행 : a= [1,2,3,4]의 리스트가 있다고 가정. [1]의 위치에 있는 2가 삭제됐을 때 3은 2의 위치로 오게됨)
 ㄴ 이렇게 되면 자동으로 3은 건너뛰고 4(인덱스[2]에 위치)를 순회하게 됨.-->오류 발생
 ㄴ 역행으로 리스트 값들을 순회했을 시 오류가 발생하지 않음--> 예시) a = [1,2,3,4] 일 때 [3]에위치한 4를 순회. 다음[2]에위치한 3, [1]에 위치한 2의 값이 제거 됐을 때 다음 순서인 1[0]을 순회
 
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
        playerX = WIDTH / 2;                           //전체 화면의 1/2 에서 시작
        score = 0;                                     //스코어 0점에서 시작 적 기체 명중시+=100
        isGameOver = false;
        bullets = new List<(int x, int y)>();          //List<(x,y)>값 bullets변수에 할당
        enemies = new List<(int x, int y)>();           //List<(x,y)>값 enemies변수에 할당
        enemyBullets = new List<(int x, int y)>();     //List<(x,y)>값 enemyBullets변수에 할당
        random = new Random();


        // 초기 적 생성
        for (int i = 0; i < 9; i++)
        {
            enemies.Add((random.Next(5, WIDTH - 5), random.Next(2, 8)));        //적 ?마리 생성 random위치(x좌표 5이상 WIDTH-5이하),(Y좌표 2이상 8이하)
        }
    }

    public void Run()
    {
        Console.CursorVisible = false;                                      //커서위치 숨김
        Console.WindowHeight = HEIGHT + 2;
        Console.WindowWidth = WIDTH + 2;                            //콘솔창의 넓이를 설정할때 Player기체의 움직임을 고려해서 전체 넓이(WIDTH)에 +2한 값을 
                                                                           //콘솔창의 크기로 설정
        while (!isGameOver)                                       //!isGameOver는 아직 게임이 끝나지 않았을 때 while루프 실행
        {
            if (Console.KeyAvailable)                           //사용자가 키를 입력했는지 확인하는 함수
            {
                HandleInput();                                        //키가 눌렸다면 HandleInput함수 실행
            }
            
            Update();                               //Update 함수 변경내용 실행(총알위치, 적 총알위치, 적 이동방향, 충돌체크(checkCollision), 적 생성)
                                                    //Update함수 안에 CheckCollisions함수 입력(CheckCollisions함수는 플레이어의 X,Y좌표와)적 총알의 X,Y좌표 검사 후
                                                    //isgameOver = True 일 때 GameOver();함수 호출
            Draw();                                                     //Draw함수(적 모양, 플레이어 기체, 총알, 게임화면 출력/초기화)

            Thread.Sleep(FRAME_DELAY);                              //적이 모두 죽고 다시 새로운 적을 생성할 때 1초동안 화면종료 후 재출력
        }

        GameOver();                                                 //Update함수 isgameOver = true 일 때 gameOver함수 호출
    }                                                               

    private void HandleInput()
    {//플레이어 이동키
        var key = Console.ReadKey(true).Key;                        //ReadKey로 키 입력을 기다림. true는 눌린 키를 화면에 표시하지 않기 위함.
        
        switch (key)                                                //var key변수를 switch에 할당
        {
            case ConsoleKey.LeftArrow:
                if (playerX > 1) playerX--;                         //playerX의 위치가 현재 X좌표 1보다만 크다면 PlayerX위치를 1씩 감소시킵니다
                break;
            case ConsoleKey.RightArrow:
                if (playerX < WIDTH - 2) playerX++;                 //playerX가 전체 콘솔 화면의 크기보다 -2작다면 오른쪽으로 ++(1)씩 증가
                break;
            case ConsoleKey.Spacebar:
                bullets.Add((playerX, HEIGHT - 2));                 //bullet(총알)의 가로위치는 playerX와 동일, 세로위치는 콘솔화면에서-2를 뺀값
                break;                                                  //이렇게 설정 했을 때 playerX가 총알을 발사하는 것처럼 보임
        }
    }

    private void Update()
    {
        // 총알 이동
        for (int i = bullets.Count-1; i >= 0; i--)              //bullets리스트의 마지막 요소부터 역순으로 순회
        {                                                     //플레이어의 총알[i]가 순서대로 순회했을 때 없어진 총알의 리스트 인덱스를 호출하지 않게되고
            var bullet = bullets[i];                        //오류가 생김 그래서 총알의 리스트를 역순으로 출력하면 앞에 없어진 인덱스의 삭제가 --->
            bullets[i] = (bullet.x, bullet.y - 1);              //다른 요소의 인덱스에 영향을 미치지 않아 오류가 없음
            if (bullet.y < 0)
            {
                bullets.RemoveAt(i);
            }
        }

        // 적 총알 이동
        for (int i = enemyBullets.Count-1; i >= 0; i--)
        {
            var bullet = enemyBullets[i];                       //enemyBullets[i]리스트를 bullet에 넣고
            int direction = random.Next(3) - 1;         //int direction = random.Next(3) - 1; ====>-1 , 0 , 1
            int newX = bullet.x + direction;          //-1(왼쪽),0(가운데),1(오른쪽)랜덤방향을 bullet.x축과 더하고 newX변수에 할당
            int newY = bullet.y + 1;                            //bullet.x에 해당하는 bullet.y좌표를 +1씩 증가
            if (newX >=0 && newX < WIDTH)               //화면 안에 구성을 위해서 x축이 0보다 크고 화면의 넓이(WIDTH=60)보다 작아야 함
            {
                enemyBullets[i] = (newX, newY);             //
            }
            else
            {
                enemyBullets[i] = (bullet.x, newY);
            }
            if (bullet.y >= HEIGHT)                             //총알의 y좌표가 HEIGHT(Y좌표20)보다 크거나 같을때 
            {
                enemyBullets.RemoveAt(i);                       //적의총알(enemyBullets)은 i리스트에서 지워짐
            }
        }

        // 적 이동 및 발사
        for (int i = enemies.Count-1; i >= 0; i--)
        {   // 적 총알발사 빈도
            var enemy = enemies[i];
            if (random.Next(100) < 25) // 2% 확률로 발사(조정가능)   //확률 조정가능(30으로 수정시 random.Next의 숫자가 30보다 작으면 총알발사)
            {
                enemyBullets.Add((enemy.x, enemy.y + 1));  //적의 x좌표,y좌표+1(1칸 아래)의 위치에 적의 총알생성 
            }
            
            // 좌우 랜덤 이동
            if (random.Next(100) < 60)                   //0에서 99까지의 숫자중에 랜덤으로 무작위 숫자를 출력-->이 숫자가 30보다 작으면
            {                                       //enemy.x 좌표에 random.Next(2) * 2 - 1은 -1 또는 1을 무작위로 생성해서 왼쪽 또는 오른쪽 이동 -->int newX의 변수에 할당
                int newX = enemy.x + (random.Next(2) * 2 - 1);   //적의 현재 X좌표에 -1또는1을 더하고 새로운 X좌표(newX)에 할당
                if (newX > 0 && newX < WIDTH - 1)           //화면의 최대치 좌표(X가 0보다 크고 && WIDTH보다 -1 작다)면
                {
                    enemies[i] = (newX, enemy.y);           //newX(새로운좌표)와 enemy(2,8)좌표를 enemies리스트에 넣음
                }
            }
        }

        // 충돌 체크
        CheckCollision();

        // 적이 모두 죽었다면 새로운 적 생성
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

    private void Draw()
    {
        Console.SetCursorPosition(0, 0);

        // 게임 화면 초기화
        var screen = new char[HEIGHT, WIDTH];                                   //이 배열은 char형식의 2차원 배열을 형성(게임 화면의 각 위치에 어떤문자를 출력할지 저장)
        for (int y = 0; y < HEIGHT; y++)
            for (int x = 0; x < WIDTH; x++)
                screen[y, x] = ' ';

        // 플레이어
        //Console.SetCursorPosition(playerX, HEIGHT);
        //Console.ForegroundColor = ConsoleColor.White;
        screen[HEIGHT - 1, playerX] = 'A';                                  //플레이어'A'위치 HEIGHT(최대20)-1 --->Y좌표 , X좌표--->2/60
        //Console.Write(playerX.Symbol);
        

        // 총알
        foreach (var bullet in bullets)                                     //foreach문을 사용하여 bullets리스트안의 모든 bullet을 순회
            if (bullet.y >= 0 && bullet.y < HEIGHT)                     //총알의 위치가 y축에서 0보다 크거나같고 HEIGHT(20)보다 작은 조건에서
                screen[bullet.y, bullet.x] = '|';                      //screen배열의 위치에 'ㅣ'문자 출력

        // 적 총알
        
        foreach (var bullet in enemyBullets)                        //enemyBullets리스트의 모든 총알 순회
            if (bullet.y >= 0 && bullet.y < HEIGHT)             //총알의 위치가 y축에서 0보다 크거나같고 HEIGHT(20)보다 작은 조건에서
                screen[bullet.y, bullet.x] = '*';                   //screen배열의 위치에 'ㅣ'문자 출력(총알이 화면밖으로 나가면 출력하지 않음)

        // 적 기체
        //Console.ForegroundColor = ConsoleColor.Red;
        foreach (var enemy in enemies)
            screen[enemy.y, enemy.x] = 'W';

        // 화면 출력
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

        // 점수 출력
        Console.WriteLine($"Score: {score}");
    }

    private void GameOver()
    {
        Console.Clear();                                                //적의 총알을 맞을시 콘솔창 clear
        Console.WriteLine($"Game Over! Final Score: {score}");          //총 스코어 확인
        Console.WriteLine("Press any key to exit...");                      //게임종료 키
        Console.ReadKey();                                          
    }

    static void Main(string[] args)
    {
        var game = new GallagaGame();
        game.Run();
    }
}
