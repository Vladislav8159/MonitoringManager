using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace MonitoringManager.DAL
{
    public class DBMonitorAdapter
    {
        public DBMonitorAdapter()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "192.168.0.3";
            builder.UserID = "MonitoringManager";
            builder.Password = "MonitoringManager";
            builder.InitialCatalog = "DBMonitor";
            Connection = new SqlConnection(builder.ConnectionString);
            Connection.Open();
        }
        private SqlConnection Connection;

        public IEnumerable<SystemInformationModel> GetLastMonitorDate()
        {
            SystemInformationModel model = new SystemInformationModel();
            string sql = "select * from VCurrentData";
            using SqlTransaction transaction = Connection.BeginTransaction();
            using SqlCommand command = new SqlCommand(sql, Connection, transaction);
            using SqlDataReader reader = command.ExecuteReader();
            List<SystemInformationModel> models = new List<SystemInformationModel>();
            while (reader.Read())
            {
               
                SystemInformationModel system = new SystemInformationModel
                {
                  SystemId = reader.GetInt32(reader.GetOrdinal("SystemId")),
                  CPULoad = reader.GetDouble(reader.GetOrdinal("CPULoad")),
                  CPUTemperature = reader.GetInt32(reader.GetOrdinal("CPUTemperature")),
                  SystemTemperature = reader.GetInt32(reader.GetOrdinal("SystemTemperature")),
                  HDDSpace = reader.GetDouble(reader.GetOrdinal("HDDSpace")),
                  Time = reader.GetDateTime(reader.GetOrdinal("Date")),
                 };
                models.Add(system);
            }
            
            reader.Close();
            transaction.Commit();
            return models;
        }
        public void InsertOne(SystemInformationModel model)
        {
            string sqlCom = string.Format("Insert Into Monitor " +
                   "(SystemId,CPULoad,CPUTemperature,SystemTemperature,HDDSpace,DateTime)" +
                   " Values(@SystemId, @CPULoad, @CPUTemperature, @SystemTemperature, @HDDSpace, @DateTime)");
            using SqlTransaction transaction = Connection.BeginTransaction();
            using SqlCommand command = new SqlCommand(sqlCom, Connection,transaction);
            
            command.Parameters.AddWithValue("@SystemId", model.SystemId);
            command.Parameters.AddWithValue("@CPULoad", model.CPULoad);
            command.Parameters.AddWithValue("@CPUTemperature", model.CPUTemperature);
            command.Parameters.AddWithValue("@SystemTemperature", model.SystemTemperature);
            command.Parameters.AddWithValue("@HDDSpace", model.HDDSpace);
            command.Parameters.AddWithValue("@DateTime", model.Time);
            command.ExecuteNonQuery();
            transaction.Commit();
        }
        public void InsertMany(IEnumerable<SystemInformationModel> models)
        {
            string sqlCom = string.Format("Insert Into Monitor" +
                   "(SystemId, CPULoad, CPUTemperature, SystemTemperature, HDDSpace, DateTime)" +
                   " Values(@SystemId, @CPULoad, @CPUTemperature, @SystemTemperature, @HDDSpace, @DateTime)");
            using SqlTransaction transaction = Connection.BeginTransaction();
      
            foreach (var item in models)
            {
                using SqlCommand command = new SqlCommand(sqlCom, Connection, transaction);
                command.Parameters.AddWithValue("@SystemId", item.SystemId);
                command.Parameters.AddWithValue("@CPULoad", item.CPULoad);
                command.Parameters.AddWithValue("@CPUTemperature", item.CPUTemperature);
                command.Parameters.AddWithValue("@SystemTemperature", item.SystemTemperature);
                command.Parameters.AddWithValue("@HDDSpace", item.HDDSpace);
                command.Parameters.AddWithValue("@DateTime", item.Time);
                command.ExecuteNonQuery();
               // Console.WriteLine(command.CommandText);
            }
            transaction.Commit();
        }
    }
}
