using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Unit
{
    public class WorkTimeTests
    {
        [Fact]
        public void Create_Invalid_WorkTime()
        {
            DateRange dateRange = new DateRange(new DateTime(2022, 11, 11), new DateTime(2022, 11, 19));
            DateTime startTime = new DateTime(2022, 11, 11, 15, 0, 0);
            DateTime endTime = new DateTime(2022, 11, 11, 7, 0, 0);

            Assert.Throws<ArgumentException>(() => new WorkTime(dateRange, startTime, endTime));
        }
    }
}
