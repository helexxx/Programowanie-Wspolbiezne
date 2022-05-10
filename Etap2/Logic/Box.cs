using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;


namespace Logic
{
    internal class Box : LogicAPI
    {
        private readonly int box_width = 400;
        private readonly int box_height = 400;
        private ObservableCollection<Ball> balls = new ObservableCollection<Ball>();
        private readonly DataAbstractAPI dataAbstract;
        private CancellationToken _cancelToken;
        public CancellationToken CancellationToken => _cancelToken;
        private List<Task> _tasks = new List<Task>();

        internal Box(DataAbstractAPI dataAbstract)
        {
            this.dataAbstract = dataAbstract;
        }

        internal void generateBalls(int number, int radius)
        {
            Random r = new Random();

            for (int i = 0; i < number; i++)
            {
                double x = r.Next(0, box_width - radius);
                double y = r.Next(0, box_height - radius);
                balls.Add(new Ball(x, y, radius));
            }
        }

        internal void MoveBalls()
        {
            while (true)
            {
                foreach (Ball ball in balls)
                {
                    ball.MoveBall(box_width, box_height);
                }
            }
        }

        public override void CreateBalls(int count, int radius)
        {
            generateBalls(count, radius);
        }


        public override void StartSimulation()
        {
            foreach (Ball ball in this.balls)
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

                        ball.MoveBall(this.Width, this.Height);

                    }
                }
                );
                _tasks.Add(task);
            }

        }

        public override void StopSimulation()
        {
            foreach (Ball ball in balls)
            {
                ball.Alive = false;
            }
            balls.Clear();
            _tasks.Clear();
        }

        public int Width { get => box_width; }
        public int Height { get => box_height; }

        public override ObservableCollection<Ball> Balls { get => balls; }

    }
}