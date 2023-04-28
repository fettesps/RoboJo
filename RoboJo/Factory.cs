namespace RoboJo
{
    class Factory
    {
        public static IDAL OpenDB()
        {
            return new DAL();
        }
    }
}
