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

        public static ModelAbstractApi CreateModelAPI(LogicAPI logicApi = default(LogicAPI))
        {
            return new ModelApi(logicApi);
        }

        public abstract void ModelStartSimulation();
        public abstract void ModelStopSimulation();

        public static ModelAbstractApi CreateApi(LogicAPI logicApi = default(LogicAPI))
            {
                return new ModelApi(logicApi);
            }
        }

    internal class ModelApi : ModelAbstractApi
    { 
        public override int Radius => 8;

        public override int Count { get => count; set => count = value; }

        public ModelApi() : this(LogicAPI.CreateAPI()) { }
        public ModelApi(LogicAPI logicApi)
        {
            LogicLayer = logicApi ?? LogicAPI.CreateAPI();
        }

        public override ObservableCollection<Ball> Balls
        {
            get
            {
                return LogicLayer.Balls;
            }
        }

        public override void ModelStartSimulation()
        {
            LogicLayer.CreateBalls(Count, Radius);
            LogicLayer.StartSimulation();
        }

        public override void ModelStopSimulation()
        {
            LogicLayer.StopSimulation();
        }

        private LogicAPI LogicLayer;
        private int count;
    }
}
