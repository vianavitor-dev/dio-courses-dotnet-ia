using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_courses_dotnet_ia.Common.Models.Tuple
{
    public class MyFileReader
    {
        public (bool Success, string[] Rows, int RowsCount) ReadFile(string path)
        {
            try
            {
                string[] rows = File.ReadAllLines(path);
                return (true, rows, rows.Count());
            }
            catch (Exception)
            {
                return (true, Array.Empty<string>(), 0);
            }
        }
        
    }

}