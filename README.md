# Habit Logger Console App

This is one of my first C# apps that required me to utilize a database for storing data. 
It is a habit logging app that lets you enter a particular habit you want to log and track by the quantity of completions.

### Requirements 

The requirements for this app were as follows:
1. App registers one habit at a time
2. Habit is tracked by quantity not time
3. Should store and retrieve data from db
4. When started the app creates db if none exists
5. Should create a table in db where habit is logged
6. Should have a menu to show user
7. User should insert, delete, update, and view logged habit
8. Should have error handling to prevent crashes
9. Should terminate when 0 is entered in menu

### Features

- This app features a single entry point to run the app in the programs file by passing in a connection string
that is used to create and connect to a database file.
- This string is used to create an instance of a Menu class that holds the interface for the app. In the Menu
class the main menu display is run prompting the user to select an action exit the app, view their listed habits,
add a new habit, update an existing habit, or delete an existing habit.
- Each action connects to an instance of another class that manages the database access. The DatabaseManager
class is used to create, connect, and access the database file using sqlite. 

### Learning Required 

To complete this app I had to familiarize myself with different tools to connect and build the app. 

- Using namespace to organize the code all within the same scope.
- Using SQLite to create and manage a database, and connecting it with other parts of my code.
- Using exception handling to help manage and prevent errors from occuring while running the app.

### Areas to Improve

1. Add a way to track dates of when these tasks are completed.
2. Improve the the structure and accessing of the DatabaseManger class.
3. Store queried data in a list before passing it to the Menu for better access and organization.
4. Improve the display of the listed habits for viewing.
5. Improve the methods for adding, updating, and deleting habits to better display and perform.
6. Add a way to provide details to habits added and a way to see these details when selected from view.
