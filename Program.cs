namespace HabitLoggerAPP {
    public class Program {
        public static void Main(string[] args){
            string connectionString = @"Data Source=habbit-logger.db";
            HabitDatabase newdb = new HabitDatabase(connectionString);
        }
    }
} 