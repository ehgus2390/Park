public class Bullet
{
    public int x { get; set; }
    public int y { get; set; }

    public Bullet(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Move()
    {
        y--;
    }
}