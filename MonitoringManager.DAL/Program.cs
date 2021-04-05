using System;
using System.Linq;
using System.Data.SqlClient;

namespace MonitoringManager.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random rand = new Random();
            TestDateSource testDate = new TestDateSource();
            var ae = testDate.GetData();
            try
            {
                DBMonitorAdapter adapter = new DBMonitorAdapter();

                foreach (var item in adapter.GetLastMonitorDate())
                {
                    Console.WriteLine(
                 $"SystemId:{item.SystemId}" +
                 $"  SystemTemerature: {item.SystemTemperature}" +
                 $"  CPULoad:{item.CPULoad}" +
                 $"  CPUTemperture: {item.CPUTemperature}" +
                 $"  HDDSpace {item.HDDSpace} " +
                 $"Data: {item.Time}");

                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            ///var a = testDate.GetData().GroupBy(s => s.SystemId);
            //var ds = ae.Select(e => e.SystemId).Distinct().GroupJoin(ae,e=>e,e=>e.SystemId,
            //    (l,r) => ae.Where(e=> e.SystemId == l && e.Time == r.Max(e=> e.Time)).First());
            ////var tms = ae.Where(e => gj.Contains(e.Time));

            //var res = ae.Select(e => e.SystemId).Distinct()
            //    .GroupJoin(ae, e => e, e => e.SystemId, (lef, rig) =>
            //    ae.Where(e => e.Time == rig.Max(e => e.Time)).Select(e=> e).First());

            //foreach (var item in res)
            //{
            //    Console.WriteLine(
            //    $"SystemId:{item.SystemId}" +
            //    $"  SystemTemerature: {item.SystemTemperature}" +
            //    $"  CPULoad:{item.CPULoad}" +
            //    $"  CPUTemperture: {item.CPUTemperature}" +
            //    $"  HDDSpace {item.HDDSpace} " +
            //    $"Data: {item.Time}");
            //}
            //Console.ReadLine();

            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = "192.168.0.3";
            //builder.UserID = "MonitoringManager";
            //builder.Password = "MonitoringManager";
            //builder.InitialCatalog = "DBMonitor";
            //string comd = "select ID f Monitor";
            //SqlConnection connection = new SqlConnection(builder.ConnectionString);
            //connection.Open();
            //SqlTransaction transaction = connection.BeginTransaction();
            //SqlCommand command = new SqlCommand(comd, connection, transaction);
            //SqlDataReader reader = command.ExecuteReader(); 
            //Console.ReadLine();


        }
    }
}
