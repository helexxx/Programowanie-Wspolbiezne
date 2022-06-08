using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System;

namespace Data
{
    internal class BallLogs
    {
        private readonly string logPath;

        private Task? logTask;

        private readonly ConcurrentQueue<JObject> ballQueue = new ConcurrentQueue<JObject>();

        private readonly Mutex mutex = new Mutex();
        private readonly JArray dataArray;

        public BallLogs()
        {
            string path = "C:\\Users\\helex\\Desktop\\LogsBalls";
            logPath = path + "LogsBalls.json";
            try
            {
                if (File.Exists(logPath))
                {
                    string input = File.ReadAllText(logPath);
                    dataArray = JArray.Parse(input);
                    return;
                }
            }
            catch (JsonReaderException) { }

            dataArray = new JArray();
            File.Create(logPath);
        }

        public void AddToLogQueue(MyDataBall ball)
        {
            mutex.WaitOne();
            try
            {
                JObject itemToAdd = JObject.FromObject(ball);
                itemToAdd["Time"] = DateTime.Now.ToString("HH:mm:ss");
                ballQueue.Enqueue(itemToAdd);

                if (logTask == null || logTask.IsCompleted)
                {
                   // logTask = Task.Factory.StartNew(this.LogToFile);
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

    }
}
