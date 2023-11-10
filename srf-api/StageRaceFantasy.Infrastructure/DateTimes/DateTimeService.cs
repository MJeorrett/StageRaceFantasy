using StageRaceFantasy.Application.Common.Interfaces;

namespace StageRaceFantasy.Infrastructure.DateTimes;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}