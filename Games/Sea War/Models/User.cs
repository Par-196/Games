using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_War.Models
{
    public abstract class User
    {
        protected string Name { get; set; }
        protected Field MyField { get; set; }
        protected Field EnemyField { get; set; }

        public User(string name)
        {
            Name = name;
            MyField = new Field();
            EnemyField = new Field();
        }
    }
}
