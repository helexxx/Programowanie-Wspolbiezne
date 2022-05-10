
using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicAPI
    {
        public static LogicAPI CreateAPI(DataAbstractAPI dataAbstractAPI = default(DataAbstractAPI))
        {
            return new Box(dataAbstractAPI);
        }

        public abstract ObservableCollection<Ball> Balls { get; }

        public abstract void CreateBalls(int count, int radius);
        public abstract void StartSimulation();

        public abstract void StopSimulation();

    }
}