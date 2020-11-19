using System;

namespace HangMan
{
    class Program
    {

        static void Main(string[] args)
        {

            string[] hangMan =
          {
                "\n \n\n \n \n ", " O \n \n\n \n \n ", " O \n | \n |\n | \n \n ",
                "   O \n   | \n --|\n   |\n   | \n \n", "   O \n   | \n --|--\n   | \n \n ",
                "  O \n  | \n--|--\n  | \n  ^ \n / ", "   O \n   | \n --|--\n   | \n   ^ \n  / \\ "
            };

            string wrongLetters = "";
            int numIncorrect = 0, numCorrect = 0;




            Console.WriteLine("Player 1: Please enter the word you would like to be guessed: ");
            string word = Console.ReadLine();


            Console.WriteLine("Give a hint to the word if you would like, if not just press any key to continue...");
            string hint = Console.ReadLine();


            Console.WriteLine("Enter the number of tries you would like your opponent to have: ");
            int attempts = int.Parse(Console.ReadLine());

            Console.Clear();


            char[] wordTrack = new char[word.Length];

            Console.Write("Player One's Word: ");


            BuildLetterPlaceholder(word, wordTrack);

            Console.WriteLine();

            while (true)
            {
                int count = 0;
                Console.Write($"Hint:{hint}");
                Console.WriteLine();
                Console.Write("Player 2: Guess a letter: ");
                var input = char.Parse(Console.ReadLine());
                Console.Clear();

                for (int j = 0; j < word.Length; j++)
                {
                    if (input == word[j])
                    {
                        wordTrack[j] = input;
                        numCorrect++;
                    }
                    else
                    {
                        count++;
                    }

                    if (count == word.Length)
                    {
                        wrongLetters += input + ", ";
                        attempts--;
                        numIncorrect++;
                    }
                }
                Console.Write("Player One's Word: ");
                Console.Write(wordTrack);
                Console.WriteLine();
                Console.WriteLine();

                Console.Write($"Wrong Letters: ({wrongLetters})");
                Console.WriteLine($" --> You have {attempts} attempts left");
                Console.WriteLine(hangMan[numIncorrect]);

                if (numCorrect == word.Length)
                {
                    Console.WriteLine("CONGRATS, YOU WON!!!");
                    break;
                }

                if (attempts == 0)
                {
                    Console.WriteLine("Sorry you ran out of attempts.");
                    break;
                }

            }

            Console.ReadLine();
        }

        private static void BuildLetterPlaceholder(string word, char[] wordTrack)
        {
            char letterSpaceHolder = '_';
            for (int i = 0; i < word.Length; i++)
            {
                wordTrack[i] = letterSpaceHolder;
                Console.Write(" " + wordTrack[i]);
            }
        }
    }
}
