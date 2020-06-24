using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace MessengerComparison
{
    class MCGenerator
    {
        static string RepresentationPath => Path.Combine("representation");
        static string DataPath => Path.Combine("data");
        static string OutputPath => Path.Combine("Output");

        static int Main(string[] args)
        {
            try
            {
                //Step 1: Prepare Output folder by copying files from representation
                CopyFolder(RepresentationPath, OutputPath);

                //Step 2: Get a list of data languages
                MCHtmlBuilder.Languages = GetLanguages(DataPath);

                //Step 3: Go over languages            
                foreach (var lang in MCHtmlBuilder.Languages)
                {
                    //Step 4: Prepare the data for a language
                    var generalDataPath = Path.Combine(DataPath, lang, "general-data.json");
                    var comparisonDataPath = Path.Combine(DataPath, lang, "comparison-data.json");

                    var generalData =  GetObjectFromFile<Dictionary<string,string>>(generalDataPath);                    
                    var comparisonData = GetObjectFromFile<List<Group>>(comparisonDataPath);
                    DateTime lastModified = GetLastModifiedDateFromGit(comparisonDataPath);

                    //Step 5: Generate HTML file from the data for a language
                    string html = new MCHtmlBuilder(lang, generalData, comparisonData, lastModified)
                                        .Build();

                    //Step 6: Save HTML file to the Output folder for a language
                    var outputFilePath = Path.Combine(OutputPath, lang, "index.html");
                    new FileInfo(outputFilePath).Directory.Create();
                    File.WriteAllText(outputFilePath, html);
                }                

                return 0;
            }
            catch
            {
                return -1;
            }
        }

        static void CopyFolder(string inputFolderPath, string outputFolderPath)
        {
            //Create all the child directories
            foreach (string dirPath in Directory.GetDirectories(inputFolderPath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(inputFolderPath, outputFolderPath));

            //Copy all the files and replace any files with the same name
            foreach (string filePath in Directory.GetFiles(inputFolderPath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(filePath, filePath.Replace(inputFolderPath, outputFolderPath), true);
        }

        static List<string> GetLanguages(string dataFolder)
        {
            var result = new List<string>();

            foreach (string dirPath in Directory.GetDirectories(dataFolder, "*"))
                result.Add(new DirectoryInfo(dirPath).Name);

            result.Sort();

            return result;
        }

        static T GetObjectFromFile<T>(string filePath) 
        {
            var jsonString = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<T>(jsonString);
        }

        static DateTime GetLastModifiedDateFromGit(string filePath)
        {
            try
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "git",
                        Arguments = $"log -1 --format=%cd --date=unix {filePath}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                process.Start();
                string unixTime = process.StandardOutput.ReadToEnd().TrimEnd('\n');
                process.WaitForExit();

                return unixTime.ToDateTime();
            }
            catch
            {
                return DateTime.UtcNow;
            }
        }
    }
}
