using System.Media;

public class SoundManager
{
    private static readonly SoundPlayer shootSound;
    private static readonly SoundPlayer explosionSound;
    private static readonly SoundPlayer gameOverSound;
    private static readonly SoundPlayer backgroundMusic;

    static SoundManager()
    {
        try
        {
            // WAV 파일 로드
            shootSound = new SoundPlayer("sounds/shoot.wav");
            explosionSound = new SoundPlayer("sounds/explosion.wav");
            gameOverSound = new SoundPlayer("sounds/gameover.wav");
            backgroundMusic = new SoundPlayer("sounds/background.wav");

            // 사운드 미리 로드
            shootSound.LoadAsync();
            explosionSound.LoadAsync();
            gameOverSound.LoadAsync();
            backgroundMusic.LoadAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"사운드 초기화 실패: {ex.Message}");
        }
    }

    public static void PlayShootSound()
    {
        try
        {
            shootSound?.Play();
        }
        catch { }
    }

    public static void PlayExplosionSound()
    {
        try
        {
            explosionSound?.Play();
        }
        catch { }
    }

    public static void PlayGameOverSound()
    {
        try
        {
            gameOverSound?.Play();
        }
        catch { }
    }

    public static void StartBackgroundMusic()
    {
        try
        {
            backgroundMusic?.PlayLooping();
        }
        catch { }
    }

    public static void StopBackgroundMusic()
    {
        try
        {
            backgroundMusic?.Stop();
        }
        catch { }
    }
}
