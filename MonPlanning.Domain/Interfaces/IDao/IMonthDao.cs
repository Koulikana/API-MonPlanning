namespace MonPlanning.Domain.Interfaces.IDao
{
    public interface IMonthDao
    {
        /// <summary>
        /// Gets or sets the month identifiyer.
        /// </summary>
        int MonthId { get; set; }

        /// <summary>
        /// Gets or sets the month name.
        /// </summary>
        string Month { get; set; }

        /// <summary>
        /// Gets or sets the month days count.
        /// </summary>
        int DaysCount { get; set; }

        /// <summary>
        /// Gets or sets the leap value.
        /// </summary>
        /// <value>True if the month changes according leap years, otherwise false.</value>
        bool Leap { get; set; }
    }
}
