using MonPlanning.Domain.Interfaces.IDao;

namespace MonPlanning.Infrastructure.Dao
{
    public class MonthDao : IMonthDao
    {
        /// <summary>
        /// Gets or sets the month identifiyer.
        /// </summary>
        public int MonthId { get; set; }

        /// <summary>
        /// Gets or sets the month name.
        /// </summary>
        public string Month { get; set;}

        /// <summary>
        /// Gets or sets the month days count.
        /// </summary>
        public int DaysCount { get; set; }

        /// <summary>
        /// Gets or sets the leap value.
        /// </summary>
        /// <value>True if the month changes according leap years, otherwise false.</value>
        public bool Leap { get; set;}
    }
}
