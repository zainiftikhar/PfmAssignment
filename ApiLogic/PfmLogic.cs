using CsvHelper;
using PfmAssignment.Models;
using System.Globalization;

namespace PfmAssignment.ApiLogic
{
    public class PfmLogic
    {
        public List<PfmData> _pfmData;

        public PfmLogic()
        {
            using (var reader = new StreamReader("Data/counts.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                _pfmData = new List<PfmData>();
            }
        }
    }
}
