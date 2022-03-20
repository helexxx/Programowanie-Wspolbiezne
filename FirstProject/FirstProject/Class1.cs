using System;

namespace FirstProject
{
    public class Calculator
    {
       public int Add(int v1, int v2)
        {
            return v1 + v2;
        }
        public int Sub(int v1, int v2)
        {
            return v1- v2;
        }
        public int Multi(int v1, int v2)
        {
            return v1 * v2;
        }
        public double Div(int v1, int v2)
        {
            if(v2 != 0 )
            {
                return v1 / v2;
            }
            else
            {
                throw new ArgumentException("Division by zero");
            }
        }
    }
}
