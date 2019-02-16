using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerLuthor
{
    public class Token
    {
        public TypeEnum Type { get; set; }

        public string Lexem { get; set; }

        public string Attribut {get; set;}


        public enum TypeEnum
        {
            Declaration,
            Identificateur,
            Condition,
            Operateur,
            Boucle,
            Erreur
        }

        public override string ToString()
        {
            string strToken = $"[Type : {Type.ToString()}], [Lexem : {Lexem}]";
            return (Attribut == null) ? strToken : strToken + $", [Attribut : {Attribut}]" ;
        }
    }
}
