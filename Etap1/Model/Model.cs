using System.Numerics;

namespace Model
{
        public abstract class ModelAbstractApi
        {
            public static ModelAbstractApi CreateApi()
            {
                return new ModelApi();
            }
        }

        internal class ModelApi : ModelAbstractApi
        {
            public static void Main()
            {
                Logic.LogicAPI logicLayer = Logic.LogicAPI.CreateAPI(Data.DataAPI.CreateAPI());
                Logic.Box box = logicLayer.CreateBox(100, 100, 3, 3);
                logicLayer.Simulation(box);

                for (int i = 0; i < box.Balls.Count; i++)
                {
                    System.Console.WriteLine("Ball " + i.ToString());
                    System.Console.WriteLine(box.Balls[i].get_x);
                    System.Console.WriteLine(box.Balls[i].get_y);
                    System.Console.WriteLine(box.Balls[i].get_radius);
                }

            }
        }
    
}