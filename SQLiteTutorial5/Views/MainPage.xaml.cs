using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SQLiteTutorial5.Models;
using System.Collections.ObjectModel;

namespace SQLiteTutorial5.Views
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Book> Books { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadBooks();
        }

        private async Task LoadBooks()
        {
            Books.Clear();
            var list = await App.Database.GetBooksAsync();
            foreach (var book in list)
                Books.Add(book);

            //BooksCollection.ItemsSource = Books;
        }

        private async void OnAddBookClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddBookPage));
        }

        private async void OnDeleteBookClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Book book)
            {
                bool confirm = await DisplayAlert("Delete", $"Delete '{book.Id}'?", "Yes", "No");
                if (confirm)
                {
                    await App.Database.DeleteBookAsync(book);
                    await LoadBooks();
                }
            }
        }
    }
}

