using MonitoringManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringManager.Services
{
    public class DBMonitorAdapterService
    {
        public DBMonitorAdapterService()
        {
            Aapter = new DBMonitorAdapter();
        }
        private DBMonitorAdapter Aapter;

        public (DateTime dateMax, DateTime dateMin) GettingDate(int sysId)
        {
            return Aapter.GettingDate(sysId);
        }
        public IEnumerable<SystemInformationModel> GetInfoSystemModel(SysInfoSearchModel model)
        {
          return Aapter.GetInfoSystemModel(model);
        }

        public IEnumerable<SystemInformationModel> ObtainingID()
        {
            return Aapter.ObtainingID();
        }

        public IEnumerable<SystemInformationModel> GetLastMonitorDate()
        {
            return Aapter.GetLastMonitorDate();
        }

        public void InsertOne(SystemInformationModel model)
        {
            Aapter.InsertOne(model);
        }

        public void InsertMany(IEnumerable<SystemInformationModel> models)
        {
            Aapter.InsertMany(models);
        }
    }
}
