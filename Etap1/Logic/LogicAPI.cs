﻿
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicAPI
    {
        public static LogicAPI CreateAPI()
        {
            return new LogicLayer();
        }
        public abstract void CreateBall(Box box);
        public abstract Box CreateBox();
        public abstract void StartSimulation(Box box);

        public abstract void Update(Box box);

        public abstract void StopSimulation(Box box);

        public class LogicLayer : LogicAPI
        {

            private CancellationToken _cancelToken;
            public CancellationToken CancellationToken => _cancelToken;
            private List<Task> _tasks = new List<Task>();
           
            public override void CreateBall(Box box)
            {
                box.Balls.Add(new Ball(box));
            }

            public override Box CreateBox()
            {
                return new Box();
            }

            public override void StartSimulation(Box box)
            {
                foreach (Ball ball in box.Balls)
                {
                    Task task = Task.Run(() =>
                    {
                        Thread.Sleep(1);
                        while (true)
                        {
                            Thread.Sleep(2);
                            try
                            {
                                _cancelToken.ThrowIfCancellationRequested();
                            }
                            catch (OperationCanceledException)
                            {
                                break;
                            }

                            ball.MoveBall(box.Width,box.Height);
                        }
                    }
                    );
                    _tasks.Add(task);
                }
            }

            public override void Update(Box box)
            {
                throw new System.NotImplementedException();
            }

            public override void StopSimulation(Box box)
            {
                throw new System.NotImplementedException();
            }

        }




    }
}