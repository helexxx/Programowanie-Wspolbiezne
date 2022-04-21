using System;
using Logic;

namespace Model
{
    public abstract class ModelAbstractApi
    {
            public abstract int Radius { get; }

            public abstract int Width { get; }
            public abstract int Height { get; }

            public abstract void BeginMove();

        public static ModelAbstractApi CreateApi()
            {
                return new ModelApi();
            }
        }

    internal class ModelApi : ModelAbstractApi
    {
        public override int Radius => 3;
        public override int Width => Width;
        public override int Height => Height;

        private Box Box = new Box();
        public override void BeginMove()
        {
            Box.generateBalls(5, 3);
            Box.MoveBalls();
        }
    }
}
