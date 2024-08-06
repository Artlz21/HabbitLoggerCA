namespace HabitLoggerAPP {
    public class Program {
        public static void Main(string[] args){
            string connectionString = @"Data Source=habbit-logger.db";
            Menu menu= new Menu(connectionString);
            menu.MainMenu();
        }
    }
} 