using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateDataAPI()
        {
            return new DataLayer();
        }


        public abstract void CreateBalls(int count, int radius);
        public abstract void StartSimulation();

        public abstract void StopSimulation();

    }
    internal class DataLayer : DataAbstractAPI
    {
        private CancellationToken _cancelToken;
        public CancellationToken CancellationToken => _cancelToken;
        private List<Task> _tasks = new List<Task>();

        private  Box box = new Box();
        public DataLayer() 
        { 

        }

        public override void CreateBalls(int count, int radius)
        {
            box.generateBalls(count, radius);
        }

        public override void StartSimulation()
        {
            foreach (Ball ball in box.Balls)
            {
                Task task = Task.Run(async () =>
                {
                    await Task.Delay(1);
                    while (ball.Alive)
                    {
                        await Task.Delay(20);
                        try
                        {
                            _cancelToken.ThrowIfCancellationRequested();
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }

                        ball.MoveBall(box.Width, box.Height);

                    }
                }
                );
                _tasks.Add(task);
            }
        }

        public override void StopSimulation()
        {
            foreach (Ball ball in box.Balls)
            {
                ball.Alive = false;
            }
            box.Balls.Clear();
            _tasks.Clear();
        }
    }
}
