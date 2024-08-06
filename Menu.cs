namespace HabitLoggerAPP{
    public class Menu {
        private string userInput = "";
        private int menuSelection;
        private bool exitApp = false;
        private string connectionString;
        private HabitDatabase habitDB;
        public Menu(string cs) {
            connectionString = cs;
            habitDB = new HabitDatabase(connectionString);
        }

        public void MainMenu () {
            while (!exitApp) {
                Console.WriteLine ("Main Menu\n");
                Console.WriteLine ("Select an option from below.");
                Console.WriteLine ("".PadLeft(25, '-'));
                Console.WriteLine ("Enter 0 to close");
                Console.WriteLine ("Enter 1 to View all records");
                Console.WriteLine ("Enter 2 to Add new record");
                Console.WriteLine ("Enter 3 to Update a record");
                Console.WriteLine ("Enter 4 to Delete a record");
                Console.WriteLine ("".PadLeft (25, '-'));

                try {
                    userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out menuSelection)) {
                        switch (menuSelection) {
                            case 0:
                                Console.Clear();
                                exitApp = true;
                                break;
                            case 1:
                                Console.Clear();
                                View();
                                break;
                            case 2:
                                Console.Clear();
                                Add();
                                break;
                            case 3:
                                Console.Clear();
                                Update();
                                break;
                            case 4:
                                Console.Clear();
                                Delete();
                                break;
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine ($"Invalid input entered {ex.Message}");
                }
            }
        }

        private void View () {
            Console.WriteLine("Here are your currently logged habits.\n");
            Console.WriteLine("".PadLeft(25, '-'));
            habitDB.ShowUserHabits();
        }

        private void Add () {
            Console.WriteLine("What Habit would you like to add?");
            Console.WriteLine("".PadLeft(25, '-'));
            Console.Write("Enter a habit: ");
            string habit = Console.ReadLine();
            Console.Write("How many times have you done this habit: ");
            int count = Convert.ToInt16(Console.ReadLine());
            habitDB.AddHabit(habit, count);
        }

        private void Update () {
            Console.WriteLine("What Habit would you like to update?");
            Console.WriteLine("".PadLeft(25, '-'));
            Console.Write("Enter a habit: ");
            string habit = Console.ReadLine();
            Console.Write("How many times have you done this habit: ");
            int count = Convert.ToInt16(Console.ReadLine());
            habitDB.UpdateHabit(habit, count);
        }

        private void Delete () {
            Console.WriteLine("What Habit would you like to Delete?");
            Console.WriteLine("".PadLeft(25, '-'));
            Console.Write("Enter a habit: ");
            string habit = Console.ReadLine();
            habitDB.DeleteHabit(habit);
        }
    }
}