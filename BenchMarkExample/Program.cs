using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Use BenchmarkRunner.Run to Benchmark your code
            var summary = BenchmarkRunner.Run<Test>();
        }
    }

    // We are using .Net Core we are adding the CoreJobAttribute here.
    [CoreJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class Test
    {
        [Params(10, 100)]
        public int N;


        static bool IsValidIf(int i)
        {
            // Uses if-expressions to implement selection statement.
            if (i == 0 ||
                i == 1)
            {
                return true;
            }
            if (i == 2 ||
                i == 3)
            {
                return false;
            }
            if (i == 4 ||
                i == 5)
            {
                return true;
            }
            return false;
        }

        static bool IsValidSwitch(int i)
        {
            // Implements a selection statement with a switch.
            switch (i)
            {
                case 0:
                case 1:
                    return true;
                case 2:
                case 3:
                    return false;
                case 4:
                case 5:
                    return true;
                default:
                    return false;
            }
        }

        const int _max = 100000000;
        [Benchmark]
        public void If()
        {
            bool b;
            for (int i = 0; i < _max; i++)
            {
                b = IsValidIf(i);
            }

        }
        [Benchmark]
        public void Switch()
        {
            bool b;

            for (int i = 0; i < _max; i++)
            {
                b = IsValidSwitch(i);
            }
        }


    }
}





















