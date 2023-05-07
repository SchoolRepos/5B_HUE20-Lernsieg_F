using LernsiegDatabase;
using LernsiegViewModels;

namespace LernsiegWPF
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            var db = new LernsiegContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            DatabaseSeeder.Seed(db);
            DataContext = new MainViewModel(db);
            InitializeComponent();
        }
    }
}
