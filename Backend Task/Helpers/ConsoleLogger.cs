using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Helpers
{
    public class ConsoleLogger : ILogger
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }

    }
}
