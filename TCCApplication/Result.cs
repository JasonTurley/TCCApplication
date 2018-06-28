using System;
using System.IO;

namespace TCCApplication
{
    public class Result
    {
        private static string _reportTime = System.DateTime.Now.ToString("MM-dd-yyyy.hh.mm.ss");
        private static string _resultFilename;

        /// <summary>
        /// Creates a test results file in the Results directory
        /// </summary>
        /// <param name="filename"></param>
        public static void CreateResultFile(string filename)
        {
            string directory = @"..\..\Results";
            //System.IO.Directory.CreateDirectory(directory);
            _resultFilename = directory + filename + "_" + _reportTime + ".html";            
        }

        /// <summary>
        /// Writes `message` to _resultFilename
        /// </summary>
        /// <param name="message">Text to be added to file</param>
        public void WriteToFile(string message)
        {
            StreamWriter writer = new StreamWriter(_resultFilename, true);
            writer.WriteLine("<h1>");
            writer.WriteLine(message);
            writer.WriteLine("</h1>");
        }
    }
}
