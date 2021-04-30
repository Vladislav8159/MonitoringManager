using Microsoft.Extensions.Hosting;
using MonitoringManager.DAL;
using NetMQ;
using NetMQ.Sockets;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MonitoringManager.Services
{
    public class DataCollectorService : IHostedService
    {
        public DataCollectorService()
        {
            Adapter = new DBMonitorAdapter();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Socket = new GatherSocket();
            Socket.Bind("tcp://*:40000");
            IsRuning = true;
            WorkTask = new Task(TaskMethod);
            WorkTask.Start();
            Console.WriteLine("Start");
        }
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            IsRuning = false;
            Socket.Close();
            await WorkTask;
            Console.WriteLine("Stop");
        }
        private async void TaskMethod()
        {
            while (IsRuning)
            {
               string str = await Socket.ReceiveStringAsync();
                Console.WriteLine(str);
               var c = JsonSerializer.Deserialize<SystemInformationModel>(str);
                Adapter.InsertOne(c);
            }
        }
        private GatherSocket Socket;
        private Task WorkTask;
        public bool IsRuning = false;
        private DBMonitorAdapter Adapter;
    }
}
