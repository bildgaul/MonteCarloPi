using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloPi
{
    class FindPiThread
    {
        int numDarts;
        int dartsInsideBoard;
        Random rng;

        public FindPiThread(int dartsToThrow)
        {
            numDarts = dartsToThrow;
            rng = new Random();
            dartsInsideBoard = 0;
        }

        public int getDartsInsideBoard()
        {
            return dartsInsideBoard;
        }
        public void throwDarts()
        {
            for (int i = 0; i < numDarts; i++)
            {
                double x = rng.NextDouble() % .5;
                double y = rng.NextDouble() % .5;
                if (Math.Sqrt(x * x + y * y) <= .5)
                {
                    dartsInsideBoard++;
                }
            }
        }
    }
}
