namespace ahorcado;
public class WordToGuess
{
    private LetterToGuess[] _word;

    private List<char> attempts;

    public WordToGuess()
    {
        LetterToGuess[] randomWord = RandomWord.getRandomWord().ToCharArray().Select((letter, index) => new LetterToGuess(letter)).ToArray();
        this._word = randomWord;
        this.attempts = new List<char>();
    }

    public LetterToGuess[] Word { get => _word; }
    public bool checkAttemptted(char attempt)
    {
        return attempts.Contains(attempt);
    }
    public bool checkAttempt(char attempt)
    {
        bool guessed = false;
        foreach (LetterToGuess letter in this._word)
        {
            guessed = letter.checkAttempt(attempt) || guessed;
        }
        if (!guessed) this.attempts.Add(attempt);
        return guessed;
    }
    public void displayWordToGuess()
    {
        string displayWord = this._word.Aggregate("", (acum, current) => acum + (current.IsGuessed ? current.Letter : '_'));
        Console.WriteLine(displayWord);
    }
    public void displayAttempts()
    {
        Console.WriteLine("Letras usadas: ");
        Console.WriteLine(string.Join(',', this.attempts));
    }
    public bool checkWin()
    {
        return this._word.Aggregate(true, (acum, current) => acum && current.IsGuessed);
    }
}

public class LetterToGuess
{
    private char _letter;
    private bool _isGuessed;
    public LetterToGuess(char letter)
    {
        this._letter = letter;
        this._isGuessed = false;
    }
    public char Letter { get => _letter; }
    public bool IsGuessed { get => _isGuessed; set => _isGuessed = value; }

    public bool checkAttempt(char attempt)
    {
        this.IsGuessed = (this.Letter == attempt) || this.IsGuessed;
        return (this.Letter == attempt);
    }
}