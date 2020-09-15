using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTRUE
{
    public class IfOnWork
    {
        public string Login { get; set; }
        public string Date { get; set; }
        public int Rab { get; set; }
        public IfOnWork(string login, string date, int rab )
        {
            
            Login = login;
            Date = date;
            Rab = rab;
           
        }

        public IfOnWork() { }

    }
}
