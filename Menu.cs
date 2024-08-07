namespace HabitLoggerAPP {
    public class Menu {
        private string userInput = "";
        private int menuSelection;
        private bool exitApp = false;
        private readonly string connectionString;
        private readonly HabitDatabase habitDB;

        public Menu(string cs) {
            connectionString = cs;
            habitDB = new HabitDatabase(connectionString);
        }

        public void MainMenu () {
            while (!exitApp) {
                Console.Clear();
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
                    userInput = Console.ReadLine() ?? "";
                    if (int.TryParse(userInput, out menuSelection)) {
                        switch (menuSelection) {
                            case 0:
                                Console.Clear();
                                exitApp = true;
                                break;
                            case 1:
                                ExecuteAction(View);
                                break;
                            case 2:
                                ExecuteAction(Add);
                                break;
                            case 3:
                                ExecuteAction(Update);
                                break;
                            case 4:
                                ExecuteAction(Delete);
                                break;
                            default:
                                Console.WriteLine ("Please enter a valid selection");
                                break;
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine ($"Invalid input entered {ex.Message}");
                }
            }
        }

        private void ExecuteAction (Action action) {
            Console.Clear();
            Console.WriteLine("".PadLeft(25, '-'));
            action();
            Console.WriteLine("".PadLeft(25, '-'));
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        private void View () {
            Console.WriteLine("Here are your currently logged habits.\n");
            habitDB.ShowUserHabits();
        }

        private void Add () {
            bool check = false;
            try{
                while (!check)
                {
                    Console.Write("Enter a habit to add: ");
                    string habit = Console.ReadLine() ?? "";
                    if (string.IsNullOrEmpty(habit))
                    {
                        Console.WriteLine("Please enter a valid input");
                        continue;
                    }
                    Console.Write("How many times have you done this habit: ");
                    string userCount = Console.ReadLine() ?? "";
                    if (int.TryParse(userCount, out int count))
                    {
                        habitDB.AddHabit(habit, count);
                        check = true;
                        break;
                    }
                    Console.WriteLine("Please enter a valid input");
                }
            }
            catch (Exception ex) {
                Console.WriteLine ($"Invalid input entered {ex.Message}");
            }
        }

        private void Update () {
            bool check = false;
            try {
                while (!check)
                {
                    Console.Write("Enter a habit to update: ");
                    string habit = Console.ReadLine() ?? "";
                    if (string.IsNullOrEmpty(habit))
                    {
                        Console.WriteLine("Please enter a valid input");
                        continue;
                    }
                    Console.Write("How many times have you done this habit: ");
                    string userCount = Console.ReadLine() ?? "";
                    if (int.TryParse(userCount, out int count))
                    {
                        habitDB.UpdateHabit(habit, count);
                        check = true;
                        break;
                    }
                    Console.WriteLine("Please enter a valid input");
                }
            }
            catch (Exception ex) {
                Console.WriteLine ($"Invalid input entered {ex.Message}");
            }
        }

        private void Delete () {
            bool check = false;
            try {
                while (!check) {
                    Console.Write("Enter a habit to delete: ");
                    string habit = Console.ReadLine() ?? "";
                    if (string.IsNullOrEmpty(habit)) {
                        Console.WriteLine("Please enter a valid input");
                        continue;
                    }
                    habitDB.DeleteHabit(habit);
                    check = true;
                }
            }
            catch (Exception ex) {
                Console.WriteLine ($"Invalid input entered {ex.Message}");
            }
        }
    }
}