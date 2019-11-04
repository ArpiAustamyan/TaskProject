using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class Log
    {
        public static void Logging(Del d)
        {
            string path = @"C:\Users\santr\OneDrive\Рабочий стол\Text.txt";
            File.AppendAllText(path, d._CreateDate.ToString());
            File.AppendAllText(path, d._CreateDate.ToString());
        }
    }
}
