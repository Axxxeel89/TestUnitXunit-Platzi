namespace StringManipulation
{
    public interface ILoggerGeneral
    {
        void message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int balaceDespuesRetiro);
        string MessageConReturnString(string message);
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public bool LogBalanceDespuesRetiro(int balaceDespuesRetiro)
        {
            if(balaceDespuesRetiro >= 0)
            {
                Console.WriteLine("Exito");
                return true;
            }

            Console.WriteLine("Error");
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageConReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }
}
