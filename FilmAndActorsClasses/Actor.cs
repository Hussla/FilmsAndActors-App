namespace FilmAndActorsClasses
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    // Class representing an Actor
    public class Actor
    {
        // Member Variables
        private string name; // Stores the name of the actor
        private int age; // Stores the age of the actor
        private List<string> films; // Stores the list of films the actor has appeared in

        // Constructor
        // Initializes a new instance of the Actor class with the specified name and age
        public Actor(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.films = new List<string>();
        }

        // Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public List<string> Films
        {
            get { return films; }
        }

        // Member Functions

        // Adds a film to the actor's filmography
        public void AddFilm(string film)
        {
            films.Add(film);
        }

        // Displays detailed information about the actor, including their name, age, and filmography
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine("Films:");
            foreach (string film in films)
            {
                Console.WriteLine("- " + film);
            }
        }

        // Unit Tests
        public static void RunTests()
        {
            // Test Name and Age properties
            Actor testActor = new Actor("Jane Doe", 30);
            Debug.Assert(testActor.Name == "Jane Doe", "Error: Name getter failed.");
            Debug.Assert(testActor.Age == 30, "Error: Age getter failed.");

            // Test setting new values
            testActor.Name = "John Smith";
            Debug.Assert(testActor.Name == "John Smith", "Error: Name setter failed.");
            testActor.Age = 40;
            Debug.Assert(testActor.Age == 40, "Error: Age setter failed.");

            // Test AddFilm and Films property
            testActor.AddFilm("Test Film");
            List<string> films = testActor.Films;
            Debug.Assert(films.Count == 1, "Error: AddFilm or Films property failed.");
            Debug.Assert(films[0] == "Test Film", "Error: Films list content incorrect.");
        }
    }
}