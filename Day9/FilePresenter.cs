using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public static class FilePresenter
    {
        public static void Print(List<FileBlock> files)
        {
            foreach (var file in files) 
            {
                var toPrint = file.IsEmpty ? "." : file.Id.ToString();
                Console.Write(toPrint);
            }
            Console.Write(Environment.NewLine);
        }

        public static string GetString(List<FileBlock> files)
        {
            var returnValue = string.Empty;
            foreach (var file in files)
            {
                var currentValue = file.IsEmpty ? "." : file.Id.ToString();
                returnValue += currentValue;
            }
            return returnValue;
        }
    }
}
