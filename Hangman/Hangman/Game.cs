using System;
using System.Dynamic;
using System.Runtime;

namespace Spaceman
{
    class Game
    {
        Random rd = new Random();
        
        //Properties
        public string CodeWord {get; set;}
        public string CurrentWord {get; set;}
        public int MaximumGuesses {get; set;}
        public int CurrentWrongGuesses {get; set;}
        public string[] Codewords {get; set;}
        Ufo ufo1 = new Ufo();
        
        //Constructor
        public Game()
        {
            Codewords = new string[] {"kuhlschrank", "mikrowelle", "wurst", "stadion", "luzern", "aarau", "handy", "swisscom", "internet", "informatik"};
            int index = rd.Next(Codewords.Length);
            CodeWord = Codewords[index];
            MaximumGuesses = 5;
            CurrentWrongGuesses = 0;
            for(int i = 0; i < CodeWord.Length; i++)
            {
                CurrentWord+="_";
            }
        }
        
        
        
        //Methoden
        public void Greet()
        {
            Console.WriteLine("*******************");
            Console.WriteLine("Willkommen Spieler!");
            Console.WriteLine("*******************");
        }

        public bool DidWin()
        {
            if(CurrentWord.Equals(CodeWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DidLose()
        {
            if(CurrentWrongGuesses>=MaximumGuesses)
            {
                return true;
            }
            else{
                return false;
            }
        }

        public void Display()
        {
            Console.WriteLine(ufo1.Stringify());
            Console.WriteLine(CurrentWord);
            Console.WriteLine($"Versuche: {MaximumGuesses-CurrentWrongGuesses}");
        }

        public void Ask()
        {
            Console.Write("Schreibe einen Buchstaben: ");
            string input = Console.ReadLine().ToLower();
            if(input.Length!=1)
            {
                Console.WriteLine("Bitte, schreibe NUR einen Buchstaben!");
                return;
            }
            char letter = Convert.ToChar(input);
            char[] underlines = CurrentWord.ToCharArray();
            if(CodeWord.Contains(input))
            {
                char[] letters = CodeWord.ToCharArray();
                for(int i = 0; i < letters.Length; i++)
                {
                    if(letters[i]==letter)
                    {
                        CurrentWord = CurrentWord.Remove(i, 1).Insert(i, input);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Oh no, der Buchstabe {letter} ist nicht vorhanden.");
                CurrentWrongGuesses+=1;
                ufo1.AddPart();
            }
        }
    }
}