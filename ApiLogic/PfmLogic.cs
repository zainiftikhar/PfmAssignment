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
                _pfmData = csv.GetRecords<PfmData>().ToList();
            }
        }

        public int GetHourlyPfm(DateTime timestamp)
        {
            return _pfmData
                .Where(x => x.DateFrom.Hour == timestamp.Hour && x.DateFrom.Date == timestamp.Date)
                .Sum(x => x.Count);
        }

        public int GetDailyPfm(DateTime timestamp)
        {
            return _pfmData
                .Where(x => x.DateFrom.Date == timestamp.Date)
                .Sum(x => x.Count);
        }

        public int GetWeeklyPfm(DateTime timestamp)
        {
            return _pfmData
                .Where(x => x.DateFrom.Date >= timestamp.Date.AddDays(-7) && x.DateFrom.Date <= timestamp.Date)
                .Sum(x => x.Count);
        }

    }
}
