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
            var swiftFilePath = @"D:\SampleCode\ToolGetDiff\docs\20220803-swift-list-format.txt";
            //List<string> dataOfSwift = System.IO.File.ReadLines(swiftFilePath).ToList();
            //get DB FilePath
            //var dbFilePath = @"D:\SampleCode\ToolGetDiff\docs\filePathDataCouchbase.txt";
            var dbFilePath = @"D:\SampleCode\ToolGetDiff\docs\dbAttachment220803.txt";
            //List<string> dataOfDb = System.IO.File.ReadLines(dbFilePath).ToList();
            //var extensionFileNames = pathGenerateExtensionfile(dbFilePath);
            var fileNamesWithoutExtensionPath = generateWithRemoveExtensionFile(dbFilePath);
            //List<string> dataOfDb = System.IO.File.ReadLines(extensionFileNames).ToList();
            //var diffFilePaths = dataOfSwift.Except(dataOfDb);
            //var diffFilePaths = dataOfDb.Except(dataOfSwift);
            //File.WriteAllLines(@"D:\SampleCode\ToolGetDiff\docs\Compare.txt", diffFilePaths);
            var diffPath = generateDiff2Files(fileNamesWithoutExtensionPath, swiftFilePath);
        }

        static string generateWithRemoveExtensionFile(string filePath)
        {
            List<string> filenames = System.IO.File.ReadLines(filePath).ToList();
            var newfilenames = new List<string>();
            foreach (var item in filenames)
            {
                newfilenames.Add(Path.GetFileNameWithoutExtension(item));
            }
            var path = @"D:\SampleCode\ToolGetDiff\docs\NameWithoutExtensionFile.txt";
            File.WriteAllLines(path, newfilenames);
            return path;
        }

        static string generateDiff2Files(string filePath1,string filePath2)
        {
            List<string> filenames1 = System.IO.File.ReadLines(filePath1).ToList(); //db without extension
            List<string> filenames2 = System.IO.File.ReadLines(filePath2).ToList(); //swift
            var newfilenames = new List<string>(); //collect same name in 2 files
            var diffFileNames = new List<string>();
            foreach (var item in filenames1)
            {
                //get same file name
                var vals = filenames2.Where(s => s.Contains(item)).ToList();
                newfilenames.AddRange(vals);
            }
            if(newfilenames.Count > 0)
            {
                diffFileNames = filenames2.Except(newfilenames).ToList();
            }
            var path = @"D:\SampleCode\ToolGetDiff\docs\diff2FileDB_Swift.txt";
            File.WriteAllLines(path, diffFileNames);
            return path;
        }

        static string pathGenerateExtensionfile(string filePath)
        {
            List<string> filenames = System.IO.File.ReadLines(filePath).ToList();
            var newfilenames = new List<string>();
            foreach (var item in filenames)
            {
                if (IsMediaFile(item))
                {
                    var arr = item.Split('.');
                    var lastarr = arr.LastOrDefault();
                    var val = item.EndsWith($".{lastarr}");
                    var item1 = $"{val}-thumb.{lastarr}";
                    var item2 = $"{val}-origin.{lastarr}";
                    newfilenames.AddRange(new List<string> { item, item1, item2 });
                }
            }
            var path = @"D:\SampleCode\ToolGetDiff\docs\AddExtensionFile.txt";
            File.WriteAllLines(path, newfilenames);
            return path;
        }

        static bool IsMediaFile(string path)
        {
            string[] mediaExtensions = {
    ".PNG", ".JPG", ".JPEG", ".BMP", ".GIF", //etc
    ".WAV", ".MID", ".MIDI", ".WMA", ".MP3", ".OGG", ".RMA", //etc
    ".AVI", ".MP4", ".DIVX", ".WMV",".MOV" //etc
};
            var extension = Path.GetExtension(path).ToUpperInvariant();
            return -1 != Array.IndexOf(mediaExtensions, extension);
        }
    }
}
