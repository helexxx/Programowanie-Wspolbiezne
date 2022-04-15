namespace View
{
    public class View
    {
        public static void Main()
        {
            Logic.LogicAPI logicLayer = Logic.LogicAPI.CreateAPI(Data.DataAPI.CreateAPI());
            Logic.Box box = logicLayer.CreateBox(100, 100, 3, 3);

            for (int i = 0; i < box.Balls.Count; i++)
            {
                System.Console.WriteLine("Ball " + i.ToString());
                System.Console.WriteLine(box.Balls[i].X);
                System.Console.WriteLine(box.Balls[i].Y);
                System.Console.WriteLine(box.Balls[i].R);
            }

        }
    }
}