using CsvHelper;
using Microsoft.AspNetCore.Mvc;
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
                //try
                //{
                _pfmData = csv.GetRecords<PfmData>().ToList();

                    // Validate loaded data (for example, ensuring required fields are present)
                    //if (_pfmData.Any(data => data.SensorId <= 0 || data.Count < 0 || data.DateFrom >= data.DateTo))
                //    {
                //        throw new InvalidDataException("Invalid data found in the CSV file.");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    // Handle exceptions, log errors, and throw custom exceptions if needed
                //    throw new Exception("Error occurred while loading data from the CSV file.", ex);
                //}
            }
        }

        public int GetHourlyPfm(DateTime dateTime)
        {
            return _pfmData
                .Where(x => x.DateFrom.Hour == dateTime.Hour && x.DateFrom.Date == dateTime.Date)
                .Sum(x => x.Count);
        }

        public int GetDailyPfm(DateTime dateTime)
        {
            return _pfmData
                .Where(x => x.DateFrom.Date == dateTime.Date)
                .Sum(x => x.Count);
        }

        public int GetWeeklyPfm(int weekNumber, int year)
        {
            return _pfmData
                .Where(x => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(x.DateFrom, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == weekNumber && x.DateFrom.Year == year)
                .Sum(x => x.Count);
        }

    }
}
