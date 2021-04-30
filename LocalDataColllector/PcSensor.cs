using LibreHardwareMonitor.Hardware;

namespace LocalDataColllector
{
  public class PcSensor
  {
        public PcSensor(ISensor sensor,IHardware hardware)
        {
            Sensor = sensor;
            Hardware = hardware;
        }
        private ISensor Sensor;
        private IHardware Hardware;
        public float? Value
        {
            get 
            {
                 Hardware.Update();
                return Sensor.Value;
            }
           
        }

  }
}
