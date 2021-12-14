using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Results
{
    public class Logger
    {
        public static void Write(string str)
        {
            ConsoleOutput.Instance.Write(str, OutputLevel.Information);
        }

        public static void WriteLine(string str)
        {
            ConsoleOutput.Instance.WriteLine(str, OutputLevel.Information);
        }
    }
}
