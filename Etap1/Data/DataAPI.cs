namespace Data
{
    public abstract class DataAPI
    {
        public static DataAPI CreateAPI()
        {
            return new DataLayer();
        }

  
        public class DataLayer : DataAPI
        {   
            public DataLayer()
            {
                
            }
        }

    }
}