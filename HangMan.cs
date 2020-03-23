using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace HangMan
{
    class Program
    {

        static void Main(string[] args)
        {

            Menu();

            Console.ReadLine();
        }


        public static void Menu()
        {
            int correctOption;

            Console.WriteLine("Welcome to Hangman! ");
            Console.WriteLine();
            Console.WriteLine("Please choose an option: (1)Play Game (2)Instructions to Play ");
            string option = Console.ReadLine();





            while (!int.TryParse(option, out correctOption))
            {
                Console.WriteLine("Please choose a valid option");
                option = Console.ReadLine();
            }

            switch (int.Parse(option))
            {
                case 1:
                    Console.Clear();
                    HangMan();
                    break;
                case 2:
                    Console.Clear();
                    Help();
                    break;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        public static void Help()
        {
            Console.WriteLine(
                "OK so this is a two-player game. Player 1 sets the word to be guessed, gives a hint (if necessary), and also sets the number of lives.\nAll while making sure Player 2 LOOKS AWAY!!\n\nHit the 'enter' key to continue.");
            Console.ReadLine();
            Console.Clear();
            HangMan();
        }

        public static void HangMan()
        {
            string[] hangMan =
            {
                "\n \n\n \n \n ", " O \n \n\n \n \n ", " O \n | \n |\n | \n \n ",
                "   O \n   | \n --|\n   |\n   | \n \n", "   O \n   | \n --|--\n   | \n \n ",
                "  O \n  | \n--|--\n  | \n  ^ \n / ", "   O \n   | \n --|--\n   | \n   ^ \n  / \\ "
            };

            string wrongLetters = "";
            int hang = 0, win = 0;
            bool playing = true;
            char letterSpaceHolder = '_';


            Console.WriteLine("Player 1: Please enter the word you would like to be guessed: ");
            var guessedWord = Console.ReadLine();


            Console.WriteLine("Give a hint to the word if you would like, if not just press any key to continue...");
            var hint = Console.ReadLine();


            Console.WriteLine("Enter the number of tries you would like your opponent to have: ");
            var attempts = int.Parse(Console.ReadLine());

            Console.Clear();



            char[] word = guessedWord.ToCharArray();
            char[] wordTrack = new char[word.Length];
            Console.Write("Player One's Word: ");
            //Builds out letter place holder
            for (int i = 0; i < word.Length; i++)
            {
                wordTrack[i] = letterSpaceHolder;
                Console.Write(" " + wordTrack[i]);
            }

            Console.WriteLine();

            while (playing)
            {
                int count = 0;
                Console.Write("Hint:{0}", " " + hint);
                Console.WriteLine();
                Console.Write("Player 2: Guess a letter: ");
                var input = char.Parse(Console.ReadLine());
                Console.Clear();

                for (int j = 0; j < word.Length; j++)
                {
                    if (input == word[j])
                    {
                        wordTrack[j] = input;
                        win++;
                    }
                    else
                    {
                        count++;
                    }

                    if (count == word.Length)
                    {
                        wrongLetters += input + ", ";
                        attempts--;
                        hang++;
                    }
                }
                Console.Write("Player One's Word: ");
                Console.Write(wordTrack);
                Console.WriteLine();
                Console.WriteLine();

                Console.Write($"Wrong Letters: ({wrongLetters})");
                Console.WriteLine($" --> You have {attempts} attempts left");
                Console.WriteLine(hangMan[hang]);

                if (win == word.Length)
                {
                    Console.WriteLine("CONGRATS, YOU WON!!!");
                    break;
                }
                else if (attempts == 0)
                {
                    Console.WriteLine("Sorry you ran out of attempts. :(");
                    break;
                }

            }
        }

    }
}
