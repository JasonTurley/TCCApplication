﻿/// <summary>
/// Result.cs - Creates and writes test results to a file.
/// </summary>
using System;
using System.IO;

namespace TCCApplication
{
    // Note: the using statement flushes and closes StreamWriter automatically
    public class Result
    {
        private static string _reportTime = System.DateTime.Now.ToString("MM-dd-yyyy.hh.mm.ss");
        private static string _resultFilename;

        /// <summary>
        /// Creates a new test result file in the Results directory
        /// </summary>
        /// <param name="filename"></param>
        public void CreateResultFile(string filename)
        {
            string directory = @"C:\Users\jturley\Desktop\TCCApplication\TCCApplication\Results\";

            System.IO.Directory.CreateDirectory(directory);
            _resultFilename = directory + filename + "_" + _reportTime + ".html";            
        }

        /// <summary>
        /// Writes `heading` as the page's main heading
        /// </summary>
        /// <param name="heading">Text to be added to file</param>
        public void WriteMainHeading(string heading)
        {
            using (StreamWriter writer = new StreamWriter(_resultFilename))
            {
                writer.WriteLine("<h1>" + heading + "</h1>");
            }
        }

        /// <summary>
        /// Writes `heading` as a sub heading
        /// </summary>
        /// <param name="heading"></param>
        public void WriteSubHeading(string heading)
        {
            using (StreamWriter writer = new StreamWriter(_resultFilename))
            {
                writer.WriteLine("<h3>" + heading + "</h3>");
            }
        }

        /// <summary>
        /// Writes the total number of hours, minutes, seconds, and milliseconds the test took to complete to html file
        /// </summary>
        /// <param name="duration"></param>
        public void TotalExecutionTime(TimeSpan duration)
        {
            using (StreamWriter writer = new StreamWriter(_resultFilename, true))
            {
                writer.WriteLine(" ");
                writer.WriteLine("<h3> ");
                writer.WriteLine("Total Test Execution Time:</br><strong> Hours: " + duration.Hours + "</br> Minutes: " + duration.Minutes
                                    + "</br> Seconds: " + duration.Seconds + "</br>Milliseconds: " + duration.Milliseconds + "</strong>");
            }
        }

        /// <summary>
        /// Writes test results to html file
        /// </summary>
        /// <param name="scriptName">Name of test script</param>
        /// <param name="passed">Number of passed test cases</param>
        /// <param name="total">Total number of test cases</param>
        public void WriteTestResults(string scriptName, uint passed, uint total)
        {
            using (StreamWriter writer = new StreamWriter(_resultFilename, true))
            {
                writer.WriteLine("<p>" + scriptName + " - "+ passed.ToString() + " of " + total.ToString() + " steps <span style=\"color: green;\">PASSED</p>");
            }
        }
    }
}
