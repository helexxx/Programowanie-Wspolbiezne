namespace Logic
{
    public class Ball
    {
        private int pos_x;
        private int pos_y;
        private int rad_r;
        private int move_x;
        private int move_y;

        internal Ball(int x, int y, int radius)
        {
            pos_x = x;
            pos_y = y;
            rad_r = radius;
        }

        public void ChangeBallPosition(int maxBorderX,int maxBorderY)
        {
            double newX = pos_x + move_x;
            double newY = pos_y + move_y;


            if (newX > maxBorderX || newX < 0)
            {
                move_x = -move_x;
            }

            if (newY > maxBorderY || newY < 0)
            {
                move_y = -move_y;
            }

            pos_x = pos_x + move_x;
            pos_y = pos_y + move_y;
        }

        public int get_x
        {
            get => pos_x;
            set => pos_x = value;
        }

        public int get_y
        {
            get => pos_y;
            set => pos_y = value;
        }

        public int get_radius
        {
            get => rad_r;
            set
            {
                if (value > 0)
                {
                    rad_r = value;
                }

                else
                {
                    throw new System.ArgumentException();
                }

            }
        }


    }
}