using SQLiteTutorial5.Services;

namespace SQLiteTutorial5
{
    public partial class App : Application
    {
        private static DatabaseService _database;

        public static DatabaseService Database
        {
            get
            {
                if(_database == null)
                {
                    string dbPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "Books.db3");

                    _database = new DatabaseService(dbPath);
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}