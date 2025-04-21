

public class GameObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }
    public bool IsActive { get; set; }

    public GameObject(int x, int y, char symbol)
    {
        X = x;
        Y = y;
        Symbol = symbol;
        IsActive = true;

    }
    //private void UpdateBoss()
    //{
    //    for (int i = enemies.Count - 1; i >= 0; i--)
    //    {

    //    }


    //}
}

