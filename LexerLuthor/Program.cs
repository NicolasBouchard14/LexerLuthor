using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleTables;

/// <summary>
/// https://github.com/khalidabuhakmeh/ConsoleTables
/// </summary>
namespace LexerLuthor
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("\\#//////////////////#\\\n\\#// Lexer Luthor //#\\\n\\#//////////////////#\\");

            bool continu = true;
            while(continu)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Choisir un fichier à analyser";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Lexer lexer = new Lexer();
                    lexer.AnalyzeFile(openFileDialog.OpenFile());
                    ConsoleTable.From<Token>(lexer.SymbolTable).Write();
                }

                Console.WriteLine("Voulez-vous analyser un nouveau fichier? (y/n): ");
                if (Console.ReadLine() == "y") continue;
                else continu = false;
            }
        }
    }
}
