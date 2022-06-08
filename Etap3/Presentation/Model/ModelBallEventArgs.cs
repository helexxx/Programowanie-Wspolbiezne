using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Presentation.Model
{
    public class ModelBallEventArgs : EventArgs
    {
        public int id;
        public Vector2 position;
        public float radius;
        public ModelBallEventArgs(int id, Vector2 position, float radius)
        {
            this.id = id;
            this.position = position;
            this.radius = radius;
        }
    }
}
