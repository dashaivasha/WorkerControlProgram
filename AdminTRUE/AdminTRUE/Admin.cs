using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTRUE
{
    public class Admins
    {
        public string Login { get; set; }
        public string Pass { get; set; }

        public string Fio { get; set; }
       
        public string Organization { get; set; }
        public string Email { get; set; }






        public Admins(string login, string pass, string fio,  string organization, string email)
        {

            Login = login;
            Pass = pass;
            Fio = fio;
           
            Organization = organization;
            Email = email;
            
        }

        public Admins() { }
    }
}
