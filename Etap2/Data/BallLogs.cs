using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class BallLogs
    {
        public void Message(Ball myBall)
        {
            string path = "C:\\Users\\helex\\Desktop\\Uczelnia4sem\\współbieżne\\Programowanie - Wspolbiezne\\Etap2";
            string logs;
            logs = myBall.id.ToString() + myBall.pos.ToString() + myBall.radius.ToString() + myBall.direction.ToString();
            System.IO.File.WriteAllText(path, logs);
        }
    }
}
