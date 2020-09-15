using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdminTRUE
{
    public class CodeGen
    {

        public string Code { get; set; }



        public CodeGen(string code)
        {
            Code = code;

        }

        public CodeGen() { }



        public static string Pass()
        {
            string pass = "";
            var r = new Random();
            while (pass.Length < 8)
            {
                Char c = (char)r.Next(33, 125);
                if (Char.IsLetterOrDigit(c))
                    pass += c;
            }
            return pass;
        }
    }
}