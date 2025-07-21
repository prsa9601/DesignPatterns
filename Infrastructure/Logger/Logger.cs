using Infrastructure.Logger;

namespace Infrastructure.Logger
{

    //Singleton Design Pattern
    public class Logger
    {
        private static Logger _instance;
        private Logger() { }

        //public static Logger Instance()
        //{
        //    return _instance ??= _instance = new Logger();
        //}

        //public static Logger Instance() => _instance ??= new Logger();

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            throw new Exception(message);
        }
    }
}
