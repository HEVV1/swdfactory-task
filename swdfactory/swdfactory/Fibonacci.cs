using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swdfactory
{
    public class Fibonacci
    {
        public int numberLength { get; set; }

        public Fibonacci(int par)
        {
            this.numberLength = par;
        }

        public int[] Task()
        {           
            int[] arrayI = new int[numberLength];
            arrayI[0] = 0;
            arrayI[1] = 1;
            for (int i = 1; i < numberLength - 1; i++)
            {
                arrayI[i + 1] = arrayI[i - 1] + arrayI[i];
            }           

            return arrayI;            
        }
    }
}
