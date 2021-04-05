using System;

namespace MonitoringManager.DAL
{
    public static class RandomDateTime
    {
        public static DateTime GetDateTime()
        {
            Random rand = new Random();
            return DateTime.UtcNow.AddDays(rand.Next(-4,3)).AddHours(rand.Next(0, 24)).AddMinutes(rand.Next(0, 60)).AddSeconds(rand.Next(0, 60));
        }
    }
}
