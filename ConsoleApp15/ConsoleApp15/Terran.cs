using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal abstract class Terran
    {
        protected int health;   //내부 데이터
        protected int maxHealth;

        public int Health   //외부 데이터
        {
            get { return health; }
            set
            {
                if(maxHealth < value)
                {
                    return;
                }

                health = value;
                Console.WriteLine("health의 값 : " + health);
            }
        }

        public abstract void Recovery();
    }
}
