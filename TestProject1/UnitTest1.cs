using FilmAndActorsClasses;

namespace TestProject1
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    // Test Class for Unit Testing

    public class FilmAndActorTests
    {
        [Test]
        public void ReturnCorrectActorName()
        {
            // Arrange
            // Create an instance of the Actor class with a given name and age

            Actor actor = new Actor("John Doe", 35);

            // Act
            // Retrieve the name of the actor
            string result = actor.GetName();

            // Assert
            // Verify that the retrieved name matches the expected name
            Assert.AreEqual("John Doe", result);
        }

        [Test]
        public void ReturnCorrectActorAge()
        {
            // Arrange
            // Create an instance of the Actor class with a given name and age
            Actor actor = new Actor("John Doe", 35);

            // Act
            // Retrieve the age of the actor
            int result = actor.GetAge();

            // Assert
            // Verify that the retrieved age matches the expected age
            Assert.AreEqual(35, result);
        }

        [Test]
        public void AddFilmToActorFilmography()
        {
            // Arrange
            // Create an instance of the Actor class and specify a film to be added
            Actor actor = new Actor("John Doe", 35);
            string film = "Example Film";

            // Act
            // Add the specified film to the actor's filmography
            actor.AddFilm(film);

            // Assert
            // Verify that the film was successfully added to the actor's filmography
            Assert.Contains(film, actor.GetFilms()); // change these to debug.assert
        }

        [Test]
        public void ReturnCorrectFilmTitle()
        {
            // Arrange
            // Create an instance of the Film class with a given title, genre, and release year
            Film film = new Film("Inception", "Sci-Fi", 2010);

            // Act
            // Retrieve the title of the film
            string result = film.GetTitle();

            // Assert
            // Verify that the retrieved title matches the expected title
            Assert.AreEqual("Inception", result);
        }

        [Test]
        public void AddActorToFilm()
        {
            // Arrange
            // Create an instance of the Film class and an instance of the Actor class
            Film film = new Film("Inception", "Sci-Fi", 2010);
            Actor actor = new Actor("Leonardo DiCaprio", 46);

            // Act
            // Add the actor to the film's list of actors
            film.AddActor(actor);

            // Assert
            // Verify that the actor was successfully added to the film's cast
            Assert.AreEqual(1, film.GetActors().Count);
            Assert.AreEqual("Leonardo DiCaprio", film.GetActors()[0].GetName());
        }
    }
}
