internal class Word
{
    private Letter[] _word;

    public Word(string word)
    {
        this._word = new Letter[word.Length];
        for (int i = 0; i < word.Length; i++)
            this._word[i] = new Letter(word[i]);
    }
    internal bool isWinner()
    {
        return false;
    }

    internal bool ContainsLetter(Letter letter)
    {
        int i = 0;
        while (!this._word[i++].isEqual(letter)) ;
        return this._word[i].isEqual(letter);
    }

    internal void Discovery(Letter letter)
    {
        for (int i = 0; i < this._word.Length; i++)
            if (this._word[i].isEqual(letter))
                this._word[i].Discovery();
    }

    internal void Display()
    {
        foreach (var letter in this._word)
            letter.Display();
        Console.WriteLine();
    }
}