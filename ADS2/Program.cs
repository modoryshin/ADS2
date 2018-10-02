using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS2
{
    class Program
    {
        static double[,] Sort(double[] job, int max, int ex)
        {
            double[,] line = new double[ex, Convert.ToInt32(max)];
            for (int i = 0; i < ex; i++)
            {
                for (int j = 0; j < Convert.ToInt32(max); j++)
                {
                    line[i, j] = 0;
                }
            }
            int count = 0;
            int v = 0;
            int h = 0;
            for(int i = 0; i < job.Length; i++)
            {
                while (count!=job[i])
                {
                    if (v >= max)
                    {
                        v = 0;
                        h++;
                    }
                    line[h, v] = i+1;
                    count++;
                    v++;
                }
                count = 0;
            }
            return line;
        }
        static int Executers()
        {
            int n;
            bool ok;
            do
            {
                Console.WriteLine("Input the number of executors.");
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok)
                    Console.WriteLine("Invalid data.");
                else if (n > 26)
                    Console.WriteLine("Unacceptable data.");
            } while (!ok || n > 20);
            return n;
        }
        static double[] Jobs()
        {
            int n;
            bool ok;
            do
            {
                Console.WriteLine("Input the number of jobs.");
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok)
                    Console.WriteLine("Invalid data.");
                else if (n > 26)
                    Console.WriteLine("Unacceptable data.");
            } while (!ok || n > 26);
            double[] info = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Input length of job {0}", i + 1);
                info[i] = Convert.ToDouble(Console.ReadLine());
            }
            return info;
        }
        static int SearchMax(double[] len,int ex)
        {
            double sum = 0;
            foreach (double x in len)
            {
                sum = sum + x;
            }
            double max = Double.MinValue;
            foreach (double x in len)
            {
                if (max < x)
                    max = x;
            }
            if ((sum / ex) > max)
                max = (sum / ex);
            return Convert.ToInt32(max);
        }
        static void PrintLine(double[,] line,int ex,int max)
        {
            string ans="";
            int[] s = new int[0];
            int co = 0;
            double cur = line[0, 0];
            int c = 0;
            for(int i = 0; i < ex; i++)
            {
                ans = i + 1 + ": ";
                s = new int[0];
                cur = line[i,0];
                co = 0;
                for(int j = 0; j < max; j++)
                {
                    if (cur != line[i, j])
                    {
                        cur = line[i, j];
                        c++;
                        if(s.Length>1)
                        ans = ans + c + "(" + s[0] + "-" + s[s.Length-1] + ") ";
                        if (s.Length == 1)
                            ans = ans + c + "(" + s[0] + ") ";
                        s = new int[0];
                        co = 0;
                        Array.Resize(ref s, s.Length + 1);
                        s[co] = j + 1;
                        co++;
                    }
                    else
                    {
                        Array.Resize(ref s, s.Length + 1);
                        s[co] = j + 1;
                        co++;
                    }
                }
                if (s.Length > 1)
                    ans = ans + cur + "(" + s[0] + "-" + s[s.Length - 1] + ") ";
                if (s.Length == 1)
                {
                    ans = ans + cur + "(" + s[0] + ") ";
                }
                Console.WriteLine(ans);
            }
            ans = ans + c + "(" + s[0] + "-" + s[1] + ") ";
        }
        static void Main(string[] args)
        {
            int ex = Executers();
            double[] len = Jobs();
            int max = SearchMax(len, ex);
            double[,] d = Sort(len, max, ex);
            PrintLine(d, ex, max);
            Console.ReadKey();
        }
    }

}
