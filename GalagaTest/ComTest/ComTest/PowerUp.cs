public enum PowerUpType
{
    ExtraLife,
    WeaponUpgrade,
    PowerOverWhelming
}

public class PowerUp : GameObject
{
    public PowerUpType Type { get; private set; }

    public PowerUp(int x, int y, PowerUpType type) : base(x, y, GetSymbol(type))
    {
        Type = type;
    }

    private static char GetSymbol(PowerUpType type)
    {
        if (type == PowerUpType.ExtraLife)
        {
            return '♥';
        }
        else if (type == PowerUpType.WeaponUpgrade)
        {
            return '⚡';
        }
        else if (type == PowerUpType.PowerOverWhelming)
        {
            return '★';
        }
        else
        {
            return '?';
        }
    }

    public void Move()
    {
        Y++;
    }
}