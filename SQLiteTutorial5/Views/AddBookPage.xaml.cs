using SQLiteTutorial5.Models;


namespace SQLiteTutorial5.Views
{
    public partial class AddBookPage : ContentPage
    {
        public AddBookPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleEntry.Text) || string.IsNullOrWhiteSpace(AuthorEntry.Text))
            {
                await DisplayAlert("Error", "Please fill in the title and author.", "OK");
                return;
            }

            int.TryParse(YearEntry.Text, out int year);

            var book = new Book
            {
                Title = TitleEntry.Text.Trim(),
                Author = AuthorEntry.Text.Trim(),
                Genre = GenreEntry.Text?.Trim(),
                Year = year,
                CreatedAt = DateTime.UtcNow
            };

            await App.Database.SaveBookAsync(book);
            await Shell.Current.GoToAsync(".."); // go back
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
