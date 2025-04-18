public class Bullet : GameObject
{
    public Bullet(int x, int y) : base(x,y, '|')
    {
    }

    public void Move()
    {
        Y--;
    }
}
