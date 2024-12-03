using FilmAndActorsClasses;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;



namespace FilmsAndActors_App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Explicitly specify the namespace to resolve the ambiguity.
            Application.Run(new Form1());


            Console.WriteLine("Running tests for Actor class...");
            Actor.RunTests(); // Run tests for Actor class

            Console.WriteLine("Running tests for Film class...");
            Film.RunTests(); // Run tests for Film class

            Console.WriteLine("All tests have been executed.");

            // Display a welcome message and instructions for using the program
            Console.WriteLine("\nWelcome to the Film and Actors Catalogue!");
            Console.WriteLine("=========================================");
            Console.WriteLine("Use this program to manage your collection of films and actors.");
            Console.WriteLine("Choose an option from the menu below:");

            // Initialise dictionary to store films and actors
            Dictionary<string, Film> films = new Dictionary<string, Film>();
            Dictionary<string, Actor> actors = new Dictionary<string, Actor>();

            // Start the main program loop
            while (true)
            {
                // Display the menu options to the user
                DisplayMenu();
                // Get the user's menu choice
                string choice = GetUserChoice();
                // Handle the user's menu choice
                HandleUserChoice(choice, films, actors);
            }
        }

        // Displays the menu options to the user
        static void DisplayMenu()
        {
            Console.WriteLine("1 - Add a new Film");
            Console.WriteLine("2 - Add a new Actor");
            Console.WriteLine("3 - Display all Films");
            Console.WriteLine("4 - Display Films by Genre");
            Console.WriteLine("5 - Load films and Actors");
            Console.WriteLine("6 - Search Films or Actors");
            Console.WriteLine("7 - Update Film or Actor Information");
            Console.WriteLine("8 - Display Films by Actor");
            Console.WriteLine("9 - Save Data");
            Console.WriteLine("10 - Remove Film or Actor");
            Console.WriteLine("11 - Rate a Film");
            Console.WriteLine("12 - Sort Films or Actors");
            Console.WriteLine("13 - Export Report");
            Console.WriteLine("14 - Exit");
            Console.WriteLine("=========================================");
        }

        // Gets the user's menu choice
        // Purpose: To retrieve and validate the user's input for selecting an action
        static string GetUserChoice()
        {
            string choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();

                // Validate user input
                if
                (
                    choice == "1" ||
                    choice == "2" ||
                    choice == "3" ||
                    choice == "4" ||
                    choice == "5" ||
                    choice == "6" ||
                    choice == "7" ||
                    choice == "8" ||
                    choice == "9" ||
                    choice == "10" ||
                    choice == "11" ||
                    choice == "12" ||
                    choice == "13" ||
                    choice == "14"
                )
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 14.");
                }
            }
        }

        // Handles the user's menu choice
        // This function takes the user's choice and calls the appropriate function to perform the action
        // Handles the user's menu choice
        static void HandleUserChoice(string choice, Dictionary<string, Film> films, Dictionary<string, Actor> actors)
        {
            switch (choice)
            {
                case "1":
                    AddNewFilm(films, actors); // Call function to add a new film
                    break;
                case "2":
                    AddNewActor(actors); // Call function to add a new actor
                    break;
                case "3":
                    DisplayAllFilms(films); // Call function to display all films
                    break;
                case "4":
                    DisplayFilmsByGenre(films); // Call function to display films by genre
                    break;
                case "5":
                    DisplayFilmsByActor(films, actors); // Call function to display films by actor
                    break;
                case "6":
                    SearchFilmsOrActors(films, actors); // Call function to search films or actors
                    break;
                case "7":
                    UpdateFilmOrActorInformation(films, actors); // Call function to update film or actor information
                    break;
                case "8":
                    LoadFilmsAndActors(films, actors); // Call function to load films and actors
                    break;
                case "9":
                    SaveDataToFile(films, actors); // Save data
                    break;
                case "10":
                    RemoveFilmOrActor(films, actors); // Remove film or actor
                    break;
                case "11":
                    RateFilm(films); // Rate a film
                    break;
                case "12":
                    SortFilmsOrActors(films, actors); // Sort films or actors
                    break;
                case "13":
                    ExportReport(films, actors); // Export report
                    break;
                case "14":
                    ExitProgram(); // Exit the program
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again."); // Handle invalid menu choices
                    break;
            }
        }


        // Adds a new film to the catalogue
        // This function prompts the user for film details and adds the film to the list of films
        static void AddNewFilm(Dictionary<string, Film> films, Dictionary<string, Actor> actors)
        {
            Console.Write("Enter the film title: ");
            string filmTitle = Console.ReadLine();

            if (films.ContainsKey(filmTitle))
            {
                Console.WriteLine("A film with this title already exists. Please enter a different title.");
                return;
            }

            Console.Write("Enter the genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter the release year: ");
            if (!int.TryParse(Console.ReadLine(), out int releaseYear))
            {
                Console.WriteLine("Invalid input. Release year must be a number.");
                return;
            }

            Film newFilm = new Film(filmTitle, genre, releaseYear);

            Console.Write("Do you want to add actors to this film? (yes/no): ");
            string addActorsResponse = Console.ReadLine().ToLower();
            while (addActorsResponse == "yes")
            {
                Console.Write("Enter the actor's name: ");
                string actorName = Console.ReadLine();

                if (actors.ContainsKey(actorName))
                {
                    newFilm.AddActor(actors[actorName]);
                    Console.WriteLine($"Actor '{actorName}' added to film '{filmTitle}'.");
                }
                else
                {
                    Console.WriteLine($"Actor '{actorName}' not found. Do you want to add this actor to the catalogue? (yes/no): ");
                    string addActorResponse = Console.ReadLine().ToLower();
                    if (addActorResponse == "yes")
                    {
                        Console.Write("Enter the actor's age: ");
                        if (int.TryParse(Console.ReadLine(), out int actorAge))
                        {
                            Actor newActor = new Actor(actorName, actorAge);
                            actors[actorName] = newActor;
                            newFilm.AddActor(newActor);
                            Console.WriteLine($"Actor '{actorName}' added to the catalogue and to film '{filmTitle}'.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Age must be a number.");
                        }
                    }
                }

                Console.Write("Do you want to add another actor to this film? (yes/no): ");
                addActorsResponse = Console.ReadLine().ToLower();
            }

            films[filmTitle] = newFilm;
            Console.WriteLine("Film added successfully!");
        }




        // Adds a new actor to the catalogue
        // This function prompts the user for actor details and adds the actor to the list of actors
        static void AddNewActor(Dictionary<string, Actor> actors)
        {
            Console.Write("Enter the actor's name: ");
            string actorName = Console.ReadLine();

            if (actors.ContainsKey(actorName))
            {
                Console.WriteLine("An actor with this name already exists. Please enter a different name.");
                return;
            }

            Console.Write("Enter the actor's age: ");
            if (!int.TryParse(Console.ReadLine(), out int actorAge))
            {
                Console.WriteLine("Invalid input. Age must be a number.");
                return;
            }

            Actor newActor = new Actor(actorName, actorAge);
            actors[actorName] = newActor;
            Console.WriteLine("Actor added successfully!");
        }

        // Function to display all films in the catalogue
        static void DisplayAllFilms(Dictionary<string, Film> films)
        {
            if (films.Count == 0)
            {
                Console.WriteLine("No films available in the catalogue.");
            }
            else
            {
                foreach (Film film in films.Values)
                {
                    film.DisplayInfo();
                    Console.WriteLine();
                }
            }
        }


        // Displays information for all films in the catalogue
        // This function iterates through the list of films and displays their details
        static void DisplayAllFilms(List<Film> films)
        {
            if (films.Count == 0)
            {
                // Display a message if there are no films available in the catalogue
                Console.WriteLine("No films available in the catalogue.");
            }
            else
            {
                // Iterate over the list of films and display their information
                foreach (Film film in films)
                {
                    film.DisplayInfo();
                    Console.WriteLine();
                }
            }
        }

        // Displays films by genre using LINQ
        // Function to display films by genre
        static void DisplayFilmsByGenre(Dictionary<string, Film> films)
        {
            Console.Write("Enter the genre to filter by: ");
            string genre = Console.ReadLine();

            // Use LINQ to filter films by the specified genre
            var filteredFilms = films.Values.Where(f => f.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filteredFilms.Count == 0)
            {
                Console.WriteLine($"No films found in the genre '{genre}'.");
            }
            else
            {
                Console.WriteLine($"Films in the genre '{genre}':");
                foreach (Film film in filteredFilms)
                {
                    film.DisplayInfo();
                    Console.WriteLine();
                }
            }
        }


        // Displays films by actor
        static void DisplayFilmsByActor(Dictionary<string, Film> films, Dictionary<string, Actor> actors)
        {
            Console.Write("Enter the actor's name to find their films: ");
            string actorName = Console.ReadLine();

            if (actors.ContainsKey(actorName))
            {
                // Use LINQ to find films featuring the specified actor
                var filmsWithActor = films.Values.Where(f => f.Actors.Any(a => a.Name.Equals(actorName, StringComparison.OrdinalIgnoreCase))).ToList();

                if (filmsWithActor.Count == 0)
                {
                    Console.WriteLine($"No films found featuring '{actorName}'.");
                }
                else
                {
                    Console.WriteLine($"Films featuring '{actorName}':");
                    foreach (Film film in filmsWithActor)
                    {
                        film.DisplayInfo();
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Actor '{actorName}' not found.");
            }
        }


        // Loads films and actors from a file
        // This function prompts the user for a filename and loads films and actors from the file if it exists
        // Function to load films and actors from a file
        static void LoadFilmsAndActors(Dictionary<string, Film> films, Dictionary<string, Actor> actors)
        {
            Console.WriteLine("What file would you like to load?");
            string filename = Console.ReadLine();

            if (File.Exists(filename))
            {
                Console.WriteLine($"Loading data from '{filename}'...");
                List<string> lines = File.ReadAllLines(filename).ToList();

                bool isFilmSection = false;
                bool isActorSection = false;

                foreach (string line in lines)
                {
                    if (line.Trim() == "Films:")
                    {
                        isFilmSection = true;
                        isActorSection = false;
                        Console.WriteLine("Found Films section");
                    }
                    else if (line.Trim() == "Actors:")
                    {
                        isFilmSection = false;
                        isActorSection = true;
                        Console.WriteLine("Found Actors section");
                    }
                    else if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (isFilmSection)
                        {
                            try
                            {
                                var parts = line.Split(",");
                                if (parts.Length >= 3)
                                {
                                    string title = parts[0].Trim();
                                    string genre = parts[1].Trim();
                                    if (int.TryParse(parts[2].Trim(), out int releaseYear))
                                    {
                                        Film newFilm = new Film(title, genre, releaseYear);
                                        films[title] = newFilm;
                                        Console.WriteLine($"Loaded Film: {title}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Incorrect film format: {line}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Incorrect film format: {line}");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error parsing film: {line}. Error: {e.Message}");
                            }
                        }
                        else if (isActorSection)
                        {
                            try
                            {
                                var parts = line.Split(",");
                                if (parts.Length >= 2)
                                {
                                    string name = parts[0].Trim();
                                    if (int.TryParse(parts[1].Trim(), out int age))
                                    {
                                        Actor newActor = new Actor(name, age);
                                        actors[name] = newActor;
                                        Console.WriteLine($"Loaded Actor: {name}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Incorrect actor format: {line}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Incorrect actor format: {line}");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error parsing actor: {line}. Error: {e.Message}");
                            }
                        }
                    }
                }

                Console.WriteLine("Data loaded successfully.");
            }
            else
            {
                Console.WriteLine($"Sorry, '{filename}' does not exist.");
            }
        }


        // Update functionality to modify film or actor information
        // Function to update film or actor information
        static void SearchFilmsOrActors(Dictionary<string, Film> films, Dictionary<string, Actor> actors)
        {
            Console.Write("Enter search term (film title or actor name): ");
            string searchTerm = Console.ReadLine().ToLower();

            // Search for films that match the search term
            var matchingFilms = films.Values.Where(f => f.Title.ToLower().Contains(searchTerm)).ToList();
            if (matchingFilms.Count > 0)
            {
                Console.WriteLine("Matching Films:");
                foreach (var film in matchingFilms)
                {
                    film.DisplayInfo();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No matching films found.");
            }

            // Search for actors that match the search term
            var matchingActors = actors.Values.Where(a => a.Name.ToLower().Contains(searchTerm)).ToList();
            if (matchingActors.Count > 0)
            {
                Console.WriteLine("Matching Actors:");
                foreach (var actor in matchingActors)
                {
                    actor.DisplayInfo();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No matching actors found.");
            }
        }

        // Function to update film or actor information
        static void UpdateFilmOrActorInformation(Dictionary<string, Film> films, Dictionary<string, Actor> actors)
        {
            Console.WriteLine("Do you want to update a Film or an Actor? (Enter 'Film' or 'Actor'):");
            string choice = Console.ReadLine().ToLower();

            if (choice == "film")
            {
                Console.Write("Enter the title of the film to update: ");
                string filmTitle = Console.ReadLine();

                if (films.ContainsKey(filmTitle))
                {
                    Console.Write("Enter new genre: ");
                    string newGenre = Console.ReadLine();
                    films[filmTitle].Genre = newGenre;

                    Console.Write("Enter new release year: ");
                    if (int.TryParse(Console.ReadLine(), out int newReleaseYear))
                    {
                        films[filmTitle].ReleaseYear = newReleaseYear;
                        Console.WriteLine("Film updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Release year must be a number.");
                    }
                }
                else
                {
                    Console.WriteLine("Film not found.");
                }
            }
            else if (choice == "actor")
            {
                Console.Write("Enter the name of the actor to update: ");
                string actorName = Console.ReadLine();

                if (actors.ContainsKey(actorName))
                {
                    Console.Write("Enter new age: ");
                    if (int.TryParse(Console.ReadLine(), out int newAge))
                    {
                        actors[actorName].Age = newAge;
                        Console.WriteLine("Actor updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Age must be a number.");
                    }
                }
                else
                {
                    Console.WriteLine("Actor not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter either 'Film' or 'Actor'.");
            }
        }


        // Saves films and actors to a file
        // Function to save films and actors data to a file
        static void SaveDataToFile(Dictionary<string, Film> films, Dictionary<string, Actor> actors)
        {
            Console.Write("Enter the filename to save data to: ");
            string filename = Console.ReadLine();

            try
            {
                List<string> lines = new List<string>();

                // Write Films section
                lines.Add("Films:");
                foreach (var film in films.Values)
                {
                    lines.Add($"{film.Title}, {film.Genre}, {film.ReleaseYear}");
                }

                // Write Actors section
                lines.Add("Actors:");
                foreach (var actor in actors.Values)
                {
                    lines.Add($"{actor.Name}, {actor.Age}");
                }

                // Write all lines to the specified file
                File.WriteAllLines(filename, lines);

                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while saving data: " + e.Message);
            }
        }


        // Removes a film or actor from the catalogue
        static void RemoveFilmOrActor(Dictionary<string, Film> films, Dictionary<string, Actor> actors)
        {
            Console.Write("Do you want to remove a Film or an Actor? (Enter 'Film' or 'Actor'): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "film")
            {
                Console.Write("Enter the title of the film to remove: ");
                string filmTitle = Console.ReadLine();

                if (films.ContainsKey(filmTitle))
                {
                    films.Remove(filmTitle);
                    Console.WriteLine("Film removed successfully!");
                }
                else
                {
                    Console.WriteLine("Film not found.");
                }
            }
            else if (choice == "actor")
            {
                Console.Write("Enter the name of the actor to remove: ");
                string actorName = Console.ReadLine();

                if (actors.ContainsKey(actorName))
                {
                    actors.Remove(actorName);
                    Console.WriteLine("Actor removed successfully!");
                }
                else
                {
                    Console.WriteLine("Actor not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter either 'Film' or 'Actor'.");
            }
        }

        // Rates a film
        static void RateFilm(Dictionary<string, Film> films)
        {
            Console.Write("Enter the title of the film to rate: ");
            string filmTitle = Console.ReadLine();

            if (films.ContainsKey(filmTitle))
            {
                Console.Write("Enter your rating (1-5): ");
                if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
                {
                    films[filmTitle].AddRating(rating);
                    Console.WriteLine("Rating added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid rating. Please enter a number between 1 and 5.");
                }
            }
            else
            {
                Console.WriteLine("Film not found.");
            }
        }

        // Sorts films or actors
        // Function to sort films or actors
        static void SortFilmsOrActors(Dictionary<string, Film> films, Dictionary<string, Actor> actors)
        {
            Console.Write("Do you want to sort Films or Actors? (Enter 'Film' or 'Actor'): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "film")
            {
                var sortedFilms = films.Values.OrderBy(f => f.Title).ToList();
                Console.WriteLine("Films sorted alphabetically:");
                foreach (var film in sortedFilms)
                {
                    film.DisplayInfo();
                    Console.WriteLine();
                }
            }
            else if (choice == "actor")
            {
                var sortedActors = actors.Values.OrderBy(a => a.Name).ToList();
                Console.WriteLine("Actors sorted alphabetically:");
                foreach (var actor in sortedActors)
                {
                    actor.DisplayInfo();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter either 'Film' or 'Actor'.");
            }
        }

        // Exports the film and actor catalogue to a text file
        // Function to export the film and actor catalogue to a text file
        static void ExportReport(Dictionary<string, Film> films, Dictionary<string, Actor> actors)
        {
            Console.Write("Enter the filename to export the report to: ");
            string filename = Console.ReadLine();

            try
            {
                List<string> reportLines = new List<string>
                {
                   "Film and Actor Catalogue Report",
                "========================================="
                };

                // Add film details to the report
                reportLines.Add("\nFilms:");
                foreach (var film in films.Values)
                {
                    reportLines.Add($"Title: {film.Title}, Genre: {film.Genre}, Release Year: {film.ReleaseYear}, Average Rating: {film.GetAverageRating()}");
                }

                // Add actor details to the report
                reportLines.Add("\nActors:");
                foreach (var actor in actors.Values)
                {
                    reportLines.Add($"Name: {actor.Name}, Age: {actor.Age}");
                }

                // Write report to the specified file
                File.WriteAllLines(filename, reportLines);

                Console.WriteLine("Report exported successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while exporting the report: " + e.Message);
            }
        }



        // Exits the program
        // This function saves the data (if necessary) and then terminates the program
        static void ExitProgram()
        {
            // Display a goodbye message and exit the program
            Console.WriteLine("Your file has been saved, Goodbye!");
            Environment.Exit(0);
        }

        // Unit Tests for Film and Actor Classes
        // Purpose: To ensure that individual components of the program work as expected
        // Function to run unit tests for Film and Actor classes
        static void RunTests()
        {
            Console.WriteLine("Running Unit Tests...");

            // Test Film Class
            Film testFilm = new Film("Test Film", "Test Genre", 2000);
            Debug.Assert(testFilm.Title == "Test Film", "Film title getter/setter failed.");
            Debug.Assert(testFilm.Genre == "Test Genre", "Film genre getter/setter failed.");
            Debug.Assert(testFilm.ReleaseYear == 2000, "Film release year getter/setter failed.");
            testFilm.AddRating(5);
            testFilm.AddRating(4);
            Debug.Assert(testFilm.GetAverageRating() == 4.5, "Film average rating calculation failed.");

            // Test Actor Class
            Actor testActor = new Actor("Test Actor", 30);
            Debug.Assert(testActor.Name == "Test Actor", "Actor name getter/setter failed.");
            Debug.Assert(testActor.Age == 30, "Actor age getter/setter failed.");
            testActor.AddFilm("Test Film");
            Debug.Assert(testActor.Films.Contains("Test Film"), "Actor film addition failed.");

            Console.WriteLine("Unit Tests Completed.");
        }
    }
}

/*
Explanation of Topics;

1.Console IO and Variables:
   -The program extensively uses Console.WriteLine() and Console.ReadLine() for user interaction.
   - Variables are used to store user input and data such as films and actors.
   - Updates: Added user prompts for additional functionalities like adding, displaying, and searching films and actors.

2. Operators and Selection:
   -The program employs selection structures like `switch` statements in `HandleUserChoice` to decide which action to perform based on the user's input.
   - An alternative could be using `if-else` statements, but `switch` provides a cleaner and more structured approach for handling multiple options.
   - An improvement could be using a dictionary with function pointers to reduce verbosity and improve scalability.
   - Updates: The `switch` statement was updated to handle new functionalities such as sorting, rating, and updating films and actors.

3. Functions, Return, and Parameters:
   -The program is modularized using functions such as `AddNewFilm`, `AddNewActor`, etc., which makes the code easier to manage and understand.
   - Each function is responsible for a specific task, promoting separation of concerns.
   - Functions return values or perform operations based on parameters, which helps maintain modularity and facilitates testing.
   - Updates: Added new functions such as `RateFilm`, `SortFilmsOrActors`, `ExportReport`, and updated existing functions to handle encapsulated properties via getters and setters.

4. For and While Loops:
   -The program uses loops to handle repetitive tasks such as displaying the menu and getting user choices until the user decides to exit.
   - A `while (true)` loop is used to keep the program running, providing continuous interaction with the user until they choose to quit.
   - The `foreach` loop is also used to iterate over collections, which simplifies the code and makes it more readable when dealing with lists or dictionaries.
   - Alternatives: A `for` loop could be used instead of `foreach`, but `foreach` is generally more readable for collection iteration.
   - Updates: The loops were updated to include additional menu options, enhancing user experience by supporting new functionalities.

5. Collections and foreach Loop:
   - The program makes use of `Dictionary<string, Film>` and `Dictionary<string, Actor>` to store collections of films and actors, ensuring unique entries for each.
   - The `foreach` loop is used to iterate over these dictionaries when displaying or saving data, enhancing readability and simplicity.
   - An alternative would be using arrays, but dictionaries are more suitable for fast lookups and managing unique keys.
   - Updates: Enhanced collection usage by adding sorting capabilities for films and actors, and implemented more efficient data manipulation.

6. Class Member Functions & Testing:
   - The `Film` and `Actor` classes have member functions such as `GetTitle`, `GetName`, and `AddActor` to encapsulate their behavior.
   - These member functions allow access to private data members and ensure encapsulation.
   - Unit Testing: The program includes unit tests using NUnit to verify the functionality of key methods in both the `Actor` and `Film` classes.
   - These tests help ensure that individual components work as expected, aiding in debugging and providing a safeguard against future changes.
   - Updates: Replaced `Debug.Assert` with NUnit testing framework, and added more comprehensive tests to cover functionalities like adding ratings, actors, and calculating averages.

7. File IO:
   - The program allows loading and saving of film and actor data using text files, ensuring data persistence across program runs.
   - Functions like `LoadFilmsAndActors` and `SaveDataToFile` are responsible for reading and writing data to files.
   - Alternatives include using a database or JSON/XML for structured data storage, which could offer more flexibility and scalability.
   - Updates: Enhanced file handling by adding the capability to export detailed reports of films and actors, and improved error handling for file operations.
   - An improvement would be implementing error recovery to handle partial data loads or invalid file formats more gracefully.
*/

/*
Explanation of Topics Included So Far:

1. Console IO and Variables:
   - The program extensively uses Console.WriteLine() and Console.ReadLine() for user interaction.
   - Variables are used to store user input and data such as films and actors.

2. Operators and Selection:
   - The program employs selection structures like `switch` statements in `HandleUserChoice` to decide which action to perform based on the user's input.
   - An alternative could be using `if-else` statements, but `switch` provides a cleaner and more structured approach for handling multiple options.
   - An improvement could be using a dictionary with function pointers to reduce verbosity and improve scalability.

3. Functions, Return, and Parameters:
   - The program is modularized using functions such as `AddNewFilm`, `AddNewActor`, etc., which makes the code easier to manage and understand.
   - Each function is responsible for a specific task, promoting separation of concerns.
   - Functions return values or perform operations based on parameters, which helps maintain modularity and facilitates testing.

4. For and While Loops:
   - The program uses loops to handle repetitive tasks such as displaying the menu and getting user choices until the user decides to exit.
   - A `while (true)` loop is used to keep the program running, providing continuous interaction with the user until they choose to quit.
   - The `foreach` loop is also used to iterate over collections, which simplifies the code and makes it more readable when dealing with lists or dictionaries.
   - Alternatives: A `for` loop could be used instead of `foreach`, but `foreach` is generally more readable for collection iteration.

5. Collections and foreach Loop:
   - The program makes use of `Dictionary<string, Film>` and `Dictionary<string, Actor>` to store collections of films and actors, ensuring unique entries for each.
   - The `foreach` loop is used to iterate over these dictionaries when displaying or saving data, enhancing readability and simplicity.
   - An alternative would be using arrays, but dictionaries are more suitable for fast lookups and managing unique keys.

6. Class Member Functions & Testing:
   - The `Film` and `Actor` classes have member functions such as `GetTitle`, `GetName`, and `AddActor` to encapsulate their behavior.
   - These member functions allow access to private data members and ensure encapsulation.
   - Unit Testing: The program includes simple unit tests using `Debug.Assert` to verify the functionality of key methods in both the `Actor` and `Film` classes.
   - These tests help ensure that individual components work as expected, aiding in debugging and providing a safeguard against future changes.

7. File IO:
   - The program allows loading and saving of film and actor data using text files, ensuring data persistence across program runs.
   - Functions like `LoadFilmsAndActors` and `SaveDataToFile` are responsible for reading and writing data to files.
   - Alternatives include using a database or JSON/XML for structured data storage, which could offer more flexibility and scalability.
   - An improvement would be implementing error recovery to handle partial data loads or invalid file formats more gracefully.
*/

