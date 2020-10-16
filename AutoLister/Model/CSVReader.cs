using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace AutoLister
{
    public class CSVReader
    {
         public List<Student> ReadList(string Path)
        {
            using (StreamReader streamReader = new StreamReader(Path))
            {
                using (CsvReader reader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    reader.Configuration.Delimiter = ",";
                    var Students = reader.GetRecords<Student>().ToList<Student>();
                    return Students;
                }
            }
             
        }
    }
}
