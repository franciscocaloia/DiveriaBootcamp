namespace ahorcado;

public class RandomWord
{
    private static string[] _pool = new string[] { "hola", "como", "estas", "jose", "ahre" };

    public static string getRandomWord()
    {
        Random rnd = new Random();
        return _pool[rnd.Next(0, _pool.Length)];
    }


}