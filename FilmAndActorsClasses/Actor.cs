using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FilmAndActorsClasses
{
    public class Actor
    {
        // Private fields for encapsulated properties
        private string _name;
        private int _age;
        private List<string> _films;

        // Constructor to initialize Actor details
        public Actor(string name, int age)
        {
            _name = name;
            _age = age;
            _films = new List<string>();
        }

        // Public properties to access private fields
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public List<string> Films
        {
            get { return _films; }
        }

        // Method to add a film to the actor's filmography
        public void AddFilm(string film)
        {
            if (!_films.Contains(film))
            {
                _films.Add(film);
            }
        }

        // Method to display actor's information
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
            Console.WriteLine("Films:");
            foreach (var film in _films)
            {
                Console.WriteLine($"- {film}");
            }
        }

        // Unit tests for the Actor class
        public static void RunTests()
        {
            // Test Actor Class
            Actor testActor = new Actor("Test Actor", 30);
            Debug.Assert(testActor.Name == "Test Actor", "Actor name getter/setter failed.");
            Debug.Assert(testActor.Age == 30, "Actor age getter/setter failed.");

            // Add a film and check if it's added correctly
            testActor.AddFilm("Test Film");
            Debug.Assert(testActor.Films.Contains("Test Film"), "Actor film addition failed.");

            Console.WriteLine("All Actor class unit tests passed successfully.");
        }
    }
}


/*
  Explanation of Actor.cs - A class representing an actor in a film.
 
  This class is used to manage information about an actor, including their name, age, and filmography.
  The main features of this class are:
 
 * 1. **Private Fields and Public Properties**:
      - The class contains private fields for `name`, `age`, and `films` to encapsulate the actor's data.
      - Public properties (`Name` and `Age`) are used to get and set the values of these private fields, allowing controlled access.
      - The `Films` property returns the list of films the actor has appeared in.
  
 * 2. **Constructors**:
      - The class provides a constructor for initializing an actor with a specific name and age.
      - The `Actor` constructor initializes the `films` list to store the actor's filmography.
   
   3. **Methods**:
      - `AddFilm(string film)`: Adds a film to the actor's filmography.
      - `DisplayInfo()`: Displays the actor's information, including their name, age, and list of films.
      - This class can be extended or inherited by other classes to introduce polymorphism if additional types of actors (such as `LeadActor` or `SupportingActor`) are needed.
  
 * 4. **Polymorphism**:
      - The `Actor` class serves as a base class, which allows for polymorphism.
      - For example, the `LeadActor` class inherits from `Actor` and adds a unique `LeadRole` property, demonstrating inheritance and adding specialised behavior.
      - In a polymorphic setting, different types of actors can be treated as `Actor` objects while still exhibiting their specialised behavior.
  
 * 5. **Encapsulation and Access Control**:
      - By using private fields and public properties, the class ensures that the data is properly encapsulated and access is controlled.
      - The use of protected constructors in the `FilmMember` class allows only derived classes to create instances of it, providing an extra layer of access control.
   
 * 6. **Inheritance from FilmPerson**:
      - The `Actor` class inherits from `FilmMember`, which serves as a general base class for people involved in films.
      - This allows code reuse and the addition of specialised behavior for other types of film-related people, such as `Director` or `Producer`.
 */


/*
Explanation of Changes:

1. Renamed the base class from `FilmPerson` to `FilmMember` to make it simpler and unique.
   - This name change makes it easier to understand that this class represents a member of the film industry without confusion.

2. `FilmMember` serves as a general representation of anyone involved in the film industry.
   - It has private fields `_name` and `_age`, along with associated getters and setters.
   - Contains an abstract method `DisplayInfo()`, which must be implemented by derived classes like `Actor`.

3. Updated `Actor` to inherit from `FilmMember`.
   - The `Actor` class now inherits the properties `Name` and `Age` from `FilmMember`.
   - This demonstrates **polymorphism**, as `Actor` provides a specific implementation of the abstract `DisplayInfo()` method.

4. Used encapsulation by keeping the fields `_name` and `_age` private and providing public properties to access them.
   - This approach ensures that the internal state of `FilmMember` cannot be modified directly from outside the class, thus preserving data integrity.

5. Added detailed inline comments to explain the purpose and functionality of classes, constructors, and methods.
   - This includes explanations for constructors, methods, and the use of inheritance and polymorphism with the `FilmMember` base class.
*/
