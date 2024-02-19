using System;

namespace DMBC
{
    // Class to determine the SMBC sprint number, this is based on 3 week sprints which are broken into points (1-3)
    // Originally written for .net 6, this can be refactored as a datetime extension
    // NOTE - earliest acceptable date is for sprint 100 which is 14 Jun 2021 
    public class Sprint
    {
        private readonly DateTime baseDate = new DateTime(2022, 8, 8);
        private readonly int baseSprint = 120;

        private readonly DateTime minValid = new DateTime(2021, 6, 14); // sprint 100 is earliest that we will arbitrarily accept

        public string SprintNumber(DateTime datetime) => datetime < minValid
                ? throw new ArgumentOutOfRangeException(nameof(datetime), datetime, "Sprint numbers before sprint 100 cannot be determined")
                : $"{Major(datetime)}.{Minor(datetime)}.0.0";

        public string SprintNumber() => SprintNumber(DateTime.Now);

        public int Major(DateTime datetime) => (int)(baseSprint + ((datetime - baseDate).TotalDays / 21));

        public int Minor(DateTime datetime)
        {
            var daysFromBase = (datetime - baseDate).TotalDays;

            var sprintDaysRemaining = daysFromBase % 21;

            if (sprintDaysRemaining < 0)
            {
                sprintDaysRemaining = 21 + sprintDaysRemaining;
            }

            return (int)(sprintDaysRemaining / 7) + 1; // as 1 based
        }
    }
}