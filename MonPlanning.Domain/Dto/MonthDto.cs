using System;
using System.Collections.Generic;
using System.Text;

namespace MonPlanning.Domain.Dto
{
    public sealed class MonthDto
    {
        /// <summary>
        /// Gets or sets the month identifiyer.
        /// </summary>
        public int MonthId { get; set; }

        /// <summary>
        /// Gets or sets the month name.
        /// </summary>
        public string Month { get; set; }

        /// <summary>
        /// Gets or sets the month days count.
        /// </summary>
        public int DaysCount { get; set; }

        /// <summary>
        /// Gets or sets the leap value.
        /// </summary>
        /// <value>True if the month changes according leap years, otherwise false.</value>
        public bool Leap { get; set; }

        private MonthDto(int monthID, string month, int daysCount, bool leap)
        {
            MonthId = monthID;
            Month = month;
            DaysCount = daysCount;
            Leap = leap;
        }

        private MonthDto(int monthId)
        {
            MonthId = monthId;
        }

        public static MonthDto SetMonthId(int monthId)
        {
            if (monthId > 0 && monthId < 13)
            {
                return new MonthDto(monthId);
            }
            else
            {
                throw new Exception($"{monthId} is not a valid month identifiyer");
            }
        }
    }
}
