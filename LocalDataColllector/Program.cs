using System;
using System.Threading.Tasks;
using System.Linq;
using NetMQ.Sockets;
using NetMQ;
using System.Text.Json;

namespace LocalDataColllector
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            var r = args.Where(e => e.Contains("system-id="));
            if (r.Any())
            {
                SysId = r.First().Split("=")[1];
                Id = int.Parse(SysId);
            }
            else
            {
                Console.WriteLine("Ошибка: Укажите SystemId:(пример)system-id=1");
                Environment.Exit(-2);
            }
            LocalDataSourse source = new LocalDataSourse(Id);
            ScatterSocket socket = new ScatterSocket();
            socket.Connect(URL);
            while (true)
            {
               var b = source.UpDate();
               string str = JsonSerializer.Serialize(b);
               Console.WriteLine(str);
               await socket.SendAsync(str);
               await Task.Delay(new TimeSpan(0,0,2));
            }
          
        }
        private static string SysId;
        private static int Id;
        private readonly static string URL = "tcp://localhost:40000";
        
    }
    
}
