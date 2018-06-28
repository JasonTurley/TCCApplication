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

        private static uint FailureCount { get; set; }

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
        /// Sets `testcaseName` as the page's main heading
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
        /// Writes the total number of tests, amount passed, and amount failed to html file
        /// </summary>
        /// <param name="totalTests"></param>
        public void WriteResults(uint totalTests)
        {
            uint amountPassed = totalTests - GetFailureCount();
            uint amountFailed = GetFailureCount();

            using (StreamWriter writer = new StreamWriter(_resultFilename, true))
            {
                writer.WriteLine(" ");
                writer.WriteLine("<h3> ");
                writer.WriteLine("<strong>Total Tests: " + totalTests.ToString() + 
                                    "</br><span style=\"color: green;\"> Passed: " + amountPassed.ToString()
                                    + "</br><span style=\"color: red;\"> Failed: " + amountFailed.ToString() + "</strong>");
            }
        }

        /// <summary>
        /// Increments the number of test cases failed for current script
        /// </summary>
        public void IncrementFailureCount()
        {
            FailureCount++;
        }

        /// <summary>
        /// Returns the amount of tests that have failed
        /// </summary>
        /// <returns></returns>
        public uint GetFailureCount()
        {
            return FailureCount;
        }

        public void ResetFailureCount()
        {
            FailureCount = 0;
        }
    }
}
