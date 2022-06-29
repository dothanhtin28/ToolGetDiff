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
            var swiftFilePath = @"E:\Work\SampleCodes\ComputeLoadFileConvert2ListStrring\docs\filePathDataSwift.txt";
            List<string> dataOfSwift = System.IO.File.ReadLines(swiftFilePath).ToList();
            var dbFilePath = @"E:\Work\SampleCodes\ComputeLoadFileConvert2ListStrring\docs\filePathDataCouchbase.txt";
            List<string> dataOfDb = System.IO.File.ReadLines(dbFilePath).ToList();

            var diffFilePaths = dataOfSwift.Except(dataOfDb);
            //var diffFilePaths = dataOfDb.Except(dataOfSwift);
            File.WriteAllLines(@"E:\Work\SampleCodes\ComputeLoadFileConvert2ListStrring\docs\Compare.txt", diffFilePaths);
        }
    }
}
