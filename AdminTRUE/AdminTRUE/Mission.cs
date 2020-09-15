using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTRUE
{
    public class Mission
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Topic { get; set; }
        public string About { get; set; }
        public double Rate { get; set; }
        public DateTime Date_Miss { get; set; }
        public int Done { get; set; }


        public Mission(int id, string login, string topic, string about, double rate, DateTime date_miss, int done)
        {
            Id = id;
            Login = login;
            Topic = topic;
            About = about;
            Rate = rate;
            Date_Miss = date_miss;
            Done = done;
        }

        public Mission() {}
    }
}
