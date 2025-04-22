public class Player : GameObject
{
    public Player(int x, int y) : base(x,y,'A')    //부모클래스인 GameObject의 생성자를 호출하면서 x,y와 문자'A'를 인자로 넘겨줌
    {

    }
    public void Move(int k)
    {
        int distX = X + k;                //플레이어 위치X(x)좌표에 k값을 더한것 == distX
        if (distX >= 0 && distX < Console.WindowWidth)
        {
            X = distX;                        //if문(distX가 0보다 크거나같고 콘솔창의 넓이보다 작다면 disX값을 X값으로 반환(즉, 새로운 좌표로 업데이트))
        }
    }
}
