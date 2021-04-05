using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringManager.DAL
{
    public class SystemInformationModel
    {
        public int SystemId { get; set; } 
        public double CPULoad { get; set; }
        public int CPUTemperature { get; set; }
        public int SystemTemperature { get; set; }
        public double HDDSpace { get; set; }
        public DateTime Time { get; set; }
    }
}
