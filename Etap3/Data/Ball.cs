using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Data
{
    public interface MyDataBall : ISerializable
    {
        public int id { get; }
        public Vector2 pos { get; }
        public float radius { get; }
        public float mass { get; }
        public Vector2 direction { get; set; }
        public void MoveBall();
        public event EventHandler<BallEventArgs>? Moved;
    }

    public class Ball : MyDataBall
    {
        public int id { get; }
        public Vector2 pos { get; private set; }
        public float radius { get; }
        public float mass { get; }
        public Vector2 direction { get; set; }
        public event EventHandler<BallEventArgs>? Moved;

        public Ball(int id, Vector2 position, float radius, float mass, Vector2 direction)
        {
            this.id = id;
            this.pos = position;
            this.radius = radius;
            this.mass = mass;
            this.direction = direction;
        }

        public async void MoveBall()
        {
            while (true)
            {
                this.pos += direction;
                var args = new BallEventArgs(this);
                Moved?.Invoke(this, args);
                await Task.Delay(1);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)         
        {             
            info.AddValue("id", id);
            info.AddValue("position", pos);
            info.AddValue("direction", direction);
        }
    }
}
