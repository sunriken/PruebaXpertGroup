using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaXpertGroup.Models
{
    public class Cube
    {
        public long[,,] Matrix { get; private set; }
        public long N { get; private set; }
       

        public Cube(long n)
        {
            N = n;
            Matrix = new long[N, N, N];

            for (long i = 0; i < N; i++)
            {
                for (long j = 0; j < N; j++)
                {
                    for (long k = 0; k < N; k++)
                    {
                        Matrix[i, j, k] = 0;
                    }
                }
            }
        }

        public long Query(long x1, long y1, long z1, long x2, long y2, long z2)
        {
            long sum = 0;
            for (long x = x1; x <= x2 && x <= N; x++)
            {
                for (long y = y1; y <= y2 && y <= N; y++)
                {
                    for (long z = z1; z <= z2 && z <= N; z++)
                    {
                        sum += Matrix[x - 1, y - 1, z - 1];
                    }
                }
            }
            return sum;
        }

        public void Update(long x, long y, long z, long w)
        {
            Matrix[x - 1, y - 1, z - 1] = w;
        }
        
    }
}
