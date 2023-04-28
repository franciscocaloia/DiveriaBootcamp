using System;
namespace ahorcado
{
    public class Ahorcado
    {
        private WordToGuess wordToGuess;

        private Hang hang;
        public Ahorcado()
        {
            this.wordToGuess = new WordToGuess();
            this.hang = new Hang();
        }
        static void Main()
        {
            new Ahorcado().play();
        }
        private void play()
        {
            this.displayGame();
            do
            {
                this.readUserInput();
                this.displayGame();
            } while (!this.hang.checkLose() && !this.wordToGuess.checkWin());
            if (this.wordToGuess.checkWin()) this.displayWin();
            if (this.hang.checkLose()) this.displayLose();
        }
        private void test()
        {
            this.wordToGuess.displayWordToGuess();
            this.wordToGuess.checkAttempt('x');
            this.wordToGuess.displayWordToGuess();
        }
        private void displayGame()
        {
            Console.Clear();
            this.hang.displayHang();
            this.hang.displayLives();
            this.wordToGuess.displayWordToGuess();
        }

        private void displayLose()
        {
            Console.WriteLine("FIN DEL JUEGO: VIDAS AGOTADAS");
        }
        private void displayWin()
        {
            Console.WriteLine("FIN DEL JUEGO: PALABRA ADIVINADA");
        }
        private void readUserInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (this.wordToGuess.checkAttemptted(key.KeyChar))
            {
                Console.WriteLine("Caracter ya ingresado");
                Thread.Sleep(1000);
                return;
            };
            if (!this.wordToGuess.checkAttempt(key.KeyChar))
            {
                this.hang.decreaseLife();
            }
        }
    }
}
