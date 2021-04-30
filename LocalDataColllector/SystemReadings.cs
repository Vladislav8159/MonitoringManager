using LibreHardwareMonitor.Hardware;
using System.Linq;

namespace LocalDataColllector
{
    public class SystemReadings
    { 
        public PcSensor GetUsedSpeedHddSensor(Computer comp)
        {
            IHardware hdd = comp.Hardware.Where(c => c.HardwareType == HardwareType.Storage).First();
            hdd.Update();
            ISensor sensor = hdd.Sensors.Where(c => c.SensorType == SensorType.Load).Where(c => c.Name.Equals("Used Space")).First();
            return new PcSensor(sensor, hdd);
        }
        public PcSensor GetCpuLoadSensor(Computer comp)
        {
            IHardware cpu = comp.Hardware.Where(c => c.HardwareType == HardwareType.Cpu).First();
            cpu.Update();
            ISensor sensor = cpu.Sensors.Where(c => c.SensorType == SensorType.Load).Where(e => e.Name.Equals("CPU Total")).First();
            return new PcSensor(sensor, cpu);
        }
        public PcSensor GetCpuTempSensor(Computer comp)
        {
            IHardware cpu = comp.Hardware.Where(c => c.HardwareType == HardwareType.Cpu).First();
            cpu.Update();
            ISensor sensor = cpu.Sensors.Where(c => c.SensorType == SensorType.Temperature)
            .Where(c => c.Name.Equals("Core (Tctl/Tdie)")).First();
            return new PcSensor(sensor, cpu);
            
        }
        public PcSensor GetMotherboardTempSensor(Computer comp)
        {
            IHardware Motherboard = comp.Hardware.Where(c => c.HardwareType == HardwareType.Motherboard).First();
            Motherboard.SubHardware.First().Update();
            ISensor sensor = Motherboard.SubHardware.First().Sensors.Where(c => c.SensorType == SensorType.Temperature)
                              .Where(c => c.Name.Equals("Temperature #1")).First();
            return new PcSensor(sensor,Motherboard);
        }


    }
}
