﻿using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using System.Text;

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
        private static Random random = new Random();
        private List<String> hugeList ;
        private List<int> list;

        
        public static String FormAWord(int length)
        {
            String output ="";
            for(int i=0;i<length;i++)
            {
                output += "a";
            }
            return null;
        }

        public static List<String> RandomIntList(int length)
        {
            int Min = 1;
            int Max = 10;
            return Enumerable
                .Repeat(0, length)
                .Select(i => FormAWord(random.Next(Min, Max)))
                .ToList();
        }
        [Params(10, 100)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            hugeList = RandomIntList(N);
        }

        const int _max = 100000000;
        [Benchmark]
        public void StringConcatenation()
        {
            String concatResult = "";
            foreach (String value in hugeList)
            {
                concatResult += value;
            }

        }
        [Benchmark]
        public void StringBuiderConcatenation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            String stringBuilderResult = "";
            foreach (String s in hugeList)
            {
                stringBuilder.Append(s);
            }

            stringBuilderResult = stringBuilder.ToString();
        }


    }
}





















