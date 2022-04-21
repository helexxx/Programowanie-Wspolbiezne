using System;
using Logic;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }

        public static ModelAbstractApi CreateAPI()
        {
            throw new NotImplementedException();
        }

        public abstract void start();
        
    }


    public class ModelApi : ModelAbstractApi
    {
       private readonly LogicAPI logicLayer = LogicAPI.CreateAPI(Data.DataAPI.CreateAPI());
        
        public override void start()
        {
            logicLayer.Simulation(logicLayer.CreateBox(400, 600, 5, 2));
        }
    }

}