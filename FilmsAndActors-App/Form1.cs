using FilmAndActorsClasses;

namespace FilmsAndActors_App
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Film> films = new Dictionary<string, Film>(); // Store films

        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for the "Add Film" button
        private void addFilmButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve information from text boxes
                string title = titleTextBox.Text;
                string genre = genreTextBox.Text;
                int releaseYear;

                // Validate release year input
                if (!int.TryParse(yearTextBox.Text, out releaseYear))
                {
                    MessageBox.Show("Please enter a valid year.");
                    return;
                }

                // Check if the film already exists
                if (films.ContainsKey(title))
                {
                    MessageBox.Show("A film with this title already exists.");
                    return;
                }

                // Create new film and add to the dictionary
                Film newFilm = new Film(title, genre, releaseYear);
                films[title] = newFilm;

                MessageBox.Show("Film added successfully!");

                // Optionally clear the input fields after adding
                titleTextBox.Clear();
                genreTextBox.Clear();
                yearTextBox.Clear();

                // Refresh the ListBox to display the newly added film
                RefreshFilmsListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void RefreshFilmsListBox()
        {
            filmsListBox.Items.Clear(); // Clear the existing items in the ListBox

            foreach (var filmEntry in films) // Iterate through each entry in the films dictionary
            {
                filmsListBox.Items.Add(filmEntry.Value.Title); // Add the title of each film to the ListBox
            }
        }



        private void filmsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filmsListBox.Items.Clear(); // Clear previous list

            // Loop through the films dictionary and add to ListBox
            foreach (var film in films.Values)
            {
                filmsListBox.Items.Add($"{film.Title} ({film.ReleaseYear}) - {film.Genre}");
            }

            if (filmsListBox.Items.Count == 0)
            {
                filmsListBox.Items.Add("No films available in the catalogue.");
            }
        }
    }
}