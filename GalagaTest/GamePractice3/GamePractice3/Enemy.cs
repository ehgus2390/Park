public class Enemy : GameObject
{
    public Enemy(int x, int y) : base(x, y, 'Y')
    {

    }

    public void Move()
    {
        Y++;
    }
}