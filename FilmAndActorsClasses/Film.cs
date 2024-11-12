namespace FilmAndActorsClasses
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    // Film class with encapsulated properties using getters and setters
    
    public class Film
    {
        // Private member variables
        private string _title;
        private string _genre;
        private int _releaseYear;
        private List<int> _ratings;
        private List<Actor> _actors;

        // Constructor
        public Film(string title, string genre, int releaseYear)
        {
            _title = title;
            _genre = genre;
            _releaseYear = releaseYear;
            _ratings = new List<int>();
            _actors = new List<Actor>();
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
                _actors.Add(actor);
            }
        }

        // Method to add a rating to the film
        public void AddRating(int rating)
        {
            if (rating >= 1 && rating <= 5)
            {
                _ratings.Add(rating);
            }
            else
            {
                throw new ArgumentException("Rating must be between 1 and 5.");
            }
        }

        // Method to calculate and return the average rating
        public double GetAverageRating()
        {
            if (_ratings.Count == 0)
            {
                return 0.0; // No ratings available
            }
            return _ratings.Average();
        }

        // Method to display detailed information about the film
        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Release Year: {ReleaseYear}");
            Console.WriteLine("Actors:");
            foreach (Actor actor in Actors)
            {
                Console.WriteLine($"- {actor.Name}");
            }
            Console.WriteLine($"Average Rating: {GetAverageRating()}");
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
