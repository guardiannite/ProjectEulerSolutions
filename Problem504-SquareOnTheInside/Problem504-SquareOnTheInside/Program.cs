using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem504_SquareOnTheInside
{
    class Program
    {
        static void Main(string[] args)
        {
            //This works and finds the 42 solutions for m=4
            //The lattice points can only be contained inside the structure, they can't be included on the border.
            /*int m = 4;
            int low=0, high =0;
            int solution = 0;
            int totalIterations = 0;

            for(int a = 1; a <= m; a++)
                for(int b = 1; b <= m; b++)
                    for(int c = 1; c <= m; c++)
                        for(int d = 1; d <= m; d++)
                        {
                            totalIterations++;
                            //Four points from the orignal points on the axises
                            int latPts = -3;// - a - b - c -d;
                            latPts -= (a);
                            latPts -= (b);
                            latPts -= (c );
                            latPts -= (d );

                            for(int i = 0; i < 4; i++)
                            {
                                switch(i)
                                {
                                    case 0:
                                        low = Math.Min(a,b);
                                        high = Math.Max(a,b);
                                        break;
                                    case 1:
                                        low = Math.Min(b,c);
                                        high = Math.Max(b,c);
                                        break;
                                    case 2:
                                        low = Math.Min(c,d);
                                        high = Math.Max(c,d);
                                        break;
                                    case 3:
                                        low = Math.Min(d,a);
                                        high = Math.Max(d,a);
                                        break;
                                }
                                if(low >= 2 && high >= 3)
                                {
                                    latPts++;
                                }
                                if(low >= 3 && high >= 4)
                                {
                                    latPts += 2;
                                }
                                latPts += high;
                                latPts += low;
                                //if (high % low != 0)
                                //{
                                //    latPts++;
                                //}

                                //int slopeMod = high % low;
                                //if(slopeMod == 0)
                                //{
                                //    slopeMod = 12345678;
                                //}

                                //int pillarSlope = high / low;
                                //int startPt = 1;
                                //for (int j = 0; j < low+1; j++)
                                //{
                                //    if(j > 0 && slopeMod != 1 && j % slopeMod == 0)
                                //    {
                                //        startPt++;
                                //    }
                                //    latPts += startPt;
                                //    startPt += pillarSlope;
                                //}
                                //latPts += startPt;
                            }

                            
                            int sqrt = (int)Math.Sqrt(latPts);
                            if(sqrt*sqrt == latPts)
                            {
                                Console.WriteLine("A: {0}, B: {1}, C: {2}, D: {3}, Lat = {4}", a, b, c, d, latPts);
                                solution++;
                            }
                        }
             * */
        }
    }
}
