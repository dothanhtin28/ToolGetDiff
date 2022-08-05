using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ComputeLoadFileConvert2ListStrring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var swiftFilePath = @"D:\SampleCode\ToolGetDiff\docs\filePathDataSwift.txt";
            List<string> dataOfSwift = System.IO.File.ReadLines(swiftFilePath).ToList();
            var dbFilePath = @"D:\SampleCode\ToolGetDiff\docs\filePathDataCouchbase.txt";
            List<string> dataOfDb = System.IO.File.ReadLines(dbFilePath).ToList();

            var diffFilePaths = dataOfSwift.Except(dataOfDb);
            //var diffFilePaths = dataOfDb.Except(dataOfSwift);
            File.WriteAllLines(@"D:\SampleCode\ToolGetDiff\docs\Compare.txt", diffFilePaths);
        }
    }
}
