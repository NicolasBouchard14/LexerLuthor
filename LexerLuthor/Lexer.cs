using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LexerLuthor
{
    public class Lexer
    {
        public Lexer()
        {
            SymbolTable = new List<Token>();
        }

        public List<Token> SymbolTable { get; set; }

        public void AnalyzeFile(Stream fileStream)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    while (!sr.EndOfStream)
                    {
                        foreach (string lexem in sr.ReadLine().Split(' '))
                        {
                            if (lexem == null || lexem == "") continue;
                            AssociateTokenToLexem(lexem.Trim());
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Regex pattern switch: https://www.c-sharpcorner.com/article/pattern-matching-in-c-sharp-7-0/ 
        /// </summary>
        private void AssociateTokenToLexem(string lexem)
        {
            switch (lexem)
            {
                case var someVal when new Regex(@TokenRegex.Declaration).IsMatch(lexem):
                    SymbolTable.Add(new Token()
                    {
                        Type = Token.TypeEnum.Declaration,
                        Lexem = lexem
                    });
                    break;
                
                case var someVal when new Regex(@TokenRegex.Condition).IsMatch(someVal):
                    SymbolTable.Add(new Token()
                    {
                        Type = Token.TypeEnum.Condition,
                        Lexem = lexem
                    });
                    break;
                case var someVal when new Regex(@TokenRegex.Operateur).IsMatch(someVal):
                    SymbolTable.Add(new Token()
                    {
                        Type = Token.TypeEnum.Operateur,
                        Lexem = lexem
                    });
                    break;
                case var someVal when new Regex(@TokenRegex.Boucle).IsMatch(someVal):
                    SymbolTable.Add(new Token()
                    {
                        Type = Token.TypeEnum.Boucle,
                        Lexem = lexem
                    });
                    break;
                case var someVal when new Regex(@TokenRegex.Identificateur).IsMatch(someVal):
                    SymbolTable.Add(new Token()
                    {
                        Type = Token.TypeEnum.Identificateur,
                        Lexem = lexem,
                        Attribut = lexem
                    });
                    break;
                default:
                    SymbolTable.Add(new Token()
                    {
                        Type = Token.TypeEnum.Erreur,
                        Lexem = lexem
                    });
                    break;
            }
        }





    }
}
