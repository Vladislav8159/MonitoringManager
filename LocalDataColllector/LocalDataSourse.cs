using LibreHardwareMonitor.Hardware;
using MonitoringManager.DAL;
using System;

namespace LocalDataColllector
{
    public class LocalDataSourse
    {
        public LocalDataSourse(int systemId)
        {
            SysId = systemId;
            System = new SystemReadings();
            Comp = new Computer
            {
                IsCpuEnabled = true,
                IsMotherboardEnabled = true,
                IsStorageEnabled = true,
                IsControllerEnabled = true
            };
            Comp.Open();
            Sensors = new PCSensors()
            {
                CpuLoadSensor = System.GetCpuLoadSensor(Comp),
                CpuTemperatureSensor = System.GetCpuTempSensor(Comp),
                HardSensor = System.GetUsedSpeedHddSensor(Comp),
                SystemTemperatureSensor = System.GetMotherboardTempSensor(Comp)
            };
        }
        public SystemInformationModel UpDate()
        {
            SystemInformationModel model = new SystemInformationModel()
            {
                SystemId = SysId,
                CPULoad = (double)Sensors.CpuLoadSensor.Value,
                CPUTemperature = (double)Sensors.CpuTemperatureSensor.Value,
                HDDSpace = (double)Sensors.HardSensor.Value,
                SystemTemperature = (double)Sensors.SystemTemperatureSensor.Value,
                Time = DateTime.UtcNow
            };
            return model;
            
        }
        private PcSensor Sensor;
        private readonly int SysId;
        private SystemReadings System;
        private Computer Comp;
        private PCSensors Sensors;
    }
}
