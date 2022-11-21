using System;

namespace IntegrationLibrary.Core.Utility
{
    /// <summary>
    ///     Represents a range of dates.
    /// </summary>
    public struct DateRange
    {
        /// <summary>
        ///     Gets the start date component of the date range.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        ///     Gets the end date component of the date range.
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        ///     Gets the number of whole days in the date range.
        /// </summary>
        public int GetDays => (EndDate - StartDate).Days + 1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DateRange" /> class to the specified start and end date.
        /// </summary>
        /// <param name="startDate">A DateTime object that contains that first date in the date range.</param>
        /// <param name="endDate">A DateTime object that contains the last date in the date range.</param>
        /// <exception cref="System.ArgumentException">
        ///		endDate is not greater than or equal to startDate
        /// </exception>
        public DateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("endDate must be greater than or equal to startDate");
            }
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
