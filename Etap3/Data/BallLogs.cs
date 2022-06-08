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
                   logTask = Task.Factory.StartNew(this.LogToFile);
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        private Mutex fileMutex = new Mutex();

        private async Task LogToFile()
        {
            while (ballQueue.TryDequeue(out JObject ball))
            {
                dataArray.Add(ball);
            }

            string output = JsonConvert.SerializeObject(dataArray);

            fileMutex.WaitOne();
            try
            {
                File.WriteAllText(logPath, output);
            }
            finally
            {
                fileMutex.ReleaseMutex();
            }
        }

        ~BallLogs()
        {
            fileMutex.WaitOne();
            fileMutex.ReleaseMutex();
        }

    }
}
