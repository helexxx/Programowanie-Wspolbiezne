using System;
using System.Collections.ObjectModel;
using Logic;

namespace Model
{
    public abstract class ModelAbstractApi
    {
            public abstract int Radius { get; }
            public abstract int Count { get; set; }

            public abstract ObservableCollection<Ball> Balls { get; }

        public abstract void StartSimulation();
        public abstract void StopSimulation();

        public static ModelAbstractApi CreateApi()
            {
                return new ModelApi();
            }
        }

    internal class ModelApi : ModelAbstractApi
    { 
        public override int Radius => 5;

        public override int Count { get => count; set => count = value; }

        public override ObservableCollection<Ball> Balls
        {
            get
            {
                return box.Balls;
            }
        }

        public override void StartSimulation()
        {
            box.generateBalls(Count, Radius);
            LogicLayer.StartSimulation(box);
        }

        public override void StopSimulation()
        {

        }

        public ModelApi()
        {
            LogicLayer = new LogicAPI.LogicLayer();
            box = LogicLayer.CreateBox();
        }

        private LogicAPI LogicLayer;
        private Box box;
        private int count;
    }
}
