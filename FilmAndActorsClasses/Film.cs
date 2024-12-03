namespace FilmAndActorsClasses
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    // Abstract base class for all films
    public abstract class FilmBase
    {
        // Private member variables
        private string _title; // Stores the title of the film
        private string _genre; // Stores the genre of the film
        private int _releaseYear; // Stores the release year of the film

        // Constructor
        protected FilmBase(string title, string genre, int releaseYear)
        {
            _title = title; // Initialize title
            _genre = genre; // Initialize genre
            _releaseYear = releaseYear; // Initialize release year
        }

        // Public properties for encapsulated access
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }

        // Abstract method to display detailed information about the film
        public abstract void DisplayInfo();
    }

    // Derived class representing a specific film
    public class Film : FilmBase
    {
        // Private member variables
        private List<int> _ratings; // Stores ratings for the film
        private List<Actor> _actors; // Stores the list of actors in the film

        // Constructor
        public Film(string title, string genre, int releaseYear) : base(title, genre, releaseYear)
        {
            _ratings = new List<int>(); // Initialise ratings list
            _actors = new List<Actor>(); // Initialise actors list
        }

        // Public properties for encapsulated access
        public List<int> Ratings
        {
            get { return _ratings; }
        }

        public List<Actor> Actors
        {
            get { return _actors; }
        }

        // Method to add an actor to the film
        public void AddActor(Actor actor)
        {
            if (!_actors.Contains(actor))
            {
                _actors.Add(actor); // Add actor if not already in the list
            }
        }

        // Method to add a rating to the film
        public void AddRating(int rating)
        {
            if (rating >= 1 && rating <= 5)
            {
                _ratings.Add(rating); // Add rating if it is between 1 and 5
            }
            else
            {
                throw new ArgumentException("Rating must be between 1 and 5."); // Throw exception for invalid ratings
            }
        }

        // Method to calculate and return the average rating
        public double GetAverageRating()
        {
            if (_ratings.Count == 0)
            {
                return 0.0; // No ratings available, return 0
            }
            return _ratings.Average(); // Calculate and return average rating
        }

        // Override method to display detailed information about the film
        public override void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Release Year: {ReleaseYear}");
            Console.WriteLine("Actors:");
            foreach (Actor actor in _actors)
            {
                Console.WriteLine($"- {actor.Name}"); // Display each actor's name
            }
            Console.WriteLine($"Average Rating: {GetAverageRating()}"); // Display average rating
        }

        // Unit tests for the Film class
        public static void RunTests()
        {
            Film testFilm = new Film("Test Film", "Action", 2021);

            // Test Title property
            Debug.Assert(testFilm.Title == "Test Film", "Error: Title property failed.");

            // Test Genre property
            Debug.Assert(testFilm.Genre == "Action", "Error: Genre property failed.");

            // Test ReleaseYear property
            Debug.Assert(testFilm.ReleaseYear == 2021, "Error: ReleaseYear property failed.");

            // Test AddRating and GetAverageRating methods
            testFilm.AddRating(4);
            testFilm.AddRating(5);
            Debug.Assert(testFilm.GetAverageRating() == 4.5, "Error: GetAverageRating method failed.");

            // Test AddActor method
            Actor testActor = new Actor("Test Actor", 35);
            testFilm.AddActor(testActor);
            Debug.Assert(testFilm.Actors.Count == 1, "Error: AddActor method failed.");
            Debug.Assert(testFilm.Actors[0] == testActor, "Error: Actor retrieval failed.");

            Console.WriteLine("All Film class tests passed successfully.");
        }
    }
}

/*
Explanation of the Film.cs:

1. **Namespace and Using Directives**:
   - The namespace `FilmAndActorsClasses` is used to organise related classes.
   - Several system namespaces are included: `System` for core functionalities, `System.Collections.Generic` for using generic collections like lists, and `System.Diagnostics` for debugging purposes.

2. **Film Class**:
   - The `Film` class represents the details and functionalities related to a film, including its title, genre, release year, ratings, and associated actors.
   - It also demonstrates the use of encapsulation by utilizing private fields and public properties for controlled access.

3. **Constructor**:
   - The constructor initialises a new `Film` object with specified parameters: title, genre, and release year.
   - `ratings` and `actors` are initialised as empty lists to store ratings and actors associated with the film.

4. **Public Properties**:
   - Properties `Title`, `Genre`, and `ReleaseYear` provide read and write access to the private fields `title`, `genre`, and `releaseYear`. This ensures controlled access to these fields.
   - The `Ratings` and `Actors` properties provide read-only access to the `ratings` and `actors` lists. This ensures that the list itself can't be replaced, though it can be modified through the class methods.

5. **AddActor Method**:
   - The `AddActor` method adds an actor to the `actors` list.
   - The `Contains` method ensures that the same actor isn't added more than once.

6. **AddRating Method**:
   - The `AddRating` method allows users to add ratings between 1 and 5.
   - If the rating is outside the valid range, an `ArgumentException` is thrown.

7. **GetAverageRating Method**:
   - The `GetAverageRating` method calculates the average rating of the film.
   - If there are no ratings, it returns `0.0` to avoid division by zero.

8. **DisplayInfo Method**:
   - The `DisplayInfo` method prints detailed information about the film, including its title, genre, release year, and a list of actors.
   - It also prints the average rating, calculated using the `GetAverageRating()` method.

9. **RunTests Method**:
   - `RunTests` is a static method used to run unit tests on the `Film` class.
   - It checks the correctness of properties like `Title`, `Genre`, and `ReleaseYear`.
   - It also tests the `AddRating` and `GetAverageRating` methods.
   - Additionally, it tests the `AddActor` method and ensures the correct actor is added to the list.

**Summary**:
This `Film` class follows best practices like encapsulation, keeping data private while exposing controlled access through properties. It includes functionalities for:
- Adding actors and ratings.
- Displaying detailed film information.
- Performing unit tests to verify the correctness of its properties and methods.

The changes that were made make it easier to maintain and extend, and they help protect the internal state of the object while allowing safe interaction with external code.
*/
