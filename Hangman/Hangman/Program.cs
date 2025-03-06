using System;

namespace Spaceman
{
  class Program
  {
    static void Main(string[] args)
    {
      Game game1 = new Game();
      game1.Greet();
      do{
        game1.Display();
        game1.Ask();
      }while(game1.DidWin()!=true&&game1.DidLose()!=true);

      Console.WriteLine(game1.CodeWord);

      if(game1.DidWin()==true)
      {
        Console.WriteLine("Du hast gewonnen!");
      }
      else{
        Console.WriteLine("Du hast verloren!");
      }
    }
  }
}
