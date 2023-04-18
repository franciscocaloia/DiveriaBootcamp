namespace ahorcado;
public class Hang
{
    private int _lives;

    private string[] _drawing;

    public Hang()
    {
        this._lives = 6;
        this._drawing = new string[]{
                    " ____      \n" +
                    "|    |     \n" +
                    "|   (¨)    \n" +
                    "|   /|\\   \n" +
                    "|   / \\   \n" +
                    "|          \n" +
                    "☰☰☰☰☰☰",
                    " ____      \n" +
                    "|    |     \n" +
                    "|   (¨)    \n" +
                    "|   /|\\   \n" +
                    "|   /      \n" +
                    "|          \n" +
                    "☰☰☰☰☰☰",
                    " ____      \n" +
                    "|    |     \n" +
                    "|   (¨)    \n" +
                    "|   /|\\   \n" +
                    "|          \n" +
                    "|          \n" +
                    "☰☰☰☰☰☰",
                    " ____      \n" +
                    "|    |     \n" +
                    "|   (¨)    \n" +
                    "|   /|     \n" +
                    "|          \n" +
                    "|          \n" +
                    "☰☰☰☰☰☰",
                    " ____      \n" +
                    "|    |     \n" +
                    "|   (¨)    \n" +
                    "|    |     \n" +
                    "|          \n" +
                    "|          \n" +
                    "☰☰☰☰☰☰",
                    " ____      \n" +
                    "|    |     \n" +
                    "|   (¨)    \n" +
                    "|          \n" +
                    "|          \n" +
                    "|          \n" +
                    "☰☰☰☰☰☰",
                    " ____      \n" +
                    "|    |     \n" +
                    "|          \n" +
                    "|          \n" +
                    "|          \n" +
                    "|          \n" +
                    "☰☰☰☰☰☰"
        };


    }
    public void displayHang()
    {
        Console.WriteLine(this._drawing[this._lives]);
    }
    public void displayLives()
    {
        Console.WriteLine("Vidas: " + this._lives);
    }

    public void decreaseLife()
    {
        this._lives--;
    }
    public bool checkLoose()
    {
        return this._lives == 0;
    }
}