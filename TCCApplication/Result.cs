using System;
using System.Collections.Generic;
using System.IO;

namespace TCCApplication
{
    // Note: the using statement flushes and closes StreamWriter automatically
    public class Result
    {
        private static string _reportTime = System.DateTime.Now.ToString("MM-dd-yyyy.hh.mm.ss");
        private static string _resultFilename;

        // Track total number of tests failed
        private List<Exception> FailedTests = new List<Exception>();

        /// <summary>
        /// Upon failure, adds an Exception to FailedTests list instead killing the program
        /// </summary>
        /// <param name="ex"></param>
        public void AddFailure(Exception ex)
        {
            FailedTests.Add(ex);
        }

        /// <summary>
        /// Returns the amount of tests that have failed
        /// </summary>
        /// <returns></returns>
        public uint TotalFailedTests()
        {
            return (uint) FailedTests.Count;
        }

        /// <summary>
        /// Creates a new test result file in the Results directory
        /// </summary>
        /// <param name="filename"></param>
        public static void CreateResultFile(string filename)
        {
            string directory = @"C:\Users\jturley\Desktop\TCCApplication\TCCApplication\Results\";

            System.IO.Directory.CreateDirectory(directory);
            _resultFilename = directory + filename + "_" + _reportTime + ".html";            
        }

        /// <summary>
        /// Sets `testcaseName` as the page heading
        /// </summary>
        /// <param name="testcaseName">Text to be added to file</param>
        public void WriteHeading(string testcaseName)
        {
            using (StreamWriter writer = new StreamWriter(_resultFilename))
            {
                writer.WriteLine("<h1>" + testcaseName + "</h1>");
            }
        }

        /// <summary>
        /// Writes the total number of hours, minutes, seconds, and milliseconds the test took to complete
        /// </summary>
        /// <param name="duration"></param>
        public void TotalExecutionTime(TimeSpan duration)
        {
            using (StreamWriter writer = new StreamWriter(_resultFilename, true))
            {
                writer.WriteLine("<h3> ");
                writer.WriteLine("Total Test Execution Time:</br><strong> Hours: " + duration.Hours + "</br> Minutes: " + duration.Minutes
                                    + "</br> Seconds: " + duration.Seconds + "</br>Milliseconds: " + duration.Milliseconds + "</strong>");
            }
        }


    }
}
