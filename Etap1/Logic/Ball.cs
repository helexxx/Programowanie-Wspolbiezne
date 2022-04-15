namespace Logic
{
    public class Ball
    {
        private int pos_x;
        private int pos_y;
        private int rad_r;

        internal Ball(int x, int y, int radius)
        {
            pos_x = x;
            pos_y = y;
            rad_r = radius;
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