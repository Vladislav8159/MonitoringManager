using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringManager.DAL
{
    public interface IDateSourse
    {
       IEnumerable<SystemInformationModel> GetData();
       
    }
}
