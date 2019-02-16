using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

/// <summary>
/// https://github.com/khalidabuhakmeh/ConsoleTables
/// </summary>
namespace LexerLuthor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\\#// Lexer Luthor //#\\");
            Console.WriteLine("Entrez le chemin du fichier à analyser(Ex.: C:\fichier.cs):");
            String filePath = Console.ReadLine();

            Lexer lexer = new Lexer();
            lexer.AnalyzeFile(filePath);

            ConsoleTable.From<Token>(lexer.SymbolTable).Write();
                
            Console.ReadLine();
        }

       


    }
}
