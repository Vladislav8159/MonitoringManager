using System;

namespace MonitoringManager.DAL
{
    public class SystemInformationModel
    {
        public int SystemId { get; set; } 
        public double CPULoad { get; set; }
        public double CPUTemperature { get; set; }
        public double SystemTemperature { get; set; }
        public double HDDSpace { get; set; }
        public DateTime Time { get; set; }
    }
}
