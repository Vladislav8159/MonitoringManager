using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringManager.DAL
{
    public class TestDateSource : IDateSourse
    {
        public IEnumerable<SystemInformationModel> GetData()
        {
            int count = 100;
            
            SystemInformationModel system = new SystemInformationModel();

            for (int i = 0; i < count; i++)
            {
                system.SystemTemperature = (int)(Random.Next(30, 100) + Random.NextDouble());
                system.CPULoad = Random.Next(10, 100);
                system.CPUTemperature = Random.Next(45, 100);
                system.SystemId = Random.Next(0, 4);
                system.HDDSpace = Random.Next(0, 100);
                system.Time = RandomDateTime.GetDateTime();
                yield return system ;
            }
            yield return system;
        }

        private Random @Random = new Random();
        private List<int> list = new List<int>().ToList();
    }
}
