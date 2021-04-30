using System;

namespace LocalDataColllector
{
    
    public class PCSensors
    {
       public PcSensor CpuLoadSensor { get; set; }
       public PcSensor CpuTemperatureSensor { get; set; }
       public PcSensor SystemTemperatureSensor { get; set; }
       public PcSensor HardSensor { get; set; }
       
    }
}
