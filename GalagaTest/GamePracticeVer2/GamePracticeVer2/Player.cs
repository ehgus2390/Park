public class Player : GameObject
{
    public Player(int x, int y) : base(x,y,'A')    //�θ�Ŭ������ GameObject�� �����ڸ� ȣ���ϸ鼭 x,y�� ����'A'�� ���ڷ� �Ѱ���
    {

    }
    public void Move(int k)
    {
        int distX = X + k;                //�÷��̾� ��ġX(x)��ǥ�� k���� ���Ѱ� == distX
        if (distX >= 0 && distX < Console.WindowWidth)
        {
            X = distX;                        //if��(distX�� 0���� ũ�ų����� �ܼ�â�� ���̺��� �۴ٸ� disX���� X������ ��ȯ(��, ���ο� ��ǥ�� ������Ʈ))
        }
    }
}
